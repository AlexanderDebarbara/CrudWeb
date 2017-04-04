using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Repositorio.Excecao
{
    public class ArquivoConfiguracaoException : AbstractException
    {
        public ArquivoConfiguracaoException(string mensagem)
            : base(mensagem)
        {

        }

        public ArquivoConfiguracaoException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
    }
}
