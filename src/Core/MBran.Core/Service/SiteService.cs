using MBran.Models;
using System;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace MBran.Core
{
    public class SiteService : ISiteService
    {
        private readonly IContentHelper _contentHelper;
        private readonly HttpContext _httpContext;

        private SiteConfig _siteConfig;
        private Error404 _errorPage;
        private Home _home;
        private int _domainNodeId;
        private string _domain;

        public SiteService(IContentHelper contentHelper,
            HttpContextBase httpContext)
        {
            _contentHelper = contentHelper;
            _httpContext = httpContext.ApplicationInstance.Context;
        }

        public SiteConfig GetSite()
        {
            if (_siteConfig == null)
            {
                _siteConfig = _contentHelper
                    .GetAncestorOrSelf<SiteConfig>(GetDomainNodeId());
            };

            return _siteConfig;
        }

        public Home GetHome()
        {
            if (_home == null)
            {
                _home = _contentHelper
                    .GetDescendantOrSelf<Home>(GetDomainNodeId());
            }

            return _home;
        }

        public int GetDomainNodeId()
        {
            if (_domainNodeId == 0)
            {
                IDomain domainNode = ApplicationContext.Current.Services.DomainService.GetByName(GetDomain());
                if (domainNode != null)
                {
                    _domainNodeId = (int)domainNode.RootContentId;
                }
                else
                {
                    Home home = _contentHelper
                        .GetDescendantOrSelf<Home>(_contentHelper.GetRoot().Id);
                    _domainNodeId = home.Id;
                }

            }

            return _domainNodeId;
        }

        public string GetDomain()
        {
            if (String.IsNullOrEmpty(_domain))
            {
                _domain = _httpContext.GetCurrentDomain();
            }
            return _domain;
        }

    }
}
