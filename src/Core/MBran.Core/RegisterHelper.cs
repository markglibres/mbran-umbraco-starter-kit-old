using Autofac;

namespace MBran.Core
{
    public class RegisterHelper : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentHelper>()
                .As<IContentHelper>()
                .SingleInstance();
            builder.RegisterType<MediaHelper>()
                .As<IMediaHelper>()
                .SingleInstance();
        }
    }
}
