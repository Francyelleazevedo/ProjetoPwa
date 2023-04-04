using Cadastro.Base;
using Cadastro.Classes;
using System;
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
                String sql = "INSERT INTO Cliente (Cpf, Nome, Sobrenome, Email, Senha, Endereco_id_Endereco)" +
                      "VALUES" +
                      "('" + cliente.Cpf + "'" + "," +
                      "'" + cliente.Nome + "'" + "," +
                      "'" + cliente.Sobrenome + "'" + "," +
                      "'" + cliente.Email + "'" + "," +
                      "'" + cliente.Senha + "'" + "," +
                      "'" + cliente.Endereco.Id + "')";

                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

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

               Endereco = new Endereco()
               {
                   Id = int.Parse(dr["ENDERECO_ID_ENDERECO"].ToString().Trim()),
               }

            };
        }
        #endregion
    }
}
