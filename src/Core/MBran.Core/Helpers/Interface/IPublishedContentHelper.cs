using System;
using System.Collections.Generic;

namespace MBran.Core.Helpers.Interface
{
    public interface IPublishedContentHelper
    {
        Type GetModelType(string docTypeAlias);
        IEnumerable<Type> GetModelTypes();
    }
}
