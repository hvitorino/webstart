using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using NHibernate;
using NHibernate.Context;
using NUnit.Framework;
using Patterns.Core;
using Patterns.Persistencia.Configuracao.NHibernate;

namespace Patterns.Persistencia.Testes
{
    [TestFixture]
    public class DadoUmRepositorioDePessoas
    {
        private ISession nhSession;

        [SetUp]
        public void Setup()
        {
            ConnectionString.Value.Set(ConfigurationManager.AppSettings["nhibernate.conexao"]);

            nhSession = SessionProvider.CurrentSession;
            nhSession.BeginTransaction();

            CurrentSessionContext.Bind(nhSession);
        }

        [TearDown]
        public void TearDown()
        {
            CurrentSessionContext.Unbind(SessionProvider.Factory);

            nhSession.Transaction.Rollback();
            nhSession.Close();
        }

        [Test]
        public void PossoIncluirUmaNovaPessoa()
        {
            var todasAsPessoas = new TodasAsPessoas();

            todasAsPessoas.Inclui(new Pessoa
            {
                Nome = "Francisco",
                Endereco = new Endereco
                {
                    Bairro = "José Walter",
                    Complemento = "AP 101",
                    Logradouro = "Rua das avenidas",
                    Numero = 101
                },
                Contatos = new List<Contato>
                {
                    new Contato
                    {
                        Referencia = "francisco@gmail.com",
                        Tipo = Contato.TipoContato.Email
                    }
                }
            });

            Assert.That(todasAsPessoas.Lista().Any(pessoa => pessoa.Nome == "Francisco"), Is.True);
        }
    }
}
