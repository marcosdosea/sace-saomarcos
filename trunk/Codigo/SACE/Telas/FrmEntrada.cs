using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SACE.Telas
{
    public partial class FrmEntrada : Form
    {
        private EstadoFormulario estado;

        public FrmEntrada()
        {
            InitializeComponent();
        }

        private void FrmEntrada_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_empresa' table. You can move, or remove it, as needed.
            this.tb_empresaTableAdapter.Fill(this.saceDataSet.tb_empresa);
            // TODO: This line of code loads data into the 'saceDataSet.tb_empresa' table. You can move, or remove it, as needed.
            this.tb_empresaTableAdapter.Fill(this.saceDataSet.tb_empresa);
            // TODO: This line of code loads data into the 'saceDataSet.tb_entrada' table. You can move, or remove it, as needed.
            this.tb_entradaTableAdapter.Fill(this.saceDataSet.tb_entrada);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmEntradaPesquisa frmEntradaPesquisa = new Telas.FrmEntradaPesquisa();
            frmEntradaPesquisa.ShowDialog();
            if (frmEntradaPesquisa.getCodEntrada() != -1)
            {
                tb_entradaBindingSource.MoveFirst();
                while (!codEntradaTextBox.Text.Equals(frmEntradaPesquisa.getCodEntrada().ToString()))
                {
                    tb_entradaBindingSource.MoveNext();
                }
            }
            frmEntradaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_entradaBindingSource.AddNew();
            codEntradaTextBox.Enabled = false;
            codigoFornecedorComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codigoFornecedorComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_entradaTableAdapter.Delete(int.Parse(codEntradaTextBox.Text));
                    tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_entradaBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_entradaBindingSource.CancelEdit();
            tb_entradaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_entradaTableAdapter.Insert(long.Parse(codigoFornecedorComboBox.SelectedValue.ToString()), 
                        long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString()), decimal.Parse(valorCustoFreteTextBox.Text), 
                        DateTime.Parse(dataEntradaDateTimePicker.Text), decimal.Parse(valorTotalTextBox.Text), 
                        tipoEntradaTextBox.Text, long.Parse(numeroNotaFiscalTextBox.Text));
                    tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
                    tb_entradaBindingSource.MoveLast();
                }
                else
                {
                    tb_entradaTableAdapter.Update(long.Parse(codigoFornecedorComboBox.SelectedValue.ToString()),
                        long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString()), decimal.Parse(valorCustoFreteTextBox.Text), DateTime.Parse(dataEntradaDateTimePicker.Text),
                        decimal.Parse(valorTotalTextBox.Text), tipoEntradaTextBox.Text, long.Parse(numeroNotaFiscalTextBox.Text), long.Parse(codEntradaTextBox.Text));
                    tb_entradaBindingSource.EndEdit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_entradaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_entradaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_entradaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_entradaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_entradaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }

            }
        }
        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_entradaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }
    }
}
