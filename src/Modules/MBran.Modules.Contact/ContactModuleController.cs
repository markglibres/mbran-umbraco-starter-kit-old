using MBran.Components.Controllers;
using MBran.Core.Extensions;
using MBran.Core.Helpers;
using MBran.Models;

namespace MBran.Modules.Contact
{
    public class ContactModuleController : ModulesController
    {
        protected override object PrepareModel()
        {
            var siteConfig = ContentHelper.Instance.GetAncestor<SiteConfig>(CurrentPage.Id);
            return siteConfig.As<ContactPerson>();
        }
    }
}
