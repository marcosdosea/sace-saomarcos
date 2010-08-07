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
    public partial class FrmProdutoPreco : Form
    {
        private EstadoFormulario estado;
        private long? codProduto = null;

        public FrmProdutoPreco()
        {
            InitializeComponent();
        }

        public FrmProdutoPreco(long codProduto)
        {
            InitializeComponent();
            this.codProduto = codProduto;
        }

        private void FrmCalcularPreco_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Funcoes.ATUALIZAÇÃO_PREÇOS, Principal.Autenticacao.CodUsuario);

            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            if (codProduto != null)
                tb_produtoBindingSource.Position = tb_produtoBindingSource.Find("codProduto", codProduto);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            novoPrecoVarejoTextBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            ipiTextBox.Focus();
            habilitaBotoes(false);
            habilitaTextBox(false);
            estado = EstadoFormulario.ATUALIZAR;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.CodProduto = Int32.Parse(codProdutoTextBox.Text);
            produto.Icms = decimal.Parse(icmsTextBox.Text);
            produto.IcmsSubstituto = decimal.Parse(icms_substitutoTextBox.Text);
            produto.Simples = decimal.Parse(simplesTextBox.Text);
            produto.Ipi = decimal.Parse(ipiTextBox.Text);
            produto.Frete = decimal.Parse(freteTextBox.Text);
            produto.CustoVenda = decimal.Parse(textBoxPrecoCusto.Text);
            produto.UltimaDataAtualizacao = DateTime.Now;
            produto.LucroPrecoVendaVarejo = decimal.Parse(lucroPrecoVendaVarejoTextBox.Text);
            produto.PrecoVendaVarejo = decimal.Parse(novoPrecoVarejoTextBox.Text);
            produto.LucroPrecoVendaAtacado = decimal.Parse(lucroPrecoVendaAtacadoTextBox.Text);
            produto.PrecoVendaAtacado = decimal.Parse(novoPrecoAtacadoTextBox.Text);
            produto.LucroPrecoVendaSuperAtacado = decimal.Parse(lucroPrecoVendaSuperAtacadoTextBox.Text);
            produto.PrecoVendaSuperAtacado = decimal.Parse(novoPrecoSuperTextBox.Text);

            GerenciadorProduto.getInstace().atualizarPrecos(produto);
            tb_produtoBindingSource.EndEdit();
            habilitaBotoes(true);
            habilitaTextBox(true);
            btnBuscar.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tb_produtoBindingSource.CancelEdit();
            tb_produtoBindingSource.EndEdit();
            habilitaBotoes(true);
            btnBuscar.Focus();
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnBuscar.Enabled = habilita;
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnAjustar.Enabled = habilita;
            tb_produtoBindingNavigator.Enabled = habilita;
            if (habilita)
            {
                estado = EstadoFormulario.ESPERA;
            }
        }

        private void habilitaTextBox(Boolean habilita)
        {
            ipiTextBox.ReadOnly = habilita;
            ipiTextBox.TabStop = !habilita;
            icmsTextBox.ReadOnly = habilita;
            icmsTextBox.TabStop = !habilita;
            icms_substitutoTextBox.ReadOnly = habilita;
            icms_substitutoTextBox.TabStop = !habilita;
            simplesTextBox.ReadOnly = habilita;
            simplesTextBox.TabStop = !habilita;
            freteTextBox.ReadOnly = habilita;
            freteTextBox.TabStop = !habilita;
            lucroPrecoVendaAtacadoTextBox.ReadOnly = habilita;
            lucroPrecoVendaAtacadoTextBox.TabStop = !habilita;
            lucroPrecoVendaSuperAtacadoTextBox.ReadOnly = habilita;
            lucroPrecoVendaSuperAtacadoTextBox.TabStop = !habilita;
            lucroPrecoVendaVarejoTextBox.ReadOnly = habilita;
            lucroPrecoVendaVarejoTextBox.TabStop = !habilita;
        }

        private void FrmProdutoPreco_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F2)
                {
                    btnBuscar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnEditar_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnAjustar_Click(sender, e);
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
        }

        private void ipiTextBox_TextChanged(object sender, EventArgs e)
        {
            IGerenciadorProduto gProduto = GerenciadorProduto.getInstace();
            decimal precoCompra = (ultimoPrecoCompraTextBox.Text.Trim()=="")?0:decimal.Parse(ultimoPrecoCompraTextBox.Text);
            decimal diferencialICMS = (icmsTextBox.Text.Trim() == "") ? 0 : decimal.Parse(icmsTextBox.Text);
            decimal ICMS_substituto = (icms_substitutoTextBox.Text.Trim() == "") ? 0 : decimal.Parse(icms_substitutoTextBox.Text);
            decimal simples = (simplesTextBox.Text.Trim() == "") ? 0 : decimal.Parse(simplesTextBox.Text);
            decimal frete = (freteTextBox.Text.Trim() == "") ? 0 : decimal.Parse(freteTextBox.Text);
            decimal ipi = (ipiTextBox.Text.Trim() == "") ? 0 : decimal.Parse(ipiTextBox.Text);
            decimal precoCusto = gProduto.calculaPrecoCustoNormal(precoCompra, diferencialICMS, simples, ipi, frete, 0);

        }
    }
}
