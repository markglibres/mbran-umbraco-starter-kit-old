using MBran.Core.Extensions;
using MBran.Core.Helpers.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;

namespace MBran.Core.Helpers
{
    public class PublishedContentHelper : IPublishedContentHelper
    {
       
        public Type GetModelType(string docTypeAlias)
        {
            return GetModelTypes()
                .Where(modelType => modelType.Name.Equals(docTypeAlias, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();
        }

        public IEnumerable<Type> GetModelTypes()
        {
            return AppDomain.CurrentDomain.FindImplementations<PublishedContentModel>();
        }
    }
}
