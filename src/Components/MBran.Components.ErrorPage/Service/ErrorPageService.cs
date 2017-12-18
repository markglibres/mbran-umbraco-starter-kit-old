using MBran.Core;
using MBran.Models;
using System.Web;

namespace MBran.Components.ErrorPage
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
            if (_errorPage == null)
            {
                _errorPage = _contentHelper
                    .GetDescendantOrSelf<Error404>(_siteService.GetDomainNodeId());
            }

            return _errorPage;
        }
    }
}
