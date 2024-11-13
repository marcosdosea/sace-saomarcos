using Negocio;

namespace Sace
{
    public partial class FrmGrupoEstatistica : Form
    {

        public FrmGrupoEstatistica()
        {
            InitializeComponent();
        }


        private void FrmGrupoEstatistica_Load(object sender, EventArgs e)
        {
            grupoBindingSource.DataSource = GerenciadorGrupo.ObterTodos();

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
                long codGrupo = (long)codGrupoComboBox.SelectedValue;

                var vendasPorGrupo = GerenciadorSaida.ObterVendasPorGrupo(codGrupo, dataInicial, dataFinal);

                vendasPorGrupoBindingSource.DataSource = vendasPorGrupo;

                chart1.Series[0].Name = "Qtd Vendidos";
                chart1.Series[0].XValueMember = "MesAno";
                chart1.Series[0].YValueMembers = "TotalVendas";
                chart1.DataBind();
                Cursor.Current = Cursors.Default;
            }
        }
    }
}