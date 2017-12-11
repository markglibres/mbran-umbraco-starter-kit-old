using System.Web.Mvc;

namespace MBran.Core.Components
{
    public class FaviconComponent : Component<FaviconSurfaceController>
    {
        public FaviconComponent(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
