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
            dt_RelContaTableAdapter1.Fill(saceRelatoriosDataSet.dt_RelConta);
            Dados.saceRelatoriosDataSet.dt_RelContaDataTable dt_RelConta = this.dt_RelContaTableAdapter1.GetData();
            contasReportViewer.LocalReport.DataSources.Clear();
            contasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("saceRelatoriosDataSet_dt_RelConta", dt_RelConta));
            contasReportViewer.RefreshReport();
        }
    }
}
