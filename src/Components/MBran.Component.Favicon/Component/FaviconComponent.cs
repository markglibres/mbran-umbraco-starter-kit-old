using MBran.Core.Components;
using System.Web.Mvc;

namespace MBran.Component.Favicon
{
    public class FaviconComponent : Component<FaviconController>
    {
        public FaviconComponent(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
