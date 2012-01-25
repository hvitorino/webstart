using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Patterns.Persistencia.Configuracao.NHibernate;
using Patterns.Web.Configuracao.Mvc;
using Patterns.Web.Configuracao.Windsor.Installers;

namespace Patterns.Web
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
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Pessoa", action = "Lista", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            Container.Install(
                new ControllersInstaller(),
                new RepositoriosInstaller());

            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(Container.Kernel));

            ConnectionString.Value.Set(ConfigurationManager.AppSettings["nhibernate.conexao"]);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}