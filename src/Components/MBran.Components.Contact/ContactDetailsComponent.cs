using MBran.Components.Contact.Service;
using MBran.Core;
using MBran.Core.Components;

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
            return _contactService.GetContact();
        }
    }
}
