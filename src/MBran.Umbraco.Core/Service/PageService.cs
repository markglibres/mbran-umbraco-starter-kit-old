namespace MBran.Umbraco.Core
{
    public class PageService : IPageService
    {
        private readonly IPageHelper _pageHelper;
        public PageService(IPageHelper pageHelper)
        {
            _pageHelper = pageHelper;
        }
        public string Title => _pageHelper.CurrentPage<ContentHeader>().ContentTitle;

        public string Summary => _pageHelper.CurrentPage<ContentHeader>().ContentSummary;

        public Image Image => _pageHelper.CurrentPage<ContentImageFile>()?.ContentImage?.As<Image>();
        
    }
}
