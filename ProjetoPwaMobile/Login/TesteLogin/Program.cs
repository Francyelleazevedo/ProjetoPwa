using Login.Classes;
using Login.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteLogin
{
    public class Program
    {
        static void Main(string[] args)
        {
            ManutencaoLogin manu = new ManutencaoLogin();
            LoginUsuario usuario = new LoginUsuario();

            usuario.EmailouCnpj = "31599146000200";
            usuario.Senha = "teste123";

            manu.Login(usuario);
        }
    }
}
