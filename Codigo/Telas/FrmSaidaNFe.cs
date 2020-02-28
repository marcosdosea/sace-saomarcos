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
using Util;

namespace Telas
{
    public partial class FrmSaidaNFe : Form
    {
        static string SERVIDOR_IMPRIMIR_NFCE = Properties.Settings.Default.ServidorImprimirNfce;
        static string SERVIDOR_IMPRIMIR_NFE = Properties.Settings.Default.ServidorImprimirNfce;

        public Saida Saida { get; set; }
        private Pessoa Cliente { get; set; }
        private long codSaida;
        private List<SaidaPedido> listaSaidaPedido;
        private List<SaidaPagamento> listaSaidaPagamento;
        
       

        public FrmSaidaNFe(long codSaida, List<SaidaPedido> listaSaidaPedido, List<SaidaPagamento> listaSaidaPagamento)
        {
            InitializeComponent();
            this.codSaida = codSaida;
            this.Saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
            this.listaSaidaPedido = listaSaidaPedido;
            this.listaSaidaPagamento = listaSaidaPagamento;
            IEnumerable<Pessoa> listaPessoas = GerenciadorPessoa.GetInstance().Obter(Saida.CodCliente);
            nfeControleBindingSource.DataSource = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);
            if (Saida.CodCliente != Global.CLIENTE_PADRAO)
            {
                pessoaBindingSource.DataSource = listaPessoas;
                Cliente = listaPessoas.FirstOrDefault();
                codPessoaComboBox.Enabled = false;
                codPessoaComboBox.TabStop = false;
            }
            else
            {
                pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
                codPessoaComboBox.Focus();
            }

            if (Saida.Observacao.Trim().Equals(""))
            {
                if (Saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO)
                {
                    Saida.Observacao = "Nao Incidencia de ICMS conforme Art 2o, XI do RICMS/SE";
                }
                else if (Saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    Saida.Observacao = "Cod Cliente: " + Saida.CodCliente;
                }
                else if (Saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR)
                {
                    Entrada entrada = GerenciadorEntrada.GetInstance().Obter(Saida.CodEntrada).ElementAtOrDefault(0);
                    Saida.Observacao += " Devolução de Mercadorias relativo a nota fiscal número " + entrada.NumeroNotaFiscal +
                        " de " + entrada.DataEmissao.ToShortDateString() + " por estar em desacordo com o pedido. Valor da operação = R$ " +
                        Saida.TotalNotaFiscal.ToString("N2") + ". Base de Cálculo do ICMS = R$ " + Saida.BaseCalculoICMS.ToString("N2") +
                        ". Valor do ICMS = R$ " + Saida.ValorICMS.ToString("N2") + ". Base de Cálculo do ICMS ST = R$ " + Saida.BaseCalculoICMSSubst.ToString("N2") +
                        ". Valor do ICMS ST = R$ " + Saida.ValorICMSSubst.ToString("N2") + ". Valor do IPI = R$ " + Saida.ValorIPI.ToString("N2");
                }
                else if (Saida.TipoSaida == Saida.TIPO_DEVOLUCAO_CONSUMIDOR)
                {
                    SaidaPesquisa saidaCupomVenda = GerenciadorSaida.GetInstance(null).ObterPorPedido(Saida.Nfe).ElementAtOrDefault(0);
                    if (Saida.TotalAVista < saidaCupomVenda.TotalAVista)
                    {
                        Saida.Observacao += "Devolução Parcial referente ao cupom fiscal " + saidaCupomVenda.CupomFiscal + " emitido em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Cliente não precisou dos itens comprados. Cupom fiscal e Nf-e relativas a venda referenciadas abaixo";
                    }
                    else
                    {
                        Saida.Observacao += "Devolução Total referente ao cupom fiscal " + saidaCupomVenda.CupomFiscal + " emitido em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Cliente não precisou dos itens comprados. Cupom fiscal e Nf-e relativas a venda referenciadas abaixo";
                    }
                }
                else if (Saida.TipoSaida == Saida.TIPO_RETORNO_FORNECEDOR)
                {
                    SaidaPesquisa saidaCupomVenda = GerenciadorSaida.GetInstance(null).ObterPorPedido(Saida.Nfe).ElementAtOrDefault(0);
                    if (Saida.TotalAVista < saidaCupomVenda.TotalAVista)
                    {
                        Saida.Observacao += "Devolução Parcial referente a nota fiscal " + saidaCupomVenda.CupomFiscal + " emitida em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Fornecedor não aceitou receber os itens devolvidos porque estavam danificados. Nf-e relativa a devolução referenciada abaixo";
                    }
                    else
                    {
                        Saida.Observacao += "Devolução Total referente a nota fiscal " + saidaCupomVenda.CupomFiscal + " emitida em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Fornecedor não aceitou receber os itens devolvidos porque estavam danificados. Nf-e relativa a devolução referenciada abaixo";
                    }
                }
            }
            //if (string.IsNullOrEmpty(Saida.Nfe))
            //    Saida.Nfe = "NF-e";
            observacaoTextBox.Text = Saida.Observacao;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma envio de pedido de cancelamento da NF-e?", "Cancelar NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                NfeControle _nfeCurrent = (NfeControle)nfeControleBindingSource.Current;
                NfeControle _nfeControle = GerenciadorNFe.GetInstance().Obter(_nfeCurrent.CodNfe).ElementAtOrDefault(0);
                _nfeControle.JustificativaCancelamento = _nfeCurrent.JustificativaCancelamento;
                _nfeControle.CodSaida = _nfeCurrent.CodSaida;
                GerenciadorNFe.GetInstance().Atualizar(_nfeControle);
                GerenciadorNFe.GetInstance().EnviarSolicitacaoCancelamento(_nfeControle);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            NfeControle nfeControle = (NfeControle)nfeControleBindingSource.Current;
            GerenciadorNFe.GetInstance().imprimirDANFE(nfeControle, SERVIDOR_IMPRIMIR_NFE, SERVIDOR_IMPRIMIR_NFCE);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // o evento foi disparo do butão que emite Nf-
            bool ehNfeComplementar = (sender is Button) && ((Button)sender).Name.Equals("btnComplementar");

            if (Saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) || Saida.TipoSaida.Equals(Saida.TIPO_REMESSA_CONSERTO))
            {
                if (MessageBox.Show("Deseja gerar espelho da NF-e para Validação?", "Criar Espelho da NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Atualiza os dados da saída
                    Saida.Observacao = observacaoTextBox.Text.Trim();
                    if (Saida.CupomFiscal.Trim().Equals(""))
                        GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, Saida.CodSaida);
                    //List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>() { new SaidaPedido() { CodSaida = Saida.CodSaida, TotalAVista = Saida.TotalAVista } };
                    //List<SaidaPagamento> listaSaidaPagamento = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(Saida.CodSaida);
                    GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao.NFE, ehNfeComplementar, true);
                }
            }

            if (MessageBox.Show("Confirma envio da NF-e?", "Enviar NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                // Atualiza os dados da saída
                if ((Cliente == null) || Cliente.CodPessoa.Equals(Global.CLIENTE_PADRAO))
                {
                    throw new TelaException("Para emissão de uma NF-e deve-se selecionar um Cliente.");
                }
                if (Cliente.CodPessoa != Saida.CodCliente)
                {
                    Saida.CodCliente = Cliente.CodPessoa;
                    GerenciadorSaida.GetInstance(null).Atualizar(Saida);
                }
                Saida.Observacao = observacaoTextBox.Text;
                if (Saida.CupomFiscal.Trim().Equals(""))
                {
                    foreach (SaidaPedido saidaPedido in listaSaidaPedido)
                        GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, saidaPedido.CodSaida);
                }
                else
                {
                    GerenciadorSaida.GetInstance(null).AtualizarPorPedido(Saida.Nfe, Saida.Observacao, Cliente.CodPessoa, Saida.CupomFiscal);
                }
                NfeControle nfe = (NfeControle)nfeControleBindingSource.Current;
                if (nfe != null)
                    GerenciadorNFe.GetInstance().Atualizar(nfe);

                // envia nota fiscal
                //List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
                //Saida saida = GerenciadorSaida.GetInstance(null).Obter(Saida.CodSaida);
                List<SaidaPesquisa> listaSaidas = GerenciadorSaida.GetInstance(null).ObterPorCodSaidas(listaSaidaPedido.Select(s=>s.CodSaida).ToList());
                List<string> listaDocumentosFiscais = listaSaidas.Select(s => s.CupomFiscal).Distinct().ToList();
                if (listaSaidas.Where(s=> !string.IsNullOrEmpty(s.CupomFiscal)).Count() > 0)
                {
                    listaSaidas = listaSaidas.Where(s => string.IsNullOrEmpty(s.CupomFiscal)).ToList();
                    foreach (string docFiscal in listaDocumentosFiscais)
                    {
                        if (!string.IsNullOrEmpty(docFiscal))
                        {
                            listaSaidas.AddRange(GerenciadorSaida.GetInstance(null).ObterPorCupomFiscal(Saida.CupomFiscal));    
                        }
                    }  
                        
                    
                    listaSaidaPedido = new List<SaidaPedido>();
                    foreach (SaidaPesquisa s in listaSaidas)
                        listaSaidaPedido.Add(new SaidaPedido() { CodSaida = s.CodSaida, TotalAVista = s.TotalAVista });
                    List<Conta> listaContas = GerenciadorConta.GetInstance(null).ObterPorNfe(Saida.CupomFiscal).ToList();

                    decimal valorTotalPagamento = listaContas.Sum(c => c.Valor) - listaContas.Sum(c => c.Desconto);
                    SaidaPagamento saidaPagamento = new SaidaPagamento();
                    FormaPagamento dinheiro = GerenciadorFormaPagamento.GetInstance().Obter(FormaPagamento.DINHEIRO).ElementAt(0);
                    saidaPagamento.CodFormaPagamento = FormaPagamento.DINHEIRO;
                    saidaPagamento.CodCartaoCredito = Global.CARTAO_LOJA;
                    saidaPagamento.MapeamentoFormaPagamento = dinheiro.Mapeamento;
                    saidaPagamento.DescricaoFormaPagamento = dinheiro.Descricao;
                    saidaPagamento.Valor = valorTotalPagamento;
                    listaSaidaPagamento.Add(saidaPagamento);
                }

                Cursor.Current = Cursors.Default;

                long codSolicitacao = GerenciadorSolicitacaoDocumento.GetInstance().InserirSolicitacaoDocumento(listaSaidaPedido, listaSaidaPagamento, DocumentoFiscal.TipoSolicitacao.NFE, ehNfeComplementar, false);
                FrmSaidaAutorizacao frmSaidaAutorizacao = new FrmSaidaAutorizacao(Saida.CodSaida, Saida.CodCliente, DocumentoFiscal.TipoSolicitacao.NFE);
                frmSaidaAutorizacao.ShowDialog();
                frmSaidaAutorizacao.Dispose();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaNF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnEnviar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnCartaCorrecao_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSituacao_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnImprimir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
        }

        private void btnSituacao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma envio de solicitação de Consulta a NF-e?", "Consulta na Base da SEFAZ da NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NfeControle nfeControle = (NfeControle)nfeControleBindingSource.Current;
                GerenciadorNFe.GetInstance().EnviarConsultaNfe(nfeControle);
            }
        }

        private void btnCartaCorrecao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma envio de Carta Correção da Nf-e?", "Correção da NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                NfeControle nfeControle = (NfeControle)nfeControleBindingSource.Current;
                GerenciadorNFe.GetInstance().EnviarCartaCorrecaoNfe(nfeControle);
            }
        }

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codPessoaComboBox_Leave(object sender, EventArgs e)
        {
            Cliente = ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox, EstadoFormulario.INSERIR, pessoaBindingSource, true, false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int posicao = nfeControleBindingSource.Position;
            IEnumerable<NfeControle> listaNfeControleExibida = (IEnumerable<NfeControle>)nfeControleBindingSource.DataSource;
            IEnumerable<NfeControle> listaNfeControle = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);
            if (listaNfeControle.Count() > 0)
            {
                var listaControleExibida = new HashSet<String>(listaNfeControleExibida.Select(nfe => nfe.SituacaoNfe).ToList());
                var listaControle = new HashSet<String>(listaNfeControle.Select(nfe => nfe.SituacaoNfe).ToList());
                //Boolean iguais = listaControle.SetEquals(listaControleExibida);


                if ((listaNfeControleExibida.Count() != listaNfeControle.Count()) ||
                    !listaControle.SetEquals(listaControleExibida))
                {
                    nfeControleBindingSource.DataSource = listaNfeControle;
                    nfeControleBindingSource.Position = posicao;
                    nfeControleBindingSource.ResumeBinding();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }

        private void codPessoaComboBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }
    }
}
