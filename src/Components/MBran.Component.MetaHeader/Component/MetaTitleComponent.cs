using MBran.Core.Components;
using System.Web.Mvc;

namespace MBran.Component.MetaHeader
{
    public class MetaTitleComponent : Component<MetaTagHeaderController>
    {
        public MetaTitleComponent(HtmlHelper htmlHelper) 
            : base(htmlHelper)
        {

        }

        public override string RenderAction
        {
            get
            {
                return nameof(MetaTagHeaderController.RenderTitle);
            }
        }

    }
}
