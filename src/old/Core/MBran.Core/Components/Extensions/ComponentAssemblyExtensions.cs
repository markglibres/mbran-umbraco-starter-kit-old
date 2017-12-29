using MBran.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MBran.Core.Components.Extensions
{
    public static class ComponentAssemblyExtensions
    {
        public static IEnumerable<Type> FindComponents(this AppDomain domain)
        {
            return domain.FindImplementations<Component>();
        }

        public static Type FindComponent(this AppDomain domain, string component)
        {
            return domain.FindComponents()
                .Where(componentType => componentType.Name.EndsWith(component))
                .FirstOrDefault();
        }
    }
}
