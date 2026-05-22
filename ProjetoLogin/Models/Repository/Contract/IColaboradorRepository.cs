using X.PagedList;

namespace ProjetoLogin.Models.Repository.Contract
{
    public interface IColaboradorRepository
    {
        // login cliente
        Colaborador Login(string Email, string Senha);

        //CRUD
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void AtualizarSenha(Colaborador colaborador);
        void Excluir(int Id);

        Cliente ObterColaborador(int Id);
        List<Colaborador> ObterTodosColaboradorPorEmail(string email);
        IEnumerable<Colaborador> ObterTodosColaboradores();
        IPagedList<Colaborador> ObterTodosColaboradores(int? pagina, string pesquisa);
    }
}
