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
        private DateTime dataInicio;
        private DateTime dataFim;
        private bool abertaChecked;
        private bool quitadaChecked;

        public FrmReceberPagamentoPessoa()
        {
            InitializeComponent();
        }

        private void FrmReceberPagamentoPessoa_Load(object sender, EventArgs e)
        {
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
           habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma registro de pagamento?", "Confirmar Pagamento", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                List<long> listaContas = new List<long>();
                for (int i = contasPessoaDataGridView.SelectedRows.Count-1; i >= 0 ; i--)
                {
                    listaContas.Add(Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[0].Value.ToString())); //codConta 
                }
                MovimentacaoConta movimentacao = new MovimentacaoConta();
                movimentacao.CodConta = listaContas.ElementAt(0); // valor é irrelevante
                movimentacao.CodContaBanco = Global.CAIXA_PADRAO;
                movimentacao.CodResponsavel = pessoa.CodPessoa;
                movimentacao.CodTipoMovimentacao = TipoMovimentacaoConta.RECEBIMENTO_CREDIARIO;
                movimentacao.DataHora = DateTime.Now;
                movimentacao.Valor = Convert.ToDecimal(valorPagamentoTextBox.Text);
                decimal descontoPorConta = Convert.ToDecimal(descontoTextBox.Text);
                GerenciadorMovimentacaoConta.getInstace().inserir(movimentacao, listaContas, descontoPorConta);
                codClienteComboBox_Leave(sender, e);
            }
            habilitaBotoes(true);
            btnNovo.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            HashSet<long> codSaidas = new HashSet<long>();

            for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
            {
                codSaidas.Add(Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString())); //pre-venda
            }

            decimal total = Convert.ToDecimal(totalContasTextBox.Text);
            decimal totalAVista = Convert.ToDecimal(totalPagarTextBox.Text);
            decimal desconto = Convert.ToDecimal(descontoTextBox.Text);

            FrmSaidaDAV frmSaidaDAV = new FrmSaidaDAV(codSaidas, total, totalAVista, desconto);
            frmSaidaDAV.ShowDialog();
            frmSaidaDAV.Dispose();
        }

        private void btnCFNfe_Click(object sender, EventArgs e)
        {
            HashSet<long> codSaidas = new HashSet<long>();

            string pedidoGerado = contasPessoaDataGridView.SelectedRows[0].Cells[4].Value.ToString();

            if (!pedidoGerado.Trim().Equals(""))
            {
                if (MessageBox.Show("Confirma emisssão da Nota Fiscal?", "Confirmar Impressão Nota Fiscal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    long codSaida = Convert.ToInt64(contasPessoaDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                    Saida saida = GerenciadorSaida.getInstace().obterSaida(codSaida);
                    GerenciadorSaida.getInstace().imprimirNotaFiscal(saida);
                }
            }
            else
            {

                for (int i = contasPessoaDataGridView.SelectedRows.Count - 1; i >= 0; i--)
                {
                    codSaidas.Add(Convert.ToInt64(contasPessoaDataGridView.SelectedRows[i].Cells[1].Value.ToString())); //pre-venda
                }

                decimal total = Convert.ToDecimal(totalContasTextBox.Text);
                decimal totalAVista = Convert.ToDecimal(totalPagarTextBox.Text);

                if (MessageBox.Show("Confirma emisssão do Cupom Fiscal das Contas Selecionadas?", "Confirmar Impressão Cupom Fiscal", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaidaPagamento saidaPagamento = new SaidaPagamento();
                    FormaPagamento dinheiro = GerenciadorFormaPagamento.getInstace().obterFormaPagamento(FormaPagamento.DINHEIRO);
                    saidaPagamento.CodFormaPagamento = FormaPagamento.DINHEIRO;
                    saidaPagamento.MapeamentoFormaPagamento = dinheiro.Mapeamento;
                    saidaPagamento.DescricaoFormaPagamento = dinheiro.Descricao;
                    saidaPagamento.Valor = Convert.ToDecimal(valorPagamentoTextBox.Text);
                    GerenciadorSaida.getInstace().GerarDocumentoFiscal(codSaidas, total, totalAVista, new List<SaidaPagamento>() { saidaPagamento });
                }
            }
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
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F7)
                {
                    btnImprimir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F8)
                {
                    btnCFNfe_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
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
            pessoa = GerenciadorPessoa.getInstace().obterPessoaNomeFantasiaIgual(codClienteComboBox.Text);
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

                    // Guarda os dados das variáveis para verificar se há necessidade de uma nova consulta
                    dataInicio = Convert.ToDateTime(dataInicioDateTimePicker.Text);
                    dataFim = Convert.ToDateTime(dataFinalDateTimePicker.Text);
                    abertaChecked = abertaCheckBox.Checked;
                    quitadaChecked = quitadaCheckBox.Checked;
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
            // Se houve alteração nos valores da consulta
            if (!dataInicioDateTimePicker.Value.Equals(dataInicio) || !dataFinalDateTimePicker.Value.Equals(dataFim) ||
                (abertaCheckBox.Checked != abertaChecked) || (quitadaCheckBox.Checked != quitadaChecked) )
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

                dataInicio = Convert.ToDateTime(dataInicioDateTimePicker.Text);
                dataFim = Convert.ToDateTime(dataFinalDateTimePicker.Text);
                abertaChecked = abertaCheckBox.Checked;
                quitadaChecked = quitadaCheckBox.Checked;

                contasPessoaDataGridView.DataSource = GerenciadorConta.getInstace().ObterContasPorPessoaSituacaoPeriodo(pessoa.CodPessoa, situacoes, dataInicio, dataFim);
                contasPessoaDataGridView.SelectAll();
            }

        }

        private void DescontoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox) sender);
            //CalcularDescontos();
            valorPagamentoTextBox.Text = totalPagarTextBox.Text;
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
            decimal totalDesconto = 0;
            decimal totalPagamentos = 0;
            for (int i = 0; i < contasPessoaDataGridView.SelectedRows.Count; i++)
            {
                totalContas += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[5].Value.ToString()); //total
                totalDesconto += Convert.ToDecimal(contasPessoaDataGridView.SelectedRows[i].Cells[6].Value.ToString()); //totalPagar
            }

            for (int i = 0; i < tb_movimentacao_contaDataGridView.RowCount; i++)
            {
                totalPagamentos += Convert.ToDecimal(tb_movimentacao_contaDataGridView.Rows[i].Cells[6].Value.ToString());
            }
            totalContasTextBox.Text = totalContas.ToString("N2");
            totalPagamentosTextBox.Text = totalPagamentos.ToString("N2");
            faltaReceberTextBox.Text = (totalContas - totalPagamentos).ToString("N2");
            totalPagarTextBox.Text = (totalContas - totalDesconto - totalPagamentos).ToString("N2");
            if (totalDesconto > 0)
            {
                descontoTextBox.Text = ((totalDesconto / totalContas) * 100).ToString("N2");
            }
            valorPagamentoTextBox.Text = totalPagarTextBox.Text;
        }

        private void ContasPessoaDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ListarPagamentosContasSelecionadas();
            CalcularTotalContasSelecionadas();
        }


       
    }
}
