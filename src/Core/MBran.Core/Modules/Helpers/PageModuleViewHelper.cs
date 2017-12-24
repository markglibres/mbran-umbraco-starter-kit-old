using System.IO;

namespace MBran.Core.Modules.Helpers
{
    public static class PageModuleViewHelper
    {
        public const string ViewPath = "~/Views/Modules/";
        private const string ViewExtension = ".cshtml";
        public static string GetFullPath(string folder, string viewName)
        {
            return Path.Combine(ViewPath,folder,viewName).Replace('\\', '/') + ViewExtension;
        }
    }
}
