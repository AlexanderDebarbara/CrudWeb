using MatriculaWeb.Dominio.Abstratas;
using MatriculaWeb.Modelo.DAO;
using MatriculaWeb.Modelo.VO;
using MatriculaWeb.Repositorio.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Negocio.BE
{
    public class AlunoBE : AbstractBE<AlunoVO>
    {
        public AlunoBE() : base() { }
        public AlunoBE(SqlCommand sqlCommand) : base(sqlCommand) { }
        public override int Alterar(AlunoVO obj)
        {
            AlunoDAO dao = null;
            int id = 0;
            try
            {
                if (obj != null)
                {
                    dao = new AlunoDAO(GetSqlCommand());
                    BeginTransaction();
                    id = dao.Alterar(obj);

                    Commit();

                    return id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
                dao = null;
            }
        }

        public override void Consultar(AlunoVO obj)
        {
            AlunoDAO dao = null;
            try
            {
                if (obj != null)
                {
                    dao = new AlunoDAO(GetSqlCommand());
                    dao.Consultar(obj);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dao = null;
            }
        }

        public override void Deletar(AlunoVO obj)
        {
            AlunoDAO dao = null;
            try
            {
                if (obj != null)
                {
                    dao = new AlunoDAO(GetSqlCommand());

                    BeginTransaction();
                    dao.Deletar(obj);
                    Commit();
                }
            }
            catch (Exception e)
            {
                Rollback();
                throw e;
            }
            finally
            {
                dao = null;
            }
        }

        public override List<AlunoVO> GetLista(AlunoVO obj)
        {
            AlunoDAO dao = null;
            try
            {

                dao = new AlunoDAO(GetSqlCommand());
                return dao.GetLista(obj);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dao = null;
            }
        }

        public override void Inserir(AlunoVO obj)
        {
            AlunoDAO dao = null;
            try
            {               

                if (obj != null)
                {
                    BeginTransaction();
                    dao = new AlunoDAO(GetSqlCommand());


                    CpfCnpj.ChecarCpf(obj.Cpf);
                    
                    var consulta = new AlunoVO() { Cpf = obj.Cpf };
                    dao.Consultar(consulta);
                    if (consulta.IdAluno > 0)
                        throw new Exception("CPF já cadastrado");

                    string numerosCpfSemFormato = "";
                    for (int i = 0; i < obj.Cpf.Length; i++)
                        if (Char.IsDigit(Convert.ToChar(obj.Cpf[i])))
                            numerosCpfSemFormato += obj.Cpf[i];

                    obj.Cpf = numerosCpfSemFormato;

                    dao.Inserir(obj);
                    Commit();
                }
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;
            }
            finally
            {
                dao = null;
            }
        }


    }
}
