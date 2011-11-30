using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Patterns.Core;
using Patterns.Persistencia.Configuracao.NHibernate;

namespace Patterns.Web.Configuracao.Windsor.Installers
{
    public class RepositoriosInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Repositorios().Configure(SingletonLifeCycle()));
        }

        private ConfigureDelegate SingletonLifeCycle()
        {
            return configure => configure.LifeStyle.Singleton;
        }

        private BasedOnDescriptor Repositorios()
        {
            return AllTypes.FromAssemblyContaining<FluentConfigurator>()
                .BasedOn(typeof(IRepositorio<>))
                .WithService
                .AllInterfaces();
        }
    }
}