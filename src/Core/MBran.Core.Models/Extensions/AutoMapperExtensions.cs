using AutoMapper;

namespace MBran.Core.Models
{
    public static class AutoMapperExtensions
    {
        public static T Map<T>(this object model)
            where T: class
        {
            T destModel = Mapper.Map<T>(model);
            return destModel;
        }
        
    }
}
