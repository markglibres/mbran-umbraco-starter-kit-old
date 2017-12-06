using Autofac;

namespace MBran.Umbraco.Core
{
    public class MBranHelperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentHelper>()
                .As<IContentHelper>()
                .SingleInstance();
            builder.RegisterType<PageHelper>()
                .As<IPageHelper>()
                .SingleInstance();
            builder.RegisterType<MediaHelper>()
                .As<IMediaHelper>()
                .SingleInstance();
        }
    }
}
