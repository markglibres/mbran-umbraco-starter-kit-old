using MBran.Umbraco.Core;
using Our.Umbraco.DocTypeGridEditor.Web.Controllers;
using System;
using System.Web.Mvc;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Components
{
    public abstract class ComponentSurfaceController : DocTypeGridEditorSurfaceController, IComponentController
    {
        private readonly IPageHelper _pageHelper;

        public int PageId { get { return _pageHelper.CurrentPageId(); } }

        public ComponentSurfaceController() { }
        public ComponentSurfaceController(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }

        public virtual PartialViewResult ComponentView()
        {
            return ComponentView(GetViewName());
        }

        public virtual PartialViewResult ComponentView(string viewName)
        {
            return ComponentView(viewName, null);
        }

        public virtual PartialViewResult ComponentView(object model)
        {
            return ComponentView(GetViewName(), model);
        }

        public virtual PartialViewResult ComponentView(string viewName, object model)
        {
            return PartialView(viewName, model);
        }

        public string GetViewName()
        {
            string viewName = this.GetType().Name.Replace("SurfaceController", String.Empty);
            return ComponentViewHelper.GetFullPath(viewName);
        }

        public abstract PartialViewResult RenderModel(IPublishedContent model = null);
    }
}
