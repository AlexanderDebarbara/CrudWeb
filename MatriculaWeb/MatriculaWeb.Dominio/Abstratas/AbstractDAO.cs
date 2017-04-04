using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Dominio.Abstratas
{
    public abstract class AbstractDAO<T>
    {
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;

        public string BancoComum { get; set; }


        public AbstractDAO(SqlCommand sqlCommand)
        {
            SetSqlCommand(sqlCommand);
            //CarregarBancos();
        }

        private void SetSqlCommand(SqlCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
        }

        protected SqlCommand GetSqlCommand()
        {
            if (sqlCommand == null) sqlCommand = new SqlCommand();

            return sqlCommand;
        }

        private void SetSqlDataReader(SqlDataReader sqlDataReader)
        {
            this.sqlDataReader = sqlDataReader;
        }

        protected SqlDataReader GetSqlDataReader()
        {
            if (sqlDataReader == null)
                sqlDataReader = GetSqlCommand().ExecuteReader();

            return sqlDataReader;
        }

        //private void CarregarBancos()
        //{
        //    try
        //    {
        //        var xmlDocument = new XmlDocument();
        //        var sb = new StringBuilder();
        //        xmlDocument.Load("C:/SimplesCadastro/ConnectionString.xml");
        //        XmlNode xmlNode = xmlDocument.SelectSingleNode("Banco_Dados");
        //        XmlNode xmlNodeBanco = xmlNode.SelectSingleNode("Banco");
        //        XmlNode xmlNodeBancoComum = xmlNodeBanco.SelectSingleNode("Comum");

        //        BancoComum = xmlNodeBancoComum.InnerText;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public DateTime GetDataAtual()
        {
            try
            {
                var dataAtual = DateTime.Now;

                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = "SELECT GETDATE() DataAtual";
                GetSqlCommand().Parameters.Clear();

                if (GetSqlDataReader().Read())
                {
                    if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("DataAtual"))))
                        dataAtual = Convert.ToDateTime(GetSqlDataReader()["DataAtual"]);
                }

                return dataAtual;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro de returno de Data", ex);
            }
            finally
            {
                Close();
            }
        }

        protected long GetIdSequence(string sequence)
        {
            long id = 0;
            try
            {
                GetSqlCommand().CommandText = "";
                GetSqlCommand().CommandText = "DECLARE @NextID int;"
                                             + "SET @NextID = NEXT VALUE FOR " + sequence + ";"
                                             + "SELECT @NextID as Incremento";
                GetSqlCommand().Parameters.Clear();

                if (GetSqlDataReader().Read())
                {
                    if (!(GetSqlDataReader().IsDBNull(GetSqlDataReader().GetOrdinal("Incremento"))))
                        id = Convert.ToInt64(GetSqlDataReader()["Incremento"]);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar o Incremento da sequence " + sequence, ex);
            }
            finally
            {
                Close();
            }
            return id;
        }

        protected void Close()
        {
            try
            {
                if (GetSqlDataReader() != null)
                    GetSqlDataReader().Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SetSqlDataReader(null);
            }
        }

        public abstract void Inserir(T obj);
        public abstract int Alterar(T obj);
        public abstract void Deletar(T obj);
        protected abstract string GetSQLConsulta(T obj);
        protected abstract void CarregarParametro(T obj);
        protected abstract void CarregarObjetoConsulta(T obj);
        public abstract void Consultar(T obj);
        public abstract List<T> GetLista(T obj);

        public object GetValueOrNull(object value)
        {
            if (value != null)
                return value;

            return DBNull.Value;
        }

        public object GetValueOrNull(long value)
        {
            if (value > 0)
                return value;

            return DBNull.Value;
        }
    }
}
