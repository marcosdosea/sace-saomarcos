using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dados;
using Dominio;
using Util;

namespace Telas
{
    public partial class FrmPlanoConta : Form
    {
        private EstadoFormulario estado;
        private Int32 codPlanoConta;

        public Int32 CodPlanoConta
        {
            get { return codPlanoConta; }
            set { codPlanoConta = value; }
        }


        public FrmPlanoConta()
        {
            InitializeComponent();
        }

        private void FrmPlanoConta_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.PLANO_DE_CONTAS, Principal.Autenticacao.CodUsuario);
            this.tb_grupo_contaTableAdapter.Fill(this.saceDataSet.tb_grupo_conta);
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmPlanoContaPesquisa frmPlanoContaPesquisa = new Telas.FrmPlanoContaPesquisa();
            frmPlanoContaPesquisa.ShowDialog();
            if (frmPlanoContaPesquisa.getCodPlanoConta() != -1)
            {
                tb_plano_contaBindingSource.Position = tb_plano_contaBindingSource.Find("codPlanoConta", frmPlanoContaPesquisa.getCodPlanoConta());
            }
            frmPlanoContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_plano_contaBindingSource.AddNew();
            codPlanoContaTextBox.Enabled = false;
            rbPagar.Checked = true;
            codGrupoContaComboBox.SelectedIndex = 0;
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            descricaoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorPlanoConta.getInstace().remover(int.Parse(codPlanoContaTextBox.Text));
                tb_plano_contaTableAdapter.Fill(saceDataSet.tb_plano_conta);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_plano_contaBindingSource.CancelEdit();
            tb_plano_contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                PlanoConta planoConta = new PlanoConta();
                planoConta.CodGrupoConta = int.Parse(codGrupoContaComboBox.SelectedValue.ToString());
                planoConta.Descricao = descricaoTextBox.Text;
                planoConta.TipoConta = (rbPagar.Checked) ? Conta.CONTA_PAGAR : Conta.CONTA_RECEBER;
                planoConta.DiaBase = (diaBaseTextBox.Text == "") ? short.Parse("0") : short.Parse(diaBaseTextBox.Text);
                planoConta.CodPlanoConta = Int32.Parse(codPlanoContaTextBox.Text);

                IGerenciadorPlanoConta gPlanoConta = GerenciadorPlanoConta.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gPlanoConta.inserir(planoConta);
                    tb_plano_contaTableAdapter.Fill(saceDataSet.tb_plano_conta);
                    tb_plano_contaBindingSource.MoveLast();
                }
                else
                {
                    gPlanoConta.atualizar(planoConta);
                    tb_plano_contaBindingSource.EndEdit();
                }
            }
           catch (Exception exc)
            {
                tb_plano_contaBindingSource.CancelEdit(); 
               throw exc;
            }
            finally {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmPlanoConta_KeyDown(object sender, KeyEventArgs e)
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
                    tb_plano_contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_plano_contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_plano_contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_plano_contaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                }
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if ((e.KeyCode == Keys.F2) && (codGrupoContaComboBox.Focused))
                {
                    Telas.FrmGrupoContaPesquisa frmGrupoContaPesquisa = new Telas.FrmGrupoContaPesquisa();
                    frmGrupoContaPesquisa.ShowDialog();
                    if (frmGrupoContaPesquisa.CodGrupoConta != -1)
                    {
                        tbgrupocontaBindingSource.Position = tbgrupocontaBindingSource.Find("codTipoConta", frmGrupoContaPesquisa.CodGrupoConta);
                    }
                    frmGrupoContaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoContaComboBox.Focused))
                {
                    Telas.FrmGrupoConta frmGrupoConta = new Telas.FrmGrupoConta();
                    frmGrupoConta.ShowDialog();
                    if (frmGrupoConta.CodGrupoConta != -1)
                    {
                        this.tb_grupo_contaTableAdapter.Fill(this.saceDataSet.tb_grupo_conta);
                        tbgrupocontaBindingSource.Position = tbgrupocontaBindingSource.Find("codGrupoConta", frmGrupoConta.CodGrupoConta);
                    }
                    frmGrupoConta.Dispose();
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
            tb_plano_contaBindingNavigator.Enabled = habilita;
            codGrupoContaComboBox.Enabled = !habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void codGrupoContaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void tb_plano_contaBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRowView linha = (DataRowView)tb_plano_contaBindingSource.Current;
            if (linha != null)
            {
                String codTipoConta = linha["codTipoConta"].ToString();
                if (codTipoConta.Equals(Conta.CONTA_PAGAR))
                {
                    rbPagar.Checked = true;
                    rbReceber.Checked = false;
                }
                else
                {
                    rbPagar.Checked = false;
                    rbReceber.Checked = true;
                }
            }
        }

        private void codGrupoContaComboBox_Leave(object sender, EventArgs e)
        {
            if (codGrupoContaComboBox.SelectedValue == null)
            {
                codGrupoContaComboBox.Focus();
                throw new TelaException("Um grupo válido precisa ser selecionado");
            }
        }

        private void FrmPlanoConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!codPlanoContaTextBox.Text.Equals(""))
            {
                codPlanoConta = Int32.Parse(codPlanoContaTextBox.Text);
            }
        }
    }
}