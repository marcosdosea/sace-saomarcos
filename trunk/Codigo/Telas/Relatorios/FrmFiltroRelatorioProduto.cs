using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Telas.Relatorios
{
    public partial class FrmFiltroRelatorioProduto : Form
    {
        public FrmFiltroRelatorioProduto()
        {
            InitializeComponent();
        }

        private void FrmFiltroRelatorioProduto_Load(object sender, EventArgs e)
        {
            codPessoaComboBox.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
        }

        private void pessoaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            long codPessoa = Convert.ToInt64(codPessoaComboBox.SelectedValue.ToString());
            Relatorios.Produtos.FrmRelProdutosRevenda relatorio = new Relatorios.Produtos.FrmRelProdutosRevenda(codPessoa);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void FrmFiltroRelatorioProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnImprimir_Click(sender, e);
            }
        }

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

    }
}
