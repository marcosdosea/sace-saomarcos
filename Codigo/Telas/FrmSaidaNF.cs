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
    public partial class FrmSaidaNF: Form
    {

        public Saida Saida { get; set; }
        
        public FrmSaidaNF(Saida Saida)
        {
            InitializeComponent();
            this.Saida = Saida;

            if ((Saida.Nfe != null) && (! Saida.Nfe.Equals("") )) {
                numeroNFText.Text = Saida.Nfe;
            } 
            else 
            {
                numeroNFText.Text = GerenciadorSaida.getInstace().ObterNumeroProximaNotaFiscal().ToString();
            }
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
                Saida.Nfe = Convert.ToInt64(numeroNFText.Text).ToString();
            }
            catch (Exception)
            {
                throw new NegocioException("Número da nota fiscal inválido. Favor verificar o formato e a sequência da numeração.");
            }
            GerenciadorSaida.getInstace().Atualizar(Saida.PedidoGerado, Saida.Nfe);
            GerenciadorSaida.getInstace().imprimirNotaFiscal(Saida);
        }

    }
}
