using Humanizer;
using MBran.Core.Modules.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core.Models;

namespace MBran.Core.Modules
{
    public abstract class PageModule : IPageModule
    {
        private readonly string _moduleName;
        public string Name => _moduleName.Humanize();
        private IPublishedContent _content;
        public IPublishedContent PublishedContent => _content ?? _contentHelper.CurrentPage();
        private RouteValueDictionary _options;
        public RouteValueDictionary Options => _options ?? new RouteValueDictionary();
        private readonly IContentHelper _contentHelper;
        private HtmlHelper _htmlHelper;

        public PageModule(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
            _moduleName = GetType().UnderlyingSystemType.Name;
        }

        public abstract IPageModuleModel GetModel();

        public MvcHtmlString Render(object model, RouteValueDictionary options)
        {
            throw new NotImplementedException();
        }

        public MvcHtmlString Render(string viewPath, object model, RouteValueDictionary options)
        {
            throw new NotImplementedException();
        }

        public MvcHtmlString Render()
        {
            throw new NotImplementedException();
        }

        public void SetHtmlHelper(HtmlHelper helper)
        {
            _htmlHelper = helper;
        }

        public void SetPublishedContent(IPublishedContent content)
        {
            _content = content;
        }

        public void SetRouteOptions(RouteValueDictionary options)
        {
            _options = options;
        }
    }
}
