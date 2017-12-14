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
            string view = this.ExecutingViewName();
            var viewEngine = this.GetViewEngine(view, true);

            if (viewEngine != null && viewEngine.View != null)
            {
                return viewEngine.GetPartialView(this.ControllerContext, model);
            }

            string controller = this.ExecutingControllerName();
            string viewPath = ComponentViewHelper.GetFullPath(controller, view);
            return PartialView(viewPath, model);
        }

        public virtual PartialViewResult ComponentView(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }
                
        public abstract PartialViewResult RenderModel(IPublishedContent model = null);

    }
}
