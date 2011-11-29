using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Patterns.Controllers;
using Patterns.Core;
using Restfulie.Server.Results;

namespace Patterns.Testes.Controllers
{
    [TestFixture]
    public class DadoUmPessoaController
    {
        [Test]
        public void Index()
        {
            var mockCadastroPessoa = new Mock<IRepositorio<Pessoa>>();

            mockCadastroPessoa
                .Setup(classe => classe.Lista())
                .Returns(new List<Pessoa>());

            var repositorio = mockCadastroPessoa.Object;
            var controller = new PessoaController(repositorio);
            var result = controller.Index();

            Assert.IsInstanceOf<RestfulieResult>(result);
        }
    }
}
