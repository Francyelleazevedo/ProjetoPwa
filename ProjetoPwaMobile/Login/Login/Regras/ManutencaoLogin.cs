using Login.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Exceptions;
using Login.Repositorio;

namespace Login.Regras
{
    public class ManutencaoLogin
    {
        Dao dao = null;
        RepositorioLogin repositorio = null;
        public string Login(LoginUsuario usuario)
        {
            ValidarEmailouCnpj(usuario.EmailouCnpj);
            ValidarSenha(usuario.Senha);
            GetLogin();

            return "Sucesso";
        }
        public void ValidarEmailouCnpj(string emailCnpj)
        {
            try
            {
                if (string.IsNullOrEmpty(emailCnpj))
                {
                    throw new ExceptionLogin("Digite um email ou cnpj válido!");
                }
                else if (emailCnpj.Length > 80)
                {
                    throw new ExceptionLogin("Limite de caracteres excedido!");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ValidarSenha(string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(senha))
                {
                    throw new ExceptionLogin("Campo senha obrigatório!");
                }
                else if (senha.Length < 8)
                {
                    throw new ExceptionLogin("A senha deve ter no mínimo 8 dígitos, incluindo letras e números!");
                }
                else if (senha.Length > 20)
                {
                    throw new ExceptionLogin("A senha deve ter no máximo 20 dígitos, , incluindo letras e números!");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<LoginUsuario> GetLogin()
        {
            try
            {
                List<LoginUsuario> list = new List<LoginUsuario>();
                dao.Abrir();
                list = repositorio.ObterLoginEmpresa();
                dao.Fechar();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
