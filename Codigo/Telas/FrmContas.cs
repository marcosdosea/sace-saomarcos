using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SACE;
using Negocio;

namespace SACE.Telas
{
    public partial class FrmContas : Form
    {
        private EstadoFormulario estado;

        public FrmContas()
        {
            InitializeComponent();
        }

        private void FrmContas_Load(object sender, EventArgs e)
        {
            Seguranca.GetInstancia().verificaPermissao(this, Funcoes.CONTAS_PAGAR, Principal.Autenticacao.CodUsuario);

            this.tb_contaTableAdapter.Fill(this.saceDataSet.tb_conta);
            this.tb_baixa_contaTableAdapter.Fill(this.saceDataSet.tb_baixa_conta);
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            
            habilitaBotoes(true);
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_contasBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmContaPesquisa frmContaPesquisa = new Telas.FrmContaPesquisa();
            frmContaPesquisa.ShowDialog();
            if (frmContaPesquisa.getCodConta() != -1)
            {
                tb_contasBindingSource.Position = tb_contasBindingSource.Find("codConta", frmContaPesquisa.getCodConta());
            }
            frmContaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_contasBindingSource.AddNew();
            codContaTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codContaTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tb_contaTableAdapter.Delete(long.Parse(codContaTextBox.Text));
                tb_contaTableAdapter.Fill(saceDataSet.tb_conta);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            char tipo= ' ';
            char situacao = ' ';
            if (devolvidoRadioButton.Checked)
                situacao = 'D';
            if (AbertoRadioButton.Checked)
                situacao = 'A';
            if (quitadoRadioButton.Checked)
                situacao = 'Q';
            if (pagarRadioButton.Checked)
                tipo = 'P';
            if (receberRadioButton.Checked)
                tipo = 'R';

            long? codEntrada = null, codSaida = null;
            if (!string.IsNullOrEmpty(codEntradaTextBox.Text)) codEntrada = Convert.ToInt64(codEntradaTextBox.Text);
            if (!string.IsNullOrEmpty(codSaidaTextBox.Text)) codSaida = Convert.ToInt64(codSaidaTextBox.Text);

            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                tb_contaTableAdapter.Insert(Convert.ToInt64(pessoaComboBox.SelectedValue),
                      Convert.ToInt64(planoContaComboBox.SelectedValue), codSaida, documentoTextBox.Text,
                      codEntrada, dataVencDateTimePicker.Value, valorTextBox.Text, situacao.ToString(), 
                      observacaoTextBox.Text, tipo.ToString());
                tb_contaTableAdapter.Fill(saceDataSet.tb_conta);
                tb_contasBindingSource.MoveLast();
            }
            else
            {
                tb_contaTableAdapter.Update(Convert.ToInt64(pessoaComboBox.SelectedValue),
                      Convert.ToInt64(planoContaComboBox.SelectedValue), codSaida, documentoTextBox.Text,
                      codEntrada, dataVencDateTimePicker.Value, Convert.ToDecimal(valorTextBox.Text), 
                      situacao.ToString(), observacaoTextBox.Text, tipo.ToString(), Convert.ToInt64(codContaTextBox.Text));
                tb_contasBindingSource.EndEdit();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_contasBindingSource.CancelEdit();
            tb_contasBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void tb_contasBindingSource_PositionChanged(object sender, EventArgs e)
        {
            DataRowView linha = (DataRowView)tb_contasBindingSource.Current;
            string tipoCliente = linha["TipoConta"].ToString();
            string situacao = linha["Situacao"].ToString();

            if (tipoCliente.Equals("P"))
            {
                pagarRadioButton.Checked = true;
                receberRadioButton.Checked = false;
            }
            else
            {
                pagarRadioButton.Checked = false;
                receberRadioButton.Checked = true;
            }

            if(situacao.Equals("A"))
            {
                AbertoRadioButton.Checked = true;
                quitadoRadioButton.Checked = false;
                devolvidoRadioButton.Checked = false;
            }
            else
            {
                if (situacao.Equals("Q"))
                {
                    AbertoRadioButton.Checked = false;
                    quitadoRadioButton.Checked = true;
                    devolvidoRadioButton.Checked = false;
                }
                else
                {
                    AbertoRadioButton.Checked = false;
                    quitadoRadioButton.Checked = false;
                    devolvidoRadioButton.Checked = true;
                }
            }
        }
    }
}
