using MBran.Umbraco.Components;
using System.Web.Mvc;

namespace MBran.Component.Meta
{
    public class MetaTitleComponent : Component<MetaTagHeaderSurfaceController>
    {
        public MetaTitleComponent(HtmlHelper htmlHelper) 
            : base(htmlHelper)
        {

        }

        public override string RenderAction
        {
            get
            {
                return nameof(MetaTagHeaderSurfaceController.RenderTitle);
            }
        }

    }
}
