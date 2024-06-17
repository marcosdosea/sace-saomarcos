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
    public partial class FrmCalcularVendasPorVendedor : Form
    {

 
        public FrmCalcularVendasPorVendedor()
        {
            InitializeComponent();
            dateTimeInicial.Value = DateTime.Now.AddMonths(-1);
        }

        private void FrmCalcularVendasPorVendedor_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; 
            DateTime dataInicial = dateTimeInicial.Value;
            DateTime dataFinal = dateTimeFinal.Value;
            vendasVendedorBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterVendasPorVendedor(dataInicial, dataFinal);
            Cursor.Current = Cursors.Default; 
        }

    }
}
