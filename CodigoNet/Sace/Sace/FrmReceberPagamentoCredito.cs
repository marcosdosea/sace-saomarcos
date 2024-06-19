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

namespace Sace
{
    public partial class FrmReceberPagamentoCredito: Form
    {

        public Saida saida { get; set; }
        public int Opcao { get; set; }

        public FrmReceberPagamentoCredito(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
            
            
            //trocoTextBox.Text = saida.Troco.ToString("N2");
            btnPreVenda.Enabled = Math.Abs(saida.TotalAVista) <= Math.Abs(saida.TotalPago); 
            Opcao = 0; // Cancelar           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Opcao = 0;
            this.Close();
        }

        private void FrmSaidaConfirma_KeyDown(object sender, KeyEventArgs e)
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

        private void btnPreVenda_Click(object sender, EventArgs e)
        {
            Opcao = Saida.TIPO_PRE_VENDA;
            this.Close();
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            Opcao = Saida.TIPO_ORCAMENTO;
            this.Close();
        }

        private void btnPreVendaNfce_Click(object sender, EventArgs e)
        {
            Opcao = Saida.TIPO_PRE_VENDA_NFCE;
            this.Close();
        }

        private void FrmSaidaConfirma_Load(object sender, EventArgs e)
        {

        }
    }
}
