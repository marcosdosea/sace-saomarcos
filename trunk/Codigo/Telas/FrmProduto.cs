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

namespace SACE.Telas
{
    public partial class FrmProduto : Form
    {
        public EstadoFormulario estado;

        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Funcoes.PRODUTOS, Principal.Autenticacao.CodUsuario);
            this.tb_cfopTableAdapter.Fill(this.saceDataSet.tb_cfop);
            this.tb_pessoaTableAdapter.FillByTipo(this.saceDataSet.tb_pessoa, Pessoa.PESSOA_JURIDICA);
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
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
            qtdProdutoAtacadoTextBox.Text = "0";
            qtdProdutoSuperAtacadoTextBox.Text = "0";
            habilitaBotoes(false);
            tbcfopBindingSource.MoveFirst();
            cfopComboBox.SelectedIndex = 0;
            tbgrupoBindingSource.MoveFirst();
            codGrupoComboBox.SelectedIndex = 0;
            tb_pessoaBindingSource.MoveFirst();
            codigoFabricanteComboBox.SelectedIndex = 0;
            unidadeTextBox.Text = "UND";
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
                tb_produtoTableAdapter.Delete(long.Parse(codProdutoTextBox.Text));
                tb_produtoTableAdapter.Fill(saceDataSet.tb_produto);
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
            Produto produto = new Produto();
            
            produto.Cfop = int.Parse(cfopComboBox.SelectedValue.ToString());
            produto.CodFabricante = Int32.Parse(codigoFabricanteComboBox.SelectedValue.ToString());
            produto.CodGrupo = Int32.Parse(codGrupoComboBox.SelectedValue.ToString());
            produto.CodigoBarra = codigoBarraTextBox.Text;
            produto.CodProduto = Int32.Parse(codProdutoTextBox.Text);
            produto.CustoVenda = (custoVendaTextBox.Text.Trim()=="")?0:Decimal.Parse(custoVendaTextBox.Text);
            produto.ExibeNaListagem = !exibeNaListagemCheckBox.Checked;
            produto.Frete = (freteTextBox.Text.Trim()=="")?0:Decimal.Parse(freteTextBox.Text);
            produto.Icms = (icmsTextBox.Text.Trim()=="")?0:Decimal.Parse(icmsTextBox.Text);
            produto.IcmsSubstituto = (icms_substitutoTextBox.Text.Trim()=="")?0:Decimal.Parse(icms_substitutoTextBox.Text);
            produto.Ipi = (ipiTextBox.Text.Trim()=="")?0:Decimal.Parse(ipiTextBox.Text);
            produto.LucroPrecoVendaAtacado = (lucroPrecoVendaAtacadoTextBox.Text.Trim()=="")?0:Decimal.Parse(lucroPrecoVendaAtacadoTextBox.Text);
            produto.LucroPrecoVendaSuperAtacado = (lucroPrecoVendaSuperAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(lucroPrecoVendaSuperAtacadoTextBox.Text);
            produto.LucroPrecoVendaVarejo = (lucroPrecoVendaVarejoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(lucroPrecoVendaVarejoTextBox.Text);
            produto.Nome = nomeTextBox.Text.Trim();
            produto.NomeFabricante = nomeFabricanteTextBox.Text.Trim();
            produto.PrecoVendaAtacado = (precoVendaAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(precoVendaAtacadoTextBox.Text.Trim());
            produto.PrecoVendaSuperAtacado = (precoVendaSuperAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(precoVendaSuperAtacadoTextBox.Text.Trim());
            produto.PrecoVendaVarejo = (precoVendaVarejoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(precoVendaVarejoTextBox.Text.Trim());
            produto.QtdProdutoAtacado = (qtdProdutoAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(qtdProdutoAtacadoTextBox.Text.Trim());
            produto.QtdProdutoSuperAtacado = (qtdProdutoSuperAtacadoTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(qtdProdutoSuperAtacadoTextBox.Text.Trim());
            produto.Simples = (simplesTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(simplesTextBox.Text);
            produto.TemVencimento = !temVencimentoCheckBox.Checked;
            produto.UltimaDataAtualizacao = ultimaDataAtualizacaoDateTimePicker.Value;
            produto.UltimoPrecoCompra = (ultimoPrecoCompraTextBox.Text.Trim() == "") ? 0 : Decimal.Parse(ultimoPrecoCompraTextBox.Text);
            produto.Unidade = unidadeTextBox.Text;

            IGerenciadorProduto gProduto = GerenciadorProduto.getInstace();
            if (estado.Equals(EstadoFormulario.INSERIR))
            {
                gProduto.inserir(produto);
                tb_produtoTableAdapter.Fill(saceDataSet.tb_produto);
                tb_produtoBindingSource.MoveLast();
            }
            else
            {
                gProduto.atualizar(produto);
                tb_produtoBindingSource.EndEdit();
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
                        tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoaPesquisa.CodPessoa);
                    }
                    frmPessoaPesquisa.Dispose();
                }
                else if ((e.KeyCode == Keys.F3) && (codigoFabricanteComboBox.Focused))
                {
                    Telas.FrmPessoa frmPessoa = new Telas.FrmPessoa();
                    frmPessoa.ShowDialog();
                    if (frmPessoa.CodPessoa > 0 )
                    {
                        this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
                        tb_pessoaBindingSource.Position = tb_pessoaBindingSource.Find("codPessoa", frmPessoa.CodPessoa);
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
    }
}
