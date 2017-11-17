using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace MBran.Umbraco.Web
{
    public class AutofacEventHandler : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();

            builder.RegisterInstance(applicationContext.Services.ContentService).As<IContentService>();
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            builder.RegisterControllers(typeof(AutofacEventHandler).Assembly);

            builder.RegisterUmbraco()
                .RegisterCustomControllers(executingAssembly)
                .RegisterServices(executingAssembly)
                .RegisterRepositories(executingAssembly)
                .RegisterModules()
                .BuildContainer();
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }
    }
}
