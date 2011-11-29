using System.Web.Mvc;
using Patterns.Core;
using Restfulie.Server;
using Restfulie.Server.Results;

namespace Patterns.Controllers
{
    [ActAsRestfulie]
    public class PessoaController : Controller
    {
        private readonly IRepositorio<Pessoa> todasAsPessoas;

        public PessoaController()
        {
            
        }

        public PessoaController(IRepositorio<Pessoa> repositorioDePessoas)
        {
            todasAsPessoas = repositorioDePessoas;
        }

        public ActionResult Index()
        {
            return new OK(todasAsPessoas.Lista());
        }

    }
}
