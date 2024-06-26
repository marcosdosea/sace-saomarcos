﻿using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmSaidaPesquisa : Form
    {
        public SaidaPesquisa SaidaSelected { get; set; }
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;
        public FrmSaidaPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            SaidaSelected = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmSaidaPesquisa_Load(object sender, EventArgs e)
        {
            saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPreVendasPendentes();
            cmbBusca.SelectedIndex = 1;
         }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (cmbBusca.SelectedIndex == 0)
                {
                    saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPreVendasPendentes();
                }
                else
                    if (cmbBusca.SelectedIndex == 1)
                       saidaBindingSource.DataSource = service.GerenciadorSaida.Obter(long.Parse(txtTexto.Text));
                    else if (cmbBusca.SelectedIndex == 2)
                    {
                        if (txtTexto.Text.Trim().Length >= 5)
                        {
                            saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPorPedido(txtTexto.Text);
                        }
                    }
                    else if (cmbBusca.SelectedIndex == 3)
                    {
                        if (txtTexto.Text.Trim().Length > 3)
                        {

                            saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPorNomeCliente(txtTexto.Text);
                        }
                    } 
                    else if ((cmbBusca.SelectedIndex == 4) && (txtTexto.Text.Trim().Length >= 10))
                    {
                        if (txtTexto.Text.Trim().Length >= 10)
                        {
                            saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPorDataPedido(txtTexto.Text);
                        }
                    }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void tb_saidaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (saidaBindingSource.Count > 0)
            {
                SaidaSelected = (SaidaPesquisa)saidaBindingSource.Current;
            }
            this.Close();
        }

        private void FrmSaidaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_saidaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                saidaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                saidaBindingSource.MovePrevious();
            }
        }        

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
            if (cmbBusca.SelectedIndex == 0)
            {
                saidaBindingSource.DataSource = service.GerenciadorSaida.ObterPreVendasPendentes();
            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                txtTexto.Text = DateTime.Now.Year + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00");
            }
        }
      
    }
}
