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
    public partial class FrmSaidaDAV : Form
    {

        private HashSet<Int64> ListaCodSaidas { get; set; }
        private decimal Total { get; set; }
        private decimal TotalAVista { get; set; }
        private decimal Desconto { get; set; }
        
        public FrmSaidaDAV(HashSet<Int64> listaCodSaida, decimal total, decimal totalAVista, decimal desconto)
        {
            InitializeComponent();
            ListaCodSaidas = listaCodSaida;
            Total = total;
            TotalAVista = totalAVista;
            Desconto = desconto;
        }

        private void btnNotmal_Click(object sender, EventArgs e)
        {
            this.Close();
            GerenciadorSaida.GetInstance().ImprimirDAV(obterSaidas(ListaCodSaidas.ToList<long>()), Total, TotalAVista, Desconto, false);
        }

        private void btnReduzido_Click(object sender, EventArgs e)
        {
            this.Close();
            GerenciadorSaida.GetInstance().ImprimirDAV(obterSaidas(ListaCodSaidas.ToList<long>()), Total, TotalAVista, Desconto, true);
        }

        private List<Saida> obterSaidas(List<long> listaCodSaidas)
        {
            List<Saida> saidas = new List<Saida>();
            foreach (Int64 codSaida in listaCodSaidas)
            {
                saidas.Add(GerenciadorSaida.GetInstance().Obter(codSaida));
            }
            return saidas;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaDAV_KeyDown(object sender, KeyEventArgs e)
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
    }
}
