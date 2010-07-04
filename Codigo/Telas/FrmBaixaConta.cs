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
        private double total = 0;

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
            string tipo;
            bool naoalterar = false;
            total = 0;
            ConfirmarButton.Enabled = true;
            avisoLabel.Visible = false;
            if (contasDataGridView.SelectedRows.Count > 0)
            {
                pesquisaPanel.Enabled = false;
                baixaPanel.Enabled = true;
                tipo = contasDataGridView.SelectedRows[0].Cells["tipoContaDataGridViewTextBoxColumn"].Value.ToString();
                for (int i = 0; i < contasDataGridView.SelectedRows.Count; i++)
                {
                    total += double.Parse(contasDataGridView.SelectedRows[i].Cells["valorDataGridViewTextBoxColumn"].Value.ToString());
                    if (tipo != contasDataGridView.SelectedRows[i].Cells["tipoContaDataGridViewTextBoxColumn"].Value.ToString())
                    {
                        ConfirmarButton.Enabled = false;
                        naoalterar = true;
                    }
                }
                if (naoalterar)
                {
                    MessageBox.Show("Não pode dar baixa em contas de tipos diferente!");
                }
                totalLabel.Text = "R$ " + string.Format("{0:N}", total);
            }
            else
            {
                throw new TelaException("Nenhum item selecionado!");
            }
        }

        public string verificaTipo()
        {
            if(pagarRadioButton.Checked)
                return "P";
            if(receberRadioButton.Checked)
                return "R";
            return null;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            pesquisaPanel.Enabled = true;
            baixaPanel.Enabled = false;
        }
    }
}
