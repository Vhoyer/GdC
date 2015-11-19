namespace GdC
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Backup");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Banco de Dados");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.sptConfig = new System.Windows.Forms.SplitContainer();
            this.trvCmenu = new System.Windows.Forms.TreeView();
            this.flpBackup = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCbackup = new System.Windows.Forms.Panel();
            this.grpFreq = new System.Windows.Forms.GroupBox();
            this.grpWeQ = new System.Windows.Forms.GroupBox();
            this.lblW = new System.Windows.Forms.Label();
            this.dtpW = new System.Windows.Forms.DateTimePicker();
            this.grpM = new System.Windows.Forms.GroupBox();
            this.lblM = new System.Windows.Forms.Label();
            this.dtpM = new System.Windows.Forms.DateTimePicker();
            this.grpY = new System.Windows.Forms.GroupBox();
            this.lblA = new System.Windows.Forms.Label();
            this.dtpA = new System.Windows.Forms.DateTimePicker();
            this.lblFreq = new System.Windows.Forms.Label();
            this.cbFreq = new System.Windows.Forms.ComboBox();
            this.grpD = new System.Windows.Forms.GroupBox();
            this.nmrHora = new System.Windows.Forms.NumericUpDown();
            this.lnlmin = new System.Windows.Forms.Label();
            this.nmrMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDoBackup = new System.Windows.Forms.Button();
            this.cbEnable = new System.Windows.Forms.CheckBox();
            this.btnDirBack = new System.Windows.Forms.Button();
            this.tbDirBack = new System.Windows.Forms.TextBox();
            this.lblDirBack = new System.Windows.Forms.Label();
            this.pnlCBd = new System.Windows.Forms.Panel();
            this.btnMysqlDir = new System.Windows.Forms.Button();
            this.tbMysqlDir = new System.Windows.Forms.TextBox();
            this.lblMysqlDir = new System.Windows.Forms.Label();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.sptConfig)).BeginInit();
            this.sptConfig.Panel1.SuspendLayout();
            this.sptConfig.Panel2.SuspendLayout();
            this.sptConfig.SuspendLayout();
            this.flpBackup.SuspendLayout();
            this.pnlCbackup.SuspendLayout();
            this.grpFreq.SuspendLayout();
            this.grpWeQ.SuspendLayout();
            this.grpM.SuspendLayout();
            this.grpY.SuspendLayout();
            this.grpD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMin)).BeginInit();
            this.pnlCBd.SuspendLayout();
            this.SuspendLayout();
            // 
            // sptConfig
            // 
            this.sptConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptConfig.Location = new System.Drawing.Point(0, 0);
            this.sptConfig.Name = "sptConfig";
            // 
            // sptConfig.Panel1
            // 
            this.sptConfig.Panel1.Controls.Add(this.trvCmenu);
            // 
            // sptConfig.Panel2
            // 
            this.sptConfig.Panel2.Controls.Add(this.flpBackup);
            this.sptConfig.Panel2.Controls.Add(this.pnlCbackup);
            this.sptConfig.Panel2.Controls.Add(this.pnlCBd);
            this.sptConfig.Size = new System.Drawing.Size(676, 417);
            this.sptConfig.SplitterDistance = 152;
            this.sptConfig.TabIndex = 0;
            // 
            // trvCmenu
            // 
            this.trvCmenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvCmenu.Location = new System.Drawing.Point(0, 0);
            this.trvCmenu.Name = "trvCmenu";
            treeNode1.Name = "NdBackup";
            treeNode1.Text = "Backup";
            treeNode2.Name = "ndBd";
            treeNode2.Text = "Banco de Dados";
            this.trvCmenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.trvCmenu.ShowRootLines = false;
            this.trvCmenu.Size = new System.Drawing.Size(152, 417);
            this.trvCmenu.TabIndex = 0;
            this.trvCmenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCmenu_AfterSelect);
            // 
            // flpBackup
            // 
            this.flpBackup.Controls.Add(this.btnSalvar);
            this.flpBackup.Controls.Add(this.btnClose);
            this.flpBackup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpBackup.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBackup.Location = new System.Drawing.Point(0, 373);
            this.flpBackup.Name = "flpBackup";
            this.flpBackup.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.flpBackup.Size = new System.Drawing.Size(520, 44);
            this.flpBackup.TabIndex = 4;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(427, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(346, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCbackup
            // 
            this.pnlCbackup.Controls.Add(this.grpFreq);
            this.pnlCbackup.Controls.Add(this.btnDoBackup);
            this.pnlCbackup.Controls.Add(this.cbEnable);
            this.pnlCbackup.Controls.Add(this.btnDirBack);
            this.pnlCbackup.Controls.Add(this.tbDirBack);
            this.pnlCbackup.Controls.Add(this.lblDirBack);
            this.pnlCbackup.Location = new System.Drawing.Point(3, 3);
            this.pnlCbackup.Name = "pnlCbackup";
            this.pnlCbackup.Size = new System.Drawing.Size(514, 367);
            this.pnlCbackup.TabIndex = 0;
            this.pnlCbackup.VisibleChanged += new System.EventHandler(this.pnlsConfig_VisibleChanged);
            // 
            // grpFreq
            // 
            this.grpFreq.Controls.Add(this.grpWeQ);
            this.grpFreq.Controls.Add(this.grpM);
            this.grpFreq.Controls.Add(this.grpY);
            this.grpFreq.Controls.Add(this.lblFreq);
            this.grpFreq.Controls.Add(this.cbFreq);
            this.grpFreq.Controls.Add(this.grpD);
            this.grpFreq.Location = new System.Drawing.Point(17, 107);
            this.grpFreq.Name = "grpFreq";
            this.grpFreq.Size = new System.Drawing.Size(287, 170);
            this.grpFreq.TabIndex = 13;
            this.grpFreq.TabStop = false;
            this.grpFreq.Text = "Frequencia e Data";
            // 
            // grpWeQ
            // 
            this.grpWeQ.Controls.Add(this.lblW);
            this.grpWeQ.Controls.Add(this.dtpW);
            this.grpWeQ.Location = new System.Drawing.Point(149, 44);
            this.grpWeQ.Name = "grpWeQ";
            this.grpWeQ.Size = new System.Drawing.Size(132, 72);
            this.grpWeQ.TabIndex = 7;
            this.grpWeQ.TabStop = false;
            this.grpWeQ.Text = "Semanalmente e Quinzenalmente";
            // 
            // lblW
            // 
            this.lblW.AutoSize = true;
            this.lblW.Location = new System.Drawing.Point(26, 30);
            this.lblW.Name = "lblW";
            this.lblW.Size = new System.Drawing.Size(81, 13);
            this.lblW.TabIndex = 5;
            this.lblW.Text = "Dia da semana:";
            // 
            // dtpW
            // 
            this.dtpW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpW.CustomFormat = "dddd";
            this.dtpW.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpW.Location = new System.Drawing.Point(5, 46);
            this.dtpW.Name = "dtpW";
            this.dtpW.Size = new System.Drawing.Size(121, 20);
            this.dtpW.TabIndex = 4;
            // 
            // grpM
            // 
            this.grpM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpM.Controls.Add(this.lblM);
            this.grpM.Controls.Add(this.dtpM);
            this.grpM.Location = new System.Drawing.Point(149, 119);
            this.grpM.Name = "grpM";
            this.grpM.Size = new System.Drawing.Size(132, 45);
            this.grpM.TabIndex = 6;
            this.grpM.TabStop = false;
            this.grpM.Text = "Mensalmente";
            // 
            // lblM
            // 
            this.lblM.AutoSize = true;
            this.lblM.Location = new System.Drawing.Point(6, 21);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(63, 13);
            this.lblM.TabIndex = 5;
            this.lblM.Text = "Dia no mês:";
            // 
            // dtpM
            // 
            this.dtpM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpM.CustomFormat = "dd";
            this.dtpM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpM.Location = new System.Drawing.Point(72, 17);
            this.dtpM.Name = "dtpM";
            this.dtpM.Size = new System.Drawing.Size(54, 20);
            this.dtpM.TabIndex = 4;
            // 
            // grpY
            // 
            this.grpY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpY.Controls.Add(this.lblA);
            this.grpY.Controls.Add(this.dtpA);
            this.grpY.Location = new System.Drawing.Point(6, 119);
            this.grpY.Name = "grpY";
            this.grpY.Size = new System.Drawing.Size(137, 45);
            this.grpY.TabIndex = 4;
            this.grpY.TabStop = false;
            this.grpY.Text = "Anualmente";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(6, 21);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(33, 13);
            this.lblA.TabIndex = 5;
            this.lblA.Text = "Data:";
            // 
            // dtpA
            // 
            this.dtpA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpA.CustomFormat = "dd \'/\' MM";
            this.dtpA.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpA.Location = new System.Drawing.Point(54, 17);
            this.dtpA.Name = "dtpA";
            this.dtpA.Size = new System.Drawing.Size(77, 20);
            this.dtpA.TabIndex = 4;
            // 
            // lblFreq
            // 
            this.lblFreq.AutoSize = true;
            this.lblFreq.Location = new System.Drawing.Point(45, 20);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(60, 13);
            this.lblFreq.TabIndex = 1;
            this.lblFreq.Text = "Frequencia";
            // 
            // cbFreq
            // 
            this.cbFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFreq.FormattingEnabled = true;
            this.cbFreq.Items.AddRange(new object[] {
            "Diario",
            "Semanal",
            "Quinzenal",
            "Mensal",
            "Anual"});
            this.cbFreq.Location = new System.Drawing.Point(111, 16);
            this.cbFreq.Name = "cbFreq";
            this.cbFreq.Size = new System.Drawing.Size(121, 21);
            this.cbFreq.TabIndex = 0;
            this.cbFreq.SelectedIndexChanged += new System.EventHandler(this.cbFreq_SelectedIndexChanged);
            // 
            // grpD
            // 
            this.grpD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpD.Controls.Add(this.nmrHora);
            this.grpD.Controls.Add(this.lnlmin);
            this.grpD.Controls.Add(this.nmrMin);
            this.grpD.Controls.Add(this.label1);
            this.grpD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpD.Location = new System.Drawing.Point(7, 44);
            this.grpD.Name = "grpD";
            this.grpD.Size = new System.Drawing.Size(137, 72);
            this.grpD.TabIndex = 7;
            this.grpD.TabStop = false;
            this.grpD.Text = "Diariamente";
            // 
            // nmrHora
            // 
            this.nmrHora.Location = new System.Drawing.Point(27, 19);
            this.nmrHora.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nmrHora.Name = "nmrHora";
            this.nmrHora.Size = new System.Drawing.Size(38, 20);
            this.nmrHora.TabIndex = 2;
            // 
            // lnlmin
            // 
            this.lnlmin.AutoSize = true;
            this.lnlmin.Location = new System.Drawing.Point(72, 48);
            this.lnlmin.Name = "lnlmin";
            this.lnlmin.Size = new System.Drawing.Size(38, 13);
            this.lnlmin.TabIndex = 6;
            this.lnlmin.Text = "minuto";
            // 
            // nmrMin
            // 
            this.nmrMin.Location = new System.Drawing.Point(27, 45);
            this.nmrMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nmrMin.Name = "nmrMin";
            this.nmrMin.Size = new System.Drawing.Size(38, 20);
            this.nmrMin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "hora";
            // 
            // btnDoBackup
            // 
            this.btnDoBackup.Location = new System.Drawing.Point(407, 19);
            this.btnDoBackup.Name = "btnDoBackup";
            this.btnDoBackup.Size = new System.Drawing.Size(89, 23);
            this.btnDoBackup.TabIndex = 12;
            this.btnDoBackup.Text = "Backup Agora";
            this.btnDoBackup.UseVisualStyleBackColor = true;
            this.btnDoBackup.Click += new System.EventHandler(this.btnDoBackup_Click);
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Checked = true;
            this.cbEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnable.Location = new System.Drawing.Point(17, 19);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(92, 17);
            this.cbEnable.TabIndex = 11;
            this.cbEnable.Text = "Fazer Backup";
            this.cbEnable.UseVisualStyleBackColor = true;
            // 
            // btnDirBack
            // 
            this.btnDirBack.Location = new System.Drawing.Point(421, 69);
            this.btnDirBack.Name = "btnDirBack";
            this.btnDirBack.Size = new System.Drawing.Size(75, 23);
            this.btnDirBack.TabIndex = 10;
            this.btnDirBack.Text = "Procurar";
            this.btnDirBack.UseVisualStyleBackColor = true;
            this.btnDirBack.Click += new System.EventHandler(this.btnDirBack_Click);
            // 
            // tbDirBack
            // 
            this.tbDirBack.Location = new System.Drawing.Point(17, 71);
            this.tbDirBack.Name = "tbDirBack";
            this.tbDirBack.Size = new System.Drawing.Size(398, 20);
            this.tbDirBack.TabIndex = 9;
            // 
            // lblDirBack
            // 
            this.lblDirBack.AutoSize = true;
            this.lblDirBack.Location = new System.Drawing.Point(14, 50);
            this.lblDirBack.Name = "lblDirBack";
            this.lblDirBack.Size = new System.Drawing.Size(100, 13);
            this.lblDirBack.TabIndex = 8;
            this.lblDirBack.Text = "Diretorio do backup";
            // 
            // pnlCBd
            // 
            this.pnlCBd.Controls.Add(this.btnMysqlDir);
            this.pnlCBd.Controls.Add(this.tbMysqlDir);
            this.pnlCBd.Controls.Add(this.lblMysqlDir);
            this.pnlCBd.Location = new System.Drawing.Point(3, 3);
            this.pnlCBd.Name = "pnlCBd";
            this.pnlCBd.Size = new System.Drawing.Size(514, 367);
            this.pnlCBd.TabIndex = 1;
            this.pnlCBd.VisibleChanged += new System.EventHandler(this.pnlsConfig_VisibleChanged);
            // 
            // btnMysqlDir
            // 
            this.btnMysqlDir.Location = new System.Drawing.Point(423, 37);
            this.btnMysqlDir.Name = "btnMysqlDir";
            this.btnMysqlDir.Size = new System.Drawing.Size(75, 23);
            this.btnMysqlDir.TabIndex = 18;
            this.btnMysqlDir.Text = "Procurar";
            this.btnMysqlDir.UseVisualStyleBackColor = true;
            this.btnMysqlDir.Click += new System.EventHandler(this.btnMysqlDir_Click);
            // 
            // tbMysqlDir
            // 
            this.tbMysqlDir.Location = new System.Drawing.Point(19, 39);
            this.tbMysqlDir.Name = "tbMysqlDir";
            this.tbMysqlDir.Size = new System.Drawing.Size(398, 20);
            this.tbMysqlDir.TabIndex = 17;
            // 
            // lblMysqlDir
            // 
            this.lblMysqlDir.AutoSize = true;
            this.lblMysqlDir.Location = new System.Drawing.Point(16, 18);
            this.lblMysqlDir.Name = "lblMysqlDir";
            this.lblMysqlDir.Size = new System.Drawing.Size(99, 13);
            this.lblMysqlDir.TabIndex = 16;
            this.lblMysqlDir.Text = "Diretorio do MySQL";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 417);
            this.Controls.Add(this.sptConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(692, 456);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 456);
            this.Name = "FrmConfig";
            this.Text = "Configurações";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfig_FormClosed);
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.sptConfig.Panel1.ResumeLayout(false);
            this.sptConfig.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptConfig)).EndInit();
            this.sptConfig.ResumeLayout(false);
            this.flpBackup.ResumeLayout(false);
            this.pnlCbackup.ResumeLayout(false);
            this.pnlCbackup.PerformLayout();
            this.grpFreq.ResumeLayout(false);
            this.grpFreq.PerformLayout();
            this.grpWeQ.ResumeLayout(false);
            this.grpWeQ.PerformLayout();
            this.grpM.ResumeLayout(false);
            this.grpM.PerformLayout();
            this.grpY.ResumeLayout(false);
            this.grpY.PerformLayout();
            this.grpD.ResumeLayout(false);
            this.grpD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrMin)).EndInit();
            this.pnlCBd.ResumeLayout(false);
            this.pnlCBd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptConfig;
        private System.Windows.Forms.TreeView trvCmenu;
        private System.Windows.Forms.Panel pnlCbackup;
        private System.Windows.Forms.Panel pnlCBd;
        private System.Windows.Forms.GroupBox grpD;
        private System.Windows.Forms.NumericUpDown nmrHora;
        private System.Windows.Forms.Label lnlmin;
        private System.Windows.Forms.FlowLayoutPanel flpBackup;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnDirBack;
        private System.Windows.Forms.TextBox tbDirBack;
        private System.Windows.Forms.Label lblDirBack;
        private System.Windows.Forms.CheckBox cbEnable;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.Button btnDoBackup;
        private System.Windows.Forms.Button btnMysqlDir;
        private System.Windows.Forms.TextBox tbMysqlDir;
        private System.Windows.Forms.Label lblMysqlDir;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpFreq;
        private System.Windows.Forms.ComboBox cbFreq;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.GroupBox grpY;
        private System.Windows.Forms.GroupBox grpM;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.DateTimePicker dtpM;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.DateTimePicker dtpA;
        private System.Windows.Forms.GroupBox grpWeQ;
        private System.Windows.Forms.Label lblW;
        private System.Windows.Forms.DateTimePicker dtpW;
        private System.Windows.Forms.NumericUpDown nmrMin;
        private System.Windows.Forms.Label label1;
    }
}