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
    public partial class FrmSaidaNFe: Form
    {

        public Saida Saida { get; set; }
        private Pessoa Cliente { get; set; }
        private long codSaida;


        public FrmSaidaNFe(long codSaida)
        {
            InitializeComponent();
            

            this.codSaida = codSaida;
            this.Saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
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
                    SaidaPesquisa saidaCupomVenda = GerenciadorSaida.GetInstance(null).ObterPorPedido(Saida.CupomFiscal).ElementAtOrDefault(0);
                    if (Saida.TotalAVista < saidaCupomVenda.TotalAVista)
                    {
                        Saida.Observacao += "Devolução Parcial referente ao cupom fiscal " + saidaCupomVenda.CupomFiscal + " emitido em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Cliente não precisou dos itens comprados. Cupom fiscal e Nf-e relativas a venda referenciadas abaixo";
                    }
                    else
                    {
                        Saida.Observacao += "Devolução Total referente ao cupom fiscal " + saidaCupomVenda.CupomFiscal + " emitido em " + saidaCupomVenda.DataSaida.ToShortDateString() + ". Motivo da Devolução: Cliente não precisou dos itens comprados. Cupom fiscal e Nf-e relativas a venda referenciadas abaixo";
                    }
                }
            }
            Saida.Nfe = "NF-e";
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
                GerenciadorNFe.GetInstance().EnviarSolicitacaoCancelamento(_nfeControle);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            NfeControle nfeControle = (NfeControle) nfeControleBindingSource.Current;
            GerenciadorNFe.GetInstance().imprimirDANFE(nfeControle);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            nfeControleBindingSource.DataSource = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);
            nfeControleDataGridView.ResumeLayout();
            //nfeControleDataGridView.DataSource = nfeControleBindingSource.DataSource; 
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // o evento foi disparo do butão que emite Nf-
            bool ehNfeComplementar = (sender is Button) && ((Button)sender).Name.Equals("btnComplementar");
            if (Saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) || Saida.TipoSaida.Equals(Saida.TIPO_REMESSA_CONSERTO) || Saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_CONSUMIDOR))
            {
                if (MessageBox.Show("Deseja gerar espelho da NF-e para Validação?", "Criar Espelho da NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Atualiza os dados da saída
                    Saida.Observacao = observacaoTextBox.Text;
                    if (Saida.CupomFiscal.Trim().Equals(""))
                        GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, Saida.CodSaida);

                    NfeControle nfe = (NfeControle) nfeControleBindingSource.Current;
                    // Gera chave e envia nota fiscal
                    nfe = GerenciadorNFe.GetInstance().GerarChaveNFE(Saida, ehNfeComplementar);
                    if (ehNfeComplementar)
                    {
                        //nfe.ComplementarImposto = ((NfeControle)nfeControleBindingSource.Current).ComplementarImposto;
                        //GerenciadorNFe.GetInstance().Atualizar(nfe);
                    }
                    if (!string.IsNullOrEmpty(nfe.Chave))
                    {
                        GerenciadorNFe.GetInstance().EnviarNFE(Saida, nfe, true, ehNfeComplementar);
                    }

                }   
            }
            
            if (MessageBox.Show("Confirma envio da NF-e?", "Enviar NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                // Atualiza os dados da saída
                Saida.Observacao = observacaoTextBox.Text;
                if (Saida.CupomFiscal.Trim().Equals(""))
                    GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, Saida.CodSaida);
                else
                    GerenciadorSaida.GetInstance(null).AtualizarPorPedido(Saida.Nfe, Saida.Observacao, Cliente.CodPessoa, Saida.CupomFiscal);

                NfeControle nfe = (NfeControle)nfeControleBindingSource.Current;
                if (nfe != null)
                    GerenciadorNFe.GetInstance().Atualizar(nfe);
                    
                // Gera chave e envia nota fiscal
                Saida saida = GerenciadorSaida.GetInstance(null).Obter(Saida.CodSaida);
                nfe = GerenciadorNFe.GetInstance().GerarChaveNFE(Saida, ehNfeComplementar);
                if (!string.IsNullOrEmpty(nfe.Chave))
                {
                    GerenciadorNFe.GetInstance().EnviarNFE(Saida, nfe, false, ehNfeComplementar);
                }
                Cursor.Current = Cursors.Default;
                nfeControleDataGridView.DataSource = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);
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
            else if (e.KeyCode == Keys.F2)
            {
                btnConsultar_Click(sender, e);
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
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codPessoaComboBox, EstadoFormulario.INSERIR, pessoaBindingSource, true);
            Cliente = (Pessoa)pessoaBindingSource.Current;
        }
    }
}
