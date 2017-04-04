using MatriculaWeb.Repositorio.Excecao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Dominio.Abstratas
{
    public abstract class AbstractBE<T>
    {

        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;
        private SqlCommand sqlCommand;
        private bool AbrirTransacao;

        private void SetSqlCommand(SqlCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
        }

        protected SqlCommand GetSqlCommand()
        {
            return sqlCommand;
        }

        private void SetSqlConnection(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        private SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }

        private void SetSqlTransaction(SqlTransaction sqlTransaction)
        {
            this.sqlTransaction = sqlTransaction;
        }

        private SqlTransaction GetSqlTransaction()
        {
            return sqlTransaction;
        }

        private void SetAbrirTransacao(bool AbrirTransacao)
        {
            this.AbrirTransacao = AbrirTransacao;
        }

        private bool IsAbrirTransacao()
        {
            return AbrirTransacao;
        }

        protected AbstractBE()
        {
            try
            {
                AbrirConexao();

                if (GetSqlCommand().Transaction == null)
                    SetAbrirTransacao(true);
                else
                    SetAbrirTransacao(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected AbstractBE(SqlCommand sqlCommand)
        {
            try
            {
                if (!sqlCommand.Connection.State.Equals(ConnectionState.Open))
                    throw new ConexaoBancoDadosException("A conexão com o banco de dados não esta aberta!");

                if (sqlCommand.Transaction != null)
                    SetAbrirTransacao(false);
                else
                    SetAbrirTransacao(true);

                SetSqlCommand(sqlCommand);
            }
            catch (Exception e)
            {
                throw new ConexaoBancoDadosException("A conexão com o banco de dados não esta aberta!", e);
            }
        }

        private void AbrirConexao()
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=MatriculaWeb; User Id=admin; Password=admin");
                    sqlConnection.Open();
                    SetSqlConnection(sqlConnection);
                    sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandTimeout = 500;
                    sqlCommand.Parameters.Clear();
                    SetSqlCommand(sqlCommand);
                }
            }
            catch (ArquivoConfiguracaoException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new ConexaoBancoDadosException("Não foi possivel abrir conexão com o banco de dados!", e);
            }
        }

        public void FecharConexao()
        {
            try
            {
                if (GetSqlConnection() != null && GetSqlCommand() != null)
                {
                    GetSqlConnection().Close();
                    GetSqlConnection().Dispose();
                    SqlConnection.ClearPool(GetSqlConnection());
                    SetSqlConnection(null);
                    GetSqlCommand().Dispose();
                    SetSqlCommand(null);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel fechar conexão com o banco de dados!", e);
            }
        }

        protected void BeginTransaction()
        {
            SqlTransaction sqlTransaction = null;
            try
            {
                if (IsAbrirTransacao())
                {
                    sqlTransaction = GetSqlConnection().BeginTransaction("AbreTransacao");
                    SetSqlTransaction(sqlTransaction);
                    GetSqlCommand().Transaction = GetSqlTransaction();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possível abrir a transação com o banco de dados!", e);
            }
        }

        protected void Commit()
        {
            try
            {
                if (IsAbrirTransacao())
                    GetSqlTransaction().Commit();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected void Rollback()
        {
            try
            {
                if (IsAbrirTransacao())
                    GetSqlTransaction().Rollback();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public abstract void Inserir(T obj);
        public abstract int Alterar(T obj);
        public abstract void Deletar(T obj);
        public abstract void Consultar(T obj);
        public abstract List<T> GetLista(T obj);
    }
}
