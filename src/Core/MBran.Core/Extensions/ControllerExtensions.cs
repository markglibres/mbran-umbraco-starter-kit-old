using System.Web.Mvc;

namespace MBran.Core.Extensions
{
    public static class ControllerExtensions
    {
        public static bool ViewExists(this Controller controller, string viewName)
        {
            return ViewEngines.Engines.ViewExists(controller.ControllerContext, viewName);
        }

        public static bool PartialViewExists(this Controller controller, string viewName)
        {
            return ViewEngines.Engines.ViewExists(controller.ControllerContext, viewName, true);
        }
    }
}
