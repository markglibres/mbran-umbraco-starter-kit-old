using MBran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MBran.Core.Models
{
    public static class PublishedContentExtensions
    {
        public static T As<T>(this IPublishedContent content)
            where T : PublishedContentModel
        {
            var newObject = (T)Activator.CreateInstance(typeof(T), content);
            return newObject;
        }

        public static object As(this IPublishedContent content, Type type)
        {
            var newObject = Activator.CreateInstance(type, content);
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

        public static Type GetDocumentType(this IPublishedContent content)
        {
            var docType = content.DocumentTypeAlias;
            var modelTypeName = Char.ToUpperInvariant(docType[0]) + docType.Substring(1);
            var modelsAssemblyNamespace = typeof(SiteConfig).Namespace;
            var modelsAssembly = typeof(SiteConfig).Assembly;
            return modelsAssembly.GetType($"{modelsAssemblyNamespace}.{modelTypeName}");
        }
    }
}
