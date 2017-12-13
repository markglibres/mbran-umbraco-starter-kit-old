using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace MBran.Core.Components
{
    public abstract class ComponentSurfaceController : SurfaceController, IComponentController
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
            string view = GetViewName();
            string controller = GetControllerName();

            //TODO: fix mvc search location beause Umbraco does not support custom locations
            var partialView = this.ViewEngineCollection.FindPartialView(this.ControllerContext, view);

            if (partialView != null && partialView.View != null)
            {
                return PartialView(view, model);
            }

            string viewPath = ComponentViewHelper.GetFullPath(controller, view);
            return PartialView(viewPath, model);
        }

        public virtual PartialViewResult ComponentView(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        private string GetViewName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }

        private string GetControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }
        
        public abstract PartialViewResult RenderModel(IPublishedContent model = null);
    }
}
