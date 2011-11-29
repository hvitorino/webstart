using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Patterns.Core;

namespace Patterns.Configuracao.Windsor.Installers
{
    public class RepositoriosInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Repositorios().Configure(SingletonLifeCycle()));
        }

        private ConfigureDelegate SingletonLifeCycle()
        {
            return c => c.LifeStyle.Singleton;
        }

        private BasedOnDescriptor Repositorios()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn(typeof(IRepositorio<>))
                .WithService
                .AllInterfaces();
        }
    }
}