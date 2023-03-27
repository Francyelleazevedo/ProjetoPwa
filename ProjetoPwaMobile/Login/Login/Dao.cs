using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySqlConnector;
using System.Threading.Tasks;
using Login.Repositorio;

namespace Login
{
    internal class Dao
    {
        RepositorioLogin repositorio = null;
        public MySqlConnection conexao { get; set; } = new MySqlConnection(@"datasource=localhost;username=root;password=HdtJfe5oxq4XDP7AYpVY;database=railway;");
        public Dao()
        {
        }

        internal void Abrir() // se a conexão estiver fechada, abrir.
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void Fechar() // se a conexão estiver aberta, feche.
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal MySqlDataReader PegarEspecifico(string sql)
        {
            MySqlCommand command = null;
            try
            {

                command = new MySqlCommand(sql, conexao);

                return command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
            }
        }
        
    }
}
