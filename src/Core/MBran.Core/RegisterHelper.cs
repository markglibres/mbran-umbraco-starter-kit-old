using Autofac;
using MBran.Core.Helpers;
using MBran.Core.Helpers.Interface;

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
            builder.RegisterType<PublishedContentHelper>()
                .As<IPublishedContentHelper>()
                .SingleInstance();
        }
    }
}
