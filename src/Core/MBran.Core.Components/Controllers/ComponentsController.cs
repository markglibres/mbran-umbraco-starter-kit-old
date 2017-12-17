using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace MBran.Core.Components
{
    public class ComponentsController : SurfaceController,
        IComponentController
    {
        private readonly IPageHelper _pageHelper;

        public int PageId { get { return _pageHelper.CurrentPageId(); } }

        public ComponentsController(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        public virtual PartialViewResult RenderModel(object model)
        {
            string customViewPath = GetCustomViewPath();
            PartialViewResult partialView = null;

            if (string.IsNullOrEmpty(customViewPath))
            {
                partialView = GetMvcView(model);
            }

            if (partialView == null)
            {
                partialView = GetDefaultView(model, customViewPath);
            }

            return partialView;
        }

        public virtual PartialViewResult Render(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        private string GetCustomViewPath()
        {
            return this.ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.VIEW_PATH_KEY]
                ?.ToString();
        }

        private string GetComponentViewName()
        {
            string component = this.ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.COMPONENT_KEY]
                ?.ToString();

            return Regex.Replace(component, "component$", String.Empty, RegexOptions.IgnoreCase);
        }

        private PartialViewResult GetMvcView(object model)
        {
            var viewEngine = this.GetViewEngine(this.GetComponentViewName(), true);

            if (viewEngine != null && viewEngine.View != null)
            {
                this.ControllerContext.RouteData.Values["action"] = GetComponentViewName();
                return viewEngine.GetPartialView(this.ControllerContext, model);
            }

            return null;
        }

        private PartialViewResult GetDefaultView(object model, string viewPath = "")
        {
            string component = this.GetComponentViewName();
            string view = string.IsNullOrEmpty(viewPath)
                ? ComponentViewHelper.GetFullPath(ComponentConstants.Folders.Views.DEFAULT, component)
                : viewPath;
            return PartialView(view, model);
        }
        
    }
}
