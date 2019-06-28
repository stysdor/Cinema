using AutoMapper;
using Cinema.Api2.Ioc;
using Cinema.Infrastructure.Mappers;
using Cinema.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace Cinema.Api2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "aplication/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //dependency Injection
            var container = new UnityContainer();
            container.RegisterType<IMovieService, MovieService>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IMapper>(AutoMapperConfig.Initialize());
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
