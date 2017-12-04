using System.Configuration;

namespace MBran.Umbraco.Core
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString
        {
            get
            {
                string conn = ConfigurationManager.AppSettings[UmbracoConstants.Config.DATABASE_KEY];
                return conn;
            }
        }
    }
}
