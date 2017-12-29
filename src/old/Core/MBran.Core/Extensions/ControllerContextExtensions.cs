using System.IO;
using System.Web.Mvc;

namespace MBran.Core
{
    public static class ControllerContextExtensions
    {
        public static string RenderViewToString(this ControllerContext context,
            string viewPath,
            object model = null,
            bool partial = false)
        {
            var viewEngine = context.GetViewEngine(viewPath, partial);
            if (viewEngine == null)
            {
                throw new FileNotFoundException("View cannot be found", viewPath);
            }

            context.SetViewEngineModel(model);
            var view = viewEngine.View;

            string result;
            using (var streamWriter = new StringWriter())
            {
                var viewContext = new ViewContext(context, view,
                    context.Controller.ViewData,
                    context.Controller.TempData,
                    streamWriter);

                view.Render(viewContext, streamWriter);
                result = streamWriter.ToString();
            }

            return result;

        }

        public static ViewEngineResult GetViewEngine(this ControllerContext context, 
            string viewPath, bool partial = false)
        {
            return partial ? ViewEngines.Engines.FindPartialView(context, viewPath) : ViewEngines.Engines.FindView(context, viewPath, null);
        }

        public static ControllerContext SetViewEngineModel(this ControllerContext context, object model)
        {
            context.Controller.ViewData.Model = model;
            return context;
        }

        public static string ExecutingViewName(this ControllerContext context)
        {
            return context.RouteData.Values["action"].ToString();
        }

        public static string ExecutingControllerName(this ControllerContext context)
        {
            return context.RouteData.Values["controller"].ToString();
        }


    }
}
