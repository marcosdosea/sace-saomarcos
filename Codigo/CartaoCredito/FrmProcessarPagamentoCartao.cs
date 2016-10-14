using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cartao
{
    public partial class FrmProcessarPagamentoCartao : Form
    {
        private List<Pagamento> listaPagamentos;
        private ComunicacaoCartao comunicacaoCartao;
        public ResultadoProcessamento ResultadoProcessamento { get; set; }


        public FrmProcessarPagamentoCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos, TipoProcessamento tipoProcessamento)
        {
            InitializeComponent();
            this.listaPagamentos = listaPagamentos;
            this.comunicacaoCartao = comunicacaoCartao;
            pagamentoBindingSource.DataSource = listaPagamentos;
            textTotal.Text = listaPagamentos.Sum(p => p.Valor).ToString("C2");
            if (tipoProcessamento.Equals(TipoProcessamento.PAGAMENTO))
                ProcessarPagamentos();

        }

        private void ProcessarPagamentos()
        {
            ResultadoProcessamento = comunicacaoCartao.ProcessarPagamentos(listaPagamentos);
            this.Close();
        }

        private void FrmProcessarPagamentoCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnImprimir_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }
   }
}
