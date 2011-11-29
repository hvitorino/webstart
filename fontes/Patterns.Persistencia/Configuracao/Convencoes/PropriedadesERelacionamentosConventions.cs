using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;

namespace Patterns.Persistencia.Configuracao.Convencoes
{
    public class PropriedadesERelacionamentosConventions
    {
        public IConvention IdComoPrimaryKey
        {
            get { return PrimaryKey.Name.Is(pk => "Id"); }
        }

        public IConvention IdSequencial
        {
            get { return ConventionBuilder.Id.Always(id => id.GeneratedBy.Identity()); }
        }

        public IConvention RelacionamentosLazy
        {
            get { return DefaultLazy.Always(); }
        }

        public IConvention OperacoesEmCascataParaColecoes
        {
            get { return ConventionBuilder.HasMany.Always(many => many.Cascade.All()); }
        }

        public IConvention NomesDosCamposNasTabelasIguaisAsPropriedades
        {
            get { return ConventionBuilder.Property.Always(prop => prop.Column(prop.Property.Name)); }
        }

        public IConvention SemConversoesParaEnumeracoes
        {
            get { return new SemConversoesParaEnumeracoesConvention(); }
        }
    }
}