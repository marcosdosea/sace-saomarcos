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

namespace SACE.Telas
{
    public partial class FrmCartaoCredito : Form
    {
        private EstadoFormulario estado;

        public FrmCartaoCredito()
        {
            InitializeComponent();
        }

        private void FrmCartaoCredito_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Funcoes.CARTÕES_DE_CREDITO, Principal.Autenticacao.CodUsuario);
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            this.tb_cartao_creditoTableAdapter.Fill(this.saceDataSet.tb_cartao_credito);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmCartaoCreditoPesquisa frmCartaoCreditoPesquisa = new Telas.FrmCartaoCreditoPesquisa();
            frmCartaoCreditoPesquisa.ShowDialog();
            if (frmCartaoCreditoPesquisa.getCodCartaoCredito() != -1)
            {
                tb_cartao_creditoBindingSource.Position = tb_cartao_creditoBindingSource.Find("codCartaoCredito", frmCartaoCreditoPesquisa.getCodCartaoCredito());
            }
            frmCartaoCreditoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tbcontabancoBindingSource.Count > 0)
            {
                tb_cartao_creditoBindingSource.AddNew();
                codCartaoTextBox.Enabled = false;
                nomeTextBox.Focus();
                habilitaBotoes(false);
                tbcontabancoBindingSource.MoveFirst();
                codContaBancoComboBox.SelectedIndex = 0;
                estado = EstadoFormulario.INSERIR;
            }
            else
            {
                throw new TelaException("É necessário inserir primeiro uma nova conta/caixa.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorCartaoCredito.getInstace().remover(int.Parse(codCartaoTextBox.Text));
                tb_cartao_creditoTableAdapter.Fill(saceDataSet.tb_cartao_credito);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_cartao_creditoBindingSource.CancelEdit();
            tb_cartao_creditoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                CartaoCredito cartaoCredito = new CartaoCredito();
                cartaoCredito.CodCartao = int.Parse(codCartaoTextBox.Text);
                cartaoCredito.Nome = nomeTextBox.Text;
                cartaoCredito.DiaBase = int.Parse(diaBaseTextBox.Text);
                cartaoCredito.CodContaBanco = Int32.Parse(codContaBancoComboBox.SelectedValue.ToString());

                IGerenciadorCartaoCredito gCartaoCredito = GerenciadorCartaoCredito.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gCartaoCredito.inserir(cartaoCredito);
                    tb_cartao_creditoTableAdapter.Fill(saceDataSet.tb_cartao_credito);
                    tb_cartao_creditoBindingSource.MoveLast();
                }
                else
                {
                    gCartaoCredito.atualizar(cartaoCredito);
                    tb_cartao_creditoBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_cartao_creditoBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmCartaoCredito_KeyDown(object sender, KeyEventArgs e)
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
                    tb_cartao_creditoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_cartao_creditoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_cartao_creditoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_cartao_creditoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codContaBancoComboBox.Focused))
                {
                    Telas.FrmContaBancoPesquisa frmContaBancoPesquisa = new Telas.FrmContaBancoPesquisa();
                    frmContaBancoPesquisa.ShowDialog();
                    if (frmContaBancoPesquisa.CodContaBanco != "")
                    {
                        tbcontabancoBindingSource.Position = tbcontabancoBindingSource.Find("codContaBanco", frmContaBancoPesquisa.CodContaBanco);
                    }
                    frmContaBancoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codContaBancoComboBox.Focused))
                {
                    Telas.FrmContaBanco frmContaBanco = new Telas.FrmContaBanco();
                    frmContaBanco.ShowDialog();
                    if (frmContaBanco.CodContaBanco != "")
                    {
                        this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
                        tbcontabancoBindingSource.Position = tbcontabancoBindingSource.Find("codContaBanco", frmContaBanco.CodContaBanco);
                    }
                    frmContaBanco.Dispose();
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
            tb_cartao_creditoBindingNavigator.Enabled = habilita;
            codContaBancoComboBox.Enabled = !(habilita);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void codContaBancoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

    }
}
