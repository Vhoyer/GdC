using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdC
{
    class BackupMngr
    {
        string erro;

        DirMngr dirmngr;
        ConfigMngr config;
        string date;

        public string Erro
        {
            get
            {
                return erro;
            }

            set
            {
                erro = value;
            }
        }

        private void Data()
        {
            date = DateTime.Today.ToString("d");
            string[] dma = date.Split('/');
            date = dma[0] + "-" + dma[1] + "-" + dma[2];
        }

        public BackupMngr()
        {
            config = new ConfigMngr();
        }

        /// <summary>
        /// separa os campos do cliente, e retorna a linha de sql para dar um insert nesse cliente
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string sqlcmd(string info)
        {
            string[] array = info.Split('[');
            string retorno = "INSERT INTO Clientes (Nome, CPF, Telefone, Celular, Email, Rua, Complemento, Numero, Bairro, Cidade, UF, CEP, Aniversario, Observacoes) VALUES('";

            for (int i = 0; i < array.Length-1; i++)
            {
                retorno += array[i] + "', '";
            }
            retorno += array[array.Length-1] + "');\n";
            return retorno;
        }

        /// <summary>
        /// cria e/ou adiciona linhas a um arquivo .sql para backup
        /// </summary>
        /// <param name="content">campos do clientes separados por "[" numa unica string</param>
        public void backup(string content)
        {
            Data();
            config = new ConfigMngr();

            dirmngr = new DirMngr(config.BackupFolder + @"\backup" + date + ".sql");

            content = sqlcmd(content);

            dirmngr.AppendText(content);
        }

        /// <summary>
        /// Faz o backup do banco de dados inteiro
        /// </summary>
        public void backupDb()
        {
            Data();
            dirmngr = new DirMngr(config.BackupFolder + @"\Dumps\");

            List<string> cmdLst = new List<string>();
            cmdLst.Add("echo off");
            cmdLst.Add("cd " + '"' + config.MysqlFolder + @"\bin" + '"');
            cmdLst.Add(
                "mysqldump -u " + Connect.User +
                " -p" + Connect.Password +
                " -x -e -B " + Connect.Database +
                " > " + '"' + config.BackupFolder + @"\Dumps\dumpGdcBackup" + date + ".sql" + '"'
                );

            dirmngr.CreateDir();

            DirMngr.runCmdExit(cmdLst);
        }

        public void restoreDb()
        {
            string file;
            List<string> cmdLst = new List<string>();
            System.Windows.Forms.OpenFileDialog opn = new System.Windows.Forms.OpenFileDialog()
            {
                DefaultExt = "sql",
                InitialDirectory = config.BackupFolder + @"\Dumps",
                Filter = "SQL script|*.sql"
            };

            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    file = opn.FileName;

                    cmdLst.Add("echo off");
                    cmdLst.Add("cd " + '"' + config.MysqlFolder + @"\bin" + '"');
                    cmdLst.Add(
                        "mysql -u " + Connect.User +
                        " -p" + Connect.Password +
                        " --database=" + Connect.Database +
                        " < " + '"' + file + '"'
                        );

                    DirMngr.runCmdExit(cmdLst);

                    System.Windows.Forms.MessageBox.Show("Banco de dados restaurado com sucesso", "Restauração", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    System.Windows.Forms.MessageBox.Show("Erro: " + err.Message, "Restauração", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
    }
}
