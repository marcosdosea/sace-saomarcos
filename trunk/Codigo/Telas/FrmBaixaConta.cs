using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using SACE.Telas;
using SACE;
using SACE.Excecoes;

namespace SACE.Telas
{
    public partial class FrmBaixaConta : Form
    {
        private double total = 0;

        public FrmBaixaConta()
        {
            InitializeComponent();
        }

        private void FrmBaixaConta_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.GetInstancia().verificaPermissao(this, Funcoes.BAIXAS, Principal.Autenticacao.CodUsuario);

            this.tb_contaTableAdapter.Fill(this.saceDataSet1.tb_conta);
            this.tb_baixa_contaTableAdapter.Fill(this.saceDataSet1.tb_baixa_conta);
            this.tb_conta_bancoTableAdapter1.Fill(this.saceDataSet1.tb_conta_banco);
            this.tb_forma_pagamentoTableAdapter1.Fill(this.saceDataSet1.tb_forma_pagamento);
        }

        private void baixaButton_Click(object sender, EventArgs e)
        {
            string tipo;
            bool naoalterar = false;
            total = 0;
            ConfirmarButton.Enabled = true;
            if (contasDataGridView.SelectedRows.Count > 0)
            {
                pesquisaPanel.Enabled = false;
                baixaPanel.Enabled = true;
                tipo = contasDataGridView.SelectedRows[0].Cells["tipoContaDataGridViewTextBoxColumn"].Value.ToString();
                for (int i = 0; i < contasDataGridView.SelectedRows.Count; i++)
                {
                    long codConta = Convert.ToInt64(contasDataGridView.SelectedRows[i].Cells["codContaDataGridViewTextBoxColumn"].Value.ToString());
                    total += Convert.ToDouble(tb_contaTableAdapter.GetValorTotalConta(codConta)) - Convert.ToDouble(tb_baixa_contaTableAdapter.GetTotalQuitado(codConta));
                    if (tipo != contasDataGridView.SelectedRows[i].Cells["tipoContaDataGridViewTextBoxColumn"].Value.ToString())
                    {
                        ConfirmarButton.Enabled = false;
                        naoalterar = true;
                    }
                }
                if (naoalterar)
                {
                    MessageBox.Show("Não pode dar baixa em contas de tipos diferente!");
                }
                totalLabel.Text = "R$ " + string.Format("{0:N}", total);
            }
            else
            {
                throw new TelaException("Nenhum item selecionado!");
            }
        }

        public string verificaTipo()
        {
            if(pagarRadioButton.Checked)
                return "P";
            if(receberRadioButton.Checked)
                return "R";
            return null;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            pesquisaPanel.Enabled = true;
            baixaPanel.Enabled = false;
        }

        private void valorTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D0:
                case Keys.D1:
                case Keys.D2:
                case Keys.D3:
                case Keys.D4:
                case Keys.D5:
                case Keys.D6:
                case Keys.D7:
                case Keys.D8:
                case Keys.D9:
                    e.SuppressKeyPress = false;
                    break;
                case Keys.Decimal:
                    e.SuppressKeyPress = false;
                    break;
                case Keys.NumPad0:
                case Keys.NumPad1:
                case Keys.NumPad2:
                case Keys.NumPad3:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                case Keys.NumPad7:
                case Keys.NumPad8:
                case Keys.NumPad9:
                case Keys.Back:
                case Keys.Left:
                case Keys.Right:
                    e.SuppressKeyPress = false;
                    break;
                default:
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            double valor = double.Parse(valorTextBox.Text);
            if (valor <= total)
            {
                int formaPgto = Convert.ToInt32(formaPagamentoComboBox.SelectedValue);
                long contaBanco = Convert.ToInt32(contaBancoComboBox.SelectedValue);
                int i = 0;
                while(i < contasDataGridView.SelectedRows.Count && total>0)
                {
                    int codConta = Convert.ToInt32(contasDataGridView.SelectedRows[i].Cells["codContaDataGridViewTextBoxColumn"].Value.ToString());
                    char situacao = 'Q';
                    double valorQuitado = Convert.ToDouble(tb_baixa_contaTableAdapter.GetTotalQuitado(codConta));
                    double valorTotal = Convert.ToDouble(tb_contaTableAdapter.GetValorTotalConta(codConta));
                    double valorRestante = valorTotal - valorQuitado;
                    if (valor < valorRestante)
                    {
                        valorRestante = valor;
                        situacao = 'A';
                    }
                    if (valorRestante > 0)
                    {
                        tb_baixa_contaTableAdapter.Insert(formaPgto, valorRestante.ToString(),
                            codConta, "0", contaBanco, dataDateTimePicker.Value);
                        tb_contaTableAdapter.UpdateSituacao(situacao.ToString(), codConta);
                        valor -= valorRestante;
                    }
                    i++;
                }
                this.tb_contaTableAdapter.Fill(this.saceDataSet1.tb_conta);
                this.tb_baixa_contaTableAdapter.Fill(this.saceDataSet1.tb_baixa_conta);
                cancelarButton_Click(sender, e);
            }
            else
            {
                throw new NegocioException("Valor não pode ser maior que o total a ser quitado!");
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            string tipo = null;
            if (pagarRadioButton.Checked)
                tipo = "P";
            if (receberRadioButton.Checked)
                tipo = "R";

            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodConta(this.saceDataSet1.tb_conta, int.Parse(txtTexto.Text), tipo);
            else if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodPessoa(this.saceDataSet1.tb_conta, int.Parse(txtTexto.Text), tipo);
            else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodEntrada(this.saceDataSet1.tb_conta, int.Parse(txtTexto.Text), tipo);
            else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodSaida(this.saceDataSet1.tb_conta, int.Parse(txtTexto.Text), tipo);
        }
    }
}
