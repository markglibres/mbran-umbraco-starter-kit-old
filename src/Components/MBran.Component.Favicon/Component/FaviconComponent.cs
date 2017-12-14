using System.Web.Mvc;

namespace MBran.Core.Components
{
    [Component(FaviconController)]
    public class FaviconComponent : Component<FaviconController>
    {
        public FaviconComponent(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
