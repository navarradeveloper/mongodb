using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace DI
{
    public class UnityControllerFactory : DefaultControllerFactory
    {

        private readonly IUnityContainer _sl;
        public UnityControllerFactory(IUnityContainer sl)
        {
            _sl = sl;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                IController controller = (IController)_sl.Resolve(controllerType);
                return controller;
            }
            else
            {
                RouteData rd = new RouteData();
                rd.Values["culture"] = "es";
                rd.Values["controller"] = "error";
                rd.Values["action"] = "notfound";
                requestContext.RouteData = rd;
                return CreateController(requestContext, "error");
            }
        }

    }
}
