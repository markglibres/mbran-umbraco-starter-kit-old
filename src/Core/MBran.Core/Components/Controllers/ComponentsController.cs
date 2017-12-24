using MBran.Core.Models;
using System.Collections.Generic;
using System.IO;
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
            var viewPath = GetViewPath();
           
            if (string.IsNullOrEmpty(viewPath))
            {
                viewPath = GetComponentName();
            }

            return PartialView(viewPath, model);
        }

        public virtual PartialViewResult Render(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        public virtual PartialViewResult RenderContent(IPublishedContent content)
        {
            var docType = content.GetDocumentType();
            var model = content.As(docType);
            var viewPath = this.GetValidCustomViewLocation(docType.Name);
            viewPath = string.IsNullOrEmpty(viewPath) ? docType.Name : viewPath;

            return PartialView(viewPath, model);
        }

        public string GetViewPath()
        {
            var viewPath = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ViewPathKey]
                ?.ToString();

            return string.IsNullOrEmpty(viewPath)
                ? this.GetValidCustomViewLocation(GetComponentName())
                : viewPath;
        }

        public string GetComponentName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ComponentKey]
                ?.ToString();

            return string.IsNullOrEmpty(component) 
                ? ControllerContext.ExecutingViewName() 
                : Regex.Replace(component, "component$", string.Empty, RegexOptions.IgnoreCase);
        }
        
        public virtual string GetValidCustomViewLocation(string viewName)
        {
            if(!(ControllerContext.RequestContext.RouteData
                .Values[ComponentConstants.ViewLocations] is List<string> viewLocations))
            {
                return string.Empty;
            }
            
            foreach(var viewPath in viewLocations)
            {
                var view = Path.Combine(viewPath, viewName + ".cshtml");
                var viewEngine = this.GetViewEngine(view, true);
                if(viewEngine?.View != null)
                {
                    return view;
                }
            }

            return string.Empty;

        }
    }
}
