using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Data;
using Util;

namespace Sace
{
    public partial class FrmProduto : Form
    {
        public EstadoFormulario estado;
        // Uusado para retornar o produto corrente da view
        public ProdutoPesquisa ProdutoPesquisa { get; set; }
        // Usado para criar um produto a partir de uma Entrada
        private EntradaProduto entradaProduto;
        
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmProduto(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            ProdutoPesquisa = null;
            entradaProduto = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            SaceService service = new SaceService(context);
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
            
            cstBindingSource.DataSource = service.GerenciadorCst.ObterTodos();
            fabricanteBindingSource.DataSource = service.GerenciadorPessoa.ObterTodos();
            grupoBindingSource.DataSource = service.GerenciadorGrupo.ObterTodos();
            subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.ObterPorGrupo((Grupo)grupoBindingSource.Current);
            situacaoprodutoBindingSource.DataSource = service.GerenciadorProduto.ObterSituacoesProduto();
            produtoBindingSource.DataSource = service.GerenciadorProduto.ObterTodos();
            
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
                    service.GerenciadorProduto.ObterPorCodigoBarraExato(entradaProduto.CodigoBarra);
                if (listaProdutosPesquisa.Count() > 0)
                {
                    ProdutoPesquisa _produto = listaProdutosPesquisa.ElementAtOrDefault(0);
                    produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new Produto() { CodProduto = _produto.CodProduto });
                }
                else
                {
                    btnNovo_Click(sender, e);
                    Produto produto = (Produto) produtoBindingSource.Current;
                    service.GerenciadorEntradaProduto.Atribuir(entradaProduto, produto);
                    produtoBindingSource.ResumeBinding();
                    nomeTextBox.Text = entradaProduto.NomeProduto;
                    nomeTextBox.Focus();
                    nomeTextBox.SelectAll();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmProdutoPesquisaPreco frmProdutoPesquisa = new FrmProdutoPesquisaPreco(true, saceOptions);
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
            produto.Simples = UtilConfig.Default.SIMPLES;
            produto.Unidade = "UN";
            produto.UnidadeCompra = "UN";
            produto.QuantidadeEmbalagem = 1;
            produto.ExibeNaListagem = true;
            produto.UltimaDataAtualizacao = DateTime.Now;
            produto.Nome = "";
            produto.NomeProdutoFabricante = "";
            produto.CodigoBarra = "";
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
                service.GerenciadorProduto.Remover(Convert.ToInt64(codProdutoTextBox.Text));
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
                long codProduto = service.GerenciadorProduto.Inserir(produto);
                codProdutoTextBox.Text = codProduto.ToString();
            }
            else
            {
                service.GerenciadorProduto.Atualizar(produto);
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
                    FrmGrupoPesquisa frmGrupoPesquisa = new FrmGrupoPesquisa(saceOptions);
                    frmGrupoPesquisa.ShowDialog();
                    if (frmGrupoPesquisa.SelectedGrupo != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupoPesquisa.SelectedGrupo);
                    }
                    frmGrupoPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codGrupoComboBox.Focused))
                {
                    FrmGrupo frmGrupo = new FrmGrupo(saceOptions);
                    frmGrupo.ShowDialog();
                    if (frmGrupo.GrupoSelected != null)
                    {
                        grupoBindingSource.Position = grupoBindingSource.List.IndexOf(frmGrupo.GrupoSelected);
                    }
                    frmGrupo.Dispose();
                }
                else if ((e.KeyCode == Keys.F2) && (codSubgrupoComboBox.Focused))
                {
                    FrmSubgrupoPesquisa frmSubGrupoPesquisa = new FrmSubgrupoPesquisa(saceOptions);
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
                    FrmSubgrupo frmSubgrupo = new FrmSubgrupo(saceOptions);
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
                    FrmPessoaPesquisa frmPessoaPesquisa = new FrmPessoaPesquisa(Pessoa.PESSOA_JURIDICA);
                    frmPessoaPesquisa.ShowDialog();
                    if (frmPessoaPesquisa.PessoaSelected != null)
                    {
                        fabricanteBindingSource.Position = fabricanteBindingSource.List.IndexOf(frmPessoaPesquisa.PessoaSelected);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFabricanteComboBox.Focused))
                {
                    FrmPessoa frmPessoa = new FrmPessoa(saceOptions);
                    frmPessoa.ShowDialog();
                    if (frmPessoa.PessoaSelected != null)
                    {
                        fabricanteBindingSource.DataSource = service.GerenciadorPessoa.ObterTodos();
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
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codigoFabricanteComboBox, estado, fabricanteBindingSource, true, false, service);
            codProdutoTextBox_Leave(sender, e);
        }

        private void codigoFabricanteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codProdutoTextBox_TextChanged(object sender, EventArgs e)
        {
            if ((codProdutoTextBox.Text != null) && (codProdutoTextBox.Text != ""))
                produtoLojaBindingSource.DataSource = service.GerenciadorProdutoLoja.ObterPorProduto(Convert.ToInt64(codProdutoTextBox.Text));
            
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            ProdutoPesquisa _produtoPesquisa = (ProdutoPesquisa)produtoBindingSource.Current;
            FrmProdutoAjusteEstoque frmAjuste = new FrmProdutoAjusteEstoque(_produtoPesquisa, saceOptions);
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
            FrmPontaEstoque frmPontaEstoque = new FrmPontaEstoque(_produtoPesquisa, saceOptions);
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
                subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.ObterPorGrupo(grupoSelected);
                subgrupoBindingSource.Position = subgrupoBindingSource.List.IndexOf(produto.CodSubgrupo);
            }
        }

        private void codProdutoTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = UtilConfig.Default.BACKCOLOR_FOCUS;
            }
        }

        private void codProdutoTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = UtilConfig.Default.BACKCOLOR_FOCUS_LEAVE;
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