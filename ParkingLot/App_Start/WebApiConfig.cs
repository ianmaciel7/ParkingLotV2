using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ParkingLot
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

          
            config.EnableCors(new EnableCorsAttribute("http://localhost:3000", "*", "*"));
        }
    }
}
