using MBran.Core.Models;
using MBran.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Umbraco.Core.Models;
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
            var customViewPath = GetViewPath();
            PartialViewResult partialView = null;

            if (string.IsNullOrEmpty(customViewPath))
            {
                partialView = GetMvcView(model);
            }

            return partialView ?? (GetView(model, customViewPath));
        }

        public virtual PartialViewResult Render(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        public string GetViewPath()
        {
            return ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ViewPathKey]
                ?.ToString();
        }

        public string GetViewName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ComponentKey]
                ?.ToString();

            return string.IsNullOrEmpty(component) 
                ? ControllerContext.ExecutingViewName() 
                : Regex.Replace(component, "component$", string.Empty, RegexOptions.IgnoreCase);
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
            var component = GetViewName();
            var view = string.IsNullOrEmpty(viewPath)
                ? ComponentViewHelper.GetFullPath(ComponentConstants.Folders.Views.Default, component)
                : viewPath;
            return PartialView(view, model);
        }

        public virtual PartialViewResult RenderContent(IPublishedContent content)
        {
            var docType = content.GetDocumentType();
            var model = content.As(docType);
            return PartialView(docType.Name, model);
        }
    }
}
