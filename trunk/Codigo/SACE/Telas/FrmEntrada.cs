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
            // TODO: This line of code loads data into the 'saceDataSet.tb_produto' table. You can move, or remove it, as needed.
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            // TODO: This line of code loads data into the 'saceDataSet.tb_entrada_produto' table. You can move, or remove it, as needed.
            this.tb_entrada_produtoTableAdapter.Fill(this.saceDataSet.tb_entrada_produto);
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
                tb_entradaBindingSource.Position = tb_entradaBindingSource.Find("codEntrada", frmEntradaPesquisa.getCodEntrada());
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
                        long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString()), valorCustoFreteTextBox.Text,
                        DateTime.Parse(dataEntradaDateTimePicker.Text), valorTotalTextBox.Text,
                        "F", long.Parse(numeroNotaFiscalTextBox.Text), valorICMSSubstitutoTextBox.Text);
                    tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
                    tb_entradaBindingSource.MoveLast();
                }
                else
                {
                    tb_entradaTableAdapter.Update(long.Parse(codigoFornecedorComboBox.SelectedValue.ToString()),
                        long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString()), decimal.Parse(valorCustoFreteTextBox.Text), DateTime.Parse(dataEntradaDateTimePicker.Text),
                        decimal.Parse(valorTotalTextBox.Text), "F", long.Parse(numeroNotaFiscalTextBox.Text), decimal.Parse(valorICMSSubstitutoTextBox.Text), long.Parse(codEntradaTextBox.Text));
                    tb_entradaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.REGISTRO_DUPLICIDADE);
                tb_entradaBindingSource.CancelEdit();
            }
            habilitaBotoes(true);
        }

        private void excluirProduto(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (tb_entrada_produtoDataGridView.Rows.Count > 0)
                    {
                        long codProduto = long.Parse(tb_entrada_produtoDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                        long codEntrada = long.Parse(codEntradaTextBox.Text);
                        tb_entrada_produtoTableAdapter.Delete(codEntrada, codProduto);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
            }
            this.tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
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
                else if (e.KeyCode == Keys.F7)
                {
                    btnProdutos_Click(sender, e);
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
                else if ((e.KeyCode == Keys.F2) && (codigoFornecedorComboBox.Focused))
                {
                    Telas.FrmEmpresaPesquisa frmEmpresaPesquisa = new Telas.FrmEmpresaPesquisa();
                    frmEmpresaPesquisa.ShowDialog();
                    if (frmEmpresaPesquisa.getCodEmpresa() != -1)
                    {
                        tbempresaBindingSource.Position = tbempresaBindingSource.Find("codigoEmpresa", frmEmpresaPesquisa.getCodEmpresa());
                    }
                    frmEmpresaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codigoEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmEmpresaPesquisa frmEmpresaPesquisa = new Telas.FrmEmpresaPesquisa();
                    frmEmpresaPesquisa.ShowDialog();
                    if (frmEmpresaPesquisa.getCodEmpresa() != -1)
                    {
                        tbempresaBindingSource1.Position = tbempresaBindingSource1.Find("codigoEmpresa", frmEmpresaPesquisa.getCodEmpresa());
                    }
                    frmEmpresaPesquisa.Dispose();
                }

            }
            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                tb_entrada_produtoDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            if ((e.KeyCode == Keys.Delete) && (tb_entrada_produtoDataGridView.Focused == true))
            {
                excluirProduto(sender, e);
            }

            if ((e.KeyCode.Equals(Keys.Tab) && (codProdutoTextBox.Focused)))
            {
                codProdutoTextBox_Tab(sender, e);
            }
            if ((e.KeyCode == Keys.Tab) && (precoCompraTextBox.Focused))
            {
                precoCompraTextBox_Tab(sender, e);
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


        private void codEntradaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!codEntradaTextBox.Text.Equals(""))
            {
                tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
                totalNotaCalculadoTextBox.Text = tb_entrada_produtoTableAdapter.totalEntrada(long.Parse(codEntradaTextBox.Text)).ToString();
            }
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            codProdutoTextBox.Focus();
        }

        private void codProdutoTextBox_Tab(object sender, EventArgs e)
        {
            int posicaoProduto = -1;
            if (codProdutoTextBox.Text.Trim().Equals(""))
            {
                Telas.FrmProdutoPesquisa frmProdutoPesquisa = new Telas.FrmProdutoPesquisa();
                frmProdutoPesquisa.ShowDialog();
                if (frmProdutoPesquisa.getCodProduto() != -1)
                {
                    codProdutoTextBox.Text = frmProdutoPesquisa.getCodProduto().ToString();
                }
                else
                {
                    codProdutoTextBox.Text = "";
                }
                frmProdutoPesquisa.Dispose();
            }
            if (!codProdutoTextBox.Text.Trim().Equals(""))
            {
                posicaoProduto = tbprodutoBindingSource.Find("codProduto", codProdutoTextBox.Text);
            }
            if (posicaoProduto <= 0)
            {
                codProdutoTextBox.Text = "";
                codProdutoTextBox.Focus();
            }
            else
            {
                tbprodutoBindingSource.Position = posicaoProduto;
                ipiTextBox.Text = "";
                precoCompraTextBox.Text = "";
            }

        }

        private void precoCompraTextBox_Tab(object sender, EventArgs e)
        {
            btnSalvar_Click(sender, e);
            try
            {
                tb_entrada_produtoTableAdapter.Insert(long.Parse(codEntradaTextBox.Text), long.Parse(codProdutoTextBox.Text),
                    decimal.Parse(quantidadeTextBox.Text), decimal.Parse(precoCompraTextBox.Text), decimal.Parse(ipiTextBox.Text),
                    decimal.Parse(icmsTextBox.Text), 0, 0);
            }
            catch (Exception)
            {
                MessageBox.Show("O produto já foi incluído na nota fiscal.");
            }
            tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            codProdutoTextBox.Text = "";
        }

        private void valorTotalTextBox_Leave(object sender, EventArgs e)
        {
            codProdutoTextBox.Focus();
        }

        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            precoCompraTextBox.Focus();
        }
    }
}
