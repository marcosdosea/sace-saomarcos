using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Data;

namespace Sace
{
    public partial class FrmSaidaAutorizacao : Form
    {
        private long codSaida;
        NfeControle nfeControle;
        private bool exibiuResultadoCartao = false;
        private bool exibiuResultadoNfe = false;
        DocumentoFiscal.TipoSolicitacao tipoNfe;
        int contConsultas;

        public FrmSaidaAutorizacao(long codSaida, long codCliente, DocumentoFiscal.TipoSolicitacao tipo)
        {
            InitializeComponent();
            this.codSaida = codSaida;
            nfeControle = null;
            lblCartao.ForeColor = Color.Black;
            tipoNfe = tipo;
            if (codCliente != Util.UtilConfig.Default.CLIENTE_PADRAO)
            {
                Pessoa? cliente = GerenciadorPessoa.Obter(codCliente);
                if ((cliente != null) && (cliente.ImprimirCF))
                    tipoNfe = DocumentoFiscal.TipoSolicitacao.NFE;
            }
            contConsultas = 0;
        }

        private void timerAtualizaNFCe_Tick(object sender, EventArgs e)
        {
            if (!exibiuResultadoCartao || !exibiuResultadoNfe)
            {
                //Dados.tb_solicitacao_documento documentoE = GerenciadorSolicitacaoDocumento.ObterSolicitacaoDocumento(codSolicitacao);
                //if (documentoE != null)
                //{
                //    if (documentoE.haPagamentoCartao && !exibiuResultadoCartao)
                //    {
                //        ExibirResultadoProcessamentoCartao(documentoE);
                //    }
                //}
                textCartao.Text = "Cartão de Crédito/Débito não utilizado.";
                ExibirResultadoProcessamentoNFCe();
            }
        }

        private void ExibirResultadoProcessamentoNFCe()
        {
            lblCartao.Text = "Solicitando Autorização... ";
            textNfe.Text = "Favor aguardar.";
            Cursor.Current = Cursors.WaitCursor;
            contConsultas++;
            // recupera a último envio da nfe
            List<NfeControle> listaNfe = GerenciadorNFe.ObterPorSaida(codSaida).OrderBy(nfe => nfe.CodNfe).ToList();
            if (tipoNfe==DocumentoFiscal.TipoSolicitacao.NFE)
                listaNfe = listaNfe.Where(nfe => nfe.Modelo.Equals(NfeControle.MODELO_NFE)).OrderBy(nfe => nfe.CodNfe).ToList();
            else
                listaNfe = listaNfe.Where(nfe => nfe.Modelo.Equals(NfeControle.MODELO_NFCE)).OrderBy(nfe => nfe.CodNfe).ToList();
            
            //if (listaNfe.Count == 0)
            //{
            //    listaNfe = GerenciadorNFe.ObterPorSaida(codSaida).OrderBy(nfe => nfe.CodNfe).ToList();
            //}
            //else
            //{
            //    novaSolicitacao = true;
            //}
            nfeControle = listaNfe.LastOrDefault();

            
            if (nfeControle != null && !nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA))
            {
                Cursor.Current = Cursors.WaitCursor;
                bool modeloSolicitado = (nfeControle.Modelo.Equals(NfeControle.MODELO_NFE) && (tipoNfe==DocumentoFiscal.TipoSolicitacao.NFE)) ||
                    (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE) && (tipoNfe == DocumentoFiscal.TipoSolicitacao.NFCE));
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA) && modeloSolicitado)
                {
                    if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                        lblNffe.Text = "NFe CONSUMIDOR AUTORIZADA.";
                    else
                        lblNffe.Text = "NFe AUTORIZADA.";
                    lblNffe.ForeColor = Color.Green;
                    Cursor.Current = Cursors.Default;
                    //this.Close();
                }
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_CONTINGENCIA_OFFLINE) && modeloSolicitado)
                {
                    if (nfeControle.Modelo.Equals(NfeControle.MODELO_NFCE))
                        lblNffe.Text = "NFe CONSUMIDOR OFF-LINE";
                    else
                        lblNffe.Text = "NFe OFF-LINE";
                    lblNffe.ForeColor = Color.Blue;
                    Cursor.Current = Cursors.Default;
                    //this.Close();
                }
                else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_REJEITADA))
                {
                    lblNffe.Text = "NF REJEITADA";
                    textNfe.Text = nfeControle.MensagemSitucaoProtocoloUso;
                    lblNffe.ForeColor = Color.Red;
                    Cursor.Current = Cursors.Default;
                    btnCancelar.Focus();
                }
                else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_NAO_VALIDADA))
                {
                    lblNffe.Text = "NF NÃO VALIDADA.";
                    //textNfe.Text = "Favor verificar {0} (1) NCM ausentes nos produtos {0} (2) CNPJ/CPF ou IE do cliente incorretos. {0}";
                    lblNffe.ForeColor = Color.Red;
                    Cursor.Current = Cursors.Default;
                    Loja loja = GerenciadorLoja.Obter(nfeControle.CodLoja).ElementAtOrDefault(0);
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
                if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_AUTORIZADA) && modeloSolicitado)
                {
                    timerAtualizaNFCe.Enabled = false;
                
                    btnImprimir.Enabled = true;
                    btnImprimir.Focus();
                }
                else if (nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_CONTINGENCIA_OFFLINE) && modeloSolicitado)
                {
                    timerAtualizaNFCe.Enabled = false;

                    btnImprimir.Enabled = true;
                    btnImprimir.Focus();
                } 
                else if (!nfeControle.SituacaoNfe.Equals(NfeControle.SITUACAO_SOLICITADA) && (contConsultas > 5))
                {
                    timerAtualizaNFCe.Enabled = false;
                    btnCancelar.Focus();
                }
                else
                {
                    btnCancelar.Focus();
                }
            }
        }

        private void ExibirResultadoProcessamentoCartao(SolicitacaoDocumento solicitacaoDocumento, List<SolicitacaoPagamento> solicitacaoPagamentos)
        {
            if (!solicitacaoDocumento.CartaoProcessado)
            {
                lblCartao.Text = "Aguardando Autorização Cartão...";
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                if (solicitacaoDocumento.CartaoAutorizado)
                {
                    lblCartao.ForeColor = Color.Green;
                    lblCartao.Text = "Transação AUTORIZADA!";
                    foreach (SolicitacaoPagamento pagamento in solicitacaoPagamentos)
                    {
                        textCartao.Text += pagamento.CupomCliente;
                    }
                }
                else
                {
                    lblCartao.ForeColor = Color.Red;
                    lblCartao.Text = "Transação NÃO REALIZADA!";
                    textCartao.Text = solicitacaoDocumento.MotivoCartaoNegado;
                }
                exibiuResultadoCartao = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (nfeControle != null)
            {
                nfeControle.CodSolicitacao = 0;
                GerenciadorNFe.Atualizar(nfeControle);
            }
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
            //nfeControle = GerenciadorNFe.ObterPorSolicitacao(codSolicitacao).FirstOrDefault();
            if (nfeControle != null)
            {
                GerenciadorNFe.ImprimirDanfe(nfeControle);
            }
            this.Close();
        }



    }
}
