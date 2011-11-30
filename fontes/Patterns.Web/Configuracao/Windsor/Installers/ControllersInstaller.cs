using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Patterns.Web.Configuracao.Windsor.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Controllers().Configure(SingletonLifeCycle()));
        }

        private static ConfigureDelegate SingletonLifeCycle()
        {
            return configure => configure.LifeStyle.Singleton;
        }

        private static BasedOnDescriptor Controllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<Controller>();
        }
    }
}