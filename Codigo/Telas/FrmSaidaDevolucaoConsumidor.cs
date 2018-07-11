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
            
            lojaBindingSourceOrigem.DataSource = GerenciadorLoja.GetInstance().ObterTodos();
            pessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().ObterTodos();

            codPessoaComboBoxOrigem.SelectedIndex = 0;
            codPessoaConsumidorComboBox.SelectedIndex = 0;

            int codLoja = ((Loja) codPessoaComboBoxOrigem.SelectedItem).CodLoja;
            cupomFiscalBindingSource.DataSource = GerenciadorSolicitacaoDocumento.GetInstance().ObterDocumentosFiscais();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            saida.CodProfissional = Global.CLIENTE_PADRAO;
            Pessoa consumidor = (Pessoa) codPessoaConsumidorComboBox.SelectedItem;
            
            if (saida.TipoSaida.Equals(Saida.TIPO_PRE_DEVOLUCAO_CONSUMIDOR))
            {
                if (MessageBox.Show("Confirma DEVOLUÇÃO do CONSUMIDOR?", "Confirmar Devolução", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GerenciadorSaida.GetInstance(null).EncerrarDevolucaoConsumidor(saida, consumidor);
                    List<SaidaPedido> listaSaidaPedido = new List<SaidaPedido>();
                    listaSaidaPedido.Add(new SaidaPedido() { CodSaida = saida.CodSaida, TotalAVista = saida.TotalAVista });
                    List<SaidaPagamento> listaSaidaPagamento = new List<SaidaPagamento>();
                    listaSaidaPagamento = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaida(saida.CodSaida);
                    
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
    }
}