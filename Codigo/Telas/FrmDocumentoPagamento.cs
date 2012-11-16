using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dados.saceDataSetTableAdapters;
using Dados;
using Dominio;
using Negocio;
using Util;


namespace Telas
{
    public partial class FrmDocumentoPagamento : Form
    {
        private EstadoFormulario estado;
        
        private Int32 codDocumentoPagamento;
        private Int32 codTipoDocumento;
        private Int32 codPessoaResponsavel;

        public Int32 CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }
        public FrmDocumentoPagamento(Int32 codTipoDocumento)
        {
            InitializeComponent();
            this.codTipoDocumento = codTipoDocumento;
            codTipoDocumentoComboBox.Enabled = false;
        }

        public FrmDocumentoPagamento(Int32 codTipoDocumento, Int32 codPessoa)
        {
            InitializeComponent();
            this.codTipoDocumento = codTipoDocumento;
            this.codPessoaResponsavel = codPessoa;
            codTipoDocumentoComboBox.Enabled = false;
            codPessoaResponsavelComboBox.Enabled = false;
        }

        private void FrmDocumentoPagamento_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.BANCOS, Principal.Autenticacao.CodUsuario);

            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
            this.tb_tipo_documentoTableAdapter.Fill(this.saceDataSet.tb_tipo_documento);
            this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);

            habilitaBotoes(true);

            if (codPessoaResponsavel != Global.CLIENTE_PADRAO)
            {
                btnNovo_Click(sender, e);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmDocumentoPagamentoPesquisa frmDocumentoPagamentoPesquisa = new Telas.FrmDocumentoPagamentoPesquisa();
            frmDocumentoPagamentoPesquisa.ShowDialog();
            if (frmDocumentoPagamentoPesquisa.CodDocumentoPagamento != -1)
            {
                tb_documento_pagamentoBindingSource.Position = tb_documento_pagamentoBindingSource.Find("codDocumentoPagamento", frmDocumentoPagamentoPesquisa.CodDocumentoPagamento);
            }
            frmDocumentoPagamentoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_documento_pagamentoBindingSource.AddNew();
            codDocumentoPagamentoTextBox.Enabled = false;
            codBancoComboBox.SelectedValue = 1;
            codPessoaResponsavelComboBox.SelectedValue = 1;
            if (codTipoDocumento > 0)
            {
                codTipoDocumentoComboBox.SelectedValue = codTipoDocumento;
                codTipoDocumentoComboBox.Enabled = false;
            }
            else
            {
                codTipoDocumentoComboBox.SelectedValue = 1;
            }

            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
            if (codPessoaResponsavel > 1)
            {
                tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", codPessoaResponsavel);
                codPessoaResponsavelComboBox.Enabled = false;
                numeroDocumentoTextBox.Focus();
            }
            else
            {
                codPessoaResponsavelComboBox.Focus();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codPessoaResponsavelComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorDocumentoPagamento.getInstace().remover(int.Parse(codDocumentoPagamentoTextBox.Text));
                tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento); 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_documento_pagamentoBindingSource.CancelEdit();
            tb_documento_pagamentoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentoPagamento documento = new DocumentoPagamento();

                documento.CodDocumentoPagamento = Convert.ToInt64(codDocumentoPagamentoTextBox.Text);
                documento.Agencia = agenciaTextBox.Text;
                documento.CodBanco = Convert.ToInt32(codBancoComboBox.SelectedValue.ToString());
                documento.CodPessoaResponsavel = Convert.ToInt64(codPessoaResponsavelComboBox.SelectedValue.ToString());
                documento.CodTipoDocumento = Convert.ToByte(codTipoDocumentoComboBox.SelectedValue.ToString());
                documento.Conta = contaTextBox.Text;
                documento.DataDocumento = Convert.ToDateTime(dataDocumentoDateTimePicker.Text);
                documento.DataVencimento = Convert.ToDateTime(dataVencimentoDateTimePicker.Text);
                documento.Emitente = emitenteTextBox.Text;
                documento.NumeroDocumento = numeroDocumentoTextBox.Text;
                documento.Observacao = observacaoTextBox.Text;
                documento.Valor = Convert.ToDecimal(valorTextBox.Text);




                GerenciadorDocumentoPagamento gDocumentoPagamento = GerenciadorDocumentoPagamento.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    gDocumentoPagamento.inserir(documento);
                    tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
                    tb_documento_pagamentoBindingSource.MoveLast();
                }
                else
                {
                    gDocumentoPagamento.atualizar(documento);
                    tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
                    tb_documento_pagamentoBindingSource.Position = tb_documento_pagamentoBindingSource.Find("codDocumentoPagamento", documento.CodDocumentoPagamento);
                    tb_documento_pagamentoBindingSource.EndEdit();
                }
            }
            catch (DadosException de)
            {
                tb_documento_pagamentoBindingSource.CancelEdit();
                throw de;
            }
            finally
            {
                habilitaBotoes(true);
                btnBuscar.Focus();
            }
        }

        private void FrmDocumentoPagamento_KeyDown(object sender, KeyEventArgs e)
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
                    tb_documento_pagamentoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_documento_pagamentoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_documento_pagamentoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_documento_pagamentoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F2) && (codPessoaResponsavelComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codPessoaResponsavelComboBox.Focused))
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
                    if (frmBanco.CodBanco > 0)
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
            tb_documento_pagamentoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        

        private void codPessoaResponsavelComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void valorTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

        private void codPessoaResponsavelComboBox_Leave(object sender, EventArgs e)
        {
            if (codPessoaResponsavelComboBox.SelectedValue == null)
            {
                codPessoaResponsavelComboBox.Focus();
                throw new TelaException("Uma pessoa responsável válida precisa ser selecionada para o documento.");
            }
        }

        private void codBancoComboBox_Leave(object sender, EventArgs e)
        {
            if (codBancoComboBox.SelectedValue == null)
            {
                codBancoComboBox.Focus();
                throw new TelaException("Uma banco válido precisa ser selecionado para o documento.");
            }
        }

        private void FrmDocumentoPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            CodDocumentoPagamento = Convert.ToInt32(codDocumentoPagamentoTextBox.Text);
        }

        private void codTipoDocumentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codTipoDocumentoComboBox.SelectedValue != null)
            {
                Int32 codTipoDocumentoSelecionado = Convert.ToInt32(codTipoDocumentoComboBox.SelectedValue.ToString());
                agenciaTextBox.Enabled = (codTipoDocumentoSelecionado == DocumentoPagamento.TIPO_CHEQUE);
                contaTextBox.Enabled = (codTipoDocumentoSelecionado == DocumentoPagamento.TIPO_CHEQUE);
            }
        }
    }
}
