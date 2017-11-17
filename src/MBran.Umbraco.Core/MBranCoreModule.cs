using Autofac;
using Autofac.Integration.Mvc;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web;

namespace MBran.Umbraco.Core
{
    public class MBranCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(this.ThisAssembly);
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterInstance(ApplicationContext.Current.DatabaseContext.Database)
                .As<UmbracoDatabase>();
            builder.Register(c => UmbracoContext.Current).As<UmbracoContext>();
            builder.Register(c => new UmbracoHelper(UmbracoContext.Current))
                .As<UmbracoHelper>();
            
        }
    }
}
