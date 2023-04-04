using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroEmpresa.Classes;
using CadastroEmpresa.Exceptions;

namespace CadastroEmpresa.Regras
{
    public class ManutencaoCadastroEmpresa
    {
        public string IniciarCadastroCliente(Empresa empresa)
        {
            try
            {
                ValidacaoDadosEmpresa(empresa);
                ValidacaoEndereco(empresa.Endereco);
                ValidarCnpj(Convert.ToString(empresa.Cnpj));
                ValidarSenha(empresa.Senha);



                return "Sucesso";
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ValidacaoDadosEmpresa(Empresa empresa)
        {
            try
            {
                if (string.IsNullOrEmpty(empresa.Nome))
                {
                    throw new ExceptionCadastroEmpresa("Campo nome é obrigatório!");
                }
                else if (empresa.Nome.Length > 200)
                {
                    throw new ExceptionCadastroEmpresa("Campo nome maior do que o permitido!");
                }
                else if (int.TryParse(empresa.Nome, out int nome))
                {
                    throw new ExceptionCadastroEmpresa("Nome não aceita números");
                }
                else if (string.IsNullOrEmpty(empresa.DiasFuncionamento))
                {
                    throw new ExceptionCadastroEmpresa("Campo dias de funcionamento é obrigatório!");
                }
                else if (empresa.DiasFuncionamento.Length > 30)
                {
                    throw new ExceptionCadastroEmpresa("Campo dias de funcionamento maior do que o permitido!");
                }
                else if (int.TryParse(empresa.DiasFuncionamento, out int dias))
                {
                    throw new ExceptionCadastroEmpresa("Dias de funcionamento não aceita números");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(empresa.CapacidadeTotal)))
                {
                    throw new ExceptionCadastroEmpresa("Campo capacidade total é obrigatório!");
                }
                else if (Convert.ToString(empresa.CapacidadeTotal).Length > 600)
                {
                    throw new ExceptionCadastroEmpresa("Capacidade total maior do que o permitido!");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(empresa.Cnpj)))
                {
                    throw new ExceptionCadastroEmpresa("Campo cnpj é obrigatório!");
                }
                else if (Convert.ToString(empresa.Cnpj).Length > 14)
                {
                    throw new ExceptionCadastroEmpresa("Campo cnpj maior do que o permitido!");
                }
                else if (string.IsNullOrEmpty(empresa.HorarioFuncionamento))
                {
                    throw new ExceptionCadastroEmpresa("Campo horário de funcionamento é obrigatório!");
                }
                else if (empresa.HorarioFuncionamento.Length > 30)
                {
                    throw new ExceptionCadastroEmpresa("Campo horário de funcionamento maior do que o permitido!");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(empresa.Telefone)))
                {
                    throw new ExceptionCadastroEmpresa("Campo telefone é obrigatório!");
                }
                else if (Convert.ToString(empresa.Telefone).Length > 20)
                {
                    throw new ExceptionCadastroEmpresa("Campo telefone maior do que o permitido!");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ValidacaoEndereco(EnderecoEmpresa endereco)
        {
            try
            {
                if (string.IsNullOrEmpty(endereco.Cidade))
                {
                    throw new ExceptionCadastroEmpresa("Campo cidade não preenchido!");
                }
                else if (int.TryParse(endereco.Cidade, out int cidade))
                {
                    throw new ExceptionCadastroEmpresa("Cidade não aceita números");
                }
                else if (endereco.Cidade.Length > 40)
                {
                    throw new ExceptionCadastroEmpresa("Campo cidade maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(endereco.Logradouro))
                {
                    throw new ExceptionCadastroEmpresa("Campo endereço não preenchido!");
                }
                else if (endereco.Logradouro.Length > 60)
                {
                    throw new ExceptionCadastroEmpresa("Campo endereço maior do que o permitido");
                }
                else if (int.TryParse(endereco.Logradouro, out int logradouro))
                {
                    throw new ExceptionCadastroEmpresa("Logradouro não aceita números");
                }
                else if (endereco.Complemento.Length > 40)
                {
                    throw new ExceptionCadastroEmpresa("Campo complemento maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(endereco.Bairro))
                {
                    throw new ExceptionCadastroEmpresa("Campo bairro não preenchido!");
                }
                else if (endereco.Bairro.Length > 40)
                {
                    throw new ExceptionCadastroEmpresa("Campo complemento maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Cep)))
                {
                    throw new ExceptionCadastroEmpresa("Campo cep não preenchido!");
                }
                else if (Convert.ToString(endereco.Cep).Length > 8)
                {
                    throw new ExceptionCadastroEmpresa("Campo cep maior do que o permitido");
                }
                else if (string.IsNullOrEmpty(Convert.ToString(endereco.Numero)))
                {
                    throw new ExceptionCadastroEmpresa("Campo número não preenchido!");
                }
                else if (Convert.ToString(endereco.Numero).Length > 5)
                {
                    throw new ExceptionCadastroEmpresa("Campo número não preenchido!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ValidarCnpj(string cnpj)
        {
            try
            {
                if (string.IsNullOrEmpty(cnpj))
                {
                    throw new ExceptionCadastroEmpresa("Digite um cnpj válido!");
                }
                else if (cnpj.Length > 80)
                {
                    throw new ExceptionCadastroEmpresa("Limite de caracteres excedido!");
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
                    throw new ExceptionCadastroEmpresa("Campo senha obrigatório!");
                }
                else if (senha.Length < 8)
                {
                    throw new ExceptionCadastroEmpresa("A senha deve ter no mínimo 8 dígitos, incluindo letras e números!");
                }
                else if (senha.Length > 20)
                {
                    throw new ExceptionCadastroEmpresa("A senha deve ter no máximo 20 dígitos, , incluindo letras e números!");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
