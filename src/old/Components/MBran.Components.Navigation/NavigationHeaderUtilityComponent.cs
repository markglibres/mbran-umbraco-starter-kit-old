using MBran.Components.Navigation.Service;
using MBran.Core;
using MBran.Core.Components;

namespace MBran.Components.Navigation
{
    public class NavigationHeaderUtilityComponent : Component
    {
        private readonly INavigationService _navigationService;

        public NavigationHeaderUtilityComponent(IContentHelper contentHelper,
            INavigationService navigationService)
            : base(contentHelper)
        {
            _navigationService = navigationService;
        }

        public override object GetModel()
        {
            return _navigationService.GetHeaderUtility();
        }
    }
}
