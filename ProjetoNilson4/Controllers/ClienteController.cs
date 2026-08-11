using Microsoft.AspNetCore.Mvc;
using ProjetoNilson4.Models;
using ProjetoNilson4.Repository.Contract;

namespace ProjetoNilson4.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if(cliente.Senha == cliente.ConfirmacaoSenha)
                {
                    _clienteRepository.Cadastrar(cliente);
                    return RedirectToAction("LoginCliente", "Home");
                }
                else
                {
                    return View(cliente);
                }
            }
            else
            {
                return View(cliente);
            }
        }
    }
}
