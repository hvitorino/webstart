using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;

namespace Patterns.Persistencia.Configuracao.Convencoes
{
    public class PatternsConventions
    {
        private static readonly PatternsConventions Singleton;

        static PatternsConventions()
        {
            Singleton = new PatternsConventions();
        }

        public static PatternsConventions Para
        {
            get { return Singleton; }
        }

        public DefaultAutomappingConfiguration EntidadesEComponentes
        {
            get { return new EntidadesEComponentesConventions(); }
        }

        public IConvention[] PropriedadesERelacionamentos
        {
            get
            {
                var convencoes = new PropriedadesERelacionamentosConventions();

                return new []
                {
                    convencoes.IdComoPrimaryKey,
                    convencoes.IdSequencial,
                    convencoes.RelacionamentosLazy,
                    convencoes.OperacoesEmCascataParaColecoes,
                    convencoes.NomesDosCamposNasTabelasIguaisAsPropriedades,
                    convencoes.SemConversoesParaEnumeracoes
                };
            }
        }
    }
}
