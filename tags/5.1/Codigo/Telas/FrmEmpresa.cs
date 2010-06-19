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
    public partial class FrmEmpresa : Form
    {
        private EstadoFormulario estado;

        public FrmEmpresa()
        {
            InitializeComponent();
        }

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_contato_empresa' table. You can move, or remove it, as needed.
            this.tb_empresaTableAdapter.Fill(this.saceDataSet.tb_empresa);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmEmpresaPesquisa frmEmpresaPesquisa = new Telas.FrmEmpresaPesquisa();
            frmEmpresaPesquisa.ShowDialog();
            if (frmEmpresaPesquisa.getCodEmpresa() != -1)
            {
                tb_empresaBindingSource.Position = tb_empresaBindingSource.Find("codigoEmpresa", frmEmpresaPesquisa.getCodEmpresa());
            }
            frmEmpresaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_empresaBindingSource.AddNew();
            codigoEmpresaTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            nomeTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    tb_empresaTableAdapter.Delete(int.Parse(codigoEmpresaTextBox.Text));
                    tb_empresaTableAdapter.Fill(saceDataSet.tb_empresa);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_empresaBindingSource.CancelEdit();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_empresaBindingSource.CancelEdit();
            tb_empresaBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    tb_empresaTableAdapter.Insert(nomeTextBox.Text, cnpjTextBox.Text, ieTextBox.Text,
                        foneTextBox.Text, enderecoTextBox.Text, bairroTextBox.Text, cepTextBox.Text,
                        cidadeTextBox.Text, ufTextBox.Text, limiteCompraTextBox.Text, observacaoTextBox.Text);
                    tb_empresaTableAdapter.Fill(saceDataSet.tb_empresa);
                    tb_empresaBindingSource.MoveLast();
                }
                else
                {
                    tb_empresaTableAdapter.Update(nomeTextBox.Text, cnpjTextBox.Text, ieTextBox.Text,
                        foneTextBox.Text, enderecoTextBox.Text, bairroTextBox.Text, cepTextBox.Text,
                        cidadeTextBox.Text, ufTextBox.Text, decimal.Parse(limiteCompraTextBox.Text), 
                        observacaoTextBox.Text, long.Parse(codigoEmpresaTextBox.Text));
                    tb_empresaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_empresaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

 
        private void btnContato_Click(object sender, EventArgs e)
        {
            Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
            frmPessoaPesquisa.ShowDialog();
            if (frmPessoaPesquisa.getCodPessoa() != -1)
            {
                btnSalvar_Click(sender, e);
                try
                {
                    tb_contato_empresaTableAdapter.Insert(long.Parse(codigoEmpresaTextBox.Text), frmPessoaPesquisa.getCodPessoa());
                }
                catch (Exception)
                {
                    MessageBox.Show("O contato selecionado já foi incluído na empresa.");
                }
            }
            frmPessoaPesquisa.Dispose();
            btnContato.Focus();
            this.tb_contato_empresaTableAdapter.FillByEmpresa(this.saceDataSet.tb_contato_empresa, long.Parse(codigoEmpresaTextBox.Text));
        }

        private void excluirContato(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão do contato?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tb_contato_empresaDataGridView.Rows.Count > 0)
                    {
                        long codPessoa = long.Parse(tb_contato_empresaDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                        long codEmpresa = long.Parse(codigoEmpresaTextBox.Text);
                        tb_contato_empresaTableAdapter.Delete(codEmpresa, codPessoa);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
            }
            this.tb_contato_empresaTableAdapter.FillByEmpresa(this.saceDataSet.tb_contato_empresa, long.Parse(codigoEmpresaTextBox.Text));
        }

        private void codigoEmpresaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!codigoEmpresaTextBox.Text.Equals(""))
            {
                this.tb_contato_empresaTableAdapter.FillByEmpresa(this.saceDataSet.tb_contato_empresa, long.Parse(codigoEmpresaTextBox.Text));
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
                     tb_empresaBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void FrmEmpresa_KeyDown(object sender, KeyEventArgs e)
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
                    tb_empresaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_empresaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_empresaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_empresaBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnCancelar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.F7)
                btnContato_Click(sender, e);

            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                tb_contato_empresaDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            if ((e.KeyCode == Keys.Delete) && (tb_contato_empresaDataGridView.Focused == true))
            {
                excluirContato(sender, e);
            }
        }
    }
}
