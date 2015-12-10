using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GdC
{
    public partial class FrmMain : Form
    {
        string _Nome;
        string _CPF;
        string _Telefone;
        string _Celular;
        string _Email;
        string _Rua;
        string _Complemento;
        string _Numero;
        string _Bairro;
        string _Cidade;
        string _UF;
        string _CEP;
        string _Aniversario;
        string _Observacoes;

        enum panel {
            Insert,Update
        }

        public FrmMain()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Connect.CreateConn();
            panelsPos(0, 26);
            this.ComboBoxes(panel.Insert);
            this.ComboBoxes(panel.Update);
            tmr.Start();
        }

        #region "outros metodos"
        private void panelsPos(int l, int h)
        {
            panelWelcome.Location = new Point(l, h);
            panel_Insert.Location = new Point(l, h);
            panel_InsertSale.Location = new Point(l, h);
            panel_Search.Location = new Point(l, h);
            panel_SearchSales.Location = new Point(l, h);
            panel_Update.Location = new Point(l, h);
        }

        private void EnableEditFields(bool bl)
        {
            if (this.tbECod.Text != "" || bl == false)
            {
                this.buttonEDelete.Enabled = bl;
                this.textBoxEBairro.Enabled = bl;
                this.textBoxEComplemento.Enabled = bl;
                this.textBoxEEmail.Enabled = bl;
                this.textBoxEName.Enabled = bl;
                this.maskedTextBoxENumber.Enabled = bl;
                this.textBoxEStreet.Enabled = bl;
                this.textBoxEObs.Enabled = bl;
                this.maskedTextBoxEBirth.Enabled = bl;
                this.maskedTextBoxECell.Enabled = bl;
                this.maskedTextBoxECEP.Enabled = bl;
                this.maskedTextBoxECPF.Enabled = bl;
                this.maskedTextBoxEPhone.Enabled = bl;
                this.comboBoxEUF.Enabled = bl;
                this.comboBoxECity.Enabled = bl;
            }
        }

        private void PanelInvisible()
        {
            this.panelWelcome.Visible = false;
            this.panel_Insert.Visible = false;
            this.panel_InsertSale.Visible = false;
            this.panel_Search.Visible = false;
            this.panel_SearchSales.Visible = false;
            this.panel_Update.Visible = false;
            this.stslbl1.Text = "";
        }

        private void ClearFields()
        {
            #region "Panel_Insert"
            this.textBoxName.Text = "";
            this.maskedTextBoxCPF.Text = "";
            this.maskedTextBoxPhone.Text = "";
            this.maskedTextBoxCell.Text = "";
            this.textBoxEmail.Text = "";
            this.maskedTextBoxNumber.Text = "";
            this.textBoxStreet.Text = "";
            this.textBoxComplemento.Text = "";
            this.maskedTextBoxNumber.Text = "";
            this.textBoxBairro.Text = "";
            this.maskedTextBoxCEP.Text = "";
            this.maskedTextBoxBirth.Text = "";
            this.textBoxObs.Text = "";
            #endregion

            #region "Panel_Update"
            this.tbECod.Text = "";
            this.textBoxEName.Text = "";
            this.maskedTextBoxECPF.Text = "";
            this.maskedTextBoxEPhone.Text = "";
            this.maskedTextBoxECell.Text = "";
            this.textBoxEEmail.Text = "";
            this.maskedTextBoxENumber.Text = "";
            this.textBoxEStreet.Text = "";
            this.textBoxEComplemento.Text = "";
            this.maskedTextBoxENumber.Text = "";
            this.textBoxEBairro.Text = "";
            this.maskedTextBoxECEP.Text = "";
            this.maskedTextBoxEBirth.Text = "";
            this.textBoxEObs.Text = "";
            #endregion

            #region "Panel_Search"
            mtbSearch.Text = "";
            #endregion
        }

        private void ButtonCancel() {
            PanelInvisible();
            ClearFields();
            this.panelWelcome.Visible = true;
        }

        private void ComboBoxes(panel pnl)
        {
            this.stslbl1.Text = "Carregando...";
            CbList dbCtrl = new CbList();

            if (pnl == panel.Insert)
            {
                this.comboBoxUF.DataSource = dbCtrl.listUf();
                this.comboBoxUF.DisplayMember = "Uf";
                this.comboBoxUF.Text = "SP";
                this.comboBoxCity.DataSource = dbCtrl.listCity(this.comboBoxUF.Text);
                this.comboBoxCity.DisplayMember = "Nome";
                this.comboBoxCity.Text = "São José dos Campos";
            }
            else if (pnl == panel.Update)
            {
                this.comboBoxEUF.DataSource = dbCtrl.listUf();
                this.comboBoxEUF.DisplayMember = "Uf";
                this.comboBoxECity.DataSource = dbCtrl.listCity(this.comboBoxUF.Text);
                this.comboBoxECity.DisplayMember = "Nome";
            }
            this.stslbl1.Text = "Carregado";
        }

        private void FixValues()
        {
            if (_Nome == "")
            {
                _Nome = "-";
            }
            if (_CPF == "   ,   ,   -")
            {
                _CPF = "-";
            }
            if (_Telefone == "(  )      ")
            {
                _Telefone = "-";
            }
            if (_Celular == "(  )       ")
            {
                _Celular = "-";
            }
            if (_Email == "")
            {
                _Email = "-";
            }
            if (_Rua == "")
            {
                _Rua = "-";
            }
            if (_Complemento == "")
            {
                _Complemento = "-";
            }
            if (_Numero == "")
            {
                _Numero = "-";
            }
            if (_Bairro == "")
            {
                _Bairro = "-";
            }
            if (_Cidade == "")
            {
                _Cidade = "-";
            }
            if (_UF == "")
            {
                _UF = "-";
            }
            if (_CEP == "     -")
            {
                _CEP = "-";
            }
            if (_Aniversario == "  /  /")
            {
                _Aniversario = "-";
            }
            if (_Observacoes == "")
            {
                _Observacoes = "-";
            }
        } 
        #endregion

        #region "Panels Controls Methods"
        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Insert.Visible = true;
        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel_Search.Visible)
            {
                string Cod;
                Cod = this.dgSearch.CurrentRow.Cells[0].Value.ToString();
                PanelInvisible();
                this.panel_Update.Visible = true;
                tbECod.Text = Cod;
                buttonELoad_Click(e, e);
            }
            else
            {
                PanelInvisible();
                this.panel_Update.Visible = true;
            }
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_InsertSale.Visible = true;
        }

        private void vendasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_SearchSales.Visible = true;
        }

        private void ShowAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Mostra Tudo";
            this.mtbSearch.Enabled = false;
            this.btSearch.Enabled = false;
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Nome";
        }

        private void cPFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "CPF";
        }

        private void telefoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Telefone";
        }

        private void celularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Celular";
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "E-mail";
        }

        private void ruaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Rua";
        }

        private void bairroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Bairro";
        }

        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Cidade";
        }

        private void cEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "CEP";
        }

        private void aniversárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelInvisible();
            this.panel_Search.Visible = true;
            this.cbSearchType.Text = "Aniversário";
        }
        #endregion

        #region "Panel Insert Methods"
        private void buttonClean_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ButtonCancel();
        }

        private void Cad(object sender, EventArgs e)
        {
            try
            {
                acsClientes dbCtrl = new acsClientes();
                #region "Passagem de info pras variebles"
                _Nome = textBoxName.Text;
                _CPF = maskedTextBoxCPF.Text;
                _Telefone = maskedTextBoxPhone.Text;
                _Celular = maskedTextBoxCell.Text;
                _Email = textBoxEmail.Text;
                _Rua = textBoxStreet.Text;
                _Complemento = textBoxComplemento.Text;
                _Numero = maskedTextBoxNumber.Text;
                _Bairro = textBoxBairro.Text;
                _Cidade = comboBoxCity.Text;
                _UF = comboBoxUF.Text;
                _CEP = maskedTextBoxCEP.Text;
                _Aniversario = maskedTextBoxBirth.Text;
                _Observacoes = textBoxObs.Text;
                #endregion

                List<string> lst = dbCtrl.ReturnList(acsClientes.Fields.Nome);
                bool found = false;

                for (int i = 0; i < lst.Count; i++)
                {
                    if (_Nome == lst[i])
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    FixValues();

                    if (dbCtrl.Insert(_Nome, _CPF, _Telefone, _Celular, _Email,
                                      _Rua, _Complemento, _Numero, _Bairro, _Cidade,
                                      _UF, _CEP, _Aniversario, _Observacoes))
                    {
                        MessageBox.Show("Cliente salvo com sucesso", "Cliente Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string info = _Nome + "[" + _CPF + "[" + _Telefone + "[" + _Celular + "[" + _Email + "[" + _Rua + "[" + _Complemento + "[" + _Numero + "[" + _Bairro + "[" + _Cidade + "[" + _UF + "[" + _CEP + "[" + _Aniversario + "[" + _Observacoes;
                        BackupMngr mngr = new BackupMngr();
                        mngr.backup(info);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Cadastrar\nErro: \n", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Cliente com mesmo nome já existe. Deseja editar esse cadastro?\n(Escolhendo 'não' será criado um novo cadastro com o mesmo nome)", "Conflito", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
                    if (dg == DialogResult.No)
                    {
                        FixValues();

                        if (dbCtrl.Insert(_Nome, _CPF, _Telefone, _Celular, _Email,
                                          _Rua, _Complemento, _Numero, _Bairro, _Cidade,
                                          _UF, _CEP, _Aniversario, _Observacoes))
                        {
                            MessageBox.Show("Cliente salvo com sucesso", "Cliente Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string info = _Nome + "[" + _CPF + "[" + _Telefone + "[" + _Celular + "[" + _Email + "[" + _Rua + "[" + _Complemento + "[" + _Numero + "[" + _Bairro + "[" + _Cidade + "[" + _UF + "[" + _CEP + "[" + _Aniversario + "[" + _Observacoes;
                            BackupMngr mngr = new BackupMngr();
                            mngr.backup(info);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao Cadastrar\nErro: \n", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dg == DialogResult.Yes)
                    {
                        string nome = textBoxName.Text; ;
                        nomeToolStripMenuItem_Click(e, e);
                        mtbSearch.Text = nome;
                        btSearch_Click(e, e);
                    }
                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro na ação\nErro: \n\n" + Erro, "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                if (MessageBox.Show("Você está prestes à salvar um Cliente sem nome, tem certeza disso?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Cad(e, e);
                }
            }
            else
            {
                Cad(e, e);
            }
        }

        private void comboBoxUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbList dbCtrl = new CbList();
            this.comboBoxCity.DataSource = dbCtrl.listCity(this.comboBoxUF.Text);
            this.comboBoxCity.DisplayMember = "Nome";
        }
        #endregion

        #region "Panel Update Methods"
        private void buttonELoad_Click(object sender, EventArgs e)
        {
            acsClientes dbCtrl = new acsClientes();
            try
            {
                //Nome, CPF, Telefone, Celular, Email, Rua, Complemento,
                //Numero, Bairro, Cidade, UF, CEP, Aniversario, Observacoes
                if (dbCtrl.Select(this.tbECod.Text))
                {
                    this.textBoxEName.Text = dbCtrl.Nome;
                    this.maskedTextBoxECPF.Text = dbCtrl.CPF;
                    this.maskedTextBoxEPhone.Text = dbCtrl.Telefone;
                    this.maskedTextBoxECell.Text = dbCtrl.Celular;
                    this.textBoxEEmail.Text = dbCtrl.Email;
                    this.textBoxEStreet.Text = dbCtrl.Rua;
                    this.textBoxEComplemento.Text = dbCtrl.Complemento;
                    this.maskedTextBoxENumber.Text = dbCtrl.Numero;
                    this.textBoxEBairro.Text = dbCtrl.Bairro;
                    this.comboBoxEUF.Text = dbCtrl.UF;
                    this.comboBoxECity.Text = dbCtrl.Cidade;
                    this.maskedTextBoxECEP.Text = dbCtrl.CEP;
                    this.maskedTextBoxEBirth.Text = dbCtrl.Aniversario;
                    this.textBoxEObs.Text = dbCtrl.Observacoes;
                    EnableEditFields(true);
                }
                else
                {
                    MessageBox.Show("Cliente não existente", "Não Existente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Por favor, só números na caixa 'Cógido'\nTenha certeza de que a caixa não está em branco\n\nErro:\n\n" + Erro, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonESave_Click(object sender, EventArgs e)
        {
            try
            {
                acsClientes dbCtrl = new acsClientes();
                string _Cod;
                
                try
                {
                    #region "Passagem de info pras variebles"
                    _Cod = tbECod.Text;
                    _Nome = textBoxEName.Text;
                    _CPF = maskedTextBoxECPF.Text;
                    _Telefone = maskedTextBoxEPhone.Text;
                    _Celular = maskedTextBoxECell.Text;
                    _Email = textBoxEEmail.Text;
                    _Rua = textBoxEStreet.Text;
                    _Complemento = textBoxEComplemento.Text;
                    _Numero = maskedTextBoxENumber.Text;
                    _Bairro = textBoxEBairro.Text;
                    _Cidade = comboBoxECity.Text;
                    _UF = comboBoxEUF.Text;
                    _CEP = maskedTextBoxECEP.Text;
                    _Aniversario = maskedTextBoxEBirth.Text;
                    _Observacoes = textBoxEObs.Text;
                    #endregion

                    FixValues();

                    if (dbCtrl.Update(_Nome, _CPF, _Telefone, _Celular, _Email,
                                      _Rua, _Complemento, _Numero, _Bairro, _Cidade,
                                      _UF, _CEP, _Aniversario, _Observacoes, _Cod))
                    {
                        MessageBox.Show("Cliente salvo com sucesso", "Cliente Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        EnableEditFields(false);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Cadastrar\nErro: \n", "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception Erro)
                {
                    MessageBox.Show("Por favor, só numeros na caixa 'Cógido'\nErro:\n\n" + Erro, "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro: \n\n" + Erro, "Erro ao Cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEDelete_Click(object sender, EventArgs e)
        {
            acsClientes dbCtrl = new acsClientes ();
            if (MessageBox.Show("Tem certeza que quer deletar esse contato?","Confimação",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dbCtrl.Delete(this.tbECod.Text))
                {
                    MessageBox.Show("Cliente excluido com sucesso","Sucesso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableEditFields(false);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Cliente não excluído","Falha",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operação Cancelada","Cliente não excluído",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void buttonEClean_Click(object sender, EventArgs e)
        {
            EnableEditFields(false);
            ClearFields();
        }

        private void buttonECancel_Click(object sender, EventArgs e)
        {
            EnableEditFields(false);
            ClearFields();
            ButtonCancel();
        }

        private void comboBoxEUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbList dbCtrl = new CbList();
            this.comboBoxECity.DataSource = dbCtrl.listCity(this.comboBoxUF.Text);
            this.comboBoxECity.DisplayMember = "Nome";
        }

        private void panel_Update_VisibleChanged(object sender, EventArgs e)
        {
            ClearFields();
            EnableEditFields(false);
        }

        private void tbECod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonELoad_Click(e, e);
            }
        }
        #endregion

        #region "Panel Search Methods"
        private void btSearch_Click(object sender, EventArgs e)
        {
            acsClientes dbCtrl = new acsClientes();
            // [Observacoes]
            string _sql = "SELECT ClienteID AS Cod, Nome, CPF, Telefone, Celular, Email, Rua AS Logradouro, Complemento, Numero AS Número , Bairro, Cidade, UF, CEP, Aniversario as Aniversário FROM Clientes WHERE ";

            switch (cbSearchType.Text)
            {
                case "Código":
                    _sql += "ClienteID LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Nome":
                    _sql += "Nome LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "CPF":
                    _sql += "CPF LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Telefone":
                    _sql += "Telefone LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Celular":
                    _sql += "Celular LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "E-mail":
                    _sql += "Email LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Rua":
                    _sql += "Rua LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Bairro":
                    _sql += "Bairro LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Cidade":
                    _sql += "Cidade LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "CEP":
                    _sql += "CEP LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                case "Aniversário":
                    _sql += "Aniversario LIKE @VALOR";
                    dgSearch.DataSource = dbCtrl.ShowGrid(_sql, "%" + mtbSearch.Text + "%");
                    break;
                default:
                    MessageBox.Show("Erro na caixa de Método de pesquisa, confira o texto da caixa e tente novamente", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
        }

        private void cbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkMask.Checked = true;

            if (cbSearchType.Text != "Mostrar Tudo")
            {
                mtbSearch.Enabled = true;
                btSearch.Enabled = true;
                panel_Search_VisibleChanged(e, e);
            }
            else
            {
                mtbSearch.Enabled = false;
                btSearch.Enabled = false;
                panel_Search_VisibleChanged(e, e);
            }

            switch (cbSearchType.Text)
            {
                case "CPF":
                    mtbSearch.Mask = "000,000,000-00";
                    break;
                case "Telefone":
                    mtbSearch.Mask = "(00) 0000 0000";
                    break;
                case "Celular":
                    mtbSearch.Mask = "(00) 00000 0000";
                    break;
                case "CEP":
                    mtbSearch.Mask = "00000-000";
                    break;
                case "Aniversário":
                    mtbSearch.Mask = "00/00";
                    break;
                default:
                    mtbSearch.Mask = "";
                    break;
            }
        }

        private void panel_Search_VisibleChanged(object sender, EventArgs e)
        {
            ClearFields();
            acsClientes dbCtrl = new acsClientes();
            dgSearch.DataSource = dbCtrl.ListAll();

            if (cbSearchType.Text != "Mostrar Tudo")
            {
                mtbSearch.Enabled = true;
                btSearch.Enabled = true;
            }
            else
            {
                mtbSearch.Enabled = false;
                btSearch.Enabled = false;
            }

            mtbSearch.Mask = "";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            ButtonCancel();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            acsClientes dbCtrl = new acsClientes();

            if (MessageBox.Show("Tem certeza que quer deletar esse contato?", "Confimação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dbCtrl.Delete(this.dgSearch.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Cliente excluido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    panel_Search_VisibleChanged(e, e);
                }
                else
                {
                    MessageBox.Show("Cliente não excluído", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Operação Cancelada", "Cliente não excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            string Cod;
            Cod = this.dgSearch.CurrentRow.Cells[0].Value.ToString();
            editarClienteToolStripMenuItem_Click(e, e);
            tbECod.Text = Cod;
            buttonELoad_Click(e, e);
        }

        private void btObs_Click(object sender, EventArgs e)
        {
            acsClientes dbCtrl = new acsClientes();
            dbCtrl.Select(this.dgSearch.CurrentRow.Cells[0].Value.ToString());

            MessageBox.Show("Observações sobre '" + this.dgSearch.CurrentRow.Cells[1].Value.ToString() + "':\n\n" + dbCtrl.Observacoes, "Observações", MessageBoxButtons.OK);
        }

        private void mtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSearch_Click(e, e);
            }
        }
        #endregion

        #region "ToolTips"
        private void btDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Clique em um linha da tabela para deletar a mesma, \ncaso nenhuma linha for selecionada será deletado o primeiro item", this.btDelete);
        }
        
        private void btObs_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Clique em um linha da tabela para ver as observações sobre respectivo cliente, \ncaso nenhuma linha for selecionada será exibido as observações sobre o primeiro item", this.btObs);
        }

        private void btEdit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Clique em um linha da tabela para editar a mesma, \ncaso nenhuma linha for selecionada será editado o primeiro item", this.btEdit);
        }
        #endregion

        private void smiBackup_Click(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.ShowDialog();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            ConfigMngr config = new ConfigMngr();
            
            stslblTime.Text = DateTime.Now.ToLongTimeString();

            if (config.BackupEnable)
            {
                if (config.BackupFrequency.ToString().ToUpper() == "D")
                {
                    if (config.BackupTime == DateTime.Now.ToShortTimeString() && !config.DidHappened)
                    {
                        config.DidHappened = true;
                        config.UpdateFile();
                        BackupMngr backup = new BackupMngr();
                        backup.backupDb();
                    }
                    else if (!(config.BackupTime == DateTime.Now.ToShortTimeString()) && config.DidHappened)
                    {
                        config.DidHappened = false;
                        config.UpdateFile();
                    }
                }
                else if (config.BackupFrequency.ToString().ToUpper() == "S")
                {
                    if (config.BackupDofW == DateTime.Now.DayOfWeek.ToString() && !config.DidHappened)
                    {
                        config.DidHappened = true;
                        config.UpdateFile();
                        BackupMngr backup = new BackupMngr();
                        backup.backupDb();
                    }
                    else if (!(config.BackupDofW == DateTime.Now.DayOfWeek.ToString()) && config.DidHappened)
                    {
                        config.DidHappened = false;
                        config.UpdateFile();
                    }
                }
                else if (config.BackupFrequency.ToString().ToUpper() == "Q")
                {
                    if (config.BackupDofW == DateTime.Now.DayOfWeek.ToString() && !config.DidHappened)
                    {
                        config.DidHappened = true;
                        config.UpdateFile();
                        BackupMngr backup = new BackupMngr();
                        backup.backupDb();
                    }
                    else if (!(config.BackupDofW == DateTime.Now.DayOfWeek.ToString()) && config.DidHappened)
                    {
                        config.DidHappened = false;
                        config.UpdateFile();
                    }
                }
                else if (config.BackupFrequency.ToString().ToUpper() == "M")
                {
                    if (config.BackupDay == DateTime.Now.Day.ToString() && !config.DidHappened)
                    {
                        config.DidHappened = true;
                        config.UpdateFile();
                        BackupMngr backup = new BackupMngr();
                        backup.backupDb();
                    }
                    else if (!(config.BackupDay == DateTime.Now.Day.ToString()) && config.DidHappened)
                    {
                        config.DidHappened = false;
                        config.UpdateFile();
                    }
                }
                else if (config.BackupFrequency.ToString().ToUpper() == "A")
                {
                    if (config.BackupMonth == DateTime.Now.Month.ToString() &&
                        config.BackupDay == DateTime.Now.Day.ToString() &&
                        !config.DidHappened)
                    {
                        config.DidHappened = true;
                        config.UpdateFile();
                        BackupMngr backup = new BackupMngr();
                        backup.backupDb();
                    }
                    else if (!(config.BackupMonth == DateTime.Now.Month.ToString() &&
                             config.BackupDay == DateTime.Now.Day.ToString()) && 
                             config.DidHappened)
                    {
                        config.DidHappened = false;
                        config.UpdateFile();
                    }
                }
            }
        }

        private void chkMask_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkMask.Checked)
            {
                mtbSearch.Mask = "";
            }
            else
            {
                cbSearchType_SelectedIndexChanged(e, e);
            }
        }
    }
}