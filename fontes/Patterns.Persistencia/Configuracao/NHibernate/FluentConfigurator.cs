using System.Configuration;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Patterns.Core;
using Patterns.Persistencia.Configuracao.Convencoes;
using Configuration = NHibernate.Cfg.Configuration;

namespace Patterns.Persistencia.Configuracao.NHibernate
{
    public class FluentConfigurator
    {
        public ISessionFactory CreateSessionFactory()
        {
            var conexao = ConnectionString.Value.Current;
            var context = ConfigurationManager.AppSettings["nhibernate.context"];

            var modelConventions = AutoMap
                .AssemblyOf<Pessoa>(PatternsConventions.Para.EntidadesEComponentes)
                .Conventions.Add(PatternsConventions.Para.PropriedadesERelacionamentos)
                .UseOverridesFromAssemblyOf<FluentConfigurator>();

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(conexao))
                .CurrentSessionContext(context)
                .Mappings(m => m.AutoMappings.Add(modelConventions))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config)
                .Execute(false, true);
        }
    }
}