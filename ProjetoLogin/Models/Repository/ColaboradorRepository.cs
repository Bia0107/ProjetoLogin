using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ProjetoLogin.Models;
using ProjetoLogin.Models.Constant;
using ProjetoLogin.Models.Repository.Contract;
using X.PagedList;

namespace ProjetoLogin.Models.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly string _conexaoMySQL;
        IConfiguration _config;
        public ColaboradorRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
            _config = conf;
        }

        public void Atualizar(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void AtualizarSenha(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            string Comum = ColaboradorTipoConstant.Comum;
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbColaborador(Nome, CPF, Telefone, Email, Senha, Tipo)" +
                    "values (@Nome, @CPF, @Telefone, @Email, @Senha, @Tipo)", conexao);

                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value =colaborador.Nome;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = colaborador.CPF;
                cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = colaborador.Telefone;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = colaborador.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = colaborador.Senha;
                cmd.Parameters.Add("@Comum", MySqlDbType.VarChar).Value = Comum;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from tbColaborador where Id=@Id", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Colaborador Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbColaborador where Email = @Email and Senha = @Senha", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Colaborador colaborador = new Colaborador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    colaborador.Id = (Int32)(dr["Id"]);
                    colaborador.Nome = (String)(dr["Nome"]);
                    colaborador.Email = (String)(dr["Email"]);
                    colaborador.Senha = (String)(dr["Senha"]);
                    colaborador.Tipo = (String)(dr["Tipo"]);
                }
                return colaborador;
            }
        }

        public Cliente ObterColaborador(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            throw new NotImplementedException();
        }

        public IPagedList<Cliente> ObterTodosColaboradores(int? pagina, string pesquisa)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterTodosColaboradorPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        IPagedList<Colaborador> IColaboradorRepository.ObterTodosColaboradores(int? pagina, string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}
