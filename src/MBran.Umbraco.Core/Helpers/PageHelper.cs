using System;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace MBran.Umbraco.Core
{
    public class PageHelper : IPageHelper
    {
        private readonly UmbracoHelper _umbracoHelper;
        public PageHelper(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }

        public IPublishedContent CurrentPage()
        {
            return _umbracoHelper.UmbracoContext.PublishedContentRequest.PublishedContent;
        }

        public T CurrentPage<T>() where T : PublishedContentModel
        {
            var currentPage = CurrentPage();
            return currentPage.As<T>();
        }

        public int CurrentPageId()
        {
            return CurrentPage().Id;
        }
    }
}
