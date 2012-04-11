using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Util;

namespace Telas
{
    public partial class FrmProduto : Form
    {
        public EstadoFormulario estado;
        private Int32 codProduto;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public FrmProduto()
        {
            InitializeComponent();
            codProduto = -1;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_cfopTableAdapter.Fill(this.saceDataSet.tb_cfop);
            this.tb_cstTableAdapter.Fill(this.saceDataSet.tb_cst);
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            this.tb_situacao_produtoTableAdapter.Fill(this.saceDataSet.tb_situacao_produto);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            
            atualizarPrecos();
            habilitaBotoes(true);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisaPreco frmProdutoPesquisa = new Telas.FrmProdutoPesquisaPreco();
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.getCodProduto() != -1)
            {
                tbprodutoBindingSource.Position = tbprodutoBindingSource.Find("codProduto", frmProdutoPesquisa.getCodProduto());
            }
            frmProdutoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tbprodutoBindingSource.AddNew();
            codProdutoTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            cfopComboBox.SelectedIndex = 0;
            codGrupoComboBox.SelectedIndex = 0;
            codigoFabricanteComboBox.SelectedIndex = 0;
            codSituacaoProdutoComboBox.SelectedIndex = 0;
            codCSTComboBox.SelectedIndex = 0;
            simplesTextBox.Text = Global.SIMPLES.ToString();
            unidadeTextBox.Text = "UN";
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

            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorProduto.getInstace().remover(Int32.Parse(codProdutoTextBox.Text));
                tb_produtoTableAdapter.Fill(saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tbprodutoBindingSource.CancelEdit();
            tbprodutoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            ProdutoLoja produtoLoja = new ProdutoLoja();

            produto.Cfop = int.Parse(cfopComboBox.SelectedValue.ToString());
            produto.CodFabricante = Int32.Parse(codigoFabricanteComboBox.SelectedValue.ToString());
            produto.CodGrupo = Int32.Parse(codGrupoComboBox.SelectedValue.ToString());
            produto.CodigoBarra = codigoBarraTextBox.Text;
            produto.CodProduto = Int32.Parse(codProdutoTextBox.Text);
            produto.ExibeNaListagem = exibeNaListagemCheckBox.Checked;
            produto.Frete = (freteTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(freteTextBox.Text);
            produto.Icms = (icmsTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(icmsTextBox.Text);
            produto.IcmsSubstituto = (icms_substitutoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(icms_substitutoTextBox.Text);
            produto.Ipi = (ipiTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(ipiTextBox.Text);
            produto.LucroPrecoVendaAtacado = (lucroPrecoVendaAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(lucroPrecoVendaAtacadoTextBox.Text);
            produto.LucroPrecoVendaVarejo = (lucroPrecoVendaVarejoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(lucroPrecoVendaVarejoTextBox.Text);
            produto.Nome = nomeTextBox.Text.Trim();
            produto.NomeProdutoFabricante = nomeFabricanteTextBox.Text.Trim();
            produto.UltimoPrecoCompra = (ultimoPrecoCompraTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(ultimoPrecoCompraTextBox.Text);
            produto.PrecoVendaAtacado = (precoVendaAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(precoVendaAtacadoTextBox.Text.Trim());
            produto.PrecoVendaVarejo = (precoVendaVarejoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(precoVendaVarejoTextBox.Text.Trim());
            produto.QtdProdutoAtacado = (qtdProdutoAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(qtdProdutoAtacadoTextBox.Text.Trim());
            produto.Simples = (simplesTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(simplesTextBox.Text);
            produto.TemVencimento = temVencimentoCheckBox.Checked;
            produto.UltimaDataAtualizacao = ultimaDataAtualizacaoDateTimePicker.Value;
            produto.Unidade = unidadeTextBox.Text;
            produto.DataUltimoPedido = dataUltimoPedidoDateTimePicker.Value;
            produto.CodSituacaoProduto = Byte.Parse(codSituacaoProdutoComboBox.SelectedValue.ToString());
            produto.ReferenciaFabricante = referenciaFabricanteTextBox.Text;
            produto.CodCST = codCSTComboBox.SelectedValue.ToString();
            produto.Ncmsh = ncmshTextBox.Text;
            produtoLoja.CodLoja = Global.LOJA_PADRAO;
            produtoLoja.QtdEstoque = 0;
            produtoLoja.QtdEstoqueAux = 0;
            
            IGerenciadorProduto gProduto = GerenciadorProduto.getInstace();
            IGerenciadorProdutoLoja gProdutoLoja = GerenciadorProdutoLoja.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                gProduto.inserir(produto);
                tb_produtoTableAdapter.Fill(saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);
                tbprodutoBindingSource.MoveLast();

                produtoLoja.CodProduto = Int32.Parse(codProdutoTextBox.Text);
                gProdutoLoja.inserir(produtoLoja);
                codProdutoTextBox_TextChanged(sender, e);
            }
            else
            {
                gProduto.atualizar(produto);
                tbprodutoBindingSource.EndEdit();
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
                else if (e.KeyCode == Keys.F7)
                {
                    btnEstoque_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tbprodutoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tbprodutoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tbprodutoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tbprodutoBindingSource.MoveNext();
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
                else if ((e.KeyCode == Keys.F3) && (codGrupoComboBox.Focused))
                {
                    Telas.FrmGrupo frmGrupo = new Telas.FrmGrupo();
                    frmGrupo.ShowDialog();
                    if (frmGrupo.CodGrupo > 0)
                    {
                        this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
                        tbgrupoBindingSource.Position = tbgrupoBindingSource.Find("codGrupo", frmGrupo.CodGrupo);
                    }
                    frmGrupo.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(Pessoa.PESSOA_JURIDICA);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.CodPessoa != -1)
                    {
                        tbpessoaBindingSource.Position = tbpessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFabricanteComboBox.Focused))
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
            }
        }


        private void atualizarPrecos()
        {
            GerenciadorPrecos gPrecos = GerenciadorPrecos.getInstance();

            decimal precoCompra = Convert.ToDecimal(ultimoPrecoCompraTextBox.Text);
            decimal creditoICMS = Convert.ToDecimal(icmsTextBox.Text);
            decimal ICMSSubstituicao = Convert.ToDecimal(icms_substitutoTextBox.Text);
            decimal simples = Convert.ToDecimal(simplesTextBox.Text);
            decimal ipi = Convert.ToDecimal(ipiTextBox.Text);
            decimal frete = Convert.ToDecimal(freteTextBox.Text);
            decimal lucroVarejo = Convert.ToDecimal(lucroPrecoVendaVarejoTextBox.Text);
            decimal lucroAtacado = Convert.ToDecimal(lucroPrecoVendaAtacadoTextBox.Text);
            decimal manutencao = 0;
            decimal precoCusto = 0;

            if (codCSTComboBox.SelectedValue != null)
            {
                String codCST = codCSTComboBox.SelectedValue.ToString();


                if (codCST.Equals(Produto.ST_TRIBUTADO_INTEGRAL))
                {
                    precoCusto = gPrecos.calculaPrecoCustoNormal(precoCompra, creditoICMS, simples, ipi, frete, manutencao);
                }
                else
                {
                    precoCusto = gPrecos.calculaPrecoCustoSubstituicao(precoCompra, ICMSSubstituicao, simples, ipi, frete, manutencao);
                }
                precoVarejoSugestaoTextBox.Text = gPrecos.calculaPrecoVenda(precoCusto, lucroVarejo).ToString("N3");
                precoAtacadoSugestaoTextBox.Text = gPrecos.calculaPrecoVenda(precoCusto, lucroAtacado).ToString("N3");
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
            btnEstoque.Enabled = habilita && (!codProdutoTextBox.Text.Equals(""));
            tb_produtoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            nomeFabricanteTextBox.Text = nomeTextBox.Text;
        }

        private void codigoFabricanteComboBox_Leave(object sender, EventArgs e)
        {
            if (codigoFabricanteComboBox.SelectedValue == null)
            {
                codigoFabricanteComboBox.Focus();
                throw new TelaException("Um fabricante válido precisa ser selecionado.");
            }
        }

        private void codigoFabricanteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codProdutoTextBox_TextChanged(object sender, EventArgs e)
        {
            this.tb_produto_lojaTableAdapter.FillByCodProduto(saceDataSet.tb_produto_loja, Int64.Parse(codProdutoTextBox.Text));
            
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            Int32 codProduto = Int32.Parse(codProdutoTextBox.Text);
            FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(codProduto);
            frmAjuste.ShowDialog();
            tb_produto_lojaTableAdapter.FillByCodProduto(saceDataSet.tb_produto_loja, codProduto); 
        }

        private void FrmProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!codProdutoTextBox.Text.Equals(""))
            {
                codProduto = Int32.Parse(codProdutoTextBox.Text);
            }
        }

        private void icmsTextBox_Leave_1(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            atualizarPrecos();
            if (Convert.ToDecimal(precoVendaVarejoTextBox.Text) == 0)
            {
                precoVendaVarejoTextBox.Text = precoVarejoSugestaoTextBox.Text;
            }
            if (Convert.ToDecimal(precoVendaAtacadoTextBox.Text) == 0)
            {
                precoVendaAtacadoTextBox.Text = precoAtacadoSugestaoTextBox.Text;
            }

        }

        private void precoVendaVarejoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom3CasasDecimais((TextBox)sender);
        }

        private void tbprodutoBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (!ultimoPrecoCompraTextBox.Text.Equals(""))
            {
                atualizarPrecos();
            }
        }

    }
}