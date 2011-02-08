using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dominio;
using Negocio;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmSaidaPagamento : Form
    {
        //private EstadoFormulario estado;
        private Saida saida;

        public FrmSaidaPagamento(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SaidaPagamento saidaPagamento = new SaidaPagamento();
            saidaPagamento.CodContaBanco = int.Parse(codContaBancoComboBox.SelectedValue.ToString());
            saidaPagamento.CodFormaPagamento = int.Parse(codFormaPagamentoComboBox.SelectedValue.ToString());
            saidaPagamento.Data = DateTime.Now;
            saidaPagamento.Valor = decimal.Parse(valorPagoTextBox.Text);

            GerenciadorSaidaPagamento.getInstace().inserir(saidaPagamento);
            
            saida.CodProfissional = long.Parse(codProfissionalComboBox.SelectedValue.ToString());
            saida.CodCliente = long.Parse(codClienteComboBox.SelectedValue.ToString());
            saida.Desconto = decimal.Parse(descontoTextBox.Text);
            saida.TipoSaida = int.Parse(codTipoSaidaComboBox.SelectedValue.ToString());
            saida.Total = decimal.Parse(totalTextBox.Text);
            //saida.TotalPago = decimal.Parse(valorPagoTextBox.Text);

            GerenciadorSaida.getInstace().atualizar(saida);

            Conta conta = new Conta();
            conta.CodSaida = saida.CodSaida;
            conta.CodPessoa = saida.CodCliente;
            conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
            conta.DataVencimento = saidaPagamento.Data;
            conta.TipoConta = Conta.CONTA_RECEBER;
            // VERIFICAR ISSO COM AS CONDICOES DE PAGAMENTO
            conta.Situacao = Conta.SITUACAO_ABERTA;
            GerenciadorConta.getInstace().inserir(conta);

            if (saidaPagamento.CodFormaPagamento == FormaPagamento.FORMA_PGTO_DINHEIRO)
            {

            }



            
            
            //GerenciadorMovimentacaoConta.getInstace().inserir(movimentacaoConta);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descontoAcrescimoLabel_Click(object sender, EventArgs e)
        {

        }

        private void FrmSaidaPagamento_Load(object sender, EventArgs e)
        {
            codSaidaTextBox.Text = saida.CodSaida.ToString();
            this.tb_tipo_saidaTableAdapter.Fill(this.saceDataSet.tb_tipo_saida);
            this.tb_forma_pagamentoTableAdapter.Fill(this.saceDataSet.tb_forma_pagamento);
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            totalTextBox.Text = saida.Total.ToString();
            totalPagarTextBox.Text = saida.Total.ToString();
            valorPagoTextBox.Text = saida.Total.ToString();
            trocoTextBox.Text = "0";
        }

        private void codSaidaTextBox_TextChanged(object sender, EventArgs e)
        {
            this.tb_saida_pagamentoTableAdapter.FillByCodSaida(saceDataSet.tb_saida_pagamento, long.Parse(codSaidaTextBox.Text));
        }

        private void codFormaPagamentoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean eDinheiro = (codFormaPagamentoComboBox.SelectedIndex == 1);
            parcelasTextBox.Enabled = !eDinheiro;
            parcelasTextBox.TabStop = !eDinheiro;
        }

        private void FrmSaidaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void valorPagoTextBox_Leave(object sender, EventArgs e)
        {
            double valorPago = double.Parse(valorPagoTextBox.Text);
            double valorTotal = double.Parse(totalPagarTextBox.Text);
            if (valorPago > valorTotal)
            {
                trocoTextBox.Text = (valorPago - valorTotal).ToString();
            }
            else
            {
                trocoTextBox.Text = "0.00";
            }
        }

        private void codTipoSaidaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void descontoTextBox_Leave(object sender, EventArgs e)
        {
            double valorTotal = double.Parse(totalPagarTextBox.Text);
            double desconto   = double.Parse(descontoTextBox.Text);
            totalPagarTextBox.Text = (valorTotal * (1 - (desconto /100))).ToString();
        }
    }
}
