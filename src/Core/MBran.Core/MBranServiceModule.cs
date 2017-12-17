using Autofac;

namespace MBran.Core
{
    public class MBranServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteService>().As<ISiteService>();
            builder.RegisterType<XmlSerializerService>().As<IXmlSerializerService>();
            builder.RegisterType<SiteMapService>().As<ISitemapService>();
            builder.RegisterType<PageService>().As<IPageService>();
            builder.RegisterType<MediaService>().As<IMediaService>();
        }
    }
}
