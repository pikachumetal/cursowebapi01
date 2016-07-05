using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication2.Handlers;

namespace WebApplication2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiV1",
            //    routeTemplate: "api/v1/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.MessageHandlers.Add(new MethodOverrideMessageHandler());
        }
    }
}
