namespace MBran.Umbraco.Models
{
    public static class AutoMapperEvents
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<MetaTitle, MetaTitleViewModel>();
        }
    }
}
