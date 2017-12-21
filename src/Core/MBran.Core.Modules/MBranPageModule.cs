using Autofac;
using MBran.Core.Modules.Controllers;

namespace MBran.Core.Modules
{
    public class MBranPageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ModulesController>().InstancePerDependency();
        }
    }
}
