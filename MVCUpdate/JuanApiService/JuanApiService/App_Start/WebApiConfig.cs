using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JuanApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //Esta ruta e la que activa o desactiva una suscripcion
            config.Routes.MapHttpRoute(
                name: "SuscripctionApi",
                routeTemplate: "api/{controller}/{action}/{id}/{status}",
              
                defaults: new
                {
                    id = RouteParameter.Optional,
                    status = RouteParameter.Optional
                }
            );
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
