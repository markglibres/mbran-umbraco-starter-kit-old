using System.Configuration;

namespace MBran.Core
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
