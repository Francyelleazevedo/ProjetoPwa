using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Classes;


namespace Login.Repositorio
{
    internal class RepositorioLogin
    {
        Dao dao = null;

        public RepositorioLogin(Dao dao)
        {
            this.dao = dao;
        }

        internal List<LoginUsuario> ObterLoginEmpresa()
        {
            IDataReader dr = null;
            List<LoginUsuario> lista = new List<LoginUsuario>();
            String sql = "SELECT Cnpj, Senha FROM Empresa";
            try
            {
                dr = dao.PegarEspecifico(sql);
                while (dr.Read())
                {
                    lista.Add(CarregarObjeto(dr));
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

        public int VerificarCnpj(string cnpj)
        {
            String sql = "SELECT COUNT(Cnpj) FROM Empresa WHERE Cnpj =" + cnpj;
            int retorno = 0;
            try
            {
                IDataReader dr = null;
                dr = dao.GetCnpj(sql);

                while (dr.Read())
                {
                     retorno = Convert.ToInt16(dr["CNPJ"]);
                }
                
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Carregar Objetos
        public LoginUsuario CarregarObjeto(IDataReader dr)
        {
            return new LoginUsuario()
            {
                EmailouCnpj = Convert.ToString(dr["CNPJ"]),
                Senha = Convert.ToString(dr["SENHA"])
            };
        }
        #endregion
    }
}



