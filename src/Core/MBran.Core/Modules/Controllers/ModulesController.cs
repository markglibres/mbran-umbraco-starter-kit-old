using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.UI;
using Umbraco.Web.Mvc;

namespace MBran.Core.Modules.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None, VaryByParam = "*")]
    public class ModulesController : SurfaceController,
        IModuleController
    {
        public int PageId => _contentHelper.CurrentPageId();
        private readonly IContentHelper _contentHelper;
        private const string DefaultViewName = "Index";

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
            var viewPath = GetViewPath();
        
            if (string.IsNullOrEmpty(viewPath))
            {
                viewPath = GetModuleName() + "/" + DefaultViewName;
            }

            return PartialView(viewPath, model);
        }

        public string GetViewPath()
        {
            return ControllerContext.RequestContext.RouteData
                ?.Values[ModuleConstants.ViewPathKey]
                ?.ToString();
        }

        public string GetModuleName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ModuleConstants.ModuleKey]
                ?.ToString();

            return string.IsNullOrEmpty(component)
                ? ControllerContext.ExecutingViewName()
                : Regex.Replace(component, "pagemodule$", string.Empty, RegexOptions.IgnoreCase);
        }
        
    }
}
