/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Demo.Api.Common;
using Swashbuckle.Application;

namespace Demo.Api
{
    public static class WebApiConfig
    { 
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스
            
            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                // routeTemplate: "api/{controller}/{id}",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            // Set Swagger as default start page
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Demo.Api.Common.Filters;
using Newtonsoft.Json;
using Swashbuckle.Application;

namespace Demo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 구성 및 서비스
            config.Routes.IgnoreRoute("check_server_ip", "ServerAlive/check_server_ip.aspx");

            // Web API 경로
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}",
                defaults: new { id = RouteParameter.Optional }
            );

            // // Set Swagger as default start page
            // config.Routes.MapHttpRoute(
            //     name: "swagger_root", 
            //     routeTemplate: "",
            //     defaults: null,
            //     constraints: null,
            //     handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            // Response body NULL Value Ignore
            var jsonformatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    NullValueHandling = NullValueHandling.Ignore
                }
            };

            config.Formatters.RemoveAt(0);
            config.Formatters.Insert(0, jsonformatter);

        }
    }
}