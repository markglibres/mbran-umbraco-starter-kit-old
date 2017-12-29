using System.Web.Mvc;
using MBran.Components.ErrorPage.Service;
using Umbraco.Core.Models;
using Umbraco.Web.Routing;

namespace MBran.Components.ErrorPage.Handlers
{
    public class Error404Handler : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            if (!contentRequest.Is404) return contentRequest.PublishedContent != null;

            var errorPageService = DependencyResolver.Current.GetService<IErrorPageService>();
            IPublishedContent notFoundNode = errorPageService.GetErrorPage();
            contentRequest.SetResponseStatus(404, "404 Page Not Found");
            contentRequest.PublishedContent = notFoundNode;

            return contentRequest.PublishedContent != null;
        }
    }
}
