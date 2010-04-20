using System;
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
                        "F", long.Parse(numeroNotaFiscalTextBox.Text), valorICMSSubstitutoTextBox.Text, icmsTextBox.Text);
                    tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
                    tb_entradaBindingSource.MoveLast();
                }
                else
                {
                    tb_entradaTableAdapter.Update(long.Parse(codigoFornecedorComboBox.SelectedValue.ToString()),
                        long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString()), decimal.Parse(valorCustoFreteTextBox.Text), DateTime.Parse(dataEntradaDateTimePicker.Text),
                        decimal.Parse(valorTotalTextBox.Text), "F", long.Parse(numeroNotaFiscalTextBox.Text), decimal.Parse(valorICMSSubstitutoTextBox.Text),
                        decimal.Parse(icmsTextBox.Text), long.Parse(codEntradaTextBox.Text));
                    tb_entradaBindingSource.EndEdit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Campos obrigatórios não foram preenchidos.");
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
                        Negocio.GerenciadorEntrada.excluirProdutoEntrada(codEntrada, codProduto);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Mensagens.ERRO_REMOCAO);
            }
            this.tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            codEntradaTextBox_TextChanged(sender, e);
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


        private void btnProdutos_Click(object sender, EventArgs e)
        {
            codProdutoTextBox.Focus();
        }

        private void camposProdutoTextBox_Enter(object sender, EventArgs e)
        {
            if (nomeTextBox.Text.Trim().Equals(""))
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
                } else {
                    posicaoProduto = tbprodutoBindingSource.Find("codProduto", codProdutoTextBox.Text);
                }
                if (posicaoProduto <= 0)
                {
                    codProdutoTextBox.Focus();
                }
                else
                {
                    tbprodutoBindingSource.Position = posicaoProduto;
                }
                codProdutoTextBox.TabIndex = 37;
            }
        }

        private void codProdutoTextBox_Enter(object sender, EventArgs e)
        {
            ipiTextBox.Text = "0";
            nomeTextBox.Text = "";
            quantidadeTextBox.Text = "0";
            precoCompraTextBox.Text = "0";
            codProdutoTextBox.TabIndex = 28;
        }

        private void precoCompraTextBox_Leave(object sender, EventArgs e)
        {
            btnSalvar_Click(sender, e);
            try
            {
                SACE.Dados.saceDataSet.tb_produtoRow produto = (SACE.Dados.saceDataSet.tb_produtoRow) ((System.Data.DataRowView) tbprodutoBindingSource.Current).Row;
                decimal percIcmsSubstituicao = (decimal.Parse(valorICMSSubstitutoTextBox.Text)>0)?decimal.Parse(valorICMSSubstitutoTextBox.Text) / decimal.Parse(valorTotalTextBox.Text) * 100:0;
                decimal percFrete = (decimal.Parse(valorCustoFreteTextBox.Text)>0)?decimal.Parse(valorCustoFreteTextBox.Text) / decimal.Parse(valorTotalTextBox.Text) * 100:0;
                decimal precoCusto = 0;
                if (produto.cfop == SACE.Negocio.SaceConst.CFOP_NORMAL)
                {
                    precoCusto = Negocio.GerenciadorPrecos.calculaPrecoCustoNormal(decimal.Parse(precoCompraTextBox.Text),
                        decimal.Parse(icmsTextBox.Text), SACE.Negocio.SaceConst.SIMPLES, decimal.Parse(ipiTextBox.Text), percFrete);
                }
                else 
                {
                    precoCusto = Negocio.GerenciadorPrecos.calculaPrecoCustoSubstituicao(decimal.Parse(precoCompraTextBox.Text),
                        percIcmsSubstituicao, SACE.Negocio.SaceConst.SIMPLES, decimal.Parse(ipiTextBox.Text), percFrete);
                }

                tb_entrada_produtoTableAdapter.Insert(long.Parse(codEntradaTextBox.Text), long.Parse(codProdutoTextBox.Text),
                    quantidadeTextBox.Text, precoCompraTextBox.Text, ipiTextBox.Text,
                    icmsTextBox.Text, "0.0", valorICMSSubstitutoTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            codProdutoTextBox.Text = "";
            codEntradaTextBox_TextChanged(sender, e);
        }

        private void codEntradaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!codEntradaTextBox.Text.Equals(""))
            {
                tb_entrada_produtoTableAdapter.FillByEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
                totalNotaCalculadoTextBox.Text = tb_entrada_produtoTableAdapter.totalEntrada(long.Parse(codEntradaTextBox.Text)).ToString();
            }
        }
    }
}
