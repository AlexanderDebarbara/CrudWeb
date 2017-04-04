using MatriculaWeb.Dominio.Abstratas;
using MatriculaWeb.Modelo.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Modelo.DAO
{
    public class AlunoDAO : AbstractDAO<AlunoVO>
    {
        public AlunoDAO(SqlCommand sqlCommand) : base(sqlCommand)
        {
        }

        public override int Alterar(AlunoVO obj)
        {
            StringBuilder sb = null;
            try
            {
                sb = new StringBuilder();
                sb.AppendLine(@"UPDATE dbo.Aluno
                                SET Nome = @Nome
                                  , Cpf = @Cpf
                                  , Email = @Email
                                  , Senha = @Senha
                                  , Rg = @Rg          
                                  , Uf = @Uf         
                                  , OrgaoEmissor = @OrgaoEmissor
                                  , Telefone    
                                WHERE IdAluno = @IdAluno");

                //GetSqlCommand().Connection.ChangeDatabase(BancoComum);

                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = sb.ToString();
                GetSqlCommand().Parameters.Clear();
                GetSqlCommand().Parameters.Add("IdAluno", SqlDbType.Int).Value = obj.IdAluno;
                GetSqlCommand().Parameters.Add("Nome", SqlDbType.VarChar).Value = obj.Nome;
                GetSqlCommand().Parameters.Add("CPF", SqlDbType.VarChar).Value = obj.Cpf;
                GetSqlCommand().Parameters.Add("Email", SqlDbType.VarChar).Value = obj.Email;
                GetSqlCommand().Parameters.Add("Senha", SqlDbType.VarChar).Value = obj.Senha;
                GetSqlCommand().Parameters.Add("Rg", SqlDbType.VarChar).Value = obj.Rg;
                GetSqlCommand().Parameters.Add("Uf", SqlDbType.VarChar).Value = obj.Uf;
                GetSqlCommand().Parameters.Add("OrgaoEmissor", SqlDbType.VarChar).Value = obj.OrgaoEmissor;
                GetSqlCommand().Parameters.Add("Telefone", SqlDbType.VarChar).Value = obj.Telefone;
                return GetSqlCommand().ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi posivel Alterar as informações da tabela Aluno.", ex);
            }
            finally
            {
                sb = null;
            }
        }

        public override void Consultar(AlunoVO obj)
        {
            try
            {


                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = GetSQLConsulta(obj);
                CarregarParametro(obj);

                if (GetSqlDataReader().Read())
                    CarregarObjetoConsulta(obj);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível Consultar os Dados na Tabela Aluno.", e);
            }
            finally
            {
                Close();
            }
        }

        public override void Deletar(AlunoVO obj)
        {
            StringBuilder sb = null;
            try
            {
                sb = new StringBuilder();
                sb.AppendLine("DELETE FROM dbo.Aluno ");
                sb.AppendLine(" WHERE IdAluno = @IdAluno");

                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = sb.ToString();
                GetSqlCommand().Parameters.Clear();
                GetSqlCommand().Parameters.Add("IdAluno", SqlDbType.Int).Value = obj.IdAluno;

                GetSqlCommand().ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível EXCLUIR as informações na Tabela Aluno", e);
            }
            finally
            {
                sb = null;
            }
        }

        public override List<AlunoVO> GetLista(AlunoVO obj)
        {
            List<AlunoVO> lista = null;
            AlunoVO objeto = null;
            try
            {
                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = GetSQLConsulta(obj);
                CarregarParametro(obj);

                lista = new List<AlunoVO>();

                while (GetSqlDataReader().Read())
                {
                    objeto = new AlunoVO();
                    CarregarObjetoConsulta(objeto);
                    lista.Add(objeto);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível Consultar os Dados na Tabela Aluno.", e);
            }
            finally
            {
                Close();
            }
        }

        public override void Inserir(AlunoVO obj)
        {
            StringBuilder sb = null;
            try
            {
                sb = new StringBuilder();
                sb.AppendLine(@"INSERT INTO dbo.Aluno ");
                sb.AppendLine(@"(                     ");
                sb.AppendLine(@"            Nome      ");
                sb.AppendLine(@"          , Cpf       ");
                sb.AppendLine(@"          , Email   ");
                sb.AppendLine(@"          , Senha   ");
                sb.AppendLine(@"          , Rg          ");
                sb.AppendLine(@"          , Uf          ");
                sb.AppendLine(@"          , OrgaoEmissor  ");
                sb.AppendLine(@"          , Telefone        ");
                sb.AppendLine(@")                     ");
                sb.AppendLine(@"VALUES                ");
                sb.AppendLine(@"(                     ");
                sb.AppendLine(@"             @Nome    ");
                sb.AppendLine(@"          ,  @Cpf     ");
                sb.AppendLine(@"          ,  @Email");
                sb.AppendLine(@"          ,  @Senha");
                sb.AppendLine(@"          ,  @Rg          ");
                sb.AppendLine(@"          ,  @Uf          ");
                sb.AppendLine(@"          ,  @OrgaoEmissor  ");
                sb.AppendLine(@"          ,  @Telefone        ");
                sb.AppendLine(@")");


                //GetSqlCommand().Connection.ChangeDatabase(BancoComum);


                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = sb.ToString();
                GetSqlCommand().Parameters.Clear();
                GetSqlCommand().Parameters.Add("Nome", SqlDbType.VarChar).Value = obj.Nome;
                GetSqlCommand().Parameters.Add("Cpf", SqlDbType.VarChar).Value = obj.Cpf;
                GetSqlCommand().Parameters.Add("Email", SqlDbType.VarChar).Value = obj.Email;
                GetSqlCommand().Parameters.Add("Senha", SqlDbType.VarChar).Value = obj.Senha;
                GetSqlCommand().Parameters.Add("Rg", SqlDbType.VarChar).Value = obj.Rg;
                GetSqlCommand().Parameters.Add("Uf", SqlDbType.VarChar).Value = obj.Uf;
                GetSqlCommand().Parameters.Add("OrgaoEmissor", SqlDbType.VarChar).Value = obj.OrgaoEmissor;
                GetSqlCommand().Parameters.Add("Telefone", SqlDbType.VarChar).Value = obj.Telefone;
                GetSqlCommand().ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível INCLUIR as informações na Tabela Aluno", e);
            }
            finally
            {
                sb = null;
            }
        }

        protected override void CarregarObjetoConsulta(AlunoVO obj)
        {
            try
            {
                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("IdAluno"))))
                    obj.IdAluno = Convert.ToInt64(GetSqlDataReader()["IdAluno"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Nome"))))
                    obj.Nome = Convert.ToString(GetSqlDataReader()["Nome"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Cpf"))))
                    obj.Cpf = Convert.ToString(GetSqlDataReader()["Cpf"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Email"))))
                    obj.Email = Convert.ToString(GetSqlDataReader()["Email"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Senha"))))
                    obj.Senha = Convert.ToString(GetSqlDataReader()["Senha"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Rg"))))
                    obj.Rg = Convert.ToString(GetSqlDataReader()["Rg"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Uf"))))
                    obj.Uf = Convert.ToString(GetSqlDataReader()["Uf"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("OrgaoEmissor"))))
                    obj.OrgaoEmissor = Convert.ToString(GetSqlDataReader()["OrgaoEmissor"]);

                if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Telefone"))))
                    obj.Telefone = Convert.ToString(GetSqlDataReader()["Telefone"]);



            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível Carregar o Objeto para a Consulta.", e);
            }
        }

        protected override void CarregarParametro(AlunoVO obj)
        {
            try
            {
                GetSqlCommand().Parameters.Clear();

                if (obj.IdAluno > 0)
                    GetSqlCommand().Parameters.Add("Id", SqlDbType.Int).Value = obj.IdAluno;

                if (!string.IsNullOrEmpty(obj.Cpf))
                    GetSqlCommand().Parameters.Add("Cpf", SqlDbType.VarChar).Value = obj.Cpf;

                if (!string.IsNullOrEmpty(obj.Nome))
                    GetSqlCommand().Parameters.Add("Nome", SqlDbType.VarChar).Value = obj.Nome;

                if (!string.IsNullOrEmpty(obj.Email))
                    GetSqlCommand().Parameters.Add("Email", SqlDbType.VarChar).Value = obj.Email;


            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível CARREGAR as informações na Tabela Aluno", e);
            }
        }

        protected override string GetSQLConsulta(AlunoVO obj)
        {
            StringBuilder sb = null;
            try
            {
                sb = new StringBuilder();
                sb.AppendLine(@"SELECT dbo.Aluno.IdAluno
                                     , dbo.Aluno.Nome 
                                     , dbo.Aluno.Cpf   
                                     , dbo.Aluno.Email
                                     , dbo.Aluno.Senha
                                     , dbo.Aluno.Rg
                                     , dbo.Aluno.Uf
                                     , dbo.Aluno.OrgaoEmissor
                                     , dbo.Aluno.Telefone
                                FROM dbo.Aluno
                                WHERE 1 = 1");

                if (obj.IdAluno > 0)
                    sb.AppendLine(@" AND dbo.Aluno.IdAluno = @IdAluno");

                if (!string.IsNullOrEmpty(obj.Nome))
                    sb.AppendLine(@" AND dbo.Aluno.Nome = @Nome");

                if (!string.IsNullOrEmpty(obj.Cpf))
                    sb.AppendLine(@" AND dbo.Aluno.Cpf = @Cpf");

                if (!string.IsNullOrEmpty(obj.Email))
                    sb.AppendLine(@" AND dbo.Aluno.Email = @Email");


                return sb.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível CONSULTAR as informações na Tabela Aluno", e);
            }
            finally
            {
                sb = null;
            }
        }
    }
}
