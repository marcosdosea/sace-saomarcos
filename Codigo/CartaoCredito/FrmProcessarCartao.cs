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
        public ResultadoProcessamento Resultado { get; set; }
        
        public FrmProcessarCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos)
        {
            InitializeComponent();
            this.listaPagamentos = listaPagamentos;
            this.comunicacaoCartao = comunicacaoCartao;
            this.Resultado = comunicacaoCartao.Resultado;
        }

        private void FrmProcessarCartao_Load(object sender, EventArgs e)
        {
            btnProcessar.Focus();
        }

        private void ProcessarCartao(ComunicacaoCartao comunicacaoCartao, List<Pagamento> listaPagamentos)
        {
            if (listaPagamentos.Count > 1)
                comunicacaoCartao.IniciarMultiCartoes(listaPagamentos.Count);
            comunicacaoCartao.Resultado.Aprovado = true;
            while (comunicacaoCartao.Resultado.Aprovado && quantidadePagamentosProcessada < listaPagamentos.Count)
            {
                Pagamento pagamento = listaPagamentos.ElementAt(quantidadePagamentosProcessada);
                AtualizarDadosTela(pagamento, quantidadePagamentosProcessada);
                comunicacaoCartao.ProcessarPagamento(listaPagamentos.ElementAt(quantidadePagamentosProcessada));
                quantidadePagamentosProcessada++;
            }
            if (comunicacaoCartao.Resultado.Aprovado)
                comunicacaoCartao.FinalizarPagamento();
        }

        private void AtualizarDadosTela(Pagamento pagamento, int ordemPagamento)
        {
            pictureBanese.Visible = pagamento.NomeCartao.Contains("BANESECARD");
            pictureVisa.Visible = pagamento.NomeCartao.Contains("VISA");
            pictureMastercard.Visible = pagamento.NomeCartao.Contains("MASTERCARD");
            pictureElo.Visible = pagamento.NomeCartao.Contains("ELO");
            pictureHipercard.Visible = pagamento.NomeCartao.Contains("HIPERCARD");
            lblAutorizacao.Text = "";
            lblCodPedido.Text = "";
            lblNumeroCartoes.Text = ordemPagamento + "/" + listaPagamentos.Count;
            lblOperacao.Text = pagamento.TipoCartao.ToString();
            btnCancelar.Text = pagamento.QuantidadeParcelas.ToString("N2");
            lblValor.Text = pagamento.Valor.ToString("N2");
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            ProcessarCartao(comunicacaoCartao, listaPagamentos);
        }
   }
}
