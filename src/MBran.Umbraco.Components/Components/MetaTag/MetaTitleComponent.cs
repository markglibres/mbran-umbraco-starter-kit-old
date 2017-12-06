using MBran.Umbraco.Components;
using System.Web.Mvc;

namespace MBran.Umbraco
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
