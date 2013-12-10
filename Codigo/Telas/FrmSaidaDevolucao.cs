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
using Dados;

namespace Telas
{
    public partial class FrmSaidaDevolucao : Form
    {
        private Saida saida;

        public FrmSaidaDevolucao(Saida saida)
        {
            InitializeComponent();
            this.saida = saida;
        }

        private void FrmSaidaDevolucao_Load(object sender, EventArgs e)
        {
            codSaidaTextBox.Text = saida.CodSaida.ToString();
            entradaBindingSource.DataSource = GerenciadorEntrada.GetInstance().ObterTodos();
            entradaBindingSource.Position = entradaBindingSource.IndexOf(new Entrada() { CodEntrada = saida.CodEntrada });
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance(null).Obter(saida.CodSaida);
            IEnumerable<Pessoa> pessoas = GerenciadorPessoa.GetInstance().ObterTodos();
            pessoaDestinoBindingSource.DataSource = pessoas;
            pessoaFreteBindingSource.DataSource = pessoas;
            pessoaDestinoBindingSource.Position = pessoaDestinoBindingSource.List.IndexOf(new Pessoa() { CodPessoa = saida.CodCliente });
            pessoaFreteBindingSource.Position = pessoaFreteBindingSource.List.IndexOf(new Pessoa() { CodPessoa = saida.CodEmpresaFrete });
        }  

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Entrada entrada = (Entrada)entradaBindingSource.Current;
            saida.CodEntrada = entrada.CodEntrada;
            saida.CodCliente = entrada.CodFornecedor;
            saida.CodEmpresaFrete = Convert.ToInt64( codEmpresaFreteComboBox.SelectedValue.ToString() );
            saida.Desconto = Convert.ToDecimal(descontoTextBox.Text);
            saida.EspecieVolumes = especieVolumesTextBox.Text;
            saida.Marca = marcaTextBox.Text;
            saida.Numero = Convert.ToDecimal(numeroTextBox.Text);
            saida.OutrasDespesas = Convert.ToDecimal(outrasDespesasTextBox.Text);
            saida.PesoBruto = Convert.ToDecimal(pesoBrutoTextBox.Text);
            saida.PesoLiquido = Convert.ToDecimal(pesoLiquidoTextBox.Text);
            saida.QuantidadeVolumes = Convert.ToDecimal(quantidadeVolumesTextBox.Text);
            saida.TotalNotaFiscal = Convert.ToDecimal(totalNotaFiscalTextBox.Text);
            saida.Total = Convert.ToDecimal(totalTextBox.Text);
            saida.TotalAVista = Convert.ToDecimal(totalTextBox.Text);
            saida.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
            saida.ValorICMS = Convert.ToDecimal(valorICMSTextBox.Text);
            saida.ValorICMSSubst = Convert.ToDecimal(valorICMSSubstTextBox.Text);
            saida.ValorIPI = Convert.ToDecimal(valorIPITextBox.Text);
            saida.ValorSeguro = Convert.ToDecimal(valorSeguroTextBox.Text);
            saida.BaseCalculoICMS = Convert.ToDecimal(baseCalculoICMSTextBox.Text);
            saida.BaseCalculoICMSSubst = Convert.ToDecimal(baseCalculoICMSSubstTextBox.Text);
            saida.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
            saida.DataSaida = dataSaidaDateTimePicker.Value;
            saida.TotalLucro = 0;

            if (MessageBox.Show("Confirma Devoulução de Produtos?", "Confirmar Dados da Devolução", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerenciadorSaida.GetInstance(null).Atualizar(saida);
                GerenciadorSaida.GetInstance(null).Encerrar(saida.CodSaida, Saida.TIPO_DEVOLUCAO_FORNECEDOR, null);
            }
            else
            {
                GerenciadorSaida.GetInstance(null).Atualizar(saida);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSaidaDevolucao_KeyDown(object sender, KeyEventArgs e)
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

        private void valorFreteTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            FormatTextBox.NumeroCom2CasasDecimais(textBox);

            if (textBox.Name.Equals("valorFreteTextBox") || textBox.Name.Equals("valorSeguroTextBox") ||
                textBox.Name.Equals("descontoTextBox") || textBox.Name.Equals("outrasDespesasTextBox"))
            {
                saida.ValorFrete = Convert.ToDecimal(valorFreteTextBox.Text);
                saida.ValorSeguro = Convert.ToDecimal(valorSeguroTextBox.Text);
                saida.Desconto = Convert.ToDecimal(descontoTextBox.Text);
                saida.OutrasDespesas = Convert.ToDecimal(outrasDespesasTextBox.Text);

                totalNotaFiscalTextBox.Text = GerenciadorSaida.GetInstance(null).ObterTotalNotaFiscal(saida).ToString("N2");
            }
            codSaidaTextBox_Leave(sender, e);
        }

        private void quantidadeVolumesTextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            FormatTextBox.NumeroCom2CasasDecimais(textBox);
            codSaidaTextBox_Leave(sender, e);
        }

        private void codEmpresaFreteComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void codEmpresaFreteComboBox_Leave(object sender, EventArgs e)
        {
            ComponentesLeave.PessoaComboBox_Leave(sender, e, codEmpresaFreteComboBox, EstadoFormulario.INSERIR, pessoaFreteBindingSource, false);
            codSaidaTextBox_Leave(sender, e);
        }

        private void codSaidaTextBox_Enter(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS;
            }
        }

        private void codSaidaTextBox_Leave(object sender, EventArgs e)
        {
            if ((sender is Control) && !(sender is Form))
            {
                Control control = (Control)sender;
                control.BackColor = Global.BACKCOLOR_FOCUS_LEAVE;
            }
        }

        private void entradaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

       
    }
}