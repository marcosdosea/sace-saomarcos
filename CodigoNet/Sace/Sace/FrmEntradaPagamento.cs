using Dominio;
using Util;

namespace Sace
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
            codEntradaTextBox.Text = entrada.CodEntrada.ToString();
            codFornecedorTextBox.Text = entrada.NomeFornecedor;
            totalNotaTextBox.Text = entrada.TotalNota.ToString("N2");
            codEmpresaFreteTextBox.Text = entrada.NomeEmpresaFrete;
            valorFreteTextBox.Text = entrada.ValorFrete.ToString("N2");

            InicializaComponentes();
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            EntradaPagamento entradaPagamento = new EntradaPagamento();
            entradaPagamento.CodContaBanco = Convert.ToInt32(codContaBancoComboBox.SelectedValue.ToString());
            entradaPagamento.CodEntrada = entrada.CodEntrada;
            entradaPagamento.CodFormaPagamento = Convert.ToInt32(codFormaPagamentoComboBox.SelectedValue.ToString());
            entradaPagamento.Data = Convert.ToDateTime(dataDateTimePicker.Text);
            entradaPagamento.PagamentoDoFrete = pagamentoDoFreteCheckBox.Checked;

            entradaPagamento.Valor = Convert.ToDecimal(valorTextBox.Text);

            //GerenciadorEntradaPagamento.GetInstance().Inserir(entradaPagamento);

            InicializaComponentes();

           // this.tb_entrada_forma_pagamentoTableAdapter.FillByCodEntrada(saceDataSet.tb_entrada_forma_pagamento, long.Parse(codEntradaTextBox.Text));

            //decimal totalPago = GerenciadorEntradaPagamento.GetInstance().ObterPorEntrada(entrada.CodEntrada).Sum(ep => ep.Valor);

            //if (totalPago == (entrada.TotalNota + entrada.ValorFrete))
           // {
              //  btnEncerrar_Click(sender, e);
           // }
            //else
           // {
            //    codFormaPagamentoComboBox.Focus();
           // }
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma lançamentos de pagamentos?", "Confirmar Pagamentos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               // gerenciadorEntrada.Encerrar(entrada);

                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicializaComponentes()
        {
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
        }


        private void excluirPagamento(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão do pagamento?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_entrada_forma_pagamentoDataGridView.Rows.Count > 0)
                {
                    //long codEntradaPagamento = long.Parse(tb_entrada_forma_pagamentoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    //Negocio.GerenciadorEntradaPagamento.GetInstance().Remover(codEntradaPagamento);
                    //this.tb_entrada_forma_pagamentoTableAdapter.FillByCodEntrada(saceDataSet.tb_entrada_forma_pagamento, entrada.CodEntrada);
                    InicializaComponentes();
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
                //codContaBancoComboBox.Enabled = (formaPagamento == FormaPagamento.DEPOSITO) || (formaPagamento == FormaPagamento.DINHEIRO);
                //codDocumentoPagamentoComboBox.Enabled = (formaPagamento == FormaPagamento.CHEQUE) || (formaPagamento == FormaPagamento.BOLETO) || (formaPagamento == FormaPagamento.PROMISSORIA);
                //valorTextBox.Enabled = (formaPagamento != FormaPagamento.CHEQUE) && (formaPagamento != FormaPagamento.BOLETO) || (formaPagamento != FormaPagamento.PROMISSORIA);
                //dataDateTimePicker.Enabled = (formaPagamento == FormaPagamento.CARTAO) || (formaPagamento == FormaPagamento.CREDIARIO)
                 //   || (formaPagamento == FormaPagamento.DEPOSITO);
            }
        }
    }
}
