using System.IO;

namespace MBran.Core.Components
{
    public static class ComponentViewHelper
    {
        public const string VIEW_PATH = "~/Views/Components/";
        private const string VIEW_EXTENSION = ".cshtml";
        public static string GetFullPath(string folder, string viewName)
        {
            return Path.Combine(VIEW_PATH,folder,viewName).Replace('\\', '/') + VIEW_EXTENSION;
        }
    }
}
