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
    public partial class FrmSaidaAutorizacao : Form
    {
        private long codSolicitacao;
        //NfeControle nfeControle;
        private bool exibiuResultadoCartao = false;
        private bool exibiuResultadoNfe = false;

        public FrmSaidaAutorizacao(long codSolicitacao)
        {
            InitializeComponent();
            btnImprimir.Enabled = false;
            this.codSolicitacao = codSolicitacao;
            lblCartao.ForeColor = Color.Black;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //GerenciadorNFe.GetInstance().imprimirDANFE(nfeControle);
        }

        private void timerAtualizaNFCe_Tick(object sender, EventArgs e)
        {
            if (!exibiuResultadoCartao || !exibiuResultadoNfe)
            {
                Dados.tb_solicitacao_documento documentoE = GerenciadorSolicitacaoDocumento.GetInstance().ObterSolicitacaoDocumento(codSolicitacao);
                if (documentoE.haPagamentoCartao && !exibiuResultadoCartao)
                {
                    ExibirResultadoProcessamentoCartao(documentoE);
                }
                else if (!documentoE.haPagamentoCartao && !exibiuResultadoCartao)
                {
                    lblCartao.Text = "Cartão de crédito/débito não utilizado.";
                    exibiuResultadoCartao = true;
                }
                //else if (!exibiuResultadoNfe)
                //{
                //    ExibirResultadoProcessamentoNfe(documentoE);
                //}
            }
        }

        private void ExibirResultadoProcessamentoNfe(Dados.tb_solicitacao_documento documentoE)
        {
            if (!documentoE.nfeProcessada)
            {
                lblCartao.Text = "Aguardando Autorização NF-e... ";
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Dados.tb_solicitacao_saida solicitacaoSaida = documentoE.tb_solicitacao_saida.FirstOrDefault();
                // recupera a último envio da nfe
                NfeControle nfeControle = GerenciadorNFe.GetInstance().ObterPorSaida(solicitacaoSaida.codSaida).OrderBy(nfe => nfe.CodNfe).LastOrDefault();
                if (nfeControle != null && !nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                    {
                        lblCartao.Text = "NFC-e AUTORIZADA.";
                        lblCartao.ForeColor = Color.Green;
                        btnImprimir.Enabled = true;
                        btnImprimir.Focus();
                    }
                    else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_REJEITADA))
                    {
                        lblCartao.Text = "NFC-e rejeitada. " + nfeControle.MensagemSitucaoProtocoloUso;
                        lblCartao.ForeColor = Color.Red;
                        btnImprimir.Enabled = false;
                        btnCancelar.Focus();
                    }
                    else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA))
                    {
                        lblCartao.Text = "NFC-e não validada. Alguns dos produtos do pedido precisam de atualizações no cadastro.";
                        lblCartao.ForeColor = Color.Red;
                        btnImprimir.Enabled = false;
                        btnCancelar.Focus();
                    }
                }
            }
        }

        private void ExibirResultadoProcessamentoCartao(Dados.tb_solicitacao_documento documentoE)
        {
            if (!documentoE.cartaoProcessado)
            {
                lblCartao.Text = "Aguardando Autorização Cartão...";
                Cursor.Current = Cursors.WaitCursor;
            }
            else 
            {
                Cursor.Current = Cursors.Default;
                if (documentoE.cartaoAutorizado)
                {
                    lblCartao.ForeColor = Color.Green;
                    lblCartao.Text = "Transação AUTORIZADA!";
                    foreach (Dados.tb_solicitacao_pagamento pagamento in documentoE.tb_solicitacao_pagamento)
                    {
                        textCartao.Text += pagamento.cupomCliente;
                    }
                }
                else
                {
                    lblCartao.ForeColor = Color.Red;
                    lblCartao.Text = "Transação NÃO REALIZADA!";
                    textCartao.Text = documentoE.motivoCartaoNegado;
                }
                exibiuResultadoCartao = true;
            }
        }

    }
}
