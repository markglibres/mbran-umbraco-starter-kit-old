using System.Web.Mvc;

namespace MBran.Core.Modules
{
    public static class HtmlHelperModuleExtensions
    {
        public static MvcHtmlString Module<T>(this HtmlHelper helper)
            where T : IPageModule
        {
            IPageModule module = DependencyResolver.Current.GetService<T>();
            module.SetHtmlHelper(helper);
            return module.Render();
        }
    }
}
