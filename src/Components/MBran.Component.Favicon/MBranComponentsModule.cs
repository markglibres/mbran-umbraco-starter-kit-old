using Autofac;
using MBran.Component.Favicon.Service;

namespace MBran.Core.Components
{
    public class MBranComponentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FaviconService>().As<IFaviconService>();
        }
    }
}
