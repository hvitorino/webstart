using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Patterns.Controllers;
using Patterns.Core;
using Restfulie.Server.Results;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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
            
            Assert.IsInstanceOfType(result, typeof(RestfulieResult));
        }
    }
}
