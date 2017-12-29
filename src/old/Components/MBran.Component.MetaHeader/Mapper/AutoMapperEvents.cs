using MBran.Components.MetaHeader.Models;

namespace MBran.Components.MetaHeader.Mapper
{
    public static class AutoMapperEvents
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<MetaTitle, MetaTitleViewModel>();
        }
    }
}
