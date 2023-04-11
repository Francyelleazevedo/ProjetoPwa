using Cadastro.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Cadastro.Exceptions;
using Cadastro.Repositorio;
using Cadastro.Base;

namespace Cadastro.Regras
{
    public class ManutencaoCadastro
    {
        #region Estancias
        Dao dao = null;
        RepositorioCadastro repositorio = null;

        public ManutencaoCadastro()
        {
            try
            {
                dao = new Dao();
                repositorio = new RepositorioCadastro(dao);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        public void IniciarCadastroCliente(Cliente cliente)
        {
            try
            {
                ValidacaoDadosPessoais(cliente);
                ValidacaoEndereco(cliente.Endereco);
                ValidarEmail(cliente.Email);
                ValidarSenha(cliente.Senha);

                InserirDadosCliente(cliente);
                //ObterClientes();
               
                InserirDadosEnderecoCliente(cliente);
                ObterEnderecosClientes();

            }
            catch (Exception)
            {
                throw;
            }

        }

        #region Validações
        public void ValidacaoDadosPessoais(Cliente cliente)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente.Nome))
                {
                    throw new ExceptionCadastro("Campo nome é obrigatório!");

                }
                else if (cliente.Nome.Length > 30)
                {
                    throw new ExceptionCadastro("Campo nome maior do que o permitido!");

                }
                else if (int.TryParse(cliente.Nome, out int nome))
                {
                    throw new ExceptionCadastro("Nome não aceita números");
                }
                else if (string.IsNullOrEmpty(cliente.Sobrenome))
                {
                    throw new ExceptionCadastro("Campo sobrenome é obrigatório!");

                }
                else if (cliente.Sobrenome.Length > 30)
                {
                    throw new ExceptionCadastro("Campo sobrenome maior do que o permitido!");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(cliente.Cpf)))
                {
                    throw new ExceptionCadastro("Campo cpf é obrigatório!");

                }
                else if (Convert.ToString(cliente.Cpf).Length > 11)
                {
                    throw new ExceptionCadastro("Campo cpf maior do que o permitido!");

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ValidacaoEndereco(Endereco endereco)
        {
            try
            {
                if (string.IsNullOrEmpty(endereco.Cidade))
                {
                    throw new ExceptionCadastro("Campo cidade não preenchido!");

                }
                else if (endereco.Cidade.Length > 40)
                {
                    throw new ExceptionCadastro("Campo cidade maior do que o permitido");

                }
                else if (int.TryParse(endereco.Cidade, out int cidade))
                {
                    throw new ExceptionCadastro("Cidade não aceita números");
                }
                else if (string.IsNullOrEmpty(endereco.Logradouro))
                {
                    throw new ExceptionCadastro("Campo logradouro não preenchido!");

                }
                else if (endereco.Logradouro.Length > 60)
                {
                    throw new ExceptionCadastro("Campo logradouro maior do que o permitido");

                }
                else if (int.TryParse(endereco.Logradouro, out int logradouro))
                {
                    throw new ExceptionCadastro("Cidade não aceita números");
                }
                else if (endereco.Complemento.Length > 40)
                {
                    throw new ExceptionCadastro("Campo complemento maior do que o permitido");

                }
                else if (string.IsNullOrEmpty(endereco.Bairro))
                {
                    throw new ExceptionCadastro("Campo bairro não preenchido!");

                }
                else if (endereco.Bairro.Length > 40)
                {
                    throw new ExceptionCadastro("Campo complemento maior do que o permitido");

                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Cep)))
                {
                    throw new ExceptionCadastro("Campo cep não preenchido!");

                }
                else if (Convert.ToString(endereco.Cep).Length > 8)
                {
                    throw new ExceptionCadastro("Campo cep maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Numero)))
                {
                    throw new ExceptionCadastro("Campo número não preenchido!");

                }
                else if (Convert.ToString(endereco.Numero).Length > 5)
                {
                    throw new ExceptionCadastro("Campo número não preenchido!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidarEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    throw new ExceptionCadastro("Digite um email válido!");
                }
                else if (email.Length > 80)
                {
                    throw new ExceptionCadastro("Limite de caracteres excedido!");
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
                    throw new ExceptionCadastro("Campo senha obrigatório!");
                }
                else if (senha.Length < 8)
                {
                    throw new ExceptionCadastro("A senha deve ter no mínimo 8 dígitos, incluindo letras e números!");
                }
                else if (senha.Length > 20)
                {
                    throw new ExceptionCadastro("A senha deve ter no máximo 20 dígitos, , incluindo letras e números!");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Inserts
        public void InserirDadosCliente(Cliente cliente)
        {
            long existeCpf = 0;
            try
            {
                ValidacaoDadosPessoais(cliente);
                ValidarEmail(cliente.Email);
                ValidarSenha(cliente.Senha);

                existeCpf = ExisteCpf(Convert.ToString(cliente.Cpf));

                if(existeCpf == 0)
                {
                    dao.Abrir();
                    repositorio.InsertDataBase(cliente); //inserindo os dados no banco
                    dao.Fechar();
                }else
                {
                    throw new ExceptionCadastro("Cliente já cadastrado!");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InserirDadosEnderecoCliente(Cliente cliente)
        {
            try
            {
                ValidacaoEndereco(cliente.Endereco);

                dao.Abrir();
                repositorio.InsertEndereco(cliente); //inserindo os dados no banco
                dao.Fechar();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Verirficar se já existe
        public long ExisteCpf(string cpf)
        {
            long existeCnpj = 0;
            try
            {
                dao.Abrir();
                existeCnpj = repositorio.VerificarCpf(cpf);
                dao.Fechar();
                return existeCnpj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obter
        public List<Cliente> ObterClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                dao.Abrir();
                clientes = repositorio.ObterClientes(); //inserindo os dados no banco
                dao.Fechar();

                return clientes;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Endereco> ObterEnderecosClientes()
        {
            try
            {
                List<Endereco> enderecos = new List<Endereco>();
                dao.Abrir();
                enderecos = repositorio.ObterEnderecos(); //inserindo os dados no banco
                dao.Fechar();

                return enderecos;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
