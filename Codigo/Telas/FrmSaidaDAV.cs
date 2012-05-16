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

        public Int64 CodSaida { get; set; }
        
        public FrmSaidaDAV(Int64 codSaida)
        {
            InitializeComponent();
            CodSaida = codSaida;
        }

        private void btnNotmal_Click(object sender, EventArgs e)
        {
            this.Close();
            Saida saida = GerenciadorSaida.getInstace().obterSaida(CodSaida);
            GerenciadorSaida.getInstace().imprimirDAV(saida, false);
        }

        private void btnReduzido_Click(object sender, EventArgs e)
        {
            this.Close();
            Saida saida = GerenciadorSaida.getInstace().obterSaida(CodSaida);
            GerenciadorSaida.getInstace().imprimirDAV(saida, true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
