using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GdC
{
    class ConfigMngr
    {
        DirMngr dirmngr;
        List<string> Param = new List<string>();
        int ln;

        public ConfigMngr()
        {
            dirmngr = new DirMngr(DirMngr.Dir + @"\Config(" + DirMngr.User + ").ini");
            LoadConfig();
        }

        /// <summary>
        /// Checa se a linha é comentada ou não, se define comentada por se iniciar por "#"
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool isComment(string line)
        {
            if (line == "")
            {
                return true;
            }
            for (int i = 0; i < line.Length; i++)
            {
                if (line.Substring(i, 1) == "#")
                {
                    return true;
                }
                else if (line.Substring(i, 1) != " ")
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Acha a linha da primeira ocorrencia da string de procura no arquivo
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private string FindinFile(string Search)
        {
            List<string> Lines = dirmngr.ReadAll();

            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Split('=')[0] == Search)
                {
                    ln = i;
                    return Lines[i].Split('=')[1];
                }
            }
            return null;
        }

        /// <summary>
        /// Faz a mesma função do "indexOf", fiz pq não sabia que existia... MAS também retorna o valor do parametro
        /// </summary>
        /// <param name="Search"></param>
        /// <returns></returns>
        private string Find(string Search)
        {
            for (int i = 0; i < Param.Count; i++)
            {
                if (Param[i].Split('=')[0] == Search)
                {
                    ln = i;
                    return Param[i].Split('=')[1];
                }
            }
            return null;
        }

        /// <summary>
        /// Loada o arquivo e carrega os parametros do arquivo nos parametros da classe
        /// </summary>
        public void LoadConfig()
        {
            Param = dirmngr.ReadAll();

            for (int i = 0; i < Param.Count; i++)
            {
                if (isComment(Param[i]))
                {
                    Param.RemoveAt(i);
                    i--;
                }
            }

            FnUVariable("backupFolder", ref backupFolder);
            FnUVariable("backupTime", ref backupTime);
            FnUVariable("backupEnable", ref backupEnable);
            FnUVariable("mysqlFolder", ref mysqlFolder);
            FnUVariable("backupFrequency", ref backupFrequency);
            FnUVariable("backupDay", ref backupDay);
            FnUVariable("backupMonth", ref backupMonth);
            FnUVariable("backupDofW", ref backupDofW);
            FnUVariable("didHappened", ref didHappened);
        }
        #region "FnUVariables"
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref string param)
        {
            if (Find(str) != null)
            {
                param = Find(str);
            }
        }
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref char param)
        {
            if (Find(str) != null)
            {
                param = char.Parse(Find(str));
            }
        }
        /// <summary>
        /// Acha e atualiza a variavel do parametro
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnUVariable(string str, ref bool param)
        {
            if (Find(str) != null)
            {
                param = bool.Parse(Find(str));
            }
        } 
        #endregion

        /// <summary>
        /// Dá um update no arquivo inteiro, muda o arquivo pelos parametros da classe
        /// </summary>
        public void UpdateFile()
        {
            dirmngr.CreateFile();

            FnRParam("backupFolder", backupFolder);
            FnRParam("backupTime", backupTime);
            FnRParam("backupEnable", backupEnable);
            FnRParam("mysqlFolder", mysqlFolder);
            FnRParam("backupFrequency", backupFrequency);
            FnRParam("backupDay", backupDay);
            FnRParam("backupMonth", backupMonth);
            FnRParam("backupDofW", BackupDofW); 
            FnRParam("didHappened", didHappened);
        }
        #region "FnRParam"
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, string param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, bool param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        /// <summary>
        /// Acha o parametro se existir atualiza ele, se não existir cria
        /// </summary>
        /// <param name="str"></param>
        /// <param name="param"></param>
        private void FnRParam(string str, char param)
        {
            if (Find(str) != null)
            {
                FindinFile(str);
                dirmngr.Rewrite(ln, str + "=" + param);
            }
            else
            {
                dirmngr.AppendText(str + "=" + param);
            }
        }
        #endregion

        /// <summary>
        /// dá um update no arquivo de config no parametros desejado
        /// </summary>
        /// <param name="config"></param>
        public void UpdateParam(string config)
        {
            string param = config.Split('=')[0];

            dirmngr.CreateFile();
            if (Find(param) != null)
            {
                FindinFile(param);
                dirmngr.Rewrite(ln, config);
            }
        }

        //parametros
        string backupFolder = DirMngr.Dir + "Backup-Sql";
        string backupTime = "12:0";
        bool backupEnable = true;
        bool didHappened = false;
        char backupFrequency = 'M';
        string backupDay = "1";
        string backupMonth = "1";
        string backupDofW = "segunda-feira";
        string mysqlFolder = @"C:\Program Files\MySQL\MySQL Server 5.7";

        public string BackupFolder
        {
            get
            {
                return backupFolder;
            }

            set
            {
                backupFolder = value;
            }
        }

        public string BackupTime
        {
            get
            {
                return backupTime;
            }

            set
            {
                backupTime = value;
            }
        }

        public bool BackupEnable
        {
            get
            {
                return backupEnable;
            }

            set
            {
                backupEnable = value;
            }
        }

        public string MysqlFolder
        {
            get
            {
                return mysqlFolder;
            }

            set
            {
                mysqlFolder = value;
            }
        }

        public char BackupFrequency
        {
            get
            {
                return backupFrequency;
            }

            set
            {
                backupFrequency = value;
            }
        }

        public string BackupDay
        {
            get
            {
                return backupDay;
            }

            set
            {
                backupDay = value;
            }
        }

        public string BackupMonth
        {
            get
            {
                return backupMonth;
            }

            set
            {
                backupMonth = value;
            }
        }

        public string BackupDofW
        {
            get
            {
                return backupDofW;
            }

            set
            {
                backupDofW = value;
            }
        }

        public bool DidHappened
        {
            get
            {
                return didHappened;
            }

            set
            {
                didHappened = value;
            }
        }
    }
}
