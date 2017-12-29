using MBran.Components.Contact.Service;
using MBran.Core;
using MBran.Core.Components;
using MBran.Core.Models;
using MBran.Models;

namespace MBran.Components.Contact
{
    public class ContactDetailsComponent : Component
    {
        private readonly IContactService _contactService;
        public ContactDetailsComponent(IContentHelper contentHelper,
            IContactService contactService) 
            : base(contentHelper)
        {
            _contactService = contactService;
        }

        public override object GetModel()
        {
            var content = PublishedContent.As<ContactDetails>()?.ContactDetailsPage;
            return _contactService.GetContact(content);
        }
    }
}
