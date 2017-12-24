using Autofac;
using Autofac.Integration.Mvc;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web;

namespace MBran.Core
{
    public class RegisterUmbraco : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());
            if (!string.IsNullOrEmpty(ConfigurationHelper.ConnectionString))
            {
                builder.RegisterInstance(ApplicationContext.Current.DatabaseContext.Database)
                .As<UmbracoDatabase>();
            }
            builder.Register(c => UmbracoContext.Current).As<UmbracoContext>();
            builder.Register(c => new UmbracoHelper(UmbracoContext.Current))
                .As<UmbracoHelper>();
            
        }
    }
}
