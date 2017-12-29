using MBran.Components.Navigation.Service;
using MBran.Core;
using MBran.Core.Components;

namespace MBran.Components.Navigation
{
    public class NavigationHeaderComponent : Component
    {
        private readonly INavigationService _navigationService;

        public NavigationHeaderComponent(IContentHelper contentHelper,
            INavigationService navigationService)
            : base(contentHelper)
        {
            _navigationService = navigationService;
        }

        public override object GetModel()
        {
            return _navigationService.GetHeader();
        }
    }
}
