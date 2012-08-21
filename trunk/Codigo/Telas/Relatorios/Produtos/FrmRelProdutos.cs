using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telas.Relatorios.Produtos
{
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            tb_produtoTableAdapter.FillByNome(saceDataSet.tb_produto, Util.Global.ACRESCIMO_PADRAO, "");  
            this.reportViewer1.RefreshReport();
            //this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
            //tbprodutoBindingSource.
            this.reportViewer1.RefreshReport();
        }

        private void tbprodutoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
