using Newtonsoft.Json;
using ProjetoLogin.Models;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace ProjetoLogin.Libraries.Login
{
    public class LoginCliente
    {
        private string key = "Login.Cliente";
        private Sessao.Sessao _sessao;

        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Cliente cliente)
        {
            //Serializar
            string clienteJSONString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastar(key, clienteJSONString);
        }

        //Reverter Json para bjeto cliente 
        public Cliente GetCliente() 
        {
            //Deserializar
            if (_sessao.Existe(key))
            {
                string clienteJSONString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONString);
            }
            else
            {
                return null;
            }
        }

        //Remove a sessão e desloga o Cliente
        public void Logout()
        {
            _sessao.RemoverTodos();
        }

    }
}
