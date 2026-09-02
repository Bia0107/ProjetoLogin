using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using ProjetoNilson4.Models;
using ProjetoNilson4.Models.Constant;
using ProjetoNilson4.Repository;
using ProjetoNilson4.Repository.Contract;

namespace ProjetoNilson4.Controllers
{
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                colaborador.Tipo = ColaboradorTipoConstant.Comum;
                _colaboradorRepository.Cadastrar(colaborador);

                TempData["MSG_S"] = "Registro salvo com sucesso!!!";

                return RedirectToAction("LoginColaborador", "Home");
            }
            else
            {
                return View(colaborador);
            }
        }
    }
}
