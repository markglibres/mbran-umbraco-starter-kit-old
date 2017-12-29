using System.Configuration;

namespace MBran.Core
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString
        {
            get
            {
                var conn = ConfigurationManager.AppSettings[UmbracoConstants.Config.DatabaseKey];
                return conn;
            }
        }
    }
}
