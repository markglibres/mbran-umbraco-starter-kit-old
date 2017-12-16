using MBran.Core.Models;
using Our.Umbraco.Ditto;
using Umbraco.Core.Models;

namespace MBran.Core
{
    public static class PublishedContentExtensions
    {
        public static T As<T>(this IBasePoco content)
            where T : class, IBasePoco
        {
            return content.PublishedContent.As<T>();
        }
    }
}
