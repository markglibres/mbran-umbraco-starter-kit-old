﻿using MBran.Core;
using MBran.Core.Components;
using MBran.Models;

namespace MBran.Components.Navigation
{
    public class NavigationHeaderComponent : Component
    {
        private readonly ISiteService _siteService;

        public NavigationHeaderComponent(IContentHelper contentHelper, 
            ISiteService siteService)
            : base(contentHelper)
        {
            _siteService = siteService;
        }

        public override object GetViewModel()
        {
            var siteNav = _siteService.GetSite().As<NavigationHeader>();
            var listNav = siteNav?.NavigationListHeader?.ConvertTo<NavigationListNested>();

            return listNav;
        }
    }
}
