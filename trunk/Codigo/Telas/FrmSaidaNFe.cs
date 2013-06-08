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
    public partial class FrmSaidaNFe: Form
    {

        public Saida Saida { get; set; }
        private long codSaida;


        public FrmSaidaNFe(long codSaida)
        {
            InitializeComponent();
            

            this.codSaida = codSaida;
            nfeControleBindingSource.DataSource = GerenciadorNFe.GetInstance().ObterPorSaida(codSaida);
            this.Saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
            
            if (Saida.Observacao.Trim().Equals(""))
            {
                if (Saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
                {
                    Saida.Observacao = "Nao Incidencia de ICMS conforme Art 2o, XI do RICMS/SE";
                }
                else if (Saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    Saida.Observacao = "Cod Cliente: " + Saida.CodCliente;
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
            nfeControleDataGridView.DataSource = nfeControleBindingSource.DataSource; 
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma envio da NF-e?", "Enviar NF-e", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;
                // Atualiza os dados da saída
                Saida.Observacao = observacaoTextBox.Text;
                if (Saida.CupomFiscal.Trim().Equals(""))
                    GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, Saida.CodSaida);
                else
                    GerenciadorSaida.GetInstance(null).AtualizarNfePorPedidoGerado(Saida.Nfe, Saida.Observacao, Saida.CupomFiscal);

                // Gera chave e envia nota fiscal
                NfeControle nfe = GerenciadorNFe.GetInstance().GerarChaveNFE(Saida);
                if (!string.IsNullOrEmpty(nfe.Chave))
                {
                    GerenciadorNFe.GetInstance().EnviarNFE(Saida, nfe);
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
            else if (e.KeyCode == Keys.F6)
            {
                btnEnviar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnImprimir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
        }


    }
}
