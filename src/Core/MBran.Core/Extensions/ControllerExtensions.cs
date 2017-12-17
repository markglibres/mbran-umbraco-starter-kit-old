using System;
using System.IO;
using System.Web.Mvc;

namespace MBran.Core
{
    public static class ControllerExtensions
    {
        public static string RenderViewToString(this Controller controller, 
            string viewPath,
            object model = null,
            bool partial = false)
        {
            return controller.ControllerContext.RenderViewToString(viewPath, model, partial);
        }

        public static string ExecutingViewName(this Controller controller)
        {
            return controller.ControllerContext.ExecutingViewName();
        }

        public static string ExecutingControllerName(this Controller controller)
        {
            return controller.ControllerContext.ExecutingControllerName();
        }

        public static ViewEngineResult GetViewEngine(this Controller controller,
            string viewPath, bool partial = false)
        {
            return controller.ControllerContext.GetViewEngine(viewPath, partial);
        }

    }
}
