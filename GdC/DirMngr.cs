using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace GdC
{
    class DirMngr
    {
        static string dir = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        static string user = Environment.UserName;

        public static string User
        {
            get { return user; }
        }

        public static string Dir
        {
            get { return dir; }
        }
        private string path, dirpath;
        public enum Dirt
        {
            file, folder
        }

        #region "Construtor da classe"
        public DirMngr(string path)
        {
            this.path = path;
            this.dirpath = dpgen(path);
            CreateDir();
            CreateFile();
        }

        public DirMngr()
        {

        }
        #endregion

        private string dpgen(string path)
        {
            string retorno = "";
            string[] sptpath = path.Split(char.Parse(@"\"));

            for (int i = 0; i < sptpath.Length - 1; i++)
            {
                retorno += sptpath[i] + @"\";
            }

            return retorno;
        }

        #region "CreateDir"
        /// <summary>
        /// cria um diretorio
        /// </summary>
        /// <returns></returns>
        public bool CreateDir()
        {
            try
            {
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// cria um diretorio
        /// </summary>
        /// <returns></returns>
        public bool CreateDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion
        
        /// <summary>
        /// Cria um arquivo
        /// </summary>
        /// <returns></returns>
        public bool CreateFile()
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Close();
                }
                else
                {
                    CreateDir();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #region "AppendText"
        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string str)
        {
            string[] stra = new string[] { str };
            CreateDir();
            System.IO.File.AppendAllLines(path, stra);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(string[] str)
        {
            CreateDir();
            System.IO.File.AppendAllLines(path, str);
        }

        /// <summary>
        /// cria e/ou anexa strings para um arquivo
        /// </summary>
        /// <param name="str"></param>
        public void AppendText(List<string> str)
        {
            CreateDir();
            System.IO.File.AppendAllLines(path, str);
        }
        #endregion

        /// <summary>
        /// lê todo um documento em um List<string>
        /// </summary>
        /// <returns></returns>
        public List<string> ReadAll()
        {
            List<string> retorno = new List<string>();
            if (!System.IO.File.Exists(this.path))
            {
                System.IO.File.Create(this.path).Close();
                return null;
            }
            retorno.AddRange(System.IO.File.ReadLines(this.path));

            return retorno;
        }

        /// <summary>
        /// reescreve uma linha especifica de um arquivo
        /// </summary>
        /// <param name="line">linha para ser editada</param>
        /// <param name="New">novo valor da linha</param>
        public void Rewrite(int line, string New)
        {

            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            List<string> lines = new List<string>();

            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            reader.Close();
            lines[line] = New;
            System.IO.File.WriteAllLines(path, lines);
        }

        /// <summary>
        /// Roda um comando no cmd
        /// </summary>
        /// <param name="cmds"></param>
        public void runCmd(List<string> cmds)
        {
            StringBuilder command = new StringBuilder();
            foreach (string str in cmds)
            {
                command.Append(str + Environment.NewLine);
            }

            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                //CreateNoWindow = true,
                RedirectStandardInput = true,
            };
            Process proc = new Process() { StartInfo = psi };

            proc.Start();

            proc.StandardInput.Write(command.ToString());

            proc.WaitForExit();
            proc.Close();
        }
    }
}
