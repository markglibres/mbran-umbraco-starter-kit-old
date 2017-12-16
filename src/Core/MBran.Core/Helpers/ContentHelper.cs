using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Our.Umbraco.Ditto;
using System;

namespace MBran.Core
{
    public class ContentHelper : IContentHelper
    {
        private readonly UmbracoHelper _umbracoHelper;
        public ContentHelper(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }
        
        private T Convert<T>(IPublishedContent content)
            where T: class
        {
            Type type = typeof(T);
            if(type.IsInterface)
            {
                //use convention to instantiate class of type excluding the "I" on the start of interface name
                string typeName = type.Name;
                if (typeName.StartsWith("I"))
                {
                    string modelName = typeName.Substring(1);
                    type = Type.GetType(type.AssemblyQualifiedName.Replace(type.Name, modelName));
                }
            }   

            object model = content.As(type);
            if(model == null)
            {
                return null;
            }

            return (T)model;
        }

        private IEnumerable<T> Filter<T>(IEnumerable<IPublishedContent> nodes)
            where T: class
        {
            if(nodes == null || !nodes.Any())
            {
                yield break;
            }

            foreach(IPublishedContent node in nodes)
            {
                T item = Convert<T>(node);
                if(item != null)
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<T> GetDescendants<T>(int startId) 
            where T : class
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            return Filter<T>(startNode.Descendants());
        }

        public IEnumerable<T> GetDescendantsOrSelf<T>(int startId) where T : class
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }
            
            return Filter<T>(startNode.DescendantsOrSelf());
        }

        public T GetDescendant<T>(int startId) where T : class
        {
            return GetDescendants<T>(startId).FirstOrDefault();
        }

        public T GetDescendantOrSelf<T>(int startId) where T : class
        {
            return GetDescendantsOrSelf<T>(startId).FirstOrDefault();
        }

        public IEnumerable<T> GetAncestors<T>(int startId) where T : class
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            return Filter<T>(startNode.Ancestors());
            
        }

        public IEnumerable<T> GetAncestorsOrSelf<T>(int startId) where T : class
        {
            IPublishedContent startNode = _umbracoHelper.TypedContent(startId);
            if (startNode == null || startNode.Id <= 0)
            {
                return new List<T>();
            }

            return Filter<T>(startNode.AncestorsOrSelf());
            
        }

        public T GetAncestor<T>(int startId) where T : class
        {
            return GetAncestors<T>(startId).FirstOrDefault();
        }

        public T GetAncestorOrSelf<T>(int startId) where T : class
        {
            return GetAncestorsOrSelf<T>(startId).FirstOrDefault();
        }
       
        public T GetContent<T>(int nodeId) where T : class
        {
            IPublishedContent node = _umbracoHelper.TypedContent(nodeId);
            return Convert<T>(node);
        }

        public IPublishedContent GetRoot()
        {
            IPublishedContent root = _umbracoHelper.TypedContentAtRoot().First();
            return root;
        }

        public T GetRoot<T>() where T : class
        {
            IPublishedContent root = GetRoot();
            return Convert<T>(root);
        }
    }
}
