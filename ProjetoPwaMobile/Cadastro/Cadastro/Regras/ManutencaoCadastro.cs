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

                }else if(endereco.Bairro.Length > 40)
                {
                    throw new Exception("Campo complemento maior do que o permitido");

                }else if (string.IsNullOrEmpty(Convert.ToString(endereco.Cep)))
                {
                    throw new Exception("Campo cep não preenchido!");

                }else if(Convert.ToString(endereco.Cep).Length > 8)
                {
                    throw new Exception("Campo cep maior do que o permitido");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
