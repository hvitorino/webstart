using System;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using Patterns.Core;

namespace Patterns.Persistencia.Configuracao.Convencoes
{
    public class EntidadesEComponentesConventions : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof(Entidade));
        }

        public override bool IsComponent(Type type)
        {
            return type.GetInterfaces().Contains(typeof(IComponente));
        }

        public override string GetComponentColumnPrefix(Member member)
        {
            return string.Empty;
        }
    }
}