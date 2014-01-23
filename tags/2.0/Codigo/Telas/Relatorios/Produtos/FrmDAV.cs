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

namespace Telas.Relatorios.Produtos
{
    public partial class FrmDAV : Form
    {
        
        private List<long> listaCodSaidas;
        private decimal total;
        private decimal totalPagar;
        private decimal desconto;



        public FrmDAV(List<long> listaCodSaidas, decimal total, decimal totalPagar, decimal desconto)
        {
            InitializeComponent();
            this.listaCodSaidas = listaCodSaidas;
            this.total = total;
            this.totalPagar = totalPagar;
            this.desconto = desconto;
        }

        private void FrmDAV_Load(object sender, EventArgs e)
        {
            // Obtém os produtos das saídas
            List<SaidaProdutoRelatorio> listaSaidaProdutoRelatorio = GerenciadorSaidaProduto.GetInstance(null).ObterPorSaidasRelatorio(listaCodSaidas);
            SaidaProdutoRelatorioBindingSource.DataSource = listaSaidaProdutoRelatorio;

            if (listaSaidaProdutoRelatorio.Count > 0)
            {
                // Obtém os demais dados para preenchimento do relatório
                long codCliente = listaSaidaProdutoRelatorio.ElementAtOrDefault(0).CodCliente;
                PessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(codCliente);
                
                Loja loja = GerenciadorLoja.GetInstance().Obter(Util.Global.LOJA_PADRAO).ElementAtOrDefault(0);
                PessoaLojaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa);

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("TotalSaidas", total.ToString("N2")));
                parameterCollection.Add(new ReportParameter("Desconto", desconto.ToString("N2")));
                parameterCollection.Add(new ReportParameter("TotalPagar", totalPagar.ToString("N2")));
                this.reportViewer1.LocalReport.SetParameters(parameterCollection);
                
                this.reportViewer1.RefreshReport();
            }
        }

        private void FrmDAV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
