using Autofac;
using Autofac.Integration.Mvc;
using System;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web;

namespace MBran.Core
{
    public class MBranCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacWebTypesModule());
            if (!String.IsNullOrEmpty(ConfigurationHelper.ConnectionString))
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
