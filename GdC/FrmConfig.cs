using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GdC
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        enum pnls
        {
            Backup,Bd
        }

        private void pnlLocation(Point l)
        {
            pnlCbackup.Location = l;
            pnlCBd.Location = l;
        }

        private void pnlVisible(pnls pnl)
        {
            pnlCbackup.Visible = false;
            pnlCBd.Visible = false;

            switch (pnl)
            {
                case pnls.Backup:
                    pnlCbackup.Visible = true;
                    break;
                case pnls.Bd:
                    pnlCBd.Visible = true;
                    break;
            }
        }

        private void BackupPnl()
        {
            pnlVisible(pnls.Backup);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            Point local = new Point(3, 3);
            pnlLocation(local);
        }

        private void trvCmenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodeCollection nodes = trvCmenu.Nodes;
            if (nodes[0].IsSelected)
            {
                BackupPnl();
            }
            else if (nodes[1].IsSelected)
            {
                pnlVisible(pnls.Bd);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ConfigMngr config = new ConfigMngr();

            config.BackupFolder = tbDirBack.Text;
            config.BackupTime = nmrHora.Value + ":" + nmrMin.Value;
            config.BackupEnable = cbEnable.Checked;
            config.MysqlFolder = tbMysqlDir.Text;
            config.BackupFrequency = checkFreq();
            config.BackupDay = dtpA.Text.Split('/')[0];
            config.BackupMonth = dtpA.Text.Split('/')[1];
            config.BackupDofW = dtpW.Text;

            try
            {
                config.UpdateFile();
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro: " + err.Message + "\n\nDetalhes:\n" + err, "Erro");
            }
        }

        private void pnlsConfig_VisibleChanged(object sender, EventArgs e)
        {
            ConfigMngr config = new ConfigMngr();

            tbDirBack.Text = config.BackupFolder;
            nmrHora.Value = int.Parse(config.BackupTime.Split(':')[0]);
            nmrMin.Value = int.Parse(config.BackupTime.Split(':')[1]);
            cbEnable.Checked = config.BackupEnable;
            tbMysqlDir.Text = config.MysqlFolder;
            cbFreq.Text = CbFreqText(config.BackupFrequency);
            dtpA.Text = config.BackupDay + '/' + config.BackupMonth;
        }

        private string CbFreqText(char c)
        {
            string retorno = null;
            switch (c)
            {
                case 'D':
                    retorno = "Diario";
                    break;
                case 'W':
                    retorno = "Semanal";
                    break;
                case 'Q':
                    retorno = "Quinzenal";
                    break;
                case 'M':
                    retorno = "Mensal";
                    break;
                case 'Y':
                    retorno = "Anual";
                    break;
            }

            return retorno;
        }

        private char checkFreq()
        {
            char ch = '-';

            switch (cbFreq.Text)
            {
                case "Anual":
                    ch = 'A';
                    break;
                case "Mensal":
                    ch = 'M';
                    break;
                case "Quinzenal":
                    ch = 'Q';
                    break;
                case "Semanal":
                    ch = 'W';
                    break;
                case "Diario":
                    ch = 'D';
                    break;
            }

            return ch;
        }

        private void FrmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain frm = new FrmMain();
            frm.tmr.Start();
        }

        private void btnDirBack_Click(object sender, EventArgs e)
        {
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbDirBack.Text = fbd1.SelectedPath;
            }
        }

        private void btnDoBackup_Click(object sender, EventArgs e)
        {
            BackupMngr backup = new BackupMngr();
            backup.backupDb();
        }

        private void btnMysqlDir_Click(object sender, EventArgs e)
        {
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                tbMysqlDir.Text = fbd1.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpY.Enabled = false;
            grpWeQ.Enabled = false;
            grpM.Enabled = false;
            grpD.Enabled = false;

            switch (cbFreq.Text)
            {
                case "Anual":
                    grpY.Enabled = true;
                    break;
                case "Mensal":
                    grpM.Enabled = true;
                    break;
                case "Quinzenal":
                    grpWeQ.Enabled = true;
                    break;
                case "Semanal":
                    grpWeQ.Enabled = true;
                    break;
                case "Diario":
                    grpD.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            ConfigMngr config = new ConfigMngr();

            config.BackupFolder = tbDirBack.Text;
            config.BackupTime = nmrHora.Value + ":" + nmrMin.Value;
            config.BackupEnable = cbEnable.Checked;
            config.MysqlFolder = tbMysqlDir.Text;
            config.BackupFrequency = checkFreq();
            config.BackupDay = dtpA.Text.Split('/')[0];
            config.BackupMonth = dtpA.Text.Split('/')[1];
            config.BackupDofW = dtpW.Text;

            try
            {
                config.UpdateFile();
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro: " + err.Message + "\n\nDetalhes:\n" + err, "Erro");
            }
        }
    }
}
