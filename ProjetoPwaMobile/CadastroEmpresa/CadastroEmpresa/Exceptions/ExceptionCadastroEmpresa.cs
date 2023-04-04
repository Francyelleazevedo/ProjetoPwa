using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEmpresa.Exceptions
{
    public class ExceptionCadastroEmpresa : Exception
    {
        public ExceptionCadastroEmpresa(string mensagem) : base(mensagem)
        { 

        }
    }
}
