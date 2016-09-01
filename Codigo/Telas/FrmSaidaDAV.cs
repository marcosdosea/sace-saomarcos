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
using Telas.Relatorios.Produtos;

namespace Telas
{
    public partial class FrmSaidaDAV : Form
    {

        private HashSet<Int64> listaCodSaidas;
        private decimal total; 
        private decimal totalAVista; 
        private decimal desconto;
        private bool ehOrcamento;
        
        public FrmSaidaDAV(HashSet<Int64> listaCodSaida, decimal total, decimal totalAVista, decimal desconto, bool ehOrcamento)
        {
            InitializeComponent();
            this.listaCodSaidas = listaCodSaida;
            this.total = total;
            this.totalAVista = totalAVista;
            this.desconto = desconto;
            this.ehOrcamento = ehOrcamento;
        }

        private void btnNotmal_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frmDAV;
            if (ehOrcamento)          
                frmDAV = new FrmDAVOrcamento(listaCodSaidas.ToList<long>(), total, totalAVista, desconto);
            else
                frmDAV = new FrmDAV(listaCodSaidas.ToList<long>(), total, totalAVista, desconto);
            frmDAV.ShowDialog();
            frmDAV.Dispose();
            
            //GerenciadorSaida.GetInstance(null).ImprimirDAV(obterSaidas(ListaCodSaidas.ToList<long>()), Total, TotalAVista, Desconto, false);
        }

        private void btnReduzido_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!GerenciadorSaida.GetInstance(null).ImprimirDAV(obterSaidas(listaCodSaidas.ToList<long>()), total, totalAVista, desconto, Util.Global.Impressora.BEMATECH)) 
            {
                MessageBox.Show("Não foi possível realizar a impressão. Por Favor Verifique se a impressora REDUZIDA está LIGADA.", "Problema na Impressão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReduzido2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!GerenciadorSaida.GetInstance(null).ImprimirDAV(obterSaidas(listaCodSaidas.ToList<long>()), total, totalAVista, desconto, Util.Global.Impressora.DARUMA))
            {
                MessageBox.Show("Não foi possível realizar a impressão. Por Favor Verifique se a impressora REDUZIDA está LIGADA.", "Problema na Impressão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<Saida> obterSaidas(List<long> listaCodSaidas)
        {
            List<Saida> saidas = new List<Saida>();
            foreach (Int64 codSaida in listaCodSaidas)
            {
                saidas.Add(GerenciadorSaida.GetInstance(null).Obter(codSaida));
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
