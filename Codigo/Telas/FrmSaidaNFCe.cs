using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Telas
{
    public partial class FrmSaidaNFCe : Form
    {
        private long codSaida;
        private bool retornouResultadoNfe;
        private bool retornouResultadoCartao;
        NfeControle nfeControle;

        public FrmSaidaNFCe(long codSaida, bool haPagamentoCartao)
        {
            InitializeComponent();
            btnImprimir.Enabled = false;
            this.codSaida = codSaida;
            retornouResultadoNfe = false;
            retornouResultadoCartao = (haPagamentoCartao) ? false : true;
            progressBarEnvio.Maximum = 100;
            progressBarEnvio.Minimum = 0;
            progressBarEnvio.Step = 10;
            progressBarEnvio.Value = 0;
            lblEnvio.ForeColor = Color.Black;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GerenciadorNFe.GetInstance().imprimirDANFE(nfeControle);
        }

        private void timerAtualizaNFCe_Tick(object sender, EventArgs e)
        {
            if (retornouResultadoNfe && retornouResultadoCartao)
            {
                progressBarEnvio.Value = 100;
                this.Close();
            }
            else if (retornouResultadoCartao == false)
            {
                progressBarEnvio.Increment(5);
                lblEnvio.Text = "Aguardando Processamento Cartão Crédito...";
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
                if (saida.CodSituacaoPagamentos == SituacaoPagamentos.QUITADA)
                {
                    retornouResultadoCartao = true;
                    lblEnvio.Text = "Transação AUTORIZADA!";
                    progressBarEnvio.Increment(5);
                }
            }
            else
            {
                lblEnvio.Text = "Enviando NFC-e. Aguarde...";

                progressBarEnvio.Increment(5);
                // recupera a último envio da nfe
                NfeControle nfeControle = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida).OrderBy(nfe => nfe.CodNfe).LastOrDefault();
                if (nfeControle != null && !nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA))
                {
                    retornouResultadoNfe = true;
                    progressBarEnvio.Value = 100;
                    if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                    {
                        lblEnvio.Text = "NFC-e AUTORIZADA.";
                        lblEnvio.ForeColor = Color.Green;
                        btnImprimir.Enabled = true;
                        btnImprimir.Focus();
                    }
                    else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_REJEITADA))
                    {
                        lblEnvio.Text = "NFC-e rejeitada. " + nfeControle.MensagemSitucaoProtocoloUso;
                        lblEnvio.ForeColor = Color.Red;
                        btnImprimir.Enabled = false;
                        btnCancelar.Focus();
                    }
                    else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA))
                    {
                        lblEnvio.Text = "NFC-e não validada. Alguns dos produtos do pedido precisam de atualizações no cadastro.";
                        lblEnvio.ForeColor = Color.Red;
                        btnImprimir.Enabled = false;
                        btnCancelar.Focus();
                    }
                }
            }            
        }

        private void lblEnvio_Click(object sender, EventArgs e)
        {

        }
    }
}
