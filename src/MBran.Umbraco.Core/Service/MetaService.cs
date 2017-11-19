using MBran.Umbraco.Models;
using System;

namespace MBran.Umbraco.Core
{
    public class MetaService : IMetaService
    {
        private readonly IPageHelper _pageHelper;
        private readonly IPageService _pageService;

        public MetaService(IPageHelper pageHelper, IPageService pageService)
        {
            _pageHelper = pageHelper;
            _pageService = pageService;
        }
        public MetaTagHeaderComponentModel Header => GetHeader();
        public Image Image => GetImage();

        private MetaTagHeaderComponentModel GetHeader()
        {
            MetaTagHeader page = _pageHelper.CurrentPage<MetaTagHeader>();
            
            var model = new MetaTagHeaderComponentModel
            {
                Title = !String.IsNullOrEmpty(page.MetaTitle) ? 
                    page.MetaTitle : _pageService.Title,
                Description = !String.IsNullOrEmpty(page.MetaDescription) ? 
                    page.MetaDescription : _pageService.Summary

            };

            return model;
        }
        
        private Image GetImage()
        {
            var image = _pageHelper.CurrentPage<MetaTagImage>()?.MetaImage?.As<Image>();
            if(image == null)
            {
                image = _pageService.Image;
            }
            return image;
        }
    }
}
