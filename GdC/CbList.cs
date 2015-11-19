using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace GdC
{
    class CbList
    {
        public List<string> listUf()
        {
            string vsql = "SELECT Uf FROM Estado";

            MySqlCommand cmd = null;
            List<string> Uf = new List<string>();

            try
            {
                cmd = new MySqlCommand(vsql, Connect.Conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uf.Add(reader["Uf"].ToString());
                }
                reader.Close();

                return Uf;
            }
            catch (MySqlException Erro)
            {
                throw Erro;
            }
        }

        public List<string> listCity(string _Uf)
        {
            string vsql = "SELECT Nome FROM Cidade WHERE Uf = '" + _Uf + "'";

            MySqlCommand cmd = null;
            List<string> Cities = new List<string>();

            try
            {
                cmd = new MySqlCommand(vsql, Connect.Conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cities.Add(reader["Nome"].ToString());
                }
                reader.Close();

                return Cities;
            }
            catch (MySqlException Erro)
            {
                throw Erro;
            }
        }
    }
}
