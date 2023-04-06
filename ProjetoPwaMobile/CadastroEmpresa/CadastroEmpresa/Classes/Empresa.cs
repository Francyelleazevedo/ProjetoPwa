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
        public string Cnpj { get; set; }
        public long Telefone { get; set; }
        public string HorarioFuncionamento { get; set; }
        public string DiasFuncionamento { get; set; }
        public string Senha { get; set; }
        public int CapacidadeTotal { get; set; }
        public EnderecoEmpresa Endereco { get; set; } = new EnderecoEmpresa();
        public Lotacao Lotacao { get; set; } = new Lotacao();
    }
}
