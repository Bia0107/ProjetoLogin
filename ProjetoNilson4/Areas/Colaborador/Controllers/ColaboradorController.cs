using Microsoft.AspNetCore.Mvc;
using ColaboradorClass = ProjetoNilson4.Models.Colaborador;
using ProjetoNilson4.Repository.Contract;

namespace ProjetoNilson4.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ColaboradorClass colaborador)
        {
            if (ModelState.IsValid)
            {
                _colaboradorRepository.Cadastrar(colaborador);
                return RedirectToAction("LoginColaborador", "Home");
            }
            else
            {
                return View(colaborador);
            }
        }
    }
    
}

