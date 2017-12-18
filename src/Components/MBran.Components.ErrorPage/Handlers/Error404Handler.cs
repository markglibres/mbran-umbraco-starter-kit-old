using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Routing;

namespace MBran.Components.ErrorPage
{
    public class Error404Handler : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            if (contentRequest.Is404)
            {
                IErrorPageService _errorPageService = DependencyResolver.Current.GetService<IErrorPageService>();
                IPublishedContent notFoundNode = _errorPageService.GetErrorPage();
                contentRequest.SetResponseStatus(404, "404 Page Not Found");
                contentRequest.PublishedContent = notFoundNode;
            }

            return contentRequest.PublishedContent != null;
        }
    }
}
