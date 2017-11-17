namespace MBran.Umbraco.Components
{
    public static class ComponentViewHelper
    {
        public const string ViewPath = "~/Views/Components/";
        private const string ViewExtension = ".cshtml";
        public static string GetFullPath(string viewName)
        {
            return ViewPath + viewName + ViewExtension;
        }
    }
}
