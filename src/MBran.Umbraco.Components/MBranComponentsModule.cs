using Autofac;
using Autofac.Integration.Mvc;

namespace MBran.Umbraco.Components
{
    public class MBranComponentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(this.ThisAssembly);
        }
    }
}
