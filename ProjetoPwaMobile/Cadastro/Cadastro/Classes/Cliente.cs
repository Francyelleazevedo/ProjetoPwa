using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Classes
{
    public class Cliente
    {
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public PreferenciaCliente Preferencia { get; set; }
    }
}
