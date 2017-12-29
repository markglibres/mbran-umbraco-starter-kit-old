using MBran.Components.Constants;
using MBran.Core.Extensions;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using System;
using MBran.Core.Helpers;

namespace MBran.Components.Controllers
{
    public class ComponentsController : SurfaceController, IComponentsController
    {
        public IPublishedContent PublishedContent => RouteData
                    .Values[RouteDataConstants.ModelKey] as IPublishedContent ?? CurrentPage;

        public string ComponentName => RouteData
                    .Values[RouteDataConstants.ComponentTypeKey] as string;

        public string ViewPath => RouteData
                    .Values[RouteDataConstants.ViewPathKey] as string 
            ?? ComponentName;
        
        public virtual PartialViewResult Render()
        {
            return PartialView(ViewPath, PrepareModel());
        }
        
        public virtual object PrepareModel()
        {
            return PublishedContent.As(ModelsHelper.Instance.StronglyTyped(ComponentName));
        }

    }
}
