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
        public string Title => GetTitle();

        public string Description => GetDescription();

        public Image Image => GetImage();

        private string GetTitle()
        {
            var title = _pageHelper.CurrentPage<MetaTagHeader>().MetaTitle;
            if(String.IsNullOrEmpty(title))
            {
                title = _pageService.Title;
            }
            return title;
        }

        private string GetDescription()
        {
            var desc = _pageHelper.CurrentPage<MetaTagHeader>().MetaDescription;
            if(String.IsNullOrEmpty(desc))
            {
                desc = _pageService.Summary;
            }
            return desc;
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
