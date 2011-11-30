using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Patterns.Core;
using Patterns.Web.Controllers;
using Restfulie.Server.Results;

namespace Patterns.Testes.Controllers
{
    [TestFixture]
    public class DadoUmPessoaController
    {
        [Test]
        public void PossoListarPessoas()
        {
            var mockCadastroPessoa = new Mock<IRepositorio<Pessoa>>();

            mockCadastroPessoa
                .Setup(classe => classe.Lista())
                .Returns(new List<Pessoa>());

            var repositorio = mockCadastroPessoa.Object;
            var controller = new PessoaController(repositorio);
            var result = controller.Lista();

            Assert.IsInstanceOf<OK>(result);
        }
    }
}
