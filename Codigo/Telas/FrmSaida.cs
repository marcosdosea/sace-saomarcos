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
using Dados;
using Util;

namespace Telas
{
    public partial class FrmSaida : Form
    {
        private EstadoFormulario estado;
        private Produto produto;
        private Saida saida;

        public FrmSaida()
        {
            InitializeComponent();
            saida = new Saida();
        }

        private void FrmSaida_Load(object sender, EventArgs e)
        {
            GerenciadorSeguranca.getInstance().verificaPermissao(this, Global.SAIDA, Principal.Autenticacao.CodUsuario);
            this.tb_saidaTableAdapter.Fill(this.saceDataSet.tb_saida);
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            habilitaBotoes(true);
            estado = EstadoFormulario.ESPERA;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Telas.FrmPreVendaPesquisa FrmPreVendaPesquisa = new Telas.FrmPreVendaPesquisa();
            //FrmPreVendaPesquisa.ShowDialog();
            //if (FrmPreVendaPesquisa.getCodGrupo() != -1)
            //{
            //    tb_grupoBindingSource.Position = tb_grupoBindingSource.Find("codGrupo", FrmPreVendaPesquisa.getCodGrupo());
            //}
            //FrmPreVendaPesquisa.Dispose();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            tb_saidaBindingSource.AddNew();

            try
            {
                saida.CodCliente = Global.CLIENTE_PADRAO;
                saida.CodProfissional = Global.PROFISSIONAL_PADRAO;
                saida.DataSaida = DateTime.Now;
                saida.Desconto = 0;
                saida.NumeroCartaoVenda = 0;
                saida.PedidoGerado = null;
                saida.TipoSaida = Global.SAIDA_PRE_VENDA;
                saida.Total = 0;
                saida.TotalLucro = 0;
                saida.TotalPago = 0;
                
                GerenciadorSaida.getInstace().inserir(saida);
                tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
                tb_saidaBindingSource.MoveLast();
            }
            catch (DadosException de)
            {
                tb_saidaBindingSource.CancelEdit();
                throw de;
            }
            codProdutoComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            codProdutoComboBox.Focus();
            habilitaBotoes(false);
            estado = EstadoFormulario.INSERIR_DETALHE;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma exclusão?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorSaida.getInstace().remover(Int32.Parse(codSaidaTextBox.Text));
                tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
                tb_saidaBindingSource.MoveLast(); 
            }
            estado = EstadoFormulario.ESPERA;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if ((tb_saida_produtoDataGridView.RowCount == 0) && (estado.Equals(EstadoFormulario.INSERIR_DETALHE)))
            {
                GerenciadorSaida.getInstace().remover(Int32.Parse(codSaidaTextBox.Text));
                tb_saidaTableAdapter.Fill(saceDataSet.tb_saida);
                tb_saidaBindingSource.MoveLast();
                habilitaBotoes(true);
                estado = EstadoFormulario.ESPERA;
                btnNovo.Focus();
            }
            else if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
            {
                tb_entrada_produtoBindingSource.CancelEdit();
                tb_entrada_produtoBindingSource.EndEdit();
                habilitaBotoes(true);
                estado = EstadoFormulario.ESPERA;
                saida = GerenciadorSaida.getInstace().obterSaida(long.Parse(codSaidaTextBox.Text));
                FrmSaidaPagamento frmSaidaPagamento = new FrmSaidaPagamento(saida);
                frmSaidaPagamento.ShowDialog();
                frmSaidaPagamento.Dispose();
                
                btnNovo.Focus();
            }
            else
            {
                tb_entrada_produtoBindingSource.CancelEdit();
                tb_entrada_produtoBindingSource.EndEdit();
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SaidaProduto saidaProduto = new SaidaProduto();
                saidaProduto.CodProduto = long.Parse(codProdutoTextBox.Text);
                saidaProduto.CodSaida = long.Parse(codSaidaTextBox.Text);
                saidaProduto.Desconto = decimal.Parse(descontoTextBox.Text);
                saidaProduto.Quantidade = decimal.Parse(quantidadeTextBox.Text);
                saidaProduto.Subtotal = decimal.Parse(subtotalTextBox.Text);
                saidaProduto.ValorVenda = decimal.Parse(valorVendaTextBox.Text);
                
                IGerenciadorSaidaProduto gSaidaProduto = GerenciadorSaidaProduto.getInstace();
                if (estado.Equals(EstadoFormulario.INSERIR_DETALHE))
                {
                    gSaidaProduto.inserir(saidaProduto);
                    codSaidaTextBox_TextChanged(sender, e);

                    saida.Total = decimal.Parse(totalAVistaTextBox.Text);
                    saida.CodSaida = long.Parse(codSaidaTextBox.Text);
                    GerenciadorSaida.getInstace().atualizar(saida);

                    tb_saida_produtoBindingSource.MoveLast();
                    codProdutoComboBox.Focus();
                }
            }
            catch (DadosException de)
            {
                tb_saida_produtoBindingSource.CancelEdit();
                throw de;
            }
        }

        private void FrmSaida_KeyDown(object sender, KeyEventArgs e)
        {
            if (estado.Equals(EstadoFormulario.ESPERA))
            {
                if (e.KeyCode == Keys.F3)
                {
                    btnNovo_Click(sender, e);
                } else 
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
                    btnExcluir_Click(sender, e);
                }
                else if (e.KeyCode == Keys.End)
                {
                    tb_saidaBindingSource.MoveLast();
                }
                else if (e.KeyCode == Keys.Home)
                {
                    tb_saidaBindingSource.MoveFirst();
                }
                else if (e.KeyCode == Keys.PageUp)
                {
                    tb_saidaBindingSource.MovePrevious();
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    tb_saidaBindingSource.MoveNext();
                }
            }
            else
            {
                if (e.KeyCode == Keys.F6)
                {
                    btnSalvar_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            // Coloca o foco na grid caso ela não possua
            if (e.KeyCode == Keys.F12)
            {
                tb_saida_produtoDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            if ((e.KeyCode == Keys.Delete) && (tb_saida_produtoDataGridView.Focused == true))
            {
                excluirProduto(sender, e);
            }
        }

        private void excluirProduto(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirma exclusão do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (tb_saida_produtoDataGridView.Rows.Count > 0)
                {
                    long codSaidaProduto = long.Parse(tb_saida_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    Negocio.GerenciadorSaidaProduto.getInstace().remover(codSaidaProduto);
                }
            }
            codSaidaTextBox_TextChanged(sender, e);
        }

        private void habilitaBotoes(Boolean habilita)
        {
            btnSalvar.Enabled = !(habilita);
            btnCancelar.Enabled = !(habilita);
            btnBuscar.Enabled = habilita;
            btnNovo.Enabled = habilita;
            btnEditar.Enabled = habilita;
            btnExcluir.Enabled = habilita;
            tb_saidaBindingNavigator.Enabled = habilita;
        }

        private void codProdutoComboBox_Leave(object sender, EventArgs e)
        {
            if (codProdutoComboBox.SelectedValue == null)
            {
                codProdutoComboBox.Focus();
                throw new TelaException("Um produto válido precisa ser selecionado.");
            }
            if (!codProdutoComboBox.SelectedValue.ToString().Equals(""))
            {
                produto = GerenciadorProduto.getInstace().obterProduto(Int32.Parse(codProdutoComboBox.SelectedValue.ToString()));
                valorVendaTextBox.Text = produto.PrecoVendaVarejoSemDesconto.ToString();
                codProdutoTextBox.Text = produto.CodProduto.ToString();
                descontoTextBox.Text = "0";
            }
            }

        private void quantidadeTextBox_Leave(object sender, EventArgs e)
        {
            decimal quantidade = decimal.Parse(quantidadeTextBox.Text);
            if ((produto.QtdProdutoAtacado != 0) && (quantidade >= produto.QtdProdutoAtacado))
               valorVendaTextBox.Text = produto.PrecoVendaAtacadoSemDesconto.ToString();
            else
               valorVendaTextBox.Text = produto.PrecoVendaVarejoSemDesconto.ToString();

            subtotalTextBox.Text = Math.Round((decimal.Parse(quantidadeTextBox.Text) * decimal.Parse(valorVendaTextBox.Text)), 2).ToString();
        }

        private void codSaidaTextBox_TextChanged(object sender, EventArgs e)
        {
            totalTextBox.Text = "0,00";
            totalAVistaTextBox.Text = "0,00";
            if (!codSaidaTextBox.Text.Trim().Equals("")) {
                tb_saida_produtoTableAdapter.FillByCodSaida(this.saceDataSet.tb_saida_produto, long.Parse(codSaidaTextBox.Text));
                if (tb_saida_produtoDataGridView.RowCount > 0)
                {
                    decimal totalSaida = (decimal)tb_saida_produtoTableAdapter.totalSaida(long.Parse(codSaidaTextBox.Text));
                    totalTextBox.Text = totalSaida.ToString();
                    totalAVistaTextBox.Text = (Math.Round(totalSaida * Global.DESCONTO_PADRAO, 2)).ToString();
                }
            }
        }

        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }
    }
}
