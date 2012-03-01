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

namespace Telas
{
    public partial class FrmContas : Form
    {
        private EstadoFormulario estado;

        public FrmContas()
        {
            InitializeComponent();
        }

        private void FrmContas_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.CONTAS_PAGAR, Principal.Autenticacao.CodUsuario);

            this.tb_situacao_contaTableAdapter.Fill(this.saceDataSet.tb_situacao_conta);
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
            this.tb_contaTableAdapter.Fill(this.saceDataSet.tb_conta);
            if (codContaTextBox.Text != "")
            {
                this.tb_movimentacao_contaTableAdapter.FillByCodConta(this.saceDataSet.tb_movimentacao_conta, Convert.ToInt64(codContaTextBox.Text));
            }
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
            Telas.FrmContaPesquisa frmContaPesquisa = new Telas.FrmContaPesquisa();
            frmContaPesquisa.ShowDialog();
            if (frmContaPesquisa.getCodConta() != -1)
            {
                tb_contaBindingSource.Position = tb_contaBindingSource.Find("codConta", frmContaPesquisa.getCodConta());
            }
            frmContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_contaBindingSource.AddNew();
            codSituacaoComboBox.SelectedIndex = 0;
            codPessoaComboBox.SelectedIndex = 0;
            codDocumentoPagamentoComboBox.SelectedIndex = 0;
            codPlanoContaComboBox.SelectedIndex = 0;
            codDocumentoPagamentoComboBox.Focus();
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
                GerenciadorConta.getInstace().remover(long.Parse(codContaTextBox.Text));
                tb_contaTableAdapter.Fill(saceDataSet.tb_conta);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Conta conta = new Conta();
            conta.CodConta = Convert.ToInt64(codContaTextBox.Text);
            conta.CodDocumento = Convert.ToInt64(codDocumentoPagamentoComboBox.SelectedValue.ToString());
            conta.CodEntrada = Convert.ToInt64(codEntradaTextBox.Text);
            conta.CodPessoa = Convert.ToInt64(codPessoaComboBox.SelectedValue.ToString());
            conta.CodPlanoConta = Convert.ToInt32(codPlanoContaComboBox.SelectedValue.ToString());
            conta.CodSaida = Convert.ToInt64(codSaidaTextBox.Text);
            conta.CodSituacao = Convert.ToChar(codSituacaoComboBox.SelectedValue.ToString());
            conta.DataVencimento = Convert.ToDateTime(dataVencimentoDateTimePicker.Value.ToString());
            conta.Observacao = observacaoTextBox.Text;
            conta.Valor = Convert.ToDecimal(valorTextBox.Text);
     

            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                GerenciadorConta.getInstace().inserir(conta);
                tb_contaTableAdapter.Fill(saceDataSet.tb_conta);
                tb_contaBindingSource.MoveLast();
            }
            else
            {
                GerenciadorConta.getInstace().atualizar(conta);
                tb_contaBindingSource.EndEdit();
                tb_contaTableAdapter.Fill(this.saceDataSet.tb_conta);
                tb_contaBindingSource.Position = tb_contaBindingSource.Find("codConta", conta.CodConta);
            }

            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_contaBindingSource.CancelEdit();
            tb_contaBindingSource.EndEdit();
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
                    tb_contaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_contaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_contaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_contaBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codDocumentoPagamentoComboBox.Focused))
                {
                    Telas.FrmDocumentoPagamentoPesquisa frmDocumentoPagamentoPesquisa = new Telas.FrmDocumentoPagamentoPesquisa();
                    frmDocumentoPagamentoPesquisa.ShowDialog();
                    if (frmDocumentoPagamentoPesquisa.CodDocumentoPagamento != -1)
                    {
                        tbdocumentopagamentoBindingSource.Position = tbdocumentopagamentoBindingSource.Find("codDocumentoPagamento", frmDocumentoPagamentoPesquisa.CodDocumentoPagamento);
                    }
                    frmDocumentoPagamentoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codDocumentoPagamentoComboBox.Focused))
                {
                    Telas.FrmDocumentoPagamento frmDocumentoPagamento = new Telas.FrmDocumentoPagamento(0);
                    frmDocumentoPagamento.ShowDialog();
                    if (frmDocumentoPagamento.CodDocumentoPagamento > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
                        tbdocumentopagamentoBindingSource.Position = tbdocumentopagamentoBindingSource.Find("codDocumentoPagamento", frmDocumentoPagamento.CodDocumentoPagamento);
                    }
                    frmDocumentoPagamento.Dispose();
                }

                else if ((e.KeyCode == Keys.F2) && (codPessoaComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPessoaComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }

                else if ((e.KeyCode == Keys.F2) && (codPlanoContaComboBox.Focused))
                {
                    Telas.FrmPlanoContaPesquisa frmPlanoContaPesquisa = new Telas.FrmPlanoContaPesquisa();
                    frmPlanoContaPesquisa.ShowDialog();
                    if (frmPlanoContaPesquisa.CodPlanoConta != -1)
                    {
                        tbplanocontaBindingSource.Position = tbplanocontaBindingSource.Find("codPlanoConta", frmPlanoContaPesquisa.CodPlanoConta);
                    }
                    frmPlanoContaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPlanoContaComboBox.Focused))
                {
                    Telas.FrmPlanoConta frmPlanoConta = new Telas.FrmPlanoConta();
                    frmPlanoConta.ShowDialog();
                    if (frmPlanoConta.CodPlanoConta > 0)
                    {
                        this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
                        tbplanocontaBindingSource.Position = tbplanocontaBindingSource.Find("codPlanoConta", frmPlanoConta.CodPlanoConta);
                    }
                    frmPlanoConta.Dispose();
                }
            }
        }

        private void codDocumentoPagamentoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codDocumentoPagamentoComboBox_Leave(object sender, EventArgs e)
        {
            if (codDocumentoPagamentoComboBox.SelectedValue == null)
            {
                codDocumentoPagamentoComboBox.Focus();
                throw new TelaException("Um documento de pagamento válido precisa ser selecionado.");
            }
            
            else 
            {
                Int64 codDocumentoPagamento = Convert.ToInt64(codDocumentoPagamentoComboBox.SelectedValue.ToString());
                // Caso que um documento válido seja selecionado. 
                if (codDocumentoPagamento != 0) {
                    DocumentoPagamento documento = GerenciadorDocumentoPagamento.getInstace().obterDocumentoPagamento(codDocumentoPagamento);
                    dataVencimentoDateTimePicker.Value = documento.DataVencimento;
                    valorTextBox.Text = documento.Valor.ToString(); ;
                    tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", documento.CodPessoaResponsavel);
                    tb_contaBindingSource_CurrentChanged(sender, e);
                }
            }
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
            bool possuiDocumento = (codDocumentoPagamentoComboBox.SelectedIndex != 0);
            dataVencimentoDateTimePicker.Enabled = !possuiDocumento;
            valorTextBox.Enabled = !possuiDocumento;
            codPessoaComboBox.Enabled = !possuiDocumento;
            if (codContaTextBox.Text != "")
                this.tb_movimentacao_contaTableAdapter.FillByCodConta(this.saceDataSet.tb_movimentacao_conta, Convert.ToInt64(codContaTextBox.Text));
        }
    }
}