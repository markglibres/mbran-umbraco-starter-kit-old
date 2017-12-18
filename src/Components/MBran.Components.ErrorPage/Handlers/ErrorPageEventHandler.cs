using Umbraco.Core;
using Umbraco.Web.Routing;

namespace MBran.Components.ErrorPage
{
    public class MBranApplicationEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //don't forget to update your web.config => system.webServer => httpErrors attribute existingResponse = "PassThrough"
            //< httpErrors errorMode = "DetailedLocalOnly" defaultResponseMode = "File" existingResponse = "PassThrough" >
            // </ httpErrors >
            ContentLastChanceFinderResolver.Current.SetFinder(new Error404Handler());
        }
    }
}
