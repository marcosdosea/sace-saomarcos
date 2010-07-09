using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using SACE.Telas;
using SACE;
using Microsoft.Reporting.WinForms;

namespace SACE.Telas
{
    public partial class FrmRelatorioConta : Form
    {
        public FrmRelatorioConta()
        {
            InitializeComponent();
        }

        private void FrmRelatorioConta_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.GetInstancia().verificaPermissao(this, Funcoes.RELATORIO_CONTAS, Principal.Autenticacao.CodUsuario);
            this.contasReportViewer.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tb_pessoaTableAdapter1.Fill(saceDataSet.tb_pessoa);
            this.tb_contaTableAdapter1.Fill(saceDataSet.tb_conta);
            Dados.saceDataSet.tb_pessoaDataTable dt_pessoa = this.tb_pessoaTableAdapter1.GetData();
            Dados.saceDataSet.tb_contaDataTable dt_conta = this.tb_contaTableAdapter1.GetData();
            contasReportViewer.LocalReport.DataSources.Clear();
            contasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("saceDataSet_tb_pessoa", dt_conta));
            contasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("saceDataSet_tb_conta", dt_pessoa));
            contasReportViewer.RefreshReport();
        }
    }
}
