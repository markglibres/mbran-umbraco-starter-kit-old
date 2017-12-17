using Autofac;
using Autofac.Integration.Mvc;
using MBran.Core;
using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace MBran.Umbraco.Web
{
    public class AutofacEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var builder = IoCBuilder.Instance.GetBuilder(applicationContext);
            //builder.RegisterControllers(typeof(AutofacEventHandler).Assembly);
            
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
