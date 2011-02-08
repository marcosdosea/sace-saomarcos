using System;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Util;

namespace Telas
{
    public partial class FrmEntrada : Form
    {
        private EstadoFormulario estado;
        private Char tipoEntrada = Global.FISCAL;
        private Produto produto;
        private Entrada entrada;
        
        public FrmEntrada()
        {
            InitializeComponent();
        }

        private void FrmEntrada_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            if ((codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0)) {
                this.tb_entrada_produtoTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
            }
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
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
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tb_entradaTableAdapter.Delete(int.Parse(codEntradaTextBox.Text));
                tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
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
            entrada = new Entrada();
            entrada.CodEmpresaFrete = long.Parse(codigoEmpresaFreteComboBox.SelectedValue.ToString());
            entrada.CodFornecedor = long.Parse(codigoFornecedorComboBox.SelectedValue.ToString());
            entrada.DataEntrada = DateTime.Parse(dataEntradaDateTimePicker.Text);
            entrada.ValorCustoFrete = decimal.Parse(valorCustoFreteTextBox.Text);
            entrada.ValorICMSSubstituto = decimal.Parse(valorICMSSubstitutoTextBox.Text);
            entrada.ICMSPadrao = decimal.Parse(icmsTextBox.Text);
            entrada.NumeroNotaFiscal = numeroNotaFiscalTextBox.Text;
            entrada.ValorTotal = decimal.Parse(valorTotalTextBox.Text);
            entrada.TipoEntrada = tipoEntrada;

            
            IGerenciadorEntrada gEntrada = GerenciadorEntrada.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                gEntrada.inserir(entrada);
                tb_entradaTableAdapter.Fill(saceDataSet.tb_entrada);
                tb_entradaBindingSource.MoveLast();
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
            else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                IGerenciadorEntradaProduto gEntradaProduto = GerenciadorEntradaProduto.getInstace();
                EntradaProduto entradaProduto = new EntradaProduto();
                entradaProduto.CodEntrada = long.Parse(codEntradaTextBox.Text);
                entradaProduto.CodProduto = int.Parse(codProdutoComboBox.SelectedValue.ToString());
                entradaProduto.DataValidade = DateTime.Parse(data_validadeDateTimePicker.Text);
                entradaProduto.Icms = decimal.Parse(icmsProdutoTextBox.Text);
                entradaProduto.IcmsSubstituto = decimal.Parse(icms_substitutoTextBox.Text);
                entradaProduto.Ipi = decimal.Parse(ipiTextBox.Text);
                entradaProduto.PrecoCusto = decimal.Parse(preco_custoTextBox.Text);
                entradaProduto.Quantidade = decimal.Parse(quantidadeTextBox.Text);
                entradaProduto.QuantidadeVendidos = 0;
                entradaProduto.ValorCompra = decimal.Parse(precoCompraTextBox.Text);
                entradaProduto.Frete = decimal.Parse(freteTextBox.Text);

                entradaProduto.Simples = decimal.Parse(simplesTextBox.Text);
                entradaProduto.LucroPrecoVendaAtacado = decimal.Parse(lucroAtacadoTextBox.Text);
                entradaProduto.LucroPrecoVendaVarejo = decimal.Parse(lucroVarejoTextBox.Text);
                entradaProduto.PrecoVendaAtacado = decimal.Parse(precoAtacadoTextBox.Text);
                entradaProduto.PrecoVendaVarejo = decimal.Parse(precoVarejoTextBox.Text);
                
                GerenciadorEntradaProduto.getInstace().inserir(entradaProduto);
                codEntradaTextBox_TextChanged(sender, e);
                codProdutoComboBox.Focus();
            }
            else 
            {
                gEntrada.atualizar(entrada);
                tb_entradaBindingSource.EndEdit();
                habilitaBotoes(true);
                btnProdutos.Focus();
            }
        }

        private void excluirProduto(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_entrada_produtoDataGridView.Rows.Count > 0)
                {
                    long codEntradaProduto = long.Parse(tb_entrada_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorEntradaProduto.getInstace().remover(codEntradaProduto);
                }
            }
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
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFornecedorComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codigoEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa();
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoEmpresaFreteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0)
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tbpessoaBindingSource1.Position = tbpessoaBindingSource1.Find("codPessoa", frmPessoa.CodPessoa);
                    }
                    frmPessoa.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProdutoPesquisa frmProdutoPesquisa = new Telas.FrmProdutoPesquisa();
                    frmProdutoPesquisa.ShowDialog();
                    if (frmProdutoPesquisa.CodProduto != -1)
                    {
                        tbprodutoBindingSource.Position = tbprodutoBindingSource.Find("codProduto", frmProdutoPesquisa.CodProduto);
                    }
                    frmProdutoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codProdutoComboBox.Focused))
                {
                    Telas.FrmProduto frmProduto = new Telas.FrmProduto();
                    frmProduto.ShowDialog();
                    if (frmProduto.CodProduto > 0)
                    {
                        this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
                        tbprodutoBindingSource.Position = tbprodutoBindingSource.Find("codProduto", frmProduto.CodProduto);
                    }
                    frmProduto.Dispose();
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
            btnProdutos.Enabled = habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            btnPagamentos.Enabled = habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            tb_entradaBindingNavigator.Enabled = habilita;
            ProdutosGroupBox.Enabled = !habilita && (codEntradaTextBox.Text != "") && (long.Parse(codEntradaTextBox.Text) > 0);
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void codigoFornecedorComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            ProdutosGroupBox.Enabled = true;
            codProdutoComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void codigoFornecedorComboBox_Leave(object sender, EventArgs e)
        {
            if (codigoFornecedorComboBox.SelectedValue == null)
            {
                codigoFornecedorComboBox.Focus();
                throw new TelaException("Um forncedor válido precisa ser selecionado.");
            }
        }

        private void codigoEmpresaFreteComboBox_Leave(object sender, EventArgs e)
        {
            if (codigoEmpresaFreteComboBox.SelectedValue == null)
            {
                codigoEmpresaFreteComboBox.Focus();
                throw new TelaException("Um Empresa de frete válida precisa ser selecionada.");
            }
        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            if (codProdutoComboBox.SelectedValue == null)
            {
                codProdutoComboBox.Focus();
                throw new TelaException("Um produto válido precisa ser selecionado.");
            }
            else
            {
                produto = GerenciadorProduto.getInstace().obterProduto(Int32.Parse(codProdutoComboBox.SelectedValue.ToString()));
                icmsProdutoTextBox.Text = icmsTextBox.Text;
                icms_substitutoTextBox.Text = produto.IcmsSubstituto.ToString();
                ipiTextBox.Text = produto.Ipi.ToString();
                simplesTextBox.Text = produto.Simples.ToString();
                precoVarejoTextBox.Text = produto.PrecoVendaVarejo.ToString();
                precoAtacadoTextBox.Text = produto.PrecoVendaAtacado.ToString();
                lucroVarejoTextBox.Text = produto.LucroPrecoVendaVarejo.ToString();
                lucroAtacadoTextBox.Text = produto.LucroPrecoVendaAtacado.ToString();
                precoCompraTextBox.Text = "0.00";
                freteTextBox.Text = Math.Round((decimal.Parse(valorCustoFreteTextBox.Text) / decimal.Parse(valorTotalTextBox.Text) * 100),2).ToString();
            }
        }

        private void precoCompraTextBox_Leave(object sender, EventArgs e)
        {
            produto.Icms = decimal.Parse(icmsProdutoTextBox.Text);
            produto.IcmsSubstituto = decimal.Parse(icms_substitutoTextBox.Text);
            produto.Simples = decimal.Parse(simplesTextBox.Text);
            produto.Ipi = decimal.Parse(ipiTextBox.Text);
            produto.UltimoPrecoCompra = decimal.Parse(precoCompraTextBox.Text);
            produto.LucroPrecoVendaVarejo = decimal.Parse(lucroVarejoTextBox.Text);
            produto.LucroPrecoVendaAtacado = decimal.Parse(lucroAtacadoTextBox.Text);
            produto.PrecoVendaVarejo = decimal.Parse(precoVarejoTextBox.Text);
            produto.PrecoVendaAtacado = decimal.Parse(precoAtacadoTextBox.Text);
            produto.Frete = decimal.Parse(freteTextBox.Text);

            
            if (!precoCompraTextBox.Text.Trim().Equals(""))
            {
                decimal precoCusto = GerenciadorProduto.getInstace().calculaPrecoCusto(produto);
                preco_custoTextBox.Text = precoCusto.ToString("0,0.00");
                precoVarejoSugestaoTextBox.Text = GerenciadorProduto.getInstace().calculaPrecoVenda(precoCusto, decimal.Parse(lucroVarejoTextBox.Text)).ToString("0,0.00");
                precoAtacadoSugestaoTextBox.Text = GerenciadorProduto.getInstace().calculaPrecoVenda(precoCusto, decimal.Parse(lucroAtacadoTextBox.Text)).ToString("0,0.00");
            }
        }

        private void codEntradaTextBox_TextChanged(object sender, EventArgs e)
        {
            totalNotaCalculadoTextBox.Text = "0,00";
            if (!codEntradaTextBox.Text.Trim().Equals("")) {
                tb_entrada_produtoTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada_produto, long.Parse(codEntradaTextBox.Text));
                totalNotaCalculadoTextBox.Text = ((decimal) tb_entrada_produtoTableAdapter.totalEntrada(long.Parse(codEntradaTextBox.Text))).ToString("0,0.00");
            }
        }

    }
}
