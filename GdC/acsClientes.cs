using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace GdC
{
    class acsClientes
    {
        public enum Fields
        {
            Nome,CPF,Telefone,Celular,Email,Rua,Complemento,Numero,Bairro,Cidade,Uf,CEP,Aniversario,Obs
        }

        string _Nome, _CPF, _Telefone, _Celular, _Email,
               _Rua, _Complemento, _Numero, _Bairro,
               _Cidade, _UF, _CEP, _Aniversario, _Observacoes;

        #region "Variaveis encapsuladas"
        public string Nome
        {
            get
            {
                return _Nome;
            }

            set
            {
                _Nome = value;
            }
        }

        public string CPF
        {
            get
            {
                return _CPF;
            }

            set
            {
                _CPF = value;
            }
        }

        public string Telefone
        {
            get
            {
                return _Telefone;
            }

            set
            {
                _Telefone = value;
            }
        }

        public string Celular
        {
            get
            {
                return _Celular;
            }

            set
            {
                _Celular = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Rua
        {
            get
            {
                return _Rua;
            }

            set
            {
                _Rua = value;
            }
        }

        public string Complemento
        {
            get
            {
                return _Complemento;
            }

            set
            {
                _Complemento = value;
            }
        }

        public string Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                _Numero = value;
            }
        }

        public string Bairro
        {
            get
            {
                return _Bairro;
            }

            set
            {
                _Bairro = value;
            }
        }

        public string Cidade
        {
            get
            {
                return _Cidade;
            }

            set
            {
                _Cidade = value;
            }
        }

        public string UF
        {
            get
            {
                return _UF;
            }

            set
            {
                _UF = value;
            }
        }

        public string CEP
        {
            get
            {
                return _CEP;
            }

            set
            {
                _CEP = value;
            }
        }

        public string Aniversario
        {
            get
            {
                return _Aniversario;
            }

            set
            {
                _Aniversario = value;
            }
        }

        public string Observacoes
        {
            get
            {
                return _Observacoes;
            }

            set
            {
                _Observacoes = value;
            }
        }
        #endregion
        
        //variaveis Mysql
        MySqlDataAdapter adpt;
        MySqlCommandBuilder cmdb;
        DataTable table;

        public DataTable Table
        {
            get { return table; }
            set { table = value; }
        }

        private void LoadTable(String _cmd)
        {
            table = new DataTable();
            adpt = new MySqlDataAdapter(_cmd, Connect.Conn);
            cmdb = new MySqlCommandBuilder(adpt);
            adpt.Fill(table);
        }

        public bool Insert(string nome, string cpf, string telefone, string celular,
                           string email, string rua, string complemento, string numero,
                           string bairro, string cidade, string uf, string cep,
                           string aniversario, string observacao)
        {
            try {
                LoadTable("INSERT INTO Clientes (Nome, CPF, Telefone, Celular, Email, Rua, Complemento, Numero, Bairro, Cidade, UF, CEP, Aniversario, Observacoes)" +
                          "VALUES('" + nome + "', '" + cpf + "', '" + telefone + "', '" + celular +
                          "', '" + email + "', '" + rua + "', '" + complemento + "', '" + numero +
                          "', '" + bairro + "', '" + cidade + "', '" + uf + "', '" + cep + "', '" +
                          aniversario + "', '" + observacao + "')");
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public bool Update(string nome, string cpf, string telefone, string celular,
                           string email, string rua, string complemento, string numero,
                           string bairro, string cidade, string uf, string cep,
                           string aniversario, string observacao, string cod)
        {
            try
            {
                LoadTable("UPDATE Clientes SET Nome = '" + nome + "', CPF = '" + cpf +
                          "', Telefone = '" + telefone + "', Celular = '" + celular + "', Email = '" + email +
                          "', Rua = '" + rua + "', Complemento = '" + complemento + "', Numero = '" + numero +
                          "', Bairro = '" + bairro + "', Cidade = '" + cidade + "', UF = '" + uf +
                          "', CEP = '" + cep + "', Aniversario = '" + aniversario + "', Observacoes = '" + observacao +
                          "' WHERE ClienteID = '" + cod + "'");
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        public DataTable ListAll()
        {
            LoadTable("SELECT ClienteID AS Cod, Nome, CPF, Telefone, Celular, Email,  Aniversario as Aniversário, Rua AS Logradouro, Numero AS Número, Complemento, Bairro, Cidade, UF, CEP FROM Clientes");
            return table;
        }
        
        public DataTable ShowGrid(string sql, string parameter)
        {
            DataTable Dt = new DataTable();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, Connect.Conn);
                cmd.Parameters.AddWithValue("@VALOR", parameter);
                MySqlDataAdapter DataAdapter = new MySqlDataAdapter(cmd);

                DataAdapter.Fill(Dt);

                return Dt;
            }
            catch (MySqlException Erro)
            {
                throw Erro;
            }
        }

        public List<string> ReturnList(Fields fld)
        {
            List<string> lst = new List<string>();
            string cmd, campo;

            #region "SqlBuilder"
            campo = "";
            cmd = "SELECT ";
            switch (fld)
            {
                case Fields.Nome:
                    campo = "Nome";
                    break;
                case Fields.CPF:
                    campo = "CPF";
                    break;
                case Fields.Telefone:
                    campo = "Telefone";
                    break;
                case Fields.Celular:
                    campo = "Celular";
                    break;
                case Fields.Email:
                    campo = "Email";
                    break;
                case Fields.Rua:
                    campo = "Rua";
                    break;
                case Fields.Complemento:
                    campo = "Complemento";
                    break;
                case Fields.Numero:
                    campo = "Numero";
                    break;
                case Fields.Bairro:
                    campo = "Bairro";
                    break;
                case Fields.Cidade:
                    campo = "Cidade";
                    break;
                case Fields.Uf:
                    campo = "Uf";
                    break;
                case Fields.CEP:
                    campo = "CEP";
                    break;
                case Fields.Aniversario:
                    campo = "Aniversario";
                    break;
                case Fields.Obs:
                    campo = "Observacoes";
                    break;
            }

            cmd += campo + " FROM Clientes";
            #endregion

            LoadTable(cmd);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                lst.Add(table.Rows[i][campo].ToString());
            }

            return lst;
        }

        public bool Select(string cod)
        {
            LoadTable("SELECT Nome, CPF, Telefone, Celular, Email,  Aniversario, " +
                      "Rua, Numero, Complemento, Bairro, Cidade, UF, CEP, Observacoes " + 
                      "FROM Clientes WHERE ClienteID = " + cod + ";");

            if (table.Rows.Count != 0)
            {
                Nome = table.Rows[0]["Nome"].ToString();
                CPF = table.Rows[0]["CPF"].ToString();
                Telefone = table.Rows[0]["Telefone"].ToString();
                Celular = table.Rows[0]["Celular"].ToString();
                Email = table.Rows[0]["Email"].ToString();
                Aniversario = table.Rows[0]["Aniversario"].ToString();
                Rua = table.Rows[0]["Rua"].ToString();
                Numero = table.Rows[0]["Numero"].ToString();
                Complemento = table.Rows[0]["Complemento"].ToString();
                Bairro = table.Rows[0]["Bairro"].ToString();
                Cidade = table.Rows[0]["Cidade"].ToString();
                UF = table.Rows[0]["UF"].ToString();
                CEP = table.Rows[0]["CEP"].ToString();
                Observacoes = table.Rows[0]["observacoes"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string _Cod)
        {
            try
            {
                LoadTable("DELETE FROM Clientes WHERE ClienteID = '" + _Cod + "';");
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}
