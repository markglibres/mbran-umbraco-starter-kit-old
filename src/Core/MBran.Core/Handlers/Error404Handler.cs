using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Routing;

namespace MBran.Core
{
    public class Error404Handler : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            if (contentRequest.Is404)
            {
                ISiteService _siteService = DependencyResolver.Current.GetService<ISiteService>();
                IPublishedContent notFoundNode = _siteService.GetErrorPage();
                contentRequest.SetResponseStatus(404, "404 Page Not Found");
                contentRequest.PublishedContent = notFoundNode;
            }

            return contentRequest.PublishedContent != null;
        }
    }
}
