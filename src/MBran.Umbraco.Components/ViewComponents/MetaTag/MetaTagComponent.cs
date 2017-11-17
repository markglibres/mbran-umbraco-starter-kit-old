using System.Web.Mvc;

namespace MBran.Umbraco.Components
{
    public static class MetaTagComponent
    {
        public const string Name = "MetaTagHeader";
        public static MvcHtmlString MetaHeader(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Component(Name);
        }
    }
}
