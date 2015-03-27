using Autofac;
using Autofac.Integration.WebApi;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Nop.Web.Infrastructure
{
    public class RouteApiProvider : IRouteProvider
    {
        public void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            //var config = GlobalConfiguration.Configuration;
            //WebApiConfig.Register(config);
            var config = GlobalConfiguration.Configuration;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<Nop.Web.Controllers.Api.CategoryController>().InstancePerRequest();
            builder.Update(EngineContext.Current.ContainerManager.Container);
            //var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(EngineContext.Current.ContainerManager.Container);


            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        public int Priority
        {
            get { return 0; }
        }
    }
}