using MBran.Models;

namespace MBran.Core
{
    public class PageService : IPageService
    {
        private readonly IContentHelper _contentHelper;
        public PageService(IContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
        }
        public string Title => _contentHelper.CurrentPage<ContentHeader>().ContentTitle;

        public string Summary => _contentHelper.CurrentPage<ContentHeader>().ContentSummary;

        public Image Image => _contentHelper.CurrentPage<ContentImageFile>()?.ContentImage?.As<Image>();
        
    }
}
