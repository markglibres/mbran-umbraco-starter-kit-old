using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MBran.Core
{
    public static class PublishedContentExtensions
    {
        public static T As<T>(this IPublishedContent content)
            where T : PublishedContentModel
        {
            var newObject = (T)Activator.CreateInstance(typeof(T), content);
            return newObject;
        }

        public static IEnumerable<T> ConvertTo<T>(this IEnumerable<IPublishedContent> content)
            where T : PublishedContentModel
        {
            if (content != null)
            {
                return content
                    .Select(c => c.As<T>())
                    .Where(c => c != null);
            }
            return new List<T>();
        }
    }
}
