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
    public partial class FrmProcessarCartao : Form
    {
        private List<Pagamento> listaPagamentos;
        private ComunicacaoCartao comunicacaoCartao;
        private int quantidadePagamentosProcessada = 0;

        public ResultadoProcessamento ResultadoProcessamento { get; set; }

        public FrmProcessarCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos)
        {
            InitializeComponent();
            this.listaPagamentos = listaPagamentos;
            ResultadoProcessamento = new ResultadoProcessamento();
            this.comunicacaoCartao = comunicacaoCartao;
            ProcessarCartao(comunicacaoCartao, listaPagamentos);
            btnProcessar.Focus();
        }

        private void ProcessarCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos)
        {
            bool cartoesAprovados = true;
            while (cartoesAprovados && quantidadePagamentosProcessada < listaPagamentos.Count) {
                Pagamento pagamento = listaPagamentos.ElementAt(quantidadePagamentosProcessada);
                quantidadePagamentosProcessada++;
                AtualizarDadosTela(pagamento, quantidadePagamentosProcessada);
                ResultadoProcessamento resultado = null;// comunicacaoCartao.ProcessarPagamentos(pagamento);
                cartoesAprovados = resultado.Aprovado;
            }
            //if (cartoesAprovados)
            //    comunicacaoCartao.FinalizarPagamento();
        }

        private void AtualizarDadosTela(Pagamento pagamento, int ordemPagamento)
        {
            pictureBanese.Visible = pagamento.NomeCartao.Equals("BANESECARD");
            pictureVisa.Visible = pagamento.NomeCartao.Equals("VISA");
            pictureMastercard.Visible = pagamento.NomeCartao.Equals("MASTERCARD");
            pictureElo.Visible = pagamento.NomeCartao.Equals("ELO");
            lblAutorizacao.Text = "";
            lblCodPedido.Text = "";
            lblNumeroCartoes.Text = ordemPagamento + "/" + listaPagamentos.Count;
            lblOperacao.Text = pagamento.TipoCartao.ToString();
            lblParcelas.Text = pagamento.QuantidadeParcelas.ToString("N2");
            lblValor.Text = pagamento.Valor.ToString("N2");
        }


        private void btnProcessar_Click(object sender, EventArgs e)
        {
            ProcessarCartao(comunicacaoCartao, listaPagamentos);
            this.Close();
        }

   }
}
