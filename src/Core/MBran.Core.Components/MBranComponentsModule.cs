using Autofac;

namespace MBran.Core.Components
{
    public class MBranComponentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ComponentsController>().InstancePerDependency();
        }
    }
}
