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
using Microsoft.Reporting.WinForms;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmRelProdutosRevenda : Form
    {
        private long codPessoa;
        private decimal lucro; 
        public FrmRelProdutosRevenda(long codPessoa, decimal lucro)
        {
            this.codPessoa = codPessoa;
            this.lucro = lucro;
            InitializeComponent();
        }

        private void FrmRelProdutosRevenda_Load(object sender, EventArgs e)
        {
            ProdutoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterPorCodigoFabricante(codPessoa);
            Loja loja = GerenciadorLoja.GetInstance().Obter(Util.Global.LOJA_PADRAO).ElementAtOrDefault(0);
            PessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa);

            string parametroLucro = (1 + lucro / 100).ToString();

            ReportParameter p1 = new ReportParameter("PorcentagemLucro", parametroLucro);
            this.reportViewer1.LocalReport.SetParameters(p1);
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
