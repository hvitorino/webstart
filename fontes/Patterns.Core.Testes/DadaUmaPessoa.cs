using System.Linq;
using NUnit.Framework;

namespace Patterns.Core.Testes
{
    [TestFixture]
    public class DadaUmaPessoa
    {
        [Test]
        public void PossoAdicionarUmTelefoneParaContato()
        {
            const string telefone = "87822118";
            var pessoa = new Pessoa { Nome = "Francisco" };

            pessoa.NovoTelefone(telefone);

            Assert.That(pessoa.Contatos.Any(contato => contato.Referencia.Equals(telefone)), Is.True);
        }

        [Test]
        public void PossoAdicionarUmEmailParaContato()
        {
            const string email = "francisco@gmail.com";
            var pessoa = new Pessoa { Nome = "Francisco" };

            pessoa.NovoEmail(email);

            Assert.That(pessoa.Contatos.Any(contato => contato.Referencia.Equals(email)), Is.True);
        }
    }
}
