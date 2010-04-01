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
    public partial class FrmProduto : Form
    {
        private EstadoFormulario estado;

        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_cfop' table. You can move, or remove it, as needed.
            this.tb_cfopTableAdapter.Fill(this.saceDataSet.tb_cfop);
            // TODO: This line of code loads data into the 'saceDataSet.tb_grupo' table. You can move, or remove it, as needed.
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            // TODO: This line of code loads data into the 'saceDataSet.tb_empresa' table. You can move, or remove it, as needed.
            this.tb_empresaTableAdapter.Fill(this.saceDataSet.tb_empresa);
            // TODO: This line of code loads data into the 'saceDataSet.tb_produto' table. You can move, or remove it, as needed.
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisa frmProdutoPesquisa = new Telas.FrmProdutoPesquisa();
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.getCodProduto() != -1)
            {
                tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", frmProdutoPesquisa.getCodProduto());
            }
            frmProdutoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_produtoBindingSource.AddNew();
            codProdutoTextBox.Enabled = false;
            nomeTextBox.Focus();
            temVencimentoCheckBox.Checked = false;
            exibeNaListagemCheckBox.Checked = true;
            cfopComboBox.SelectedIndex = 0;
            qtdProdutoAtacadoTextBox.Text = "0";
            qtdProdutoSuperAtacadoTextBox.Text = "0";
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
                    tb_produtoTableAdapter.Delete(long.Parse(codProdutoTextBox.Text));
                    tb_produtoTableAdapter.Fill(saceDataSet.tb_produto);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
                tb_produtoBindingSource.CancelEdit();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_produtoBindingSource.CancelEdit();
            tb_produtoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Grupo do produto pode ser null
                long? codGrupo = null;
                if (codGrupoComboBox.SelectedValue != null)
                    codGrupo = long.Parse(codGrupoComboBox.SelectedValue.ToString());

                // CFOP pode ser null
                int? cfop = null;
                if (cfopComboBox.SelectedValue != null)
                    cfop = int.Parse(cfopComboBox.SelectedValue.ToString());

                // Fabricante pode ser null
                long? codFabricante = null;
                if (codigoFabricanteComboBox.SelectedValue != null)
                    codFabricante = long.Parse(codigoFabricanteComboBox.SelectedValue.ToString());

                if (estado.Equals(EstadoFormulario.INSERIR))
                {
                    //tb_produtoTableAdapter.Insert(nomeTextBox.Text, nomeFabricanteTextBox.Text, unidadeTextBox.Text,
                    //     codigoBarraTextBox.Text, codGrupo, codFabricante, temVencimentoCheckBox.Checked,
                    //    cfop, 0, 0,0, 0, 0, 0, 0, 0, 0, ultimaDataAtualizacaoDateTimePicker.Value,
                    //    0, 0, decimal.Parse(qtdProdutoAtacadoTextBox.Text), 0,0,
                    //    decimal.Parse(qtdProdutoSuperAtacadoTextBox.Text),0, 0,
                    //     exibeNaListagemCheckBox.Checked);
                    tb_produtoTableAdapter.Fill(saceDataSet.tb_produto);
                    tb_produtoBindingSource.MoveLast();
                }
                else
                {
                    tb_produtoTableAdapter.Update(nomeTextBox.Text, nomeFabricanteTextBox.Text, unidadeTextBox.Text,
                        codigoBarraTextBox.Text, codGrupo, codFabricante, temVencimentoCheckBox.Checked,
                        cfop, decimal.Parse(icmsTextBox.Text), decimal.Parse(simplesTextBox.Text),
                        decimal.Parse(ipiTextBox.Text), decimal.Parse(freteTextBox.Text), decimal.Parse(custoVendaTextBox.Text), decimal.Parse("0"),
                        ultimaDataAtualizacaoDateTimePicker.Value, decimal.Parse(lucroPrecoVendaVarejoTextBox.Text),
                        decimal.Parse(precoVendaVarejoTextBox.Text), decimal.Parse(qtdProdutoAtacadoTextBox.Text),
                        decimal.Parse(lucroPrecoVendaAtacadoTextBox.Text), decimal.Parse(precoVendaAtacadoTextBox.Text), decimal.Parse(qtdProdutoSuperAtacadoTextBox.Text), 
                        decimal.Parse(lucroPrecoVendaSuperAtacadoTextBox.Text), decimal.Parse(precoVendaSuperAtacadoTextBox.Text), 
                        exibeNaListagemCheckBox.Checked, long.Parse(codProdutoTextBox.Text));
                    tb_produtoBindingSource.EndEdit();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                tb_produtoBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
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
                    tb_produtoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_produtoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_produtoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_produtoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.F7)
                {
                    btnPreco_Click(sender, e);
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
                else if ((e.KeyCode == Keys.F2) && (codGrupoComboBox.Focused))
                {
                    Telas.FrmGrupoPesquisa frmGrupoPesquisa = new Telas.FrmGrupoPesquisa();
                    frmGrupoPesquisa.ShowDialog();
                    if (frmGrupoPesquisa.getCodGrupo() != -1)
                    {
                        tbgrupoBindingSource.Position = tbgrupoBindingSource.Find("codGrupo", frmGrupoPesquisa.getCodGrupo());                        
                    }
                    frmGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmEmpresaPesquisa frmEmpresaPesquisa = new Telas.FrmEmpresaPesquisa();
                    frmEmpresaPesquisa.ShowDialog();
                    if (frmEmpresaPesquisa.getCodEmpresa() != -1)
                    {
                        tbempresaBindingSource.Position = tbempresaBindingSource.Find("codigoEmpresa", frmEmpresaPesquisa.getCodEmpresa());
                    }
                    frmEmpresaPesquisa.Dispose();
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
            btnPreco.Enabled = habilita;
            tb_produtoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void btnPreco_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPreco frmProdutoPreco = new Telas.FrmProdutoPreco(long.Parse(codProdutoTextBox.Text));
            frmProdutoPreco.ShowDialog();
            string codProduto = codProdutoTextBox.Text;
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", codProduto);
            frmProdutoPreco.Dispose();
        }
    }
}
