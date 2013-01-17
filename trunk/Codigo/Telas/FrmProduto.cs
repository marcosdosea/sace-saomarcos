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
using Dados;

namespace Telas
{
    public partial class FrmProduto : Form
    {
        public EstadoFormulario estado;
        public ProdutoPesquisa ProdutoPesquisa { get; set; }


        public FrmProduto()
        {
            InitializeComponent();
            ProdutoPesquisa = null;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.PRODUTOS, Principal.Autenticacao.CodUsuario);

            cstBindingSource.DataSource = GerenciadorCst.GetInstance().ObterTodos();
            codigoFabricanteComboBox.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            cfopComboBox.DataSource = GerenciadorCfop.GetInstance().ObterTodos();
            grupoBindingSource.DataSource = GerenciadorGrupo.GetInstance().ObterTodos();
            situacaoprodutoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterSituacoesProduto();
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
            pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterPorTipoPessoa(Pessoa.PESSOA_JURIDICA);
            
            habilitaBotoes(true);
            Cursor.Current = Cursors.Default;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisaPreco frmProdutoPesquisa = new Telas.FrmProdutoPesquisaPreco(true);
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.ProdutoPesquisa != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(frmProdutoPesquisa.ProdutoPesquisa);
            }
            frmProdutoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            produtoBindingSource.AddNew();
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
            unidadeCompraTextBox.Text = "UN";
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
                GerenciadorProduto.GetInstance().Remover(Convert.ToInt64(codProdutoTextBox.Text));
                produtoBindingSource.RemoveCurrent();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            produtoBindingSource.CancelEdit();
            produtoBindingSource.EndEdit();
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
            produto.CodSubgrupo = Int32.Parse(codSubgrupoComboBox.SelectedValue.ToString());
            produto.CodigoBarra = codigoBarraTextBox.Text;
            produto.CodProduto = Int32.Parse(codProdutoTextBox.Text);
            produto.ExibeNaListagem = exibeNaListagemCheckBox.Checked;
            produto.Frete = (freteTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(freteTextBox.Text);
            produto.Icms = (icmsTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(icmsTextBox.Text);
            produto.IcmsSubstituto = (icms_substitutoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(icms_substitutoTextBox.Text);
            produto.Ipi = (ipiTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(ipiTextBox.Text);
            produto.Desconto = (descontoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(descontoTextBox.Text);
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
            produto.UnidadeCompra = unidadeCompraTextBox.Text;
            produto.QuantidadeEmbalagem = (quantidadeEmbalagemTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(quantidadeEmbalagemTextBox.Text.Trim());
            produto.DataUltimoPedido = dataUltimoPedidoDateTimePicker.Value;
            produto.CodSituacaoProduto = SByte.Parse(codSituacaoProdutoComboBox.SelectedValue.ToString());
            produto.ReferenciaFabricante = referenciaFabricanteTextBox.Text;
            produto.CodCST = codCSTComboBox.SelectedValue.ToString();
            produto.Ncmsh = ncmshTextBox.Text;
            produtoLoja.CodLoja = Global.LOJA_PADRAO;
            produtoLoja.QtdEstoque = 0;
            produtoLoja.QtdEstoqueAux = 0;
            
            GerenciadorProduto gProduto = GerenciadorProduto.GetInstance();
            GerenciadorProdutoLoja gProdutoLoja = GerenciadorProdutoLoja.GetInstance();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                long codProduto = gProduto.Inserir(produto);
                codProdutoTextBox.Text = codProduto.ToString();
                
                produtoLoja.CodProduto = codProduto;
                gProdutoLoja.Inserir(produtoLoja);
                //codProdutoTextBox_TextChanged(sender, e);
            }
            else
            {
                gProduto.Atualizar(produto);
            }
            produtoBindingSource.EndEdit();
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
                    produtoBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    produtoBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    produtoBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    produtoBindingSource.MoveNext();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (codigoFabricanteComboBox.Focused)
                    {
                        codigoFabricanteComboBox_Leave(sender, e);
                    }
                    e.Handled = true;
                    SendKeys.Send("{tab}");
                } 
                else if (e.KeyCode == Keys.Escape)
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
                    if (frmGrupoPesquisa.SelectedGrupo != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupoPesquisa.SelectedGrupo);
                    }
                    frmGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoComboBox.Focused))
                {
                    Telas.FrmGrupo frmGrupo = new Telas.FrmGrupo();
                    frmGrupo.ShowDialog();
                    if (frmGrupo.GrupoSelected != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupo.GrupoSelected);
                    }
                    frmGrupo.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codSubgrupoComboBox.Focused))
                {
                    Telas.FrmSubgrupoPesquisa frmSubGrupoPesquisa = new Telas.FrmSubgrupoPesquisa();
                    frmSubGrupoPesquisa.ShowDialog();
                    if (frmSubGrupoPesquisa.SubgrupoSelected != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmSubGrupoPesquisa.GrupoSelected);
                        subgrupoBindingSource.Position = subgrupoBindingSource.List.IndexOf(frmSubGrupoPesquisa.SubgrupoSelected);
                    }
                    frmSubGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codSubgrupoComboBox.Focused))
                {
                    Telas.FrmSubgrupo frmSubgrupo = new Telas.FrmSubgrupo( Convert.ToInt32(codGrupoComboBox.SelectedValue.ToString() ) );
                    frmSubgrupo.ShowDialog();
                    if (frmSubgrupo.SubgrupoSelected != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmSubgrupo.GrupoSelected);
                        subgrupoBindingSource.Position = subgrupoBindingSource.List.IndexOf(frmSubgrupo.SubgrupoSelected);
                    }
                    frmSubgrupo.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmPessoaPesquisa frmPessoaPesquisa = new Telas.FrmPessoaPesquisa(Pessoa.PESSOA_JURIDICA);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        pessoaBindingSource.Position = pessoaBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
                    }
                    frmPessoa.Dispose();
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
            btnEstoque.Enabled = habilita && (!codProdutoTextBox.Text.Equals(""));
            tb_produtoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }


        private void nomeTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
            if (nomeFabricanteTextBox.Text.Trim().Equals(""))
            {
                nomeFabricanteTextBox.Text = nomeTextBox.Text;
            }
            codProdutoTextBox_Leave(sender, e);
        }

        private void codigoFabricanteComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codigoFabricanteComboBox, estado, pessoaBindingSource, true);
            codProdutoTextBox_Leave(sender, e);
        }

        private void codigoFabricanteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codProdutoTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((codProdutoTextBox.Text != null) && (codProdutoTextBox.Text != ""))
                produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance().ObterPorProduto(Convert.ToInt64(codProdutoTextBox.Text));
            
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            Int32 codProduto = Int32.Parse(codProdutoTextBox.Text);
            FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(codProduto);
            frmAjuste.ShowDialog();
            if (frmAjuste.CodProduto != -1)
            {
                produtoBindingSource.Position = produtoBindingSource.Find("codProduto", frmAjuste.CodProduto);
            }
            codProdutoTextBox_TextChanged(sender, e);
        }

        private void FrmProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!codProdutoTextBox.Text.Equals(""))
            {
                ProdutoPesquisa = (Produto) produtoBindingSource.Current;
            }
        }

        private void icmsTextBox_Leave_1(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            if (Convert.ToDecimal(precoVendaVarejoTextBox.Text) == 0)
            {
                precoVendaVarejoTextBox.Text = precoVarejoSugestaoTextBox.Text;
            }
            if (Convert.ToDecimal(precoVendaAtacadoTextBox.Text) == 0)
            {
                precoVendaAtacadoTextBox.Text = precoAtacadoSugestaoTextBox.Text;
            }
            codProdutoTextBox_Leave(sender, e);
        }

        private void precoVendaVarejoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom2CasasDecimais((TextBox)sender);
            codProdutoTextBox_Leave(sender, e);
        }

        private void codGrupoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (codGrupoComboBox.SelectedValue != null)
            {
                Produto produto = (Produto)produtoBindingSource.Current;
                grupoBindingSource.Position = grupoBindingSource.List.IndexOf(new Grupo() { CodGrupo = produto.CodGrupo });
                Grupo grupoSelected = (Grupo) grupoBindingSource.Current;
                subgrupoBindingSource.DataSource = GerenciadorSubgrupo.GetInstance().ObterPorGrupo(grupoSelected);
                subgrupoBindingSource.Position = subgrupoBindingSource.List.IndexOf(produto.CodSubgrupo);
            }
        }

        private void codProdutoTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }

        private void codProdutoTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
            }
        }

        private void precoVendaAtacadoTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.NumeroCom3CasasDecimais((TextBox)sender);
            codProdutoTextBox_Leave(sender, e);
        }

        private void nomeFabricanteTextBox_Leave(object sender, EventArgs e)
        {
            FormatTextBox.RemoverAcentos((TextBox)sender);
            codProdutoTextBox_Leave(sender, e);
        }

    }
}