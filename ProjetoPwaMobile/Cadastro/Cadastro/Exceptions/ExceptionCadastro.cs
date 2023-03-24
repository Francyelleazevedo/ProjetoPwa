using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Exceptions
{
    public class ExceptionCadastro : Exception
    {
        public ExceptionCadastro(string mensagem) : base(mensagem)
        {

        }
    }
}
