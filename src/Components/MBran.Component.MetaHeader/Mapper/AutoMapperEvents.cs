namespace MBran.Components.MetaHeader
{
    public static class AutoMapperEvents
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<MetaTitle, MetaTitleViewModel>();
        }
    }
}
