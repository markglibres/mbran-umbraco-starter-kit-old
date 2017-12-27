using MBran.Core;
using MBran.Core.Models;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.Contact.Service
{
    public class ContactService : IContactService
    {
        private readonly ISiteService _siteService;
        public ContactService(ISiteService siteService)
        {
            _siteService = siteService;
        }
        
        public ContactPerson GetContact(IPublishedContent content = null)
        {
            var node = content ?? _siteService.GetSite();
            return node?.As<ContactPerson>();
        }
    }
}
