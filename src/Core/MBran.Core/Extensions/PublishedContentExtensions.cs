using System;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MBran.Core
{
    public static class PublishedContentExtensions
    {
        public static T As<T>(this IPublishedContent content)
            where T : PublishedContentModel
        {
            T newObject = (T)Activator.CreateInstance(typeof(T), content);
            return newObject;
        }
    }
}
