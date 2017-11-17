using System;
using Umbraco.Core.Models;

namespace MBran.Umbraco.Core
{
    public static class PublishedContentExtensions
    {
        public static T As<T>(this IPublishedContent content)
            where T : class, IPublishedContent
        {
            T newObject = (T)Activator.CreateInstance(typeof(T), content);
            return newObject;
        }
    }
}
