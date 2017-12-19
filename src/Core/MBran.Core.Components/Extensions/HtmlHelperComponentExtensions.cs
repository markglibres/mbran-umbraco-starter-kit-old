using System.Web.Mvc;

namespace MBran.Core.Components
{
    public static class HtmlHelperComponentExtensions
    {
        public static MvcHtmlString Component<T>(this HtmlHelper helper)
            where T : IComponent, IComponentRender
        {
            
            IComponentRender component = DependencyResolver.Current.GetService<T>();
            component.SetHtmlHelper(helper);
            return component.Render();
        }
        
    }
}
