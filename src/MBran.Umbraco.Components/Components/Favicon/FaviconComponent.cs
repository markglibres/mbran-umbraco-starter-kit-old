using System.Web.Mvc;

namespace MBran.Umbraco.Components
{
    public class FaviconComponent : Component<FaviconSurfaceController>
    {
        public FaviconComponent(HtmlHelper htmlHelper) : base(htmlHelper)
        {
        }
    }
}
