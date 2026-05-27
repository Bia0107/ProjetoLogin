namespace ProjetoLogin.Libraries.Sessao
{
    public class Sessao
    {
        IHttpContextAccessor _context;
        //Interface com uma biblioteca para manipular a ssesção
        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }


       //CRUD - Cadastrar, Atualizar, Remover, Consultar
       public void Cadastar(string Key,  string Valor)
        {
            _context.HttpContext.Session.SetString(Key, Valor); 
        }

        public string Consultar(string Key)
        {
            return _context.HttpContext.Session.GetString(Key);
        }

        public bool Existe(string Key)
        {
            if (_context.HttpContext.Session.GetString(Key) == null)
            {
                return false;
            }
            return true;
        }

        public void Remover(string Key)
        {
            _context.HttpContext.Session.Remove(Key);
        }

        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }

        public void Atualizar(string Key, string valor)
        {
            if (Existe(Key))
            {
                _context.HttpContext.Session.Remove(Key);
            }
            _context.HttpContext.Session.SetString(Key, valor);
        }
    }
}
