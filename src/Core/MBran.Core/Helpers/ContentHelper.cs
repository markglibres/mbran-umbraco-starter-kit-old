using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace MBran.Core
{
    public class ContentHelper : IContentHelper
    {
        private readonly UmbracoHelper _umbracoHelper;
        public ContentHelper(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }
        public IEnumerable<T> GetDescendants<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            var children = startNode.Descendants<T>()
                .Where(c => c.Id > 0);

            return children;
        }

        public IEnumerable<T> GetDescendantsOrSelf<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            var children = startNode.DescendantsOrSelf<T>().ToList();
            return children;
        }

        public T GetDescendant<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return default(T);
            }

            var descendant = startNode.Descendant<T>();

            return descendant;
        }

        public T GetDescendantOrSelf<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return default(T);
            }

            var descendant = startNode.DescendantOrSelf<T>();
            return descendant;
        }

        public IEnumerable<T> GetAncestors<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            var children = startNode.Ancestors<T>()
                .Where(c => c.Id > 0);

            return children;
        }

        public IEnumerable<T> GetAncestorsOrSelf<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            var children = startNode.AncestorsOrSelf<T>().ToList();
            return children;
        }

        public T GetAncestor<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return default(T);
            }

            var ancestor = startNode.Ancestor<T>();

            return ancestor;
        }

        public T GetAncestorOrSelf<T>(int startId) where T : class, IPublishedContent
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return default(T);
            }

            var ancestor = startNode.Ancestor<T>();
            return ancestor;
        }
       
        public T GetContent<T>(int nodeId) where T : PublishedContentModel
        {
            T node = _umbracoHelper.TypedContent(nodeId)?.As<T>();
            return node;
        }

        public IPublishedContent GetRoot()
        {
            IPublishedContent root = _umbracoHelper.TypedContentAtRoot().First();
            return root;
        }
    }
}
