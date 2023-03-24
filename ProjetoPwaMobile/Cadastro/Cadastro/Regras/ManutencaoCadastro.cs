using Cadastro.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Regras
{
    public class ManutencaoCadastro
    {
        public string IniciarCadastroCliente(Cliente cliente)
        {
            ValidacaoDadosPessoais(cliente);
            ValidacaoEndereco(cliente.Endereco);

            return "Sucesso";
        }

        public void ValidacaoDadosPessoais(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new Exception("Campo nome é obrigatório!");

            }
            else if (cliente.Nome.Length > 30)
            {
                throw new Exception("Campo nome maior do que o permitido!");

            }
            else if (string.IsNullOrEmpty(cliente.Sobrenome))
            {
                throw new Exception("Campo sobrenome é obrigatório!");

            }
            else if (cliente.Sobrenome.Length > 30)
            {
                throw new Exception("Campo sobrenome maior do que o permitido!");
            }
            else if (string.IsNullOrEmpty(Convert.ToString(cliente.Cpf)))
            {
                throw new Exception("Campo cpf é obrigatório!");

            }
            else if (Convert.ToString(cliente.Cpf).Length > 11)
            {
                throw new Exception("Campo cpf maior do que o permitido!");

            }
        }

        public void ValidacaoEndereco(Endereco endereco)
        {
            try
            {
                if (string.IsNullOrEmpty(endereco.Cidade))
                {
                    throw new Exception("Campo cidade não preenchido!");

                }
                else if (endereco.Cidade.Length > 40)
                {
                    throw new Exception("Campo cidade maior do que o permitido");

                }
                else if (string.IsNullOrEmpty(endereco.Logradouro))
                {
                    throw new Exception("Campo endereço não preenchido!");

                }
                else if (endereco.Logradouro.Length > 60)
                {
                    throw new Exception("Campo endereço maior do que o permitido");

                }
                else if (endereco.Complemento.Length > 40)
                {
                    throw new Exception("Campo complemento maior do que o permitido");

                }
                else if (string.IsNullOrEmpty(endereco.Bairro))
                {
                    throw new Exception("Campo bairro não preenchido!");

                }
                else if (endereco.Bairro.Length > 40)
                {
                    throw new Exception("Campo complemento maior do que o permitido");

                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Cep)))
                {
                    throw new Exception("Campo cep não preenchido!");

                }
                else if (Convert.ToString(endereco.Cep).Length > 8)
                {
                    throw new Exception("Campo cep maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Numero)))
                {
                    throw new Exception("Campo número não preenchido!");

                }
                else if (Convert.ToString(endereco.Numero).Length > 5)
                {
                    throw new Exception("Campo número não preenchido!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
