using System.Text.RegularExpressions;

namespace MBran.Core.Components
{
    public static class ComponentConstants
    {
        public const string ViewPathKey = "viewPath";
        public const string ComponentKey = "component";
        public const string ContentKey = "content";
        public const string ModelKey = "model";

        public static string ControllerName = Regex.Replace(nameof(ComponentsController), "Controller$", string.Empty);
        public static string RenderModelAction = nameof(IComponentController.RenderModel);
        public static string RenderAction = nameof(IComponentController.Render);
        public static string RenderContentAction = nameof(IComponentController.RenderContent);

        public static class Folders
        {
            public static class Views
            {
                public const string Default = "Defaults";
            }
        }

    }
}
