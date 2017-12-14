using System.Web.Mvc;

namespace MBran.Core.Components
{
    public class FaviconComponent : Component<FaviconController>
    {
        public FaviconComponent(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
