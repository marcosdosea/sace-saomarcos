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
using SACE.Excecoes;

namespace SACE.Telas
{
    public partial class FrmBaixaConta : Form
    {
        public FrmBaixaConta()
        {
            InitializeComponent();
        }

        private void FrmBaixaConta_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.BAIXAS, Principal.Autenticacao.CodUsuario);

            this.tb_contaTableAdapter.Fill(this.saceDataSet1.tb_conta);
            this.tb_baixa_contaTableAdapter.Fill(this.saceDataSet1.tb_baixa_conta);
        }

        private void baixaButton_Click(object sender, EventArgs e)
        {
            if (contasDataGridView.SelectedRows.Count > 0)
            {
                pesquisaPanel.Enabled = false;
                baixaPanel.Enabled = true;
            }
            else
            {
                throw new TelaException("Nenhum item selecionado!");
            }
        }
    }
}
