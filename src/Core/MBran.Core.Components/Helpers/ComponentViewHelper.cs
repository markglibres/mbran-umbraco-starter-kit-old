using System.IO;

namespace MBran.Core.Components
{
    public static class ComponentViewHelper
    {
        public const string ViewPath = "~/Views/Components/";
        private const string ViewExtension = ".cshtml";
        public static string GetFullPath(string folder, string viewName)
        {
            return Path.Combine(ViewPath,folder,viewName).Replace('\\', '/') + ViewExtension;
        }
    }
}
