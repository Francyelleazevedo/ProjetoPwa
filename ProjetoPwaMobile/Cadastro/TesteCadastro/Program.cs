﻿using Cadastro.Classes;
using Cadastro.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastro
{
    public class Program
    {
        static void Main(string[] args)
        {
            ManutencaoCadastro manu = new ManutencaoCadastro();
            Cliente cliente = new Cliente();

            cliente.Cpf = 09987769080;
            cliente.Nome = "Francyelle";
            cliente.Sobrenome = "Azevedo";
            cliente.Email = "testeback@teste.com";
            cliente.Senha = "12345678";
            cliente.Endereco.Id = 4;
            cliente.Endereco.Cidade = "recife";
            cliente.Endereco.Logradouro = "Rua Severino Pessoa";
            cliente.Endereco.Cep = 50610400;
            cliente.Endereco.Bairro = "Madalena";
            cliente.Endereco.Complemento = "casa 02";
            cliente.Endereco.Numero = 1;


            //manu.InserirDadosCliente(cliente);
            manu.ObterClientes();
            
        }
    }
}
