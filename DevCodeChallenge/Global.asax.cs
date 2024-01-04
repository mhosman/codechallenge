using DevCodeChallenge.Repositories;
using DevCodeChallenge.Config;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;
using DevCodeChallenge.Services;

namespace DevCodeChallenge
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Create Unity Container
            var container = new UnityContainer();

            // Register dependencies
            container.RegisterType<PurchaseService>();
            container.RegisterType<PurchaseRepository>();

            // Register NHibernate.ISessionFactory
            container.RegisterInstance(NHibernateConfig.CreateSessionFactory());

            // Set the MVC Dependency Resolver to use Unity
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
