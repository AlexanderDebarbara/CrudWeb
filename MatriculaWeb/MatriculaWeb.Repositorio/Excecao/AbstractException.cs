using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Repositorio.Excecao
{
    public abstract class AbstractException : ApplicationException
    {
        public AbstractException()
            : base()
        {

        }

        public AbstractException(string message)
            : base(message)
        {

        }

        public AbstractException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}