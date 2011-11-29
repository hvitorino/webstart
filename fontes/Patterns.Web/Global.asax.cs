using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Patterns.Configuracao.Mvc;
using Patterns.Configuracao.Windsor.Installers;
using Patterns.Persistencia.Configuracao.NHibernate;

namespace Patterns
{
    public class MvcApplication : HttpApplication
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            Container.Install(
                new ControllersInstaller(),
                new RepositoriosInstaller());

            ConnectionString.Value.Set(ConfigurationManager.AppSettings["nhibernate.conexao"]);

            AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(Container.Kernel));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}