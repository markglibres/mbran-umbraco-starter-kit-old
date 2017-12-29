using MBran.Components.Navigation.Service;
using MBran.Core;
using MBran.Core.Components;

namespace MBran.Components.Navigation
{
    public class NavigationFooterUtilityComponent : Component
    {
        private readonly INavigationService _navigationService;

        public NavigationFooterUtilityComponent(IContentHelper contentHelper,
            INavigationService navigationService)
            : base(contentHelper)
        {
            _navigationService = navigationService;
        }

        public override object GetModel()
        {
            return _navigationService.GetFooterUtility();
        }
    }
}
