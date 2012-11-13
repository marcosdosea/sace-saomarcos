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
        }
    }
}
