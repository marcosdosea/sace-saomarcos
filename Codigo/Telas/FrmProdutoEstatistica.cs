﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Negocio;
using Dominio;
using Util;
using System.Data;
using Dados;

namespace Telas
{
    public partial class FrmProdutoEstatistica : Form
    {

        private Produto produto;

        public FrmProdutoEstatistica()
        {
            InitializeComponent();
            produto = null;
        }

        public FrmProdutoEstatistica(Produto produto)
        {
            InitializeComponent();
            this.produto = produto;
        }

        public FrmProdutoEstatistica(long codProduto)
        {
            InitializeComponent();
            this.produto = GerenciadorProduto.GetInstance().Obter(new ProdutoPesquisa() { CodProduto = codProduto });
        }


        private void FrmProdutoEstatistica_Load(object sender, EventArgs e)
        {
            //GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.ENTRADA_PRODUTOS, Principal.Autenticacao.CodUsuario);
            produtoBindingSource.DataSource = GerenciadorProduto.GetInstance().ObterTodos();
            //this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto, Global.ACRESCIMO_PADRAO);

            if (produto != null)
            {
                produtoBindingSource.Position = produtoBindingSource.List.IndexOf(produto);
            }

            codProdutoComboBox.SelectAll();
            codProdutoComboBox.Focus();
        }



        private void FrmProdutoEstatistica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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

      

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            EstadoFormulario estado = EstadoFormulario.INSERIR;
            ProdutoPesquisa _produtoPesquisa = ComponentesLeave.ProdutoComboBox_Leave(sender, e, codProdutoComboBox, estado, produtoBindingSource, true);
            
            if (_produtoPesquisa != null)
            {
                preencherDadosEstatisticos(_produtoPesquisa);
                codProdutoComboBox.Focus();
                codProdutoComboBox.SelectAll();
            }
            
        }

        private void preencherDadosEstatisticos(ProdutoPesquisa produtoPesquisa)
        {
            Produto produto = GerenciadorProduto.GetInstance().Obter(produtoPesquisa);
            
            preco_custoTextBox.Text = produto.PrecoCusto.ToString("N2");
            precoVarejoSugestaoTextBox.Text = produto.PrecoVendaVarejoSugestao.ToString("N2");
            precoAtacadoSugestaoTextBox.Text = produto.PrecoVendaAtacadoSugestao.ToString("N2");

            produtoLojaBindingSource.DataSource = GerenciadorProdutoLoja.GetInstance(null).ObterPorProduto(produto.CodProduto);
            this.entradasPorProdutoTableAdapter.FillEntradasByProduto(this.saceDataSetConsultas.EntradasPorProduto, produto.CodProduto);
            this.produtosVendidosTableAdapter.FillQuantidadeProdutosVendidosMesAnoAsc(saceDataSetConsultas.ProdutosVendidos, produto.CodProduto);

            Dados.saceDataSetConsultas.ProdutosVendidosDataTable pVendidosTable = new Dados.saceDataSetConsultas.ProdutosVendidosDataTable();
            pVendidosTable = this.saceDataSetConsultas.ProdutosVendidos;

           chart1.DataSource = produtosVendidosTableAdapterBindingSource;

            chart1.Series[0].Name = "Qtd Vendidos";
            chart1.Series[0].XValueMember = pVendidosTable.mesanoColumn.ToString();
            chart1.EndInit();
            //chart1.Series[0].
            chart1.Series[0].YValueMembers = pVendidosTable.quantidadeVendidaColumn.ToString();

            chart1.DataBind();
            chart1.Visible = true;

            List<ProdutoVendido> produtosVendidos = GerenciadorProdutosVendidos.getInstace().ObterProdutosVendidosDezoitoMeses(produto.CodProduto);

           decimal somaVendidos = 0;
            if (produtosVendidos.Count == 0)
            {
                vendidos3textBox.Text = "0,00";
                vendidos6textBox.Text = "0,00";
                vendidos12textBox.Text = "0,00";
                vendidos18textBox.Text = "0,00";
            }
            
            for (int i = 0; i < produtosVendidos.Count && i < 18; i++)
            {
                ProdutoVendido produtoVendido = produtosVendidos[i];
                somaVendidos += produtoVendido.QuantidadeVendida;
                if (i < 3)
                {
                    vendidos3textBox.Text = somaVendidos.ToString("N2");
                    vendidos6textBox.Text = somaVendidos.ToString("N2");
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else if (i < 6)
                {
                    vendidos6textBox.Text = somaVendidos.ToString("N2");
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else if (i < 12)
                {
                    vendidos12textBox.Text = somaVendidos.ToString("N2");
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
                else
                {
                    vendidos18textBox.Text = somaVendidos.ToString("N2");
                }
            }

        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }
    }
}