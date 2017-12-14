using System.IO;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace MBran.Core.Components
{
    public abstract class ComponentSurfaceController : SurfaceController, 
        IComponentController
    {
        private readonly IPageHelper _pageHelper;

        public int PageId { get { return _pageHelper.CurrentPageId(); } }

        public ComponentSurfaceController(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        public virtual PartialViewResult ComponentView()
        {
            return ComponentView(null);
        }

        public virtual PartialViewResult ComponentView(string viewName)
        {
            return PartialView(viewName);
        }

        public virtual PartialViewResult ComponentView(object model)
        {
            string customViewPath = GetCustomViewPath();
            PartialViewResult partialView = null;

            if (string.IsNullOrEmpty(customViewPath))
            {
                partialView = GetMvcView(model);
            }
            
            if(partialView == null)
            {
                partialView = GetDefaultView(model, customViewPath);
            }

            return partialView;
        }

        public virtual PartialViewResult ComponentView(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        private string GetCustomViewPath()
        {
            return this.ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.VIEW_PATH_KEY]
                ?.ToString();
        }

        private PartialViewResult GetMvcView(object model)
        {
            var viewEngine = this.GetViewEngine(this.ExecutingViewName(), true);

            if (viewEngine != null && viewEngine.View != null)
            {
                return viewEngine.GetPartialView(this.ControllerContext, model);
            }

            return null;
        }

        private PartialViewResult GetDefaultView(object model, string viewPath = "")
        {
            string controller = this.ExecutingControllerName();
            string view = string.IsNullOrEmpty(viewPath)
                ? ComponentViewHelper.GetFullPath(controller, this.ExecutingViewName())
                : viewPath;
            return PartialView(view, model);
        }

        public abstract PartialViewResult RenderModel(IPublishedContent model = null);

    }
}
