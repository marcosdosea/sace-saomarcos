using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace SACE.Telas
{
    public partial class FrmContaBanco : Form
    {
        private EstadoFormulario estado;
        
        private String codContaBanco;

        public String CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        public FrmContaBanco()
        {
            InitializeComponent();
        }

        private void FrmContaBanco_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Funcoes.CONTAS_BANCO_CAIXA, Principal.Autenticacao.CodUsuario);
            this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
            frmContaBancoPesquisa.ShowDialog();
            if (frmContaBancoPesquisa.CodContaBanco != "")
            {
                tb_conta_bancoBindingSource.Position = tb_conta_bancoBindingSource.Find("codContaBanco", frmContaBancoPesquisa.CodContaBanco);
            }
            frmContaBancoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_conta_bancoBindingSource.AddNew();
            codContaBancoTextBox.Focus();
            habilitaBotoes(false);
            codBancoComboBox.SelectedIndex = 0;
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codContaBancoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorContaBanco.getInstace().remover(codContaBancoTextBox.Text);
                tb_conta_bancoTableAdapter.Fill(saceDataSet.tb_conta_banco);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_conta_bancoBindingSource.CancelEdit();
            tb_conta_bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBanco contaBanco = new ContaBanco();
                contaBanco.CodContaBanco = codContaBancoTextBox.Text;
                contaBanco.Agencia = agenciaTextBox.Text;
                contaBanco.Descricao = descricaoTextBox.Text;
                contaBanco.Saldo = decimal.Parse(saldoTextBox.Text);
                contaBanco.CodBanco = Int32.Parse(codBancoComboBox.SelectedValue.ToString());

                IGerenciadorContaBanco gContaBanco = GerenciadorContaBanco.getInstace();

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gContaBanco.inserir(contaBanco);
                    tb_conta_bancoTableAdapter.Fill(saceDataSet.tb_conta_banco);
                    //tb_conta_bancoBindingSource.MoveLast();
                }
                else
                {
                    gContaBanco.atualizar(contaBanco);
                    tb_conta_bancoBindingSource.EndEdit();
                }
            }
            catch (Dados.DadosException de)
            {
                tb_conta_bancoBindingSource.CancelEdit();
                throw de;
            }
            finally {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmContaBanco_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_conta_bancoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_conta_bancoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_conta_bancoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_conta_bancoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F2) && (codBancoComboBox.Focused))
                {
                    Telas.FrmBancoPesquisa frmBancoPesquisa = new Telas.FrmBancoPesquisa();
                    frmBancoPesquisa.ShowDialog();
                    if (frmBancoPesquisa.CodBanco != -1)
                    {
                        tbbancoBindingSource.Position = tbbancoBindingSource.Find("codBanco", frmBancoPesquisa.CodBanco);
                    }
                    frmBancoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codBancoComboBox.Focused))
                {
                    Telas.FrmBanco frmBanco = new Telas.FrmBanco();
                    frmBanco.ShowDialog();
                    if (frmBanco.CodBanco != -1)
                    {
                        this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
                        tbbancoBindingSource.Position = tbbancoBindingSource.Find("codBanco", frmBanco.CodBanco);
                    }
                    frmBanco.Dispose();
                }
            }
        }
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_conta_bancoBindingNavigator.Enabled = habilita;
            codBancoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmContaBanco_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodContaBanco = codContaBancoTextBox.Text;
        }
    }
}
