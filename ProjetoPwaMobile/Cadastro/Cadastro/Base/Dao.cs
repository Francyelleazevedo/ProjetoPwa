using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro.Classes;
using MySqlConnector;

namespace Cadastro.Base
{
    internal class Dao
    {
        public MySqlConnection conexao { get; set; } = new MySqlConnection(@"data source=sql10.freemysqlhosting.net;username=sql10610547;password=YPrcBDSM73;database=sql10610547");
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

        //retorna a leitura do meu sql
        internal MySqlDataReader GetDataReader(string sql) //retorna leitura de banco
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

        // retorna um sql que vai pegar um codigo especifico
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

        //inserir valores no banco
        internal void Insert(string sql)
        {
            try
            {
                MySqlCommand command;
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                // executando o comando insert 
                command = new MySqlCommand(sql, conexao);

                adapter.InsertCommand = new MySqlCommand(sql, conexao);
                adapter.InsertCommand.ExecuteNonQuery();

                command.Dispose(); //fechar command
            }
            catch (Exception)
            {
                throw;
            }
        }


        ////deletando um dado 
        //internal void DeleteDataBase(String sql)
        //{
        //    try
        //    {

        //        SqlCommand command;
        //        SqlDataAdapter adapter = new SqlDataAdapter();

        //        command = new SqlCommand(sql, conexao);

        //        adapter.DeleteCommand = new SqlCommand(sql, conexao);
        //        adapter.DeleteCommand.ExecuteNonQuery();

        //        command.Dispose(); //fechar command
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        ////atualizar um dado no banco
        //internal void UpdateDataBase(string id, string nome, string dataNascimento, int idGenero, int idParentesco, FamiliaFrancyelle familia)
        //{
        //    try
        //    {
        //        SqlCommand command;
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        String sql = "";

        //        sql = "UPDATE FrancyelleFamilia SET " +
        //        "Nome_Familiar='" + nome + "'," +
        //        "Data_Nascimento='" + dataNascimento + "'," +
        //        "Id_Genero='" + idGenero + "'," +
        //        /*"Tipo_Genero='" + familia.Genero.TipoGenero + "'," +*/
        //        "Id_Parentesco='" + idParentesco /*+ "',"*/ +
        //        /*"Tipo_Parentesco='" + familia.Parentesco.TipoParentesco +*/
        //        "'WHERE Id_Familia='" + id + "'";

        //        // executando o comando update 
        //        command = new SqlCommand(sql, conexao);

        //        adapter.UpdateCommand = new SqlCommand(sql, conexao);
        //        adapter.UpdateCommand.ExecuteNonQuery();

        //        command.Dispose(); //fechar command
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //internal void ObterHero() //só trás um unico campo
        //{
        //    try
        //    {
        //        SqlCommand command;
        //        SqlDataAdapter adapter = new SqlDataAdapter();
        //        String sql = "";

        //        sql = "Insert";

        //        command = new SqlCommand(sql, conexao);

        //        adapter.InsertCommand = new SqlCommand(sql, conexao);
        //        adapter.InsertCommand.ExecuteScalar();

        //        command.Dispose(); //fechar o command
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
