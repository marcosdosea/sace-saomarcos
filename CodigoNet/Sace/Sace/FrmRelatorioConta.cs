using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Microsoft.Reporting.WinForms;
using Util;

namespace Telas
{
    public partial class FrmRelatorioConta : Form
    {
        public FrmRelatorioConta()
        {
            InitializeComponent();
        }

        private void FrmRelatorioConta_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, UtilConfig.Default.RELATORIO_CONTAS, Principal.Autenticacao.CodUsuario);
            this.contasReportViewer.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long? pessoa = null;
            string tipo = null;
            string situcao = null;
            DateTime dataini = inicialDateTimePicker.Value;
            DateTime datafim = finalDateTimePicker.Value;
            if (!string.IsNullOrEmpty(codPessoaTextBox.Text))
                pessoa = Convert.ToInt64(codPessoaTextBox.Text);
            if (abertoRadioButton.Checked)
                situcao = "A";
            if (quitadoRadioButton.Checked)
                situcao = "Q";
            if (pagarRadioButton.Checked)
                tipo = "P";
            if (receberRadioButton.Checked)
                tipo = "R";
            dt_RelContaTableAdapter1.Fill(saceRelatoriosDataSet.dt_RelConta);
            Dados.saceRelatoriosDataSet.dt_RelContaDataTable dt_RelConta;
            dt_RelConta = this.dt_RelContaTableAdapter1.GetDataByParametros(pessoa, dataini, datafim, tipo, situcao);
            contasReportViewer.Visible = true;
            contasReportViewer.LocalReport.DataSources.Clear();
            contasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("saceRelatoriosDataSet_dt_RelConta", dt_RelConta));
            contasReportViewer.RefreshReport();
        }
    }
}
