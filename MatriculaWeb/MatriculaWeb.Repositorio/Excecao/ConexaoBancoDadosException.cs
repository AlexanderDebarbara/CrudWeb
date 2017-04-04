using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Repositorio.Excecao
{
    public class ConexaoBancoDadosException : AbstractException
    {
        public ConexaoBancoDadosException(string mensagem)
            : base(mensagem)
        {

        }

        public ConexaoBancoDadosException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
    }
}
