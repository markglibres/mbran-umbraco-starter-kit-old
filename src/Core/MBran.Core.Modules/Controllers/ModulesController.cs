using MBran.Core.Modules.Helpers;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace MBran.Core.Modules.Controllers
{
    public class ModulesController : SurfaceController,
        IModuleController
    {
        public int PageId => _contentHelper.CurrentPageId();
        private readonly IContentHelper _contentHelper;

        public ModulesController(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
        }

        public PartialViewResult Render(string viewName, object model)
        {
            return PartialView(viewName, model);
        }

        public PartialViewResult RenderModel(object model)
        {
            var customViewPath = GetViewPath();
            PartialViewResult partialView = null;

            if (string.IsNullOrEmpty(customViewPath))
            {
                partialView = GetMvcView(model);
            }

            return partialView ?? (GetView(model, customViewPath));
        }

        public string GetViewPath()
        {
            return ControllerContext.RequestContext.RouteData
                ?.Values[ModuleConstants.ViewPathKey]
                ?.ToString();
        }

        public string GetViewName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ModuleConstants.ModuleKey]
                ?.ToString();

            return string.IsNullOrEmpty(component)
                ? ControllerContext.ExecutingViewName()
                : Regex.Replace(component, "pagemodule$", string.Empty, RegexOptions.IgnoreCase);
        }

        public PartialViewResult GetMvcView(object model)
        {
            var viewEngine = this.GetViewEngine(GetViewName(), true);

            if (viewEngine?.View == null) return null;

            ControllerContext.RouteData.Values["action"] = GetViewName();
            return viewEngine.GetPartialView(ControllerContext, model);
        }

        public PartialViewResult GetView(object model, string viewPath = "")
        {
            var viewName = GetViewName();
            var view = string.IsNullOrEmpty(viewPath)
                ? PageModuleViewHelper.GetFullPath(viewName, viewName)
                : viewPath;
            return PartialView(view, model);
        }
    }
}
