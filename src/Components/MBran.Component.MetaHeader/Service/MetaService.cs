using MBran.Components.MetaHeader.Models;
using MBran.Core;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.MetaHeader.Service
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
       
        public MetaTitle GetHeader(IPublishedContent node = null)
        {
            var page = node == null ? _pageHelper.CurrentPage<MetaTagHeader>() : node.As<MetaTagHeader>();
            
            var model = new MetaTitle
            {
                Title = !string.IsNullOrEmpty(page.MetaTitle) ? 
                    page.MetaTitle : _pageService.Title,
                Description = !string.IsNullOrEmpty(page.MetaDescription) ? 
                    page.MetaDescription : _pageService.Summary

            };

            return model;
        }

        public Image GetImage(IPublishedContent node = null)
        {
            var image = (node == null 
                            ? _pageHelper.CurrentPage<MetaTagImage>()?.MetaImage?.As<Image>() 
                            : node.As<MetaTagImage>()?.MetaImage?.As<Image>()) ?? _pageService.Image;

            return image;

           
        }
    }
}
