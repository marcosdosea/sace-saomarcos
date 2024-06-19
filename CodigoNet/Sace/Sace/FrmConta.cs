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
using Util;

namespace Sace
{
    public partial class FrmConta : Form
    {
        private EstadoFormulario estado;

        public FrmConta()
        {
            InitializeComponent();
        }

        private void FrmContas_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, UtilConfig.Default.CONTAS_PAGAR, Principal.Autenticacao.CodUsuario);

            pessoaBindingSource.DataSource = gerenciadorPessoa.ObterTodos();
            planoContaBindingSource.DataSource = GerenciadorPlanoConta.GetInstance().ObterTodos();
            contaBindingSource.DataSource = gerenciadorConta.ObterTodos();
            situacaoContaBindingSource.DataSource = gerenciadorConta.ObterSituacoesConta();
            
            habilitaBotoes(true);
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_contaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmContaPesquisa frmContaPesquisa = new FrmContaPesquisa();
            frmContaPesquisa.ShowDialog();
            if (frmContaPesquisa.ContaSelected != null)
            {
                contaBindingSource.Position = contaBindingSource.List.IndexOf(frmContaPesquisa.ContaSelected);
            }
            frmContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            contaBindingSource.AddNew();
            codSituacaoComboBox.SelectedIndex = 0;
            codPessoaComboBox.SelectedIndex = 0;
            codPlanoContaComboBox.SelectedIndex = 0;
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codContaTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gerenciadorConta.Remover(long.Parse(codContaTextBox.Text));
                contaBindingSource.RemoveCurrent();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Conta conta = new Conta();
            conta.CodConta = Convert.ToInt64(codContaTextBox.Text);
            conta.CodEntrada = Convert.ToInt64(codEntradaTextBox.Text);
            conta.CodPessoa = Convert.ToInt64(codPessoaComboBox.SelectedValue.ToString());
            conta.CodPlanoConta = Convert.ToInt32(codPlanoContaComboBox.SelectedValue.ToString());
            conta.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
            conta.CodSituacao = codSituacaoComboBox.SelectedValue.ToString();
            conta.DataVencimento = Convert.ToDateTime(dataVencimentoDateTimePicker.Value.ToString());
            conta.Observacao = observacaoTextBox.Text;
            conta.Valor = Convert.ToDecimal(valorTextBox.Text);
            conta.CodPagamento = 0;
            conta.FormatoConta = Conta.FORMATO_CONTA_FICHA;

            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                long codConta = gerenciadorConta.Inserir(conta);
                codContaTextBox.Text = codConta.ToString();
            }
            else
            {
                gerenciadorConta.Atualizar(conta);
            }
            contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            contaBindingSource.CancelEdit();
            contaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        
        private void FrmContas_KeyDown(object sender, KeyEventArgs e)
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
                    contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    contaBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codPessoaComboBox.Focused))
                {
                    FrmPessoaPesquisa frmPessoaPesquisa = new FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPessoaComboBox.Focused))
                {
                    FrmPessoa frmPessoa = new FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                    }
                    frmPessoa.Dispose();
                }

                else if ((e.KeyCode == Keys.F2) && (codPlanoContaComboBox.Focused))
                {
                    FrmPlanoContaPesquisa frmPlanoContaPesquisa = new FrmPlanoContaPesquisa();
                    frmPlanoContaPesquisa.ShowDialog();
                    if (frmPlanoContaPesquisa.PlanoContaSelected != null)
                    {
                        planoContaBindingSource.Position = planoContaBindingSource.List.IndexOf(frmPlanoContaPesquisa.PlanoContaSelected);
                    }
                    frmPlanoContaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPlanoContaComboBox.Focused))
                {
                    FrmPlanoConta frmPlanoConta = new FrmPlanoConta();
                    frmPlanoConta.ShowDialog();
                    if (frmPlanoConta.PlanoContaSelected != null)
                    {
                        planoContaBindingSource.Position = planoContaBindingSource.List.IndexOf(frmPlanoConta.PlanoContaSelected);
                    }
                    frmPlanoConta.Dispose();
                }
            }
        }

        private void codDocumentoPagamentoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        
        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            if (codPessoaComboBox.SelectedValue == null)
            {
                codPessoaComboBox.Focus();
                throw new TelaException("Uma pessoa válida precisa ser selecionada para a conta.");
            }
        }

        private void codPlanoContaComboBox_Leave(object sender, EventArgs e)
        {
            if (codPlanoContaComboBox.SelectedValue == null)
            {
                codPlanoContaComboBox.Focus();
                throw new TelaException("Um plano de contas válido precisa ser selecionada para a conta.");
            }
        }

        private void tb_contaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (codContaTextBox.Text != "")
                movimentacaoContaBindingSource.DataSource = gerenciadorMovimentacaoConta.ObterPorConta(Convert.ToInt64(codContaTextBox.Text));
        }
    }
}