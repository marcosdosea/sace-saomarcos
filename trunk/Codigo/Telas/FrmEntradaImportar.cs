using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Telas
{
    public partial class FrmEntradaImportar : Form
    {
        IEnumerable<EntradaProduto> listaEntradaProduto;
        public FrmEntradaImportar(IEnumerable<EntradaProduto> listaEntradaProduto)
        {
            InitializeComponent();
            this.listaEntradaProduto = listaEntradaProduto;
        }

        private void FrmEntradaImportar_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
            entradaProdutoBindingSource.DataSource = listaEntradaProduto;
        }
    }
}
