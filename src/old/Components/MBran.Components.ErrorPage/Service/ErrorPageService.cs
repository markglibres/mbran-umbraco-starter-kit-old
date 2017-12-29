using System.Web;
using MBran.Core;
using MBran.Models;

namespace MBran.Components.ErrorPage.Service
{
    public class ErrorPageService : IErrorPageService
    {
        private readonly IContentHelper _contentHelper;
        private readonly ISiteService _siteService;
        private readonly HttpContext _httpContext;

        private Error404 _errorPage;
        
        public ErrorPageService(HttpContextBase httpContext,
            IContentHelper contentHelper,
            ISiteService siteService
            )
        {
            _contentHelper = contentHelper;
            _siteService = siteService;
            _httpContext = httpContext.ApplicationInstance.Context;
        }

        
        public Error404 GetErrorPage()
        {
            return _errorPage ?? (_errorPage = _contentHelper
                       .GetDescendantOrSelf<Error404>(_siteService.GetDomainNodeId()));
        }
    }
}
