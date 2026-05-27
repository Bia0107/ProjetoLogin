using Newtonsoft.Json;
using ProjetoLogin.Models;

namespace ProjetoLogin.Libraries.Login
{
    public class LoginColaborador
    {
        private string key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaboradr)
        {
            //Serializar
            string colaboradorJSONString = JsonConvert.SerializeObject(colaboradr);

            _sessao.Cadastar(key, colaboradorJSONString);
        }

        //Reverter Json
        public Colaborador GetColaborador()
        {
            //Deserializar
            if (_sessao.Existe(key))
            {
                string colaboradorJSONString = _sessao.Consultar(key);
                return JsonConvert.DeserializeObject<Colaborador>(colaboradorJSONString);
            }
            else
            {
                return null;
            }
        }

        //Remove a sessão e desloga o Colaborador
        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
