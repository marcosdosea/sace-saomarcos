﻿using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmEntradaImportar : Form
    {
        IEnumerable<EntradaProduto> listaEntradaProduto;
        Entrada entrada;

        public FrmEntradaImportar(Entrada entrada, IEnumerable<EntradaProduto> listaEntradaProduto)
        {
            InitializeComponent();
            this.listaEntradaProduto = listaEntradaProduto;
            this.entrada = entrada;
        }

        private void FrmEntradaImportar_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodosNomes();
            entradaProdutoBindingSource.DataSource = listaEntradaProduto;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            EntradaProduto entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
            entradaProduto.QuantidadeEmbalagem = entradaProduto.QuantidadeEmbalagem == 0 ? 1 : entradaProduto.QuantidadeEmbalagem;
            entradaProduto.QuantidadeDisponivel = entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem;
            GerenciadorEntradaProduto.Inserir(entradaProduto, Entrada.TIPO_ENTRADA);
            entradaProdutoBindingSource.RemoveCurrent();
            codProdutoComboBox.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            ProdutoPesquisa produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, EstadoFormulario.INSERIR_DETALHE, produtoBindingSource, true);
            EntradaProduto entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
            if (produtoPesquisa.CodProduto != 1)
            {
                entradaProduto.QuantidadeEmbalagem = produtoPesquisa.QuantidadeEmbalagem;
                entradaProduto.QtdProdutoAtacado = produtoPesquisa.QtdProdutoAtacado;
                entradaProduto.LucroPrecoRevenda = produtoPesquisa.LucroPrecoRevenda;
                entradaProduto.LucroPrecoVendaAtacado = produtoPesquisa.LucroPrecoVendaAtacado;
                entradaProduto.LucroPrecoVendaVarejo = produtoPesquisa.LucroPrecoVendaVarejo;
                entradaProduto.PrecoVendaVarejo = produtoPesquisa.PrecoVendaVarejo;
                entradaProduto.PrecoVendaAtacado = produtoPesquisa.PrecoVendaAtacado;
                entradaProduto.PrecoRevenda = produtoPesquisa.PrecoRevenda;
                entradaProdutoBindingSource.ResumeBinding();
                entradaProdutoPesquisaBindingSource.DataSource = 
                    GerenciadorEntradaProduto.ObterPorProdutoTipoEntradaFornecedor(produtoPesquisa.CodProduto);
            }
        }


        private void FrmEntradaImportar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F3) && (codProdutoComboBox.Focused))
            {
                FrmProduto frmProduto = new FrmProduto();
                frmProduto.ShowDialog();
                if (frmProduto.ProdutoPesquisa != null)
                {
                    produtoBindingSource.DataSource = GerenciadorProduto.ObterTodosNomes();
                    produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new ProdutoNome() { CodProduto = frmProduto.ProdutoPesquisa.CodProduto });
                }
                frmProduto.Dispose();
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnNovoProduto_Click(sender, e);
            }
            else if (e.KeyCode == Keys.End)
            {
                entradaProdutoBindingSource.MoveLast();
            }
            else if (e.KeyCode == Keys.Home)
            {
                entradaProdutoBindingSource.MoveFirst();
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                entradaProdutoBindingSource.MovePrevious();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                entradaProdutoBindingSource.MoveNext();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (codProdutoComboBox.Focused)
                {
                    codProdutoComboBox_Leave(sender, e);
                }

                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }


        private void entradaProdutoBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            EntradaProduto entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
            if (entradaProduto != null)
            {
                Cst cstProduto = new Cst() { CodCST = entradaProduto.CodCST };
                if (entrada.FretePagoEmitente)
                {
                    entradaProduto.Frete = Math.Round(entrada.ValorFrete / entrada.TotalProdutos * 100, 2);
                }

                if (cstProduto.EhTributacaoIntegral)
                {
                    entradaProduto.IcmsSubstituto = 0;
                }
                else
                {
                    if (cstProduto.EhTributacaoSimples)
                        entradaProduto.IcmsSubstituto = 0;
                    else
                        entradaProduto.IcmsSubstituto = Math.Round(entrada.TotalSubstituicao / entrada.TotalProdutosST * 100, 2);
                }
                Produto produtoCalculo = new Produto()
                {
                    CodCST = entradaProduto.CodCST,
                    Desconto = entradaProduto.Desconto,
                    Icms = entradaProduto.Icms,
                    IcmsSubstituto = entradaProduto.IcmsSubstituto,
                    Ipi = entradaProduto.Ipi,
                    Frete = entradaProduto.Frete,
                    Simples = entradaProduto.Simples,
                    UltimoPrecoCompra = entradaProduto.ValorUnitario,
                    QuantidadeEmbalagem = entradaProduto.QuantidadeEmbalagem
                };

                entradaProduto.PrecoCusto = produtoCalculo.PrecoCusto;
                produtoCalculo.LucroPrecoRevenda = entradaProduto.LucroPrecoRevenda;
                produtoCalculo.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
                produtoCalculo.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;

                entradaProduto.PrecoRevendaSugestao = produtoCalculo.PrecoRevendaSugestao;
                entradaProduto.PrecoVendaAtacadoSugestao = produtoCalculo.PrecoVendaAtacadoSugestao;
                entradaProduto.PrecoVendaVarejoSugestao = produtoCalculo.PrecoVendaVarejoSugestao;
            }
            entradaProdutoBindingSource.ResumeBinding();

        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            EntradaProduto entradaProduto = (EntradaProduto)entradaProdutoBindingSource.Current;
            FrmProduto frmProduto = new FrmProduto(entradaProduto);
            frmProduto.ShowDialog();
            entradaProduto.CodProduto = frmProduto.ProdutoPesquisa.CodProduto;
            entradaProdutoBindingSource.ResumeBinding();
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodosNomes();
            produtoBindingSource.Position = produtoBindingSource.List.IndexOf(new ProdutoNome() { CodProduto = entradaProduto.CodProduto });
            frmProduto.Dispose();
        }
    }

}
