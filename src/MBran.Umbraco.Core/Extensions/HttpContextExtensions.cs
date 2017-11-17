using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBran.Umbraco.Core
{
    public static class HttpRequestExtensions
    {
        public static IEnumerable<T> GetEnumerableParams<T>(this HttpContext context, string queryString)
            where T : struct
        {
            var filters = context.Request.Params[queryString];
            var curFilters = new List<T>();

            if (!string.IsNullOrEmpty(filters))
            {
                curFilters.AddRange(filters
                    .Split(',')
                    .Where(p => !string.IsNullOrEmpty(p))
                    .Select(p => (T)Convert.ChangeType(p, typeof(T)))
                );
            }
            return curFilters;
        }

        public static string GetParam(this HttpContext context, string queryString)
        {
            var paramVal = context.Request.Params[queryString];
            return paramVal;
        }

        public static T GetParam<T>(this HttpContext context, string queryString)
            where T : struct
        {
            var paramVal = context.Request.Params[queryString];
            try
            {
                return (T)Convert.ChangeType(paramVal, typeof(T));
            }
            catch
            {
                return default(T);
            }

        }

        public static string GetCurrentFullDomain(this HttpContext context)
        {
            Uri uri = context.Request.Url;
            return string.Format("{0}://{1}", uri.Scheme, uri.Authority);
        }

        public static string GetCurrentDomain(this HttpContext context)
        {
            Uri uri = context.Request.Url;
            return uri.Authority;
        }

    }
}
