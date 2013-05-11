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
    public partial class FrmSaidaVenda: Form
    {

        public Saida Saida { get; set; }

        public FrmSaidaVenda(long codSaida)
        {
            InitializeComponent();
            this.Saida = GerenciadorSaida.GetInstance(null).Obter(codSaida);
            
            if (Saida.Observacao.Trim().Equals(""))
            {
                if (Saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO)
                {
                    Saida.Observacao = "Nao Incidencia de ICMS conforme Art 2o, XI do RICMS/SE";
                }
                else if (Saida.TipoSaida == Saida.TIPO_VENDA)
                {
                    Saida.Observacao = "VEND:   0   CLI: " + Saida.CodCliente;
                }
            }
            observacaoTextBox.Text = Saida.Observacao;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                Saida.Observacao = observacaoTextBox.Text;
            }
            catch (Exception)
            {
                throw new NegocioException("Número da nota fiscal inválido. Favor verificar o formato e a sequência da numeração.");
            }
            if (Saida.CupomFiscal.Trim().Equals(""))
            {
                GerenciadorSaida.GetInstance(null).AtualizarNfePorCodSaida(Saida.Nfe, Saida.Observacao, Saida.CodSaida);
            }
            else
            {
                GerenciadorSaida.GetInstance(null).AtualizarNfePorPedidoGerado(Saida.Nfe, Saida.Observacao, Saida.CupomFiscal);
            }
            NfeControle nfe = new NfeControle();
            nfe.CodNfe = GerenciadorNFe.GetInstance().Inserir(nfe, Saida);
            nfe.Chave = GerenciadorNFe.GetInstance().GerarChaveNFE(Saida, nfe);
                     
            if (!string.IsNullOrEmpty(nfe.Chave))
            {
                GerenciadorNFe.GetInstance().Atualizar(nfe);    
                GerenciadorNFe.GetInstance().EnviarNFE(Saida, nfe);
            }
            //GerenciadorSaida.GetInstance(null).ImprimirNotaFiscal(Saida);
        }

    }
}
