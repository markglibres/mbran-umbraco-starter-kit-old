using System;
using System.Web.Mvc;
using MBran.Umbraco.Components;

namespace MBran.Umbraco
{
    public class MetaTitleComponent : Component<MetaTagHeaderSurfaceController>
    {
        public MetaTitleComponent(HtmlHelper htmlHelper) 
            : base(htmlHelper)
        {

        }
        
    }
}
