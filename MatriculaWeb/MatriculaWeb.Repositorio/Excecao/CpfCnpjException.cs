using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Repositorio.Excecao
{
    class CpfCnpjException : AbstractException
    {
        public CpfCnpjException(string message) : base(message)
        {

        }
    }
}
