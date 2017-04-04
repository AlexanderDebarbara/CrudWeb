using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatriculaWeb.Modelo.VO
{
    public class AlunoVO
    {
        public long IdAluno { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Uf { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Telefone { get; set; }
    }
}
