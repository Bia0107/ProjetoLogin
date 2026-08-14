using Microsoft.AspNetCore.Mvc;
using ProjetoNilson4.Libraries.Filtro;
using ProjetoNilson4.Libraries.Login;
using ProjetoNilson4.Models;
using ProjetoNilson4.Repository.Contract;
using System.Diagnostics;

namespace ProjetoNilson4.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _clienteRepository;
        private IColaboradorRepository _colaboradorRepository;
        private LoginColaborador _loginColaborador;
        private LoginCliente _loginCliente;
        public HomeController(IClienteRepository clienteRepository, IColaboradorRepository colaboradorRepository, LoginCliente loginCliente, LoginColaborador loginColaborador)
        {
            _clienteRepository = clienteRepository;
            _colaboradorRepository = colaboradorRepository;
            _loginCliente = loginCliente;
            _loginColaborador = loginColaborador;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginCliente()
        {
            return View();
        }
        [HttpPost]

        public IActionResult LoginCliente([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _clienteRepository.Login(cliente.Email, cliente.Senha);

            if(clienteDB.Email != null && clienteDB.Senha != null)
            {
                _loginCliente.Login(clienteDB);
                return new RedirectResult(Url.Action(nameof(PainelCliente)));
            }
            else
            {
                // erro na sessão
                ViewData["MSG_E"] = "Usuário não localizado, por favor verifique e-mail e senha digitado";
                return View();
            }


        }

        [ClienteAutorizacao]
        public IActionResult PainelCliente()
        {
            ViewBag.Nome = _loginCliente.GetCliente().Nome;
            ViewBag.CPF = _loginCliente.GetCliente().CPF;
            ViewBag.Email = _loginCliente.GetCliente().Email;
            //return new ContentResult() { Content = "Este é o Painel do Cliente!};
            return View();
        }

        public IActionResult PainelColaborador()
        {
            ViewBag.Nome = _loginColaborador.GetColaborador().Nome;
            ViewBag.Tipo = _loginColaborador.GetColaborador().Tipo;
            ViewBag.Email = _loginColaborador.GetColaborador().Email;

            return View();
        }

        [ClienteAutorizacao]
        public IActionResult LogoutCliente()
        {
            _loginCliente.Logout();
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
