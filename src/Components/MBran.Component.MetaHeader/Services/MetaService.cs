using MBran.Core;
using MBran.Models;
using System;
using Umbraco.Core.Models;

namespace MBran.Components.MetaHeader
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
            MetaTagHeader page;
            if (node == null)
            {
                page = _pageHelper.CurrentPage<MetaTagHeader>();
            }
            else
            {
                page = node.As<MetaTagHeader>();
            }
            
            var model = new MetaTitle
            {
                Title = !String.IsNullOrEmpty(page.MetaTitle) ? 
                    page.MetaTitle : _pageService.Title,
                Description = !String.IsNullOrEmpty(page.MetaDescription) ? 
                    page.MetaDescription : _pageService.Summary

            };

            return model;
        }

        public Image GetImage(IPublishedContent node = null)
        {
            Image image;
            if (node == null)
            {
                image = _pageHelper.CurrentPage<MetaTagImage>()?.MetaImage?.As<Image>();
            }
            else
            {
                image = node.As<MetaTagImage>()?.MetaImage?.As<Image>();
            }
            
            if(image == null)
            {
                image = _pageService.Image;
            }
            return image;

           
        }
    }
}
