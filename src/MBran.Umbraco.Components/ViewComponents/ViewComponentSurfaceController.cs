using MBran.Umbraco.Core;
using System;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace MBran.Umbraco.Components
{
    public abstract class ViewComponentSurfaceController : SurfaceController
    {
        private readonly IPageHelper _pageHelper;

        protected IPublishedContent Model { get { return _pageHelper.CurrentPage(); } }
        protected int PageId { get { return _pageHelper.CurrentPageId(); } }

        public ViewComponentSurfaceController(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        protected internal virtual PartialViewResult ComponentView()
        {
            return ComponentView(GetViewName());
        }

        protected internal virtual PartialViewResult ComponentView(string viewName)
        {
            return ComponentView(viewName, null);
        }

        protected internal virtual PartialViewResult ComponentView(object model)
        {
            return ComponentView(GetViewName(), model);
        }

        protected internal virtual PartialViewResult ComponentView(string viewName, object model)
        {
            return PartialView(viewName, model);
        }

        protected virtual string GetViewName()
        {
            string viewName = this.GetType().Name.Replace("SurfaceController", String.Empty);
            return ComponentViewHelper.GetFullPath(viewName);
        }

    }
}
