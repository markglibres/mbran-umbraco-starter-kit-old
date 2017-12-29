using MBran.Models;
using System.Web;
using Umbraco.Core;

namespace MBran.Core
{
    public class SiteService : ISiteService
    {
        private readonly IContentHelper _contentHelper;
        private readonly HttpContext _httpContext;

        private Home _home;
        private int _domainNodeId;
        private string _domain;

        private SiteConfig SiteConfig { get; set; }

        public SiteService(IContentHelper contentHelper,
            HttpContextBase httpContext)
        {
            _contentHelper = contentHelper;
            _httpContext = httpContext.ApplicationInstance.Context;
        }

        public SiteConfig GetSite()
        {
            if (SiteConfig == null)
            {
                SiteConfig = _contentHelper
                    .GetAncestorOrSelf<SiteConfig>(GetDomainNodeId());
            };

            return SiteConfig;
        }

        public Home GetHome()
        {
            return _home ?? (_home = _contentHelper
                       .GetDescendantOrSelf<Home>(GetDomainNodeId()));
        }

        public int GetDomainNodeId()
        {
            if (_domainNodeId != 0) return _domainNodeId;

            var domainNode = ApplicationContext.Current.Services.DomainService.GetByName(GetDomain());
            if (domainNode?.RootContentId != null)
            {
                _domainNodeId = (int) domainNode.RootContentId;
            }
            else
            {
                var home = _contentHelper
                    .GetDescendantOrSelf<Home>(_contentHelper.GetRoot().Id);
                _domainNodeId = home.Id;
            }

            return _domainNodeId;
        }

        public string GetDomain()
        {
            if (string.IsNullOrEmpty(_domain))
            {
                _domain = _httpContext.GetCurrentDomain();
            }
            return _domain;
        }

    }
}
