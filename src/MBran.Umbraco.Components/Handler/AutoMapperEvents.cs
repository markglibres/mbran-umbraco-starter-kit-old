using MBran.Umbraco.Core;
using MBran.Umbraco.Models;

namespace MBran.Umbraco.Components
{
    public static class AutoMapperEvents
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<MetaTagHeaderComponentModel, MetaTagHeaderViewModel>();
        }
    }
}
