using Cadastro.Base;
using Cadastro.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Repositorio
{
    internal class RepositorioCadastro
    {
        Dao dao = null;

        public RepositorioCadastro(Dao dao)
        {
            this.dao = dao;
        }

        public void InsertDataBase(Cliente cliente)
        {
            try
            {
                String sql = "INSERT INTO Cliente (Cpf, Nome, Sobrenome, Email, Senha)" +
                      "VALUES" +
                      "('" + cliente.Cpf + "'" + "," +
                      "'" + cliente.Nome + "'" + "," +
                      "'" + cliente.Sobrenome + "'" + "," +
                      "'" + cliente.Email + "'" + "," +
                      "'" + cliente.Senha + "')";
                
                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEndereco(Cliente cliente)
        {
            try
            {
                String sql = "INSERT INTO Endereco (Cidade, Cep, Bairro, Logradouro, Numero, Complemento, Cliente_Cpf, Empresa_Cnpj)" +
                      "VALUES" +
                      "('" + cliente.Endereco.Cidade + "'" + "," +
                      "'" + cliente.Endereco.Cep + "'" + "," +
                      "'" + cliente.Endereco.Bairro + "'" + "," +
                      "'" + cliente.Endereco.Logradouro + "'" + "," +
                      "'" + cliente.Endereco.Numero + "'" + "," +
                      "'" + cliente.Endereco.Complemento + "'" + "," +
                      "'" + cliente.Cpf + "'" + "," +
                      "null" + ")";

                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Obter Tabelas
        internal List<Cliente> ObterClientes()
        {
            IDataReader dr = null;
            List<Cliente> lista = new List<Cliente>();
            String sql = "SELECT * FROM Cliente";
            try
            {
                dr = dao.GetDataReader(sql);
                while (dr.Read())
                {
                    lista.Add(CarregarObjetoCliente(dr));
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
            }
        }

        internal List<Endereco> ObterEnderecos()
        {
            IDataReader dr = null;
            List<Endereco> listaEndereco = new List<Endereco>();
            String sql = "SELECT * FROM Endereco";
            try
            {
                dr = dao.GetDataReader(sql);
                while (dr.Read())
                {
                    listaEndereco.Add(CarregarObjetoEndereco(dr));
                }
                return listaEndereco;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
            }
        }

        #endregion

        #region Carregar Objetos
        public Cliente CarregarObjetoCliente(IDataReader dr)
        {
            return new Cliente()
            {
                Cpf = long.Parse(dr["CPF"].ToString().Trim()),
                Nome = Convert.ToString(dr["NOME"]),
                Sobrenome = Convert.ToString(dr["SOBRENOME"]),
                Email = Convert.ToString(dr["EMAIL"]),
                Senha = Convert.ToString(dr["SENHA"]),
            };
        }

        public Endereco CarregarObjetoEndereco(IDataReader dr)
        {
            return new Endereco()
            {
                Logradouro = Convert.ToString(dr["LOGRADOURO"]),
                Cep = int.Parse(dr["CEP"].ToString().Trim()),
                Cidade = Convert.ToString(dr["CIDADE"]),
                Bairro = Convert.ToString(dr["BAIRRO"]),
                Numero = int.Parse(dr["NUMERO"].ToString().Trim()),
                Complemento = Convert.ToString(dr["COMPLEMENTO"])
            };
        }
        #endregion
    }
}
