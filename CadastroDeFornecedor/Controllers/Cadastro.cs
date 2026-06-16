using Estagio.Models;
using Estagio.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Estagio.Controllers
{
    public class Cadastro : Controller
    {
        private readonly FornecedoresRepositorio _fornecedoresRepositorio;
        public Cadastro(FornecedoresRepositorio fornecedoresRepositorio)
        {
            _fornecedoresRepositorio = fornecedoresRepositorio;
        }
        public IActionResult Index()
        {
           List <FornecedorModel>fornecedores= _fornecedoresRepositorio.BuscarTodos();
                            
            return View(fornecedores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           FornecedorModel fornecedor= _fornecedoresRepositorio.ListarPorId(id);
            return View(fornecedor);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedoresRepositorio.ListarPorId(id);
            return View(fornecedor);
        }
        public IActionResult Apagar(int id)
        {
            _fornecedoresRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            _fornecedoresRepositorio.Adiconar(fornecedor);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Editar(FornecedorModel fornecedor)
        {
            _fornecedoresRepositorio.Atualizar(fornecedor);
            return RedirectToAction("Index");

        }


    }
}
