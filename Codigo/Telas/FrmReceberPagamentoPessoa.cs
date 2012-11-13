using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Dados.saceDataSetTableAdapters;
using MySql.Data.MySqlClient;
using Dados;
using Dominio;
using Negocio;
using Util;


namespace Telas
{
    public partial class FrmReceberPagamentoPessoa : Form
    {
        private EstadoFormulario estado;

        Pessoa pessoa;

        public FrmReceberPagamentoPessoa()
        {
            InitializeComponent();
        }

        private void FrmReceberPagamentoPessoa_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.BANCOS, Principal.Autenticacao.CodUsuario);
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_forma_pagamentoTableAdapter.Fill(this.saceDataSet.tb_forma_pagamento);
            habilitaBotoes(true);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            totalContasTextBox.Text = "0,00";
            totalPagamentosTextBox.Text = "0,00";
            faltaReceberTextBox.Text = "0,00";
            descontoTextBox.Text = "0,00";
            totalPagarTextBox.Text = "0,00";
            valorPagamentoTextBox.Text = "0,00";
            codClienteComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //tb_bancoBindingSource.CancelEdit();
            //tb_bancoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma registro de pagamento GLOBAL?", "Confirmar Pagamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //GerenciadorLoja.getInstace().remover(int.Parse(codLojaTextBox.Text));
                //tb_lojaTableAdapter.Fill(saceDataSet.tb_loja);
            }
            habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void FrmReceberPagamentoPessoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
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
                else if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
        }
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnNovo.Enabled = habilita;

            btnImprimir.Enabled = contasPessoaDataGridView.RowCount > 0;
            btnCFNfe.Enabled = contasPessoaDataGridView.RowCount > 0;

            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void codClienteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codClienteComboBox_Leave(object sender, EventArgs e)
        {
            pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeIgual(codClienteComboBox.Text);
            if (pessoa == null)
            {
                Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(codClienteComboBox.Text);
                frmPessoaPesquisa.ShowDialog();
                if (frmPessoaPesquisa.CodPessoa != -1)
                {
                    tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    codClienteComboBox.Text = ((Dados.saceDataSet.tb_pessoaRow)((DataRowView)tbpessoaBindingSource.Current).Row).nome;
                }
                else
                {
                    codClienteComboBox.Focus();
                }
                frmPessoaPesquisa.Dispose();
            }
            else
            {
                tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", pessoa.CodPessoa);
                // Obter todas as contas da pessoa em aberto
                contasPessoaDataGridView.DataSource = GerenciadorConta.getInstace().ObterContasPorPessoaAberta(pessoa.CodPessoa);
                descontoTextBox.Text = "0";
                if (contasPessoaDataGridView.RowCount > 0)
                {
                    //Obter maior e menor data de vencimento para preencher corrretamente
                    dataInicioDateTimePicker.Text = contasPessoaDataGridView.Rows[0].Cells[2].Value.ToString();
                    int ultimaLinha = contasPessoaDataGridView.RowCount - 1;
                    dataFinalDateTimePicker.Text = contasPessoaDataGridView.Rows[ultimaLinha].Cells[2].Value.ToString();

                }
                contasPessoaDataGridView.SelectAll();
            }
            habilitaBotoes(false);
        }

        private string obterListaSituacao()
        {
            if (abertaCheckBox.Checked && quitadaCheckBox.Checked)
                return Conta.SITUACAO_ABERTA + "," + Conta.SITUACAO_PARCIALMENTE_QUITADA + "," + Conta.SITUACAO_QUITADA;
            else if (abertaCheckBox.Checked)
                return Conta.SITUACAO_ABERTA + "," + Conta.SITUACAO_PARCIALMENTE_QUITADA;
            else if (quitadaCheckBox.Checked)
                return Conta.SITUACAO_QUITADA.ToString();
            else
                return "";
        }

        private void dataInicioDateTimePicker_Leave(object sender, EventArgs e)
        {
            List<char> situacoes = new List<char>();

            if (abertaCheckBox.Checked)
            {
                situacoes.Add(Conta.SITUACAO_ABERTA);
            }
            if (quitadaCheckBox.Checked)
            {
                situacoes.Add(Conta.SITUACAO_QUITADA);
            }

            DateTime dataInicio = dataInicioDateTimePicker.Value;
            DateTime dataFinal = dataFinalDateTimePicker.Value;

            contasPessoaDataGridView.DataSource = GerenciadorConta.getInstace().ObterContasPorPessoaSituacaoPeriodo(pessoa.CodPessoa, situacoes, dataInicio, dataFinal);
        }

        private void DescontoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox) sender);
            CalcularDescontos();
        }
        
        private void CalcularDescontos() {
            decimal desconto = Convert.ToDecimal(descontoTextBox.Text);
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                decimal valor = (decimal)contasPessoaDataGridView.Rows[i].Cells[5].Value; //total
                decimal descontoValorConta = valor * (desconto / 100);
                contasPessoaDataGridView.SelectedRows[i].Cells[6].Value = descontoValorConta.ToString("N2"); // desconto
                contasPessoaDataGridView.SelectedRows[i].Cells[7].Value = (valor - descontoValorConta).ToString("N2"); //totalPagar
            }
            CalcularTotalContasSelecionadas();
        }

        private void ListarPagamentosContasSelecionadas()
        {
            var contasExibidas = new List<Int64>();
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                contasExibidas.Add((long)contasPessoaDataGridView.SelectedRows[i].Cells[0].Value);
            }
            tb_movimentacao_contaDataGridView.DataSource = GerenciadorMovimentacaoConta.getInstace().ObterMovimentacaoPorContas(contasExibidas);
        }

        
        private void CalcularTotalContasSelecionadas()
        {
            decimal totalContas = 0;
            decimal totalPagar = 0;
            decimal totalPagamentos = 0;
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                totalContas += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[5].Value.ToString()); //total
                totalPagar += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[7].Value.ToString()); //totalPagar
            }

            for (int i = 0; i < tb_movimentacao_contaDataGridView.RowCount; i++)
            {
                totalPagamentos += Convert.ToDecimal(tb_movimentacao_contaDataGridView.Rows[i].Cells[2].Value.ToString());
            }
            totalContasTextBox.Text = totalContas.ToString("N2");
            totalPagamentosTextBox.Text = totalPagamentos.ToString("N2");
            faltaReceberTextBox.Text = (totalContas - totalPagamentos).ToString("N2");
            totalPagarTextBox.Text = totalPagar.ToString("N2");
        }

        private void ContasPessoaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            AnularDescontos();
            CalcularDescontos();
            ListarPagamentosContasSelecionadas();
        }

        private  void AnularDescontos()
        {
            for (int i = 0; i < contasPessoaDataGridView.Rows.Count; i++)
            {
                var valor = (decimal) contasPessoaDataGridView.Rows[i].Cells[5].Value; //total
                contasPessoaDataGridView.Rows[i].Cells[6].Value = 0; // desconto
                contasPessoaDataGridView.Rows[i].Cells[7].Value = valor; //totalPagar
            }
        }

    }
}
