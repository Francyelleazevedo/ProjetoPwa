﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Classes
{
    public class Cliente
    {
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; } = new Endereco();
    }
}
