using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;
using Util;

namespace Telas
{
    public partial class FrmEntradaPagamento : Form
    {
        private Entrada entrada;
        
        public FrmEntradaPagamento(Entrada entrada)
        {
            InitializeComponent();
            this.entrada = entrada;
        }

        private void FrmEntradaPagamento_Load(object sender, EventArgs e)
        {
            this.tb_forma_pagamentoTableAdapter.Fill(this.saceDataSet.tb_forma_pagamento);
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
            this.tb_entrada_forma_pagamentoTableAdapter.FillByCodEntrada(saceDataSet.tb_entrada_forma_pagamento, entrada.CodEntrada);

            codEntradaTextBox.Text = entrada.CodEntrada.ToString();
            codFornecedorTextBox.Text = entrada.NomeFornecedor;
            totalNotaTextBox.Text = entrada.TotalNota.ToString("N2");
            codEmpresaFreteTextBox.Text = entrada.NomeEmpresaFrete;
            valorFreteTextBox.Text = entrada.ValorFrete.ToString("N2");

            atualizaValores();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            EntradaPagamento entradaPagamento = new EntradaPagamento();
            entradaPagamento.CodContaBanco = Convert.ToInt32(codContaBancoComboBox.SelectedValue.ToString());
            entradaPagamento.CodDocumentoPagamento = Convert.ToInt32(codDocumentoPagamentoComboBox.SelectedValue.ToString());
            entradaPagamento.CodEntrada = entrada.CodEntrada;
            entradaPagamento.CodFormaPagamento = Convert.ToInt32(codFormaPagamentoComboBox.SelectedValue.ToString());
            entradaPagamento.Data = Convert.ToDateTime(dataDateTimePicker.Text);
            entradaPagamento.PagamentoDoFrete = pagamentoDoFreteCheckBox.Checked;

            entradaPagamento.Valor = Convert.ToDecimal(valorTextBox.Text);

            GerenciadorEntradaPagamento.getInstace().inserir(entradaPagamento, entrada);

            atualizaValores();

            this.tb_entrada_forma_pagamentoTableAdapter.FillByCodEntrada(saceDataSet.tb_entrada_forma_pagamento, long.Parse(codEntradaTextBox.Text));


            if (entrada.TotalPago == (entrada.TotalNota + entrada.ValorFrete) )
            {
                btnEncerrar_Click(sender, e);
            }
            else
            {
                codFormaPagamentoComboBox.Focus();
            }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma lançamentos de pagamentos?", "Confirmar Pagamentos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorEntrada.getInstace().encerrar(entrada);

                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void atualizaValores()
        {
            entrada.TotalPago = GerenciadorEntradaPagamento.getInstace().totalPagamentos(entrada.CodEntrada);
            totalRecebidoLabel.Text = entrada.TotalPago.ToString("N2");

            codFormaPagamentoComboBox.SelectedIndex = 3;
            codDocumentoPagamentoComboBox.SelectedIndex = 0;
            codContaBancoComboBox.SelectedIndex = 0;
        }

        private void FrmEntradaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F7)
            {
                btnEncerrar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                tb_entrada_forma_pagamentoDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            if ((e.KeyCode == Keys.Delete) && (tb_entrada_forma_pagamentoDataGridView.Focused == true))
            {
                excluirPagamento(sender, e);
            }

            if ((e.KeyCode == Keys.F2) && (codDocumentoPagamentoComboBox.Focused))
            {
                //Telas.FrmDocumentoPagamentoPesquisa frmDocumentoPagamentoPesquisa = new Telas.FrmDocumentoPagamentoPesquisa();
                //frmDocumentoPagamentoPesquisa.ShowDialog();
                //if (frmDocumentoPagamentoPesquisa.CodDocumentoPagamento != -1)
                //{
                //    tbdocumentopagamentoBindingSource.Position = tbdocumentopagamentoBindingSource.Find("codDocumentoPagamento", frmDocumentoPagamentoPesquisa.CodDocumentoPagamento);
                //}
                //frmDocumentoPagamentoPesquisa.Dispose();
            }
            else if ((e.KeyCode == Keys.F3) && (codDocumentoPagamentoComboBox.Focused))
            {
                //Int32 formaPagamentoSelecionada = Convert.ToInt32(codFormaPagamentoComboBox.SelectedValue.ToString());

                //Int32 codTipoDocumento = 0;
                //if (formaPagamentoSelecionada == FormaPagamento.BOLETO)
                //    codTipoDocumento = DocumentoPagamento.TIPO_BOLETO;
                //else if (formaPagamentoSelecionada == FormaPagamento.CHEQUE)
                //    codTipoDocumento = DocumentoPagamento.TIPO_CHEQUE;
                //else
                //    codTipoDocumento = DocumentoPagamento.TIPO_PROMISSORIA;

                ////Telas.FrmDocumentoPagamento frmDocumentoPagamento = new Telas.FrmDocumentoPagamento(codTipoDocumento);
                //frmDocumentoPagamento.ShowDialog();
                //if (frmDocumentoPagamento.CodDocumentoPagamento > 0)
                //{
                //    this.tb_documento_pagamentoTableAdapter.Fill(this.saceDataSet.tb_documento_pagamento);
                //    tbdocumentopagamentoBindingSource.Position = tbdocumentopagamentoBindingSource.Find("codDocumentoPagamento", frmDocumentoPagamento.CodDocumentoPagamento);
                //}
                //frmDocumentoPagamento.Dispose();
            }
        }


        private void excluirPagamento(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do pagamento?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_entrada_forma_pagamentoDataGridView.Rows.Count > 0)
                {
                    long codEntradaPagamento = long.Parse(tb_entrada_forma_pagamentoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorEntradaPagamento.getInstace().remover(codEntradaPagamento);
                    this.tb_entrada_forma_pagamentoTableAdapter.FillByCodEntrada(saceDataSet.tb_entrada_forma_pagamento, entrada.CodEntrada);
                    atualizaValores();
                }
            }
        }

        private void codDocumentoPagamentoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void valorTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
        }

      
        private void codFormaPagamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codFormaPagamentoComboBox.SelectedValue != null)
            {
                int formaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
                codContaBancoComboBox.Enabled = (formaPagamento == FormaPagamento.DEPOSITO) || (formaPagamento == FormaPagamento.DINHEIRO);
                codDocumentoPagamentoComboBox.Enabled = (formaPagamento == FormaPagamento.CHEQUE) || (formaPagamento == FormaPagamento.BOLETO) || (formaPagamento == FormaPagamento.PROMISSORIA);
                valorTextBox.Enabled = (formaPagamento != FormaPagamento.CHEQUE) && (formaPagamento != FormaPagamento.BOLETO) || (formaPagamento != FormaPagamento.PROMISSORIA);
                dataDateTimePicker.Enabled = (formaPagamento == FormaPagamento.CARTAO) || (formaPagamento == FormaPagamento.CREDIARIO)
                    || (formaPagamento == FormaPagamento.DEPOSITO);
            }
        }
    }
}
