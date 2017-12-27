using MBran.Core;
using MBran.Core.Models;
using MBran.Models;

namespace MBran.Components.Contact.Service
{
    public class ContactService : IContactService
    {
        private readonly ISiteService _siteService;
        public ContactService(ISiteService siteService)
        {
            _siteService = siteService;
        }
        public ContactPerson GetContact()
        {
            return _siteService.GetSite()?.As<ContactPerson>();
        }
    }
}
