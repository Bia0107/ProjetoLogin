using ProjetoNilson4.Models;
using X.PagedList;

namespace ProjetoNilson4.Repository.Contract
{
    public interface IColaboradorRepository
    {
        Colaborador Login(string Email, string Senha);

        void Cadastrar(Colaborador colaborador);

        void Atualizar(Colaborador colaborador);

        void AtualizarSenha(Colaborador colaborador);

        void Excluir(int Id);

        Colaborador ObterColaborador(int Id);

        List<Colaborador> ObterColaboradorPorEmail(string email);

        IEnumerable<Colaborador> ObterTodosColaboradores();

        IPagedList<Colaborador> ObterTodosColaboradores(int? pagina, string pesquisa);
    }
}
