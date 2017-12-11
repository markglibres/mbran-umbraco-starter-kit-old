using MBran.Core;
using System;
using System.Diagnostics;
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
            return ComponentView(GetViewPath());
        }

        public virtual PartialViewResult ComponentView(string viewName)
        {
            return ComponentView(viewName, null);
        }

        public virtual PartialViewResult ComponentView(object model)
        {
            return ComponentView(GetViewPath(), model);
        }

        public virtual PartialViewResult ComponentView(string viewName, object model)
        {
            return PartialView(viewName, model);
        }

        public string GetViewPath()
        {
            string componentFolder = this.GetType().Name.Replace("SurfaceController", String.Empty);
            StackTrace stackTrace = new StackTrace();
            string actionMethod = stackTrace.GetFrame(2).GetMethod().Name;

            return ComponentViewHelper.GetFullPath(componentFolder, actionMethod);
        }
        
        public abstract PartialViewResult RenderModel(IPublishedContent model = null);
    }
}
