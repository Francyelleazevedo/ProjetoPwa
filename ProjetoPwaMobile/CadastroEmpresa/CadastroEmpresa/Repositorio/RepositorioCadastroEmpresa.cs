using CadastroEmpresa.Base;
using CadastroEmpresa.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEmpresa.Repositorio
{
    internal class RepositorioCadastroEmpresa
    {
        Dao dao = null;

        public RepositorioCadastroEmpresa(Dao dao)
        {
            this.dao = dao;
        }

        #region Inserts
        internal void InserirEmpresa(Empresa empresa)
        {
            try
            {
                String sql = "INSERT INTO Empresa (Cnpj, Nome, Senha, Telefone, Hora_func, Dia_func, Capacidade_total)" +
                      "VALUES" +
                      "('" + empresa.Cnpj + "'" + "," +
                      "'" + empresa.Nome + "'" + "," +
                      "'" + empresa.Senha + "'" + "," +
                      "'" + empresa.Telefone + "'" + "," +
                      "'" + empresa.HorarioFuncionamento + "'" + "," +
                      "'" + empresa.DiasFuncionamento + "'" + "," +
                      "'" + empresa.CapacidadeTotal + "')";

                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertEndereco(Empresa empresa)
        {
            try
            {
                String sql = "INSERT INTO Endereco (Cidade, Cep, Bairro, Logradouro, Numero, Complemento, Cliente_Cpf, Empresa_Cnpj)" +
                      "VALUES" +
                      "('" + empresa.Endereco.Cidade + "'" + "," +
                      "'" + empresa.Endereco.Cep + "'" + "," +
                      "'" + empresa.Endereco.Bairro + "'" + "," +
                      "'" + empresa.Endereco.Logradouro + "'" + "," +
                      "'" + empresa.Endereco.Numero + "'" + "," +
                      "'" + empresa.Endereco.Complemento + "'" + "," +
                      "null" + "," +
                      "'" + empresa.Cnpj + "')";

                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void InserirLotacao(Empresa empresa)
        {
            try
            {
                String sql = "INSERT INTO Lotacao (Empresa_Cnpj, Qtd_lugares, Data)" +
                      "VALUES" +
                      "('" + empresa.Cnpj + "'" + "," +
                      "'" + empresa.Lotacao.QuantidadeLugares + "'" + "," +
                      "'" + empresa.Lotacao.Data + "')";

                dao.Insert(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Gets

        internal long VerificarCnpj(string cnpj)
        {
            IDataReader dr = null;
            Empresa empresa = new Empresa(); 
            long retorno = 0;
            try
            {
                string sql = string.Format("SELECT Cnpj FROM Empresa WHERE Cnpj = " + cnpj);

                dr = dao.GetDataReader(sql);
                while (dr.Read())
                {
                    retorno = long.Parse(dr["CNPJ"].ToString().Trim());
                }
                return retorno;
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
        internal List<Empresa> ObterEmpresas()
        {
            IDataReader dr = null;
            List<Empresa> lista = new List<Empresa>();
            String sql = "SELECT * FROM Empresa";
            try
            {
                dr = dao.GetDataReader(sql);
                while (dr.Read())
                {
                    lista.Add(CarregarObjetoEmpresa(dr));
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
        #endregion

        #region Carregar Objetos
        internal Empresa CarregarObjetoEmpresa(IDataReader dr)
        {
            return new Empresa()
            {
                Cnpj = dr["CNPJ"].ToString().Trim(),
                Nome = dr["NOME"].ToString().Trim(),
                Telefone = long.Parse(dr["TELEFONE"].ToString().Trim()),
                HorarioFuncionamento = dr["HORA_FUNC"].ToString().Trim(),
                DiasFuncionamento = dr["DIA_FUNC"].ToString().Trim(),
                Senha = dr["SENHA"].ToString().Trim(),
                CapacidadeTotal = int.Parse(dr["CAPACIDADE_TOTAL"].ToString().Trim()),
            };
        }

        internal Empresa CarregarCnpj(IDataReader dr)
        {
            return new Empresa()
            {
                Cnpj = dr["CNPJ"].ToString().Trim(),
            };
        }
        #endregion
    }
}
