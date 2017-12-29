using MBran.Models;
using System.Collections.Generic;

namespace MBran.Components.Navigation.Service
{
    public interface INavigationService
    {
        IEnumerable<NavigationListNested> GetHeader();
        IEnumerable<NavigationListNested> GetFooter();
        IEnumerable<NavigationListNested> GetHeaderUtility();
        IEnumerable<NavigationListNested> GetFooterUtility();
    }
}
