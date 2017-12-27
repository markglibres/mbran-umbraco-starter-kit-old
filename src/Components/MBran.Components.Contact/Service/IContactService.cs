using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.Contact.Service
{
    public interface IContactService
    {
        ContactPerson GetContact(IPublishedContent content = null);
    }
}
