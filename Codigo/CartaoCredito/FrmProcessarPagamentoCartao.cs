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


        public FrmProcessarPagamentoCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos)
        {
            InitializeComponent();
            this.listaPagamentos = listaPagamentos;
            this.comunicacaoCartao = comunicacaoCartao;
            pagamentoBindingSource.DataSource = listaPagamentos;
            textTotal.Text = listaPagamentos.Sum(p => p.Valor).ToString("C2");
            btnProcessar.Focus();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            ResultadoProcessamento = comunicacaoCartao.ProcessarPagamentos(listaPagamentos);
            this.Close();
        }


   }
}
