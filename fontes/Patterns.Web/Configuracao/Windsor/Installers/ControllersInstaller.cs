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
            container.Register(Controllers().Configure(TransientLifeCycle()));
        }

        private static ConfigureDelegate TransientLifeCycle()
        {
            return configure => configure.LifeStyle.Transient;
        }

        private static BasedOnDescriptor Controllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<Controller>();
        }
    }
}