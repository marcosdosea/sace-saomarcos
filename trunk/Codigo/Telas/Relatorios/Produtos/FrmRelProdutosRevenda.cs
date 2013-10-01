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

namespace Telas.Relatorios.Produtos
{
    public partial class FrmRelProdutosRevenda : Form
    {
        private long codPessoa;
        public FrmRelProdutosRevenda(long codPessoa)
        {
            this.codPessoa = codPessoa;
            InitializeComponent();
        }

        private void FrmRelProdutosRevenda_Load(object sender, EventArgs e)
        {
            ProdutoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorCodigoFabricante(codPessoa);
            Loja loja = GerenciadorLoja.GetInstance().Obter(Util.Global.LOJA_PADRAO).ElementAtOrDefault(0);
            PessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa);
            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
