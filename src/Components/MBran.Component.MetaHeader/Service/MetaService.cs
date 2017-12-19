using MBran.Components.MetaHeader.Models;
using MBran.Core;
using MBran.Models;
using Umbraco.Core.Models;

namespace MBran.Components.MetaHeader.Service
{
    public class MetaService : IMetaService
    {
        private readonly IContentHelper _contentHelper;
        private readonly IPageService _pageService;

        public MetaService(IContentHelper contentHelper, IPageService pageService)
        {
            _contentHelper = contentHelper;
            _pageService = pageService;
        }
       
        public MetaTitle GetHeader(IPublishedContent node = null)
        {
            var page = node == null ? _contentHelper.CurrentPage<MetaTagHeader>() : node.As<MetaTagHeader>();
            
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
                            ? _contentHelper.CurrentPage<MetaTagImage>()?.MetaImage?.As<Image>() 
                            : node.As<MetaTagImage>()?.MetaImage?.As<Image>()) ?? _pageService.Image;

            return image;

           
        }
    }
}
