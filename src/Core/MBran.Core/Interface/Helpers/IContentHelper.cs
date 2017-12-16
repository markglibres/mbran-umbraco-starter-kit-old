using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MBran.Core
{
    public interface IContentHelper
    {
        IEnumerable<T> GetDescendants<T>(int startId) where T : class;
        IEnumerable<T> GetDescendantsOrSelf<T>(int startId) where T : class;
        T GetDescendant<T>(int startId) where T : class;
        T GetDescendantOrSelf<T>(int startId) where T : class;
        IEnumerable<T> GetAncestors<T>(int startId) where T : class;
        IEnumerable<T> GetAncestorsOrSelf<T>(int startId) where T : class;
        T GetAncestor<T>(int startId) where T : class;
        T GetAncestorOrSelf<T>(int startId) where T : class;
        T GetContent<T>(int nodeId) where T : class;
        IPublishedContent GetRoot();
        T GetRoot<T>() where T: class;
    }
}
