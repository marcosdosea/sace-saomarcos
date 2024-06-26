using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmGrupoEstatistica : Form
    {
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmGrupoEstatistica(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            SaceService service = new SaceService(context); 
        }


        private void FrmGrupoEstatistica_Load(object sender, EventArgs e)
        {
            grupoBindingSource.DataSource = service.GerenciadorGrupo.ObterTodos();

            dataInicioTimePicker.Value = DateTime.Now.AddMonths(-12);
            dataFimTimePicker.Value = DateTime.Now;
            codGrupoComboBox_SelectedIndexChanged(sender, e);
            codGrupoComboBox.SelectAll();
            codGrupoComboBox.Focus();
        }



        private void FrmGrupoEstatistica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

      
        private void codProdutoComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper().ToCharArray()[0];
        }

        private void codGrupoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dataInicial = dataInicioTimePicker.Value;
            DateTime dataFinal = dataFimTimePicker.Value;
            if (codGrupoComboBox.SelectedValue != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                int codGrupo = (int)codGrupoComboBox.SelectedValue;

                var vendasPorGrupo = service.GerenciadorSaida.ObterVendasPorGrupo(codGrupo, dataInicial, dataFinal);

                //saceDataSetConsultas.VendasPorGrupoDataTable vendasgrupoDataTable = new saceDataSetConsultas.VendasPorGrupoDataTable();
                //Dados.saceDataSetConsultasTableAdapters.VendasPorGrupoTableAdapter vendasGrupoTA = new Dados.saceDataSetConsultasTableAdapters.VendasPorGrupoTableAdapter();
                //vendasGrupoTA.FillValorVendidoPorGrupoAnoMes(vendasgrupoDataTable, codGrupo, dataInicial, dataFinal);

                vendasPorGrupoBindingSource.DataSource = vendasPorGrupo;

                chart1.Series[0].Name = "Qtd Vendidos";
                chart1.Series[0].XValueMember = "MesAno";
                chart1.EndInit();
                chart1.Series[0].YValueMembers = "TotalVendas";

                chart1.DataBind();
                chart1.Visible = true;
                Cursor.Current = Cursors.Default;
            }
        }
    }
}