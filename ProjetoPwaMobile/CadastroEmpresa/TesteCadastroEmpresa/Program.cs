using CadastroEmpresa.Classes;
using CadastroEmpresa.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCadastroEmpresa
{
    public class Program
    {
        static void Main(string[] args)
        {
            ManutencaoCadastroEmpresa manu = new ManutencaoCadastroEmpresa();
            Empresa empresa = new Empresa();

            empresa.Nome = "Testeback Empresa";
            empresa.Cnpj = "34565478965432";
            empresa.CapacidadeTotal = 120;
            empresa.HorarioFuncionamento = "8:00 às 17:00";
            empresa.Telefone = 81987590879;
            empresa.Senha = "12345678";
            empresa.DiasFuncionamento = "segunda à sexta";
            empresa.Endereco.Cidade = "Recife1234";
            empresa.Endereco.Logradouro = "Rua Avelar";
            empresa.Endereco.Complemento = "";
            empresa.Endereco.Bairro = "teste bairro";
            empresa.Endereco.Cep = 50610450;
            

            //manu.InserirCadastroEmpresa(empresa);
            manu.InserirEnderecoEmpresa(empresa);
            manu.GetEmpresas();
        }
    }
}
