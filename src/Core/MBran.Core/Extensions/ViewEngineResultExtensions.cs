using System.Web.Mvc;

namespace MBran.Core
{
    public static class ViewEngineResultExtensions
    {
        public static PartialViewResult GetPartialView(this ViewEngineResult engineView, 
            ControllerContext context, 
            object model = null)
        {
            context.SetViewEngineModel(model);

            return new PartialViewResult
            {
                ViewName = context.ExecutingViewName(),
                ViewData = context.Controller.ViewData,
                TempData = context.Controller.TempData
            };
        }
    }
}
