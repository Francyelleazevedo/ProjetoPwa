using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEmpresa.Classes
{
    public class Empresa
    {
        public string Nome { get; set; }
        public int Cnpj { get; set; }
        public int Telefone { get; set; }
        public string HorarioFuncionamento { get; set; }
        public string DiasFuncionamento { get; set; }

    }
}
