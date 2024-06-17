using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dominio;
using Negocio;
using Util;
using System.Windows.Forms;

namespace Telas
{
    public partial class FrmSaidaDevolucaoConsumidor : Form
    {
        private Saida saida;

        public FrmSaidaDevolucaoConsumidor(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
        }

        private void FrmSaidaDevolucaoConsumidor_Load(object sender, EventArgs e)
        {
            codSaidaTextBox.Text = saida.CodSaida.ToString();
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
            saida = (Saida) saidaBindingSource.Current;
            
            lojaBindingSourceOrigem.DataSource = gerenciadorLoja.ObterTodos();
            int codLoja = ((Loja) codPessoaComboBoxOrigem.SelectedItem).CodLoja;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saida.CodProfissional = UtilConfig.Default.CLIENTE_PADRAO;
            saida.CodCliente = ((Saida)saidaCupomBindingSource.Current).CodCliente;
            string docFiscalReferenciado = ((Saida)saidaCupomBindingSource.Current).CupomFiscal;
            //Pessoa consumidor = (Pessoa) codPessoaConsumidorComboBox.SelectedItem;
            
            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR))
            {
                if (MessageBox.Show("Confirma DEVOLUÇÃO do CONSUMIDOR/Fornecedor?", "Confirmar Devolução", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    saida.Nfe = docFiscalReferenciado;
                    GerenciadorSaida.GetInstance(null).EncerrarDevolucaoConsumidor(saida);
                    List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
                    listaSaidaPedido.Add(new SaidaPedido() { CodSaida = saida.CodSaida, TotalAVista = saida.TotalAVista });
                    List<SaidaPagamento> listaSaidaPagamento = new List<SaidaPagamento>();
                    listaSaidaPagamento = gerenciadorSaidaPagamento.ObterPorSaida(saida.CodSaida);
                
                    FrmSaidaNFe frmSaidaNF = new FrmSaidaNFe(saida.CodSaida, listaSaidaPedido, listaSaidaPagamento);
                    frmSaidaNF.ShowDialog();
                    frmSaidaNF.Dispose();
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaDeposito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnBuscar_Click(sender, e);
            }
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Telas.FrmSaidaPesquisa frmSaidaPesquisa = new Telas.FrmSaidaPesquisa();
            frmSaidaPesquisa.ShowDialog();
            if (frmSaidaPesquisa.SaidaSelected != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                saidaCupomBindingSource.DataSource = GerenciadorSaida.GetInstance(null).ObterSaidaConsumidor(frmSaidaPesquisa.SaidaSelected.CodSaida);
                saidaCupomBindingSource.Position = saidaBindingSource.List.IndexOf(frmSaidaPesquisa.SaidaSelected);
                Cursor.Current = Cursors.Default;
            }
            frmSaidaPesquisa.Dispose();
            btnSalvar.Focus();
        }
    }
}