using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Classes
{
    public class Endereco
    {
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
    }
}
