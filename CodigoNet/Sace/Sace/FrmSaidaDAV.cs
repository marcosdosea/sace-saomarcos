using Dominio;
using Negocio;
using Sace.Relatorios.Produtos;

namespace Sace
{
    public partial class FrmSaidaDAV : Form
    {

        private HashSet<long> listaCodSaidas;
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
            
            //gerenciadorSaida.ImprimirDAV(obterSaidas(ListaCodSaidas.ToList<long>()), Total, TotalAVista, Desconto, false);
        }

        private void btnReduzido_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!GerenciadorSaida.SolicitaImprimirDAV(listaCodSaidas.ToList<long>(), total, totalAVista, desconto, Impressora.Tipo.REDUZIDO1)) 
            {
                MessageBox.Show("Não foi possível realizar a impressão. Por Favor Verifique se a impressora REDUZIDA está LIGADA.", "Problema na Impressão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReduzido2_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!GerenciadorSaida.SolicitaImprimirDAV(listaCodSaidas.ToList<long>(), total, totalAVista, desconto, Impressora.Tipo.REDUZIDO2))
            {
                MessageBox.Show("Não foi possível realizar a impressão. Por Favor Verifique se a impressora REDUZIDA está LIGADA.", "Problema na Impressão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
