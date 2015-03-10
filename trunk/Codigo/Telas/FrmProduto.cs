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
        // Uusado para retornar o produto corrente da view
        public ProdutoPesquisa ProdutoPesquisa { get; set; }
        // Usado para criar um produto a partir de uma Entrada
        private EntradaProduto entradaProduto;


        public FrmProduto()
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            entradaProduto = null;
        }

        public FrmProduto(EntradaProduto entradaProduto)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            this.entradaProduto = entradaProduto;
        }


        private void FrmProduto_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.PRODUTOS, Principal.Autenticacao.CodUsuario);

            cstBindingSource.DataSource = GerenciadorCst.GetInstance().ObterTodos();
            fabricanteBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
            grupoBindingSource.DataSource = GerenciadorGrupo.GetInstance().ObterTodos();
            subgrupoBindingSource.DataSource = GerenciadorSubgrupo.GetInstance().ObterPorGrupo((Grupo)grupoBindingSource.Current);
            situacaoprodutoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterSituacoesProduto();
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
            
            habilitaBotoes(true);
            InserirEntradaProduto(sender, e);

            Cursor.Current = Cursors.Default;
        }

        private void InserirEntradaProduto(object sender, EventArgs e)
        {
            if (entradaProduto != null)
            {
                IEnumerable<ProdutoPesquisa> listaProdutosPesquisa = new List<ProdutoPesquisa>();
                if (!string.IsNullOrWhiteSpace(entradaProduto.CodigoBarra))
                    GerenciadorProduto.GetInstance().ObterPorCodBarra(entradaProduto.CodigoBarra);
                if (listaProdutosPesquisa.Count() > 0)
                {
                    ProdutoPesquisa _produto = listaProdutosPesquisa.ElementAtOrDefault(0);
                    produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = _produto.CodProduto });
                }
                else
                {
                    btnNovo_Click(sender, e);
                    Produto produto = (Produto) produtoBindingSource.Current;
                    GerenciadorEntradaProduto.GetInstance(null).Atribuir(entradaProduto, produto);
                    produtoBindingSource.ResumeBinding();
                    nomeTextBox.Text = entradaProduto.NomeProduto;
                    nomeTextBox.Focus();
                    nomeTextBox.SelectAll();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmProdutoPesquisaPreco frmProdutoPesquisa = new Telas.FrmProdutoPesquisaPreco(true);
            frmProdutoPesquisa.ShowDialog();
            if (frmProdutoPesquisa.ProdutoPesquisa != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = frmProdutoPesquisa.ProdutoPesquisa.CodProduto } );
                produtoBindingSource.ResumeBinding();
                Produto produto = (Produto) produtoBindingSource.Current;
            }
            frmProdutoPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Produto produto = (Produto) produtoBindingSource.AddNew();
            codProdutoTextBox.Enabled = false;
            nomeTextBox.Focus();
            habilitaBotoes(false);
            produto.CodGrupo = ((Grupo)grupoBindingSource.Current).CodGrupo;
            produto.CodSubgrupo = ((Subgrupo)subgrupoBindingSource.Current).CodSubgrupo;
            produto.CodFabricante = ((Pessoa)fabricanteBindingSource.Current).CodPessoa;
            produto.CodSituacaoProduto = ((SituacaoProduto)situacaoprodutoBindingSource.Current).CodSituacaoProduto;
            produto.CodCST = ((Cst)cstBindingSource.Current).CodCST;
            produto.Simples = Global.SIMPLES;
            produto.Unidade = "UN";
            produto.UnidadeCompra = "UN";
            produto.QuantidadeEmbalagem = 1;
            produto.ExibeNaListagem = true;
            produto.UltimaDataAtualizacao = DateTime.Now;
            produto.Nome = "";
            produto.NomeProdutoFabricante = "";
            produtoBindingSource.ResumeBinding();
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
            produtoBindingSource_CurrentItemChanged(sender, e);
            Produto produto = (Produto) produtoBindingSource.Current;
            
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                long codProduto = GerenciadorProduto.GetInstance().Inserir(produto);
                codProdutoTextBox.Text = codProduto.ToString();
            }
            else
            {
                GerenciadorProduto.GetInstance().Atualizar(produto);
            }
            produtoBindingSource.EndEdit();
            codProdutoTextBox_TextChanged(sender, e);
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
                else if (e.KeyCode == Keys.F8)
                {
                    btnPontaEstoque_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F9)
                {
                    btnEstatistica_Click(sender, e);
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
                        fabricanteBindingSource.Position = fabricanteBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        fabricanteBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();
                        fabricanteBindingSource.Position = fabricanteBindingSource.List.IndexOf(frmPessoa.PessoaSelected);
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
            btnPontaEstoque.Enabled = habilita && (!codProdutoTextBox.Text.Equals(""));
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
                Produto produto = (Produto)produtoBindingSource.Current;
                produto.NomeProdutoFabricante = nomeTextBox.Text; 
            }
            produtoBindingSource.ResumeBinding();
            codProdutoTextBox_Leave(sender, e);
        }

        private void codigoFabricanteComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codigoFabricanteComboBox, estado, fabricanteBindingSource, true);
            codProdutoTextBox_Leave(sender, e);
        }

        private void codigoFabricanteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codProdutoTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((codProdutoTextBox.Text != null) && (codProdutoTextBox.Text != ""))
                produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(Convert.ToInt64(codProdutoTextBox.Text));
            
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            ProdutoPesquisa _produtoPesquisa = (ProdutoPesquisa)produtoBindingSource.Current;
            FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(_produtoPesquisa);
            frmAjuste.ShowDialog();
            frmAjuste.Dispose();
            if (frmAjuste.ProdutoSelected != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = frmAjuste.ProdutoSelected.CodProduto });
            }
            codProdutoTextBox_TextChanged(sender, e);
        }

        private void btnPontaEstoque_Click(object sender, EventArgs e)
        {
            ProdutoPesquisa _produtoPesquisa = (ProdutoPesquisa)produtoBindingSource.Current;
            FrmPontaEstoque frmPontaEstoque = new FrmPontaEstoque(_produtoPesquisa);
            frmPontaEstoque.ShowDialog();
            frmPontaEstoque.Dispose();
            if (frmPontaEstoque.ProdutoSelected != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = frmPontaEstoque.ProdutoSelected.CodProduto });
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
            produtoBindingSource_CurrentItemChanged(sender, e);
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

        private void produtoBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            produtoBindingSource.ResumeBinding();
            //Produto produto = (Produto)produtoBindingSource.Current;
            //if (grupoBindingSource.Current != null)
            //{
                //produto.CodGrupo = ((Grupo)grupoBindingSource.Current).CodGrupo;
                //produto.CodFabricante = ((Pessoa)pessoaBindingSource.Current).CodPessoa;
                //produto.NomeFabricante = ((Pessoa)pessoaBindingSource.Current).NomeFantasia;
                //produto.CodSituacaoProduto = ((SituacaoProduto)situacaoprodutoBindingSource.Current).CodSituacaoProduto;
                //produto.CodCST = ((Cst)cstBindingSource.Current).CodCST;
                //produto.CodSubgrupo = ((Subgrupo)subgrupoBindingSource.Current).CodSubgrupo;
            //}
        }

        private void btnEstatistica_Click(object sender, EventArgs e)
        {
            Produto produto = (Produto) produtoBindingSource.Current;
            FrmProdutoEstatistica frmProdutoEstatistica = new FrmProdutoEstatistica(produto);
            frmProdutoEstatistica.ShowDialog();
            frmProdutoEstatistica.Dispose();
        }
    }
}