using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GdC
{
    abstract class Connect
    {
        static MySqlConnection conn;
        static string 
            user = "vsDb", 
            server = "127.0.0.1", 
            password = "vsDb@612", 
            database = "GdC";

        public static MySqlConnection Conn
        {
            get { return Connect.conn; }
            set { Connect.conn = value; }
        }

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static string Server
        {
            get { return server; }
            set { server = value; }
        }

        public static string User
        {
            get { return user; }
            set { user = value; }
        }

        public static string Database
        {
            get { return database; }
            set { database = value; }
        }

        /// <summary>
        /// Cria uma conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public static bool CreateConn()
        {
            if (conn != null)
            {
                conn.Clone();
            }

            string ConnStr = string.Format("server={0};user id={1}; password={2};database=mysql; pooling=false", server, user, password);

            try
            {
                conn = new MySqlConnection(ConnStr);
                conn.Open();
            }
            catch (MySqlException)
            {
                try
                {
                    ConnStr = string.Format("server={0};user id={1}; password={2};database=mysql; pooling=false", "127.0.0.1", "root", "");
                    conn = new MySqlConnection(ConnStr);
                    conn.Open();
                }
                catch (MySqlException ERRO)
                {
                    throw ERRO;
                }
            }

            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand("USE " + database, conn);

            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException ERRO)
            {
                throw ERRO;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return true;
        }
    }
}
