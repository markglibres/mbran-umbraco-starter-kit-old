using MBran.Core.Helpers.Interface;
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
        private readonly IPublishedContentHelper _publishedContentHelper;

        private IPublishedContent _model;

        public int PageId => _contentHelper.CurrentPageId();
        public IPublishedContent PublishedContent => _model ?? _contentHelper.CurrentPage();
        
        public ComponentsController(IContentHelper contentHelper,
            IPublishedContentHelper publishedContentHelper)
        {
            _contentHelper = contentHelper;
            _publishedContentHelper = publishedContentHelper;

            _model = (IPublishedContent)ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ModelKey];
        }

        protected virtual object GetModel()
        {
            var doctypeName = Regex.Replace(this.GetType().UnderlyingSystemType.Name, "Controller$", string.Empty);
            var baseClassName = Regex.Replace(this.GetType().Name, "Controller$", string.Empty);
            if(doctypeName == baseClassName)
            {
                doctypeName = ControllerContext.RequestContext.RouteData
                    ?.Values[ComponentConstants.ModelTypeKey]
                    ?.ToString();
            }

            var modelType = _publishedContentHelper.GetModelType(doctypeName);
            return PublishedContent.As(modelType);
        }

        [ChildActionOnly]
        public virtual PartialViewResult Render()
        {
            return RenderModel(GetModel());
        }

        [ChildActionOnly]
        public virtual PartialViewResult RenderModel(object model)
        {
            var viewPath = GetViewPath();
           
            if (string.IsNullOrEmpty(viewPath))
            {
                viewPath = GetComponentName();
            }

            return PartialView(viewPath, model);
        }

        [ChildActionOnly]
        public virtual PartialViewResult Render(string viewPath, object model)
        {
            return PartialView(viewPath, model);
        }

        [ChildActionOnly]
        public virtual PartialViewResult RenderContent(IPublishedContent content)
        {
            var docType = content.GetDocumentType();
            var model = content.As(docType);
            var viewPath = this.GetValidCustomViewLocation(docType.Name);
            viewPath = string.IsNullOrEmpty(viewPath) ? docType.Name : viewPath;

            return PartialView(viewPath, model);
        }

        protected virtual string GetViewPath()
        {
            var viewPath = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ViewPathKey]
                ?.ToString();

            return string.IsNullOrEmpty(viewPath)
                ? this.GetValidCustomViewLocation(GetComponentName())
                : viewPath;
        }

        protected virtual string GetComponentName()
        {
            var component = ControllerContext.RequestContext.RouteData
                ?.Values[ComponentConstants.ComponentKey]
                ?.ToString();

            return string.IsNullOrEmpty(component) 
                ? ControllerContext.ExecutingViewName() 
                : Regex.Replace(component, "component$", string.Empty, RegexOptions.IgnoreCase);
        }

        protected virtual string GetValidCustomViewLocation(string viewName)
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
