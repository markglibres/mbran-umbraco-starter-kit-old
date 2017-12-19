using System.Text.RegularExpressions;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace MBran.Core.Components
{
    public class ComponentsController : SurfaceController,
        IComponentController
    {
        private readonly IContentHelper _contentHelper;

        public int PageId => _contentHelper.CurrentPageId();

        public ComponentsController(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
        }

        public virtual PartialViewResult RenderModel(object model)
        {
            var customViewPath = GetCustomViewPath();
            PartialViewResult partialView = null;

            if (string.IsNullOrEmpty(customViewPath))
            {
                partialView = GetMvcView(model);
            }

            return partialView ?? (GetDefaultView(model, customViewPath));
        }

        public virtual PartialViewResult Render(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        private string GetCustomViewPath()
        {
            return ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ViewPathKey]
                ?.ToString();
        }

        private string GetComponentViewName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ComponentKey]
                ?.ToString();

            return string.IsNullOrEmpty(component) 
                ? ControllerContext.ExecutingViewName() 
                : Regex.Replace(component, "component$", string.Empty, RegexOptions.IgnoreCase);
        }

        private PartialViewResult GetMvcView(object model)
        {
            var viewEngine = this.GetViewEngine(GetComponentViewName(), true);

            if (viewEngine?.View == null) return null;

            ControllerContext.RouteData.Values["action"] = GetComponentViewName();
            return viewEngine.GetPartialView(ControllerContext, model);
        }

        private PartialViewResult GetDefaultView(object model, string viewPath = "")
        {
            var component = GetComponentViewName();
            var view = string.IsNullOrEmpty(viewPath)
                ? ComponentViewHelper.GetFullPath(ComponentConstants.Folders.Views.Default, component)
                : viewPath;
            return PartialView(view, model);
        }
        
    }
}
