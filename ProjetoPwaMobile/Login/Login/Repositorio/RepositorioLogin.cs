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
            String sql = "SELECT CNPJ, SENHA FROM EMPRESA";
            try
            {
                dr = dao.GetDataReader(sql);
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

        public LoginUsuario CarregarObjeto(IDataReader dr)
        {
            return new LoginUsuario()
            {
                EmailouCnpj = Convert.ToString(dr["CNPJ"]),
                Senha = Convert.ToString(dr["SENHA"])
            };
        }
    }
}



