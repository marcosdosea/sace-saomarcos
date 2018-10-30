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
    public partial class FrmCalculoParticipacao : Form
    {

 
        public FrmCalculoParticipacao()
        {
            InitializeComponent();
        }

        private void FrmCalculoParticipacao_KeyDown(object sender, KeyEventArgs e)
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
            decimal valorMinimoVenda = 0;
            decimal.TryParse(textValorVenda.Text, out valorMinimoVenda);
            int numeroFuncionarios = 0;
            int.TryParse(textFuncionarios.Text, out numeroFuncionarios);

            List<Saida> saidas = GerenciadorSaida.GetInstance(null).ObterVendasParticipacaoLucros(dataInicial, dataFinal, valorMinimoVenda);
            decimal lucroBruto = saidas.Sum(s => s.TotalLucro);
            
            decimal valorParticipacao = lucroBruto * new Decimal(0.01);
            textValorCalculado.Text = (valorParticipacao / numeroFuncionarios).ToString("N2");
            Cursor.Current = Cursors.Default; 
        }
    }
}
