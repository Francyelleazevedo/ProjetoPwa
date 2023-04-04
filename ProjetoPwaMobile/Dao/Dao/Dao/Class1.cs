using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroEmpresa.Classes;
using Cadastro.Classes;
using MySqlConnector;

namespace Dao.Base
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
        //internal MySqlDataReader GetDataReader() //retorna leitura de banco
        //{
        //    String sql = "SELECT f.Id_Familia, f.Nome_Familiar, f.Data_Nascimento,  g.Id_Genero, " +
        //        "g.Tipo_Genero, p.Id_Parentesco, p.Tipo_Parentesco from FrancyelleFamilia f " +
        //        "inner join GeneroFrancyelle g on g.Id_Genero = f.Id_Genero " +
        //        "inner join ParentescoFrancyelle p on p.Id_Parentesco = f.Id_Parentesco";

        //    SqlCommand command = null;
        //    try
        //    {
        //        command = new MySqlCommand(sql, conexao);

        //        return command.ExecuteReader();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        command.Dispose();
        //    }
        //}
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
        internal void InsertDataBase(Cliente cliente)
        {
            try
            {
                MySqlCommand command;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                String sql = "";

                sql = "INSERT INTO cliente (Cpf, Nome, Sobrenome, Email, Senha, Endereco_id_Endereco)" +
                      "VALUES" +
                      "('" + cliente.Cpf + "'" + "," +
                      "'" + cliente.Nome + "'" + "," +
                      "'" + cliente.Sobrenome + "'" + "," +
                      "'" + cliente.Email + "'" + "," +
                      "'" + cliente.Senha + "'" + "," +
                      "'" + cliente.Endereco.Id + "')";

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


