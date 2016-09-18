using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cartao
{
    public partial class FrmProcessarPagamentoCartao : Form
    {
        public FrmProcessarPagamentoCartao(List<Pagamento> listaPagamentos)
        {
            InitializeComponent();
            pagamentoBindingSource.DataSource = listaPagamentos;
        }

        private void pagamentoBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void pagamentoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmProcessarPagamentoCartao_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
