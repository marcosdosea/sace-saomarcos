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
using System.IO;

namespace Telas
{
    public partial class FrmSaidaAutorizacao : Form
    {
        private long codSaida;
        private long codSolicitacao;
        NfeControle nfeControle;
        private bool exibiuResultadoCartao = false;
        private bool exibiuResultadoNfe = false;

        public FrmSaidaAutorizacao(long codSaida, long codSolicitacao)
        {
            InitializeComponent();
            this.codSaida = codSaida;
            this.codSolicitacao = codSolicitacao;
            nfeControle = null;
            lblCartao.ForeColor = Color.Black;
        }

        private void timerAtualizaNFCe_Tick(object sender, EventArgs e)
        {
            if (!exibiuResultadoCartao || !exibiuResultadoNfe)
            {
                Dados.tb_solicitacao_documento documentoE = GerenciadorSolicitacaoDocumento.GetInstance().ObterSolicitacaoDocumento(codSolicitacao);
                if (documentoE != null)
                {
                    if (documentoE.haPagamentoCartao && !exibiuResultadoCartao)
                    {
                        ExibirResultadoProcessamentoCartao(documentoE);
                    }
                }
                textCartao.Text = "Cartão de Crédito/Débito não utilizado.";
                ExibirResultadoProcessamentoNFCe();
            }
        }

        private void ExibirResultadoProcessamentoNFCe()
        {
            lblCartao.Text = "Aguardando Autorização NF-e... ";
            textNfe.Text = "Favor aguardar....";
            Cursor.Current = Cursors.WaitCursor;
            // recupera a último envio da nfe
            List<NfeControle> listaNfe = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida).OrderBy(nfe => nfe.CodNfe).ToList();
            nfeControle = listaNfe.LastOrDefault();

            if (nfeControle != null && !nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA))
            {
                Cursor.Current = Cursors.WaitCursor;
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                {
                    lblNffe.Text = "NFC-e AUTORIZADA.";
                    lblNffe.ForeColor = Color.Green;
                    Cursor.Current = Cursors.Default;
                    //this.Close();
                }
                else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_REJEITADA))
                {
                    lblNffe.Text = "NFC-e rejeitada. ";
                    textNfe.Text = nfeControle.MensagemSitucaoProtocoloUso;
                    lblNffe.ForeColor = Color.Red;
                    Cursor.Current = Cursors.Default;
                    btnCancelar.Focus();
                }
                else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA))
                {
                    lblNffe.Text = "NFC-e não Validada.";
                    //textNfe.Text = "Favor verificar {0} (1) NCM ausentes nos produtos {0} (2) CNPJ/CPF ou IE do cliente incorretos. {0}";
                    lblNffe.ForeColor = Color.Red;
                    Cursor.Current = Cursors.Default;
                    Loja loja = GerenciadorLoja.GetInstance().Obter(nfeControle.CodLoja).ElementAtOrDefault(0);
                    if (loja != null)
                    {
                        DirectoryInfo Dir = new DirectoryInfo(loja.PastaNfeErro);
                        string numeroLote = "";
                        if (Dir.Exists)
                        {
                            string arquivoRetornoLote = nfeControle.Chave + "-nfe.err";
                            FileInfo[] files = Dir.GetFiles(arquivoRetornoLote, SearchOption.TopDirectoryOnly);
                            if (files.Length > 0)
                            {
                                StreamReader reader = new StreamReader(files[0].FullName);
                                textNfe.Text = reader.ReadToEnd();
                            }
                        }
                    }
                }
                
                
                btnCancelar.Enabled = true;
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA))
                {
                    timerAtualizaNFCe.Enabled = false;
                
                    btnImprimir.Enabled = true;
                    btnImprimir.Focus();
                }
                else
                {
                    btnCancelar.Focus();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaAutorizacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            } else if (e.KeyCode == Keys.F8)
            {
                btnImprimir_Click(sender, e);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (nfeControle != null)
                GerenciadorNFe.GetInstance().imprimirDANFE(nfeControle);
            this.Close();
        }



    }
}
