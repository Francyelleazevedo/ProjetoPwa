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
            empresa.Nome = "1234";
            empresa.Cnpj = 0657678098089;
            empresa.CapacidadeTotal = 120;
            empresa.HorarioFuncionamento = "8:00 às 17:00";
            empresa.Telefone = 81987590879;
            empresa.DiasFuncionamento = "segunda à sexta";
            empresa.Endereco.Cidade = "Recife1234";

            manu.IniciarCadastroCliente(empresa);
        }
    }
}
