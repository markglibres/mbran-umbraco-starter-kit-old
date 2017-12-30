using MBran.Autofac;
using Umbraco.Core;

namespace MBran.Umbraco.Web
{
    public class AutofacEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = IoCBuilder.Instance.GetBuilder(applicationContext);
            builder.BuildContainer();
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }
    }
}
