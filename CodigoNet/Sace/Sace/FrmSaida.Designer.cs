namespace Sace
{
    partial class FrmSaida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label codSaidaLabel;
            Label quantidadeLabel;
            Label valorVendaLabel;
            Label dataSaidaLabel;
            Label nomeLabel;
            Label subtotalLabel;
            Label totalLabel;
            Label pedidoGeradoLabel;
            Label label4;
            Label data_validadeLabel;
            Label nomeClienteLabel;
            Label descricaoTipoSaidaLabel;
            Label nfeLabel;
            Label descricaoSituacaoPagamentosLabel;
            Label label5;
            Label baseCalculoICMSLabel;
            Label valorICMSLabel;
            Label baseCalculoICMSSubstLabel;
            Label valorICMSSubstLabel;
            Label valorIPILabel;
            Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaida));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblSaidaProdutos = new Label();
            panel1 = new Panel();
            lblFormaEntrada = new Label();
            pedidoGeradoTextBox = new TextBox();
            saidaBindingSource = new BindingSource(components);
            codSaidaTextBox = new TextBox();
            dataSaidaDateTimePicker = new DateTimePicker();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            tb_saidaBindingNavigator = new BindingNavigator(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            produtoBindingSource = new BindingSource(components);
            quantidadeTextBox = new TextBox();
            precoVendaSemDescontoTextBox = new TextBox();
            subtotalTextBox = new TextBox();
            tb_saida_produtoDataGridView = new DataGridView();
            codSaidaProdutoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Unidade = new DataGridViewTextBoxColumn();
            quantidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorVendaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subtotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subtotalAVistaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            saidaProdutoBindingSource = new BindingSource(components);
            totalTextBox = new TextBox();
            label2 = new Label();
            totalAVistaTextBox = new TextBox();
            btnBuscar = new Button();
            label3 = new Label();
            label6 = new Label();
            codProdutoComboBox = new ComboBox();
            btnEditar = new Button();
            precoVendatextBox = new TextBox();
            data_validadeDateTimePicker = new DateTimePicker();
            nomeClienteTextBox = new TextBox();
            descricaoTipoSaidaTextBox = new TextBox();
            btnEncerrar = new Button();
            nfeTextBox = new TextBox();
            entregaRealizadaCheckBox = new CheckBox();
            descricaoSituacaoPagamentosTextBox = new TextBox();
            btnImprimir = new Button();
            subtotalAVistatextBox = new TextBox();
            lblBalcao = new Label();
            panelBalcao = new Panel();
            btnCfNfe = new Button();
            baseCalculoICMSTextBox = new TextBox();
            valorICMSTextBox = new TextBox();
            baseCalculoICMSSubstTextBox = new TextBox();
            valorICMSSubstTextBox = new TextBox();
            valorIPITextBox = new TextBox();
            lblPreco = new Label();
            labelAtualizarPrecos = new Label();
            VendedorTextBox = new TextBox();
            codSaidaLabel = new Label();
            quantidadeLabel = new Label();
            valorVendaLabel = new Label();
            dataSaidaLabel = new Label();
            nomeLabel = new Label();
            subtotalLabel = new Label();
            totalLabel = new Label();
            pedidoGeradoLabel = new Label();
            label4 = new Label();
            data_validadeLabel = new Label();
            nomeClienteLabel = new Label();
            descricaoTipoSaidaLabel = new Label();
            nfeLabel = new Label();
            descricaoSituacaoPagamentosLabel = new Label();
            label5 = new Label();
            baseCalculoICMSLabel = new Label();
            valorICMSLabel = new Label();
            baseCalculoICMSSubstLabel = new Label();
            valorICMSSubstLabel = new Label();
            valorIPILabel = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)saidaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_saidaBindingNavigator).BeginInit();
            tb_saidaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_saida_produtoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saidaProdutoBindingSource).BeginInit();
            panelBalcao.SuspendLayout();
            SuspendLayout();
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codSaidaLabel.ForeColor = Color.Black;
            codSaidaLabel.Location = new Point(22, 541);
            codSaidaLabel.Margin = new Padding(4, 0, 4, 0);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new Size(62, 20);
            codSaidaLabel.TabIndex = 21;
            codSaidaLabel.Text = "Pedido:";
            // 
            // quantidadeLabel
            // 
            quantidadeLabel.AutoSize = true;
            quantidadeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantidadeLabel.Location = new Point(10, 158);
            quantidadeLabel.Margin = new Padding(4, 0, 4, 0);
            quantidadeLabel.Name = "quantidadeLabel";
            quantidadeLabel.Size = new Size(96, 20);
            quantidadeLabel.TabIndex = 23;
            quantidadeLabel.Text = "Quantidade:";
            // 
            // valorVendaLabel
            // 
            valorVendaLabel.AutoSize = true;
            valorVendaLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valorVendaLabel.Location = new Point(6, 222);
            valorVendaLabel.Margin = new Padding(4, 0, 4, 0);
            valorVendaLabel.Name = "valorVendaLabel";
            valorVendaLabel.Size = new Size(89, 20);
            valorVendaLabel.TabIndex = 25;
            valorVendaLabel.Text = "Preço (R$):";
            // 
            // dataSaidaLabel
            // 
            dataSaidaLabel.AutoSize = true;
            dataSaidaLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataSaidaLabel.ForeColor = Color.Black;
            dataSaidaLabel.Location = new Point(131, 541);
            dataSaidaLabel.Margin = new Padding(4, 0, 4, 0);
            dataSaidaLabel.Name = "dataSaidaLabel";
            dataSaidaLabel.Size = new Size(48, 20);
            dataSaidaLabel.TabIndex = 27;
            dataSaidaLabel.Text = "Data:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nomeLabel.Location = new Point(12, 63);
            nomeLabel.Margin = new Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(69, 20);
            nomeLabel.TabIndex = 29;
            nomeLabel.Text = "Produto:";
            // 
            // subtotalLabel
            // 
            subtotalLabel.AutoSize = true;
            subtotalLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtotalLabel.Location = new Point(10, 287);
            subtotalLabel.Margin = new Padding(4, 0, 4, 0);
            subtotalLabel.Name = "subtotalLabel";
            subtotalLabel.Size = new Size(108, 20);
            subtotalLabel.TabIndex = 30;
            subtotalLabel.Text = "Subtotal (R$):";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalLabel.Location = new Point(774, 561);
            totalLabel.Margin = new Padding(4, 0, 4, 0);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(131, 37);
            totalLabel.TabIndex = 36;
            totalLabel.Text = "TOTAL:";
            // 
            // pedidoGeradoLabel
            // 
            pedidoGeradoLabel.AutoSize = true;
            pedidoGeradoLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pedidoGeradoLabel.ForeColor = Color.Black;
            pedidoGeradoLabel.Location = new Point(570, 541);
            pedidoGeradoLabel.Margin = new Padding(4, 0, 4, 0);
            pedidoGeradoLabel.Name = "pedidoGeradoLabel";
            pedidoGeradoLabel.Size = new Size(76, 20);
            pedidoGeradoLabel.TabIndex = 27;
            pedidoGeradoLabel.Text = "CF / NFe:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 351);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(142, 20);
            label4.TabIndex = 65;
            label4.Text = "Preço à Vista (R$):";
            // 
            // data_validadeLabel
            // 
            data_validadeLabel.AutoSize = true;
            data_validadeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            data_validadeLabel.Location = new Point(20, 475);
            data_validadeLabel.Margin = new Padding(4, 0, 4, 0);
            data_validadeLabel.Name = "data_validadeLabel";
            data_validadeLabel.Size = new Size(114, 20);
            data_validadeLabel.TabIndex = 66;
            data_validadeLabel.Text = "Data Validade:";
            // 
            // nomeClienteLabel
            // 
            nomeClienteLabel.AutoSize = true;
            nomeClienteLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nomeClienteLabel.Location = new Point(22, 602);
            nomeClienteLabel.Margin = new Padding(4, 0, 4, 0);
            nomeClienteLabel.Name = "nomeClienteLabel";
            nomeClienteLabel.Size = new Size(62, 20);
            nomeClienteLabel.TabIndex = 67;
            nomeClienteLabel.Text = "Cliente:";
            // 
            // descricaoTipoSaidaLabel
            // 
            descricaoTipoSaidaLabel.AutoSize = true;
            descricaoTipoSaidaLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descricaoTipoSaidaLabel.ForeColor = Color.Black;
            descricaoTipoSaidaLabel.Location = new Point(407, 541);
            descricaoTipoSaidaLabel.Margin = new Padding(4, 0, 4, 0);
            descricaoTipoSaidaLabel.Name = "descricaoTipoSaidaLabel";
            descricaoTipoSaidaLabel.Size = new Size(39, 20);
            descricaoTipoSaidaLabel.TabIndex = 68;
            descricaoTipoSaidaLabel.Text = "Tipo";
            // 
            // nfeLabel
            // 
            nfeLabel.AutoSize = true;
            nfeLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nfeLabel.ForeColor = Color.Black;
            nfeLabel.Location = new Point(700, 541);
            nfeLabel.Margin = new Padding(4, 0, 4, 0);
            nfeLabel.Name = "nfeLabel";
            nfeLabel.Size = new Size(42, 20);
            nfeLabel.TabIndex = 69;
            nfeLabel.Text = "Doc:";
            // 
            // descricaoSituacaoPagamentosLabel
            // 
            descricaoSituacaoPagamentosLabel.AutoSize = true;
            descricaoSituacaoPagamentosLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descricaoSituacaoPagamentosLabel.Location = new Point(570, 602);
            descricaoSituacaoPagamentosLabel.Margin = new Padding(4, 0, 4, 0);
            descricaoSituacaoPagamentosLabel.Name = "descricaoSituacaoPagamentosLabel";
            descricaoSituacaoPagamentosLabel.Size = new Size(103, 20);
            descricaoSituacaoPagamentosLabel.TabIndex = 71;
            descricaoSituacaoPagamentosLabel.Text = "Pagamentos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 416);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(157, 20);
            label5.TabIndex = 73;
            label5.Text = "Subtotal à Vista(R$):";
            // 
            // baseCalculoICMSLabel
            // 
            baseCalculoICMSLabel.AutoSize = true;
            baseCalculoICMSLabel.Font = new Font("Microsoft Sans Serif", 12F);
            baseCalculoICMSLabel.Location = new Point(224, 482);
            baseCalculoICMSLabel.Margin = new Padding(4, 0, 4, 0);
            baseCalculoICMSLabel.Name = "baseCalculoICMSLabel";
            baseCalculoICMSLabel.Size = new Size(114, 20);
            baseCalculoICMSLabel.TabIndex = 73;
            baseCalculoICMSLabel.Text = "BC ICMS (R$):";
            // 
            // valorICMSLabel
            // 
            valorICMSLabel.AutoSize = true;
            valorICMSLabel.Font = new Font("Microsoft Sans Serif", 12F);
            valorICMSLabel.Location = new Point(405, 482);
            valorICMSLabel.Margin = new Padding(4, 0, 4, 0);
            valorICMSLabel.Name = "valorICMSLabel";
            valorICMSLabel.Size = new Size(129, 20);
            valorICMSLabel.TabIndex = 74;
            valorICMSLabel.Text = "Valor ICMS (R$):";
            // 
            // baseCalculoICMSSubstLabel
            // 
            baseCalculoICMSSubstLabel.AutoSize = true;
            baseCalculoICMSSubstLabel.Font = new Font("Microsoft Sans Serif", 12F);
            baseCalculoICMSSubstLabel.Location = new Point(604, 482);
            baseCalculoICMSSubstLabel.Margin = new Padding(4, 0, 4, 0);
            baseCalculoICMSSubstLabel.Name = "baseCalculoICMSSubstLabel";
            baseCalculoICMSSubstLabel.Size = new Size(160, 20);
            baseCalculoICMSSubstLabel.TabIndex = 75;
            baseCalculoICMSSubstLabel.Text = "BC ICMS Subst (R$):";
            // 
            // valorICMSSubstLabel
            // 
            valorICMSSubstLabel.AutoSize = true;
            valorICMSSubstLabel.Font = new Font("Microsoft Sans Serif", 12F);
            valorICMSSubstLabel.Location = new Point(793, 482);
            valorICMSSubstLabel.Margin = new Padding(4, 0, 4, 0);
            valorICMSSubstLabel.Name = "valorICMSSubstLabel";
            valorICMSSubstLabel.Size = new Size(175, 20);
            valorICMSSubstLabel.TabIndex = 76;
            valorICMSSubstLabel.Text = "Valor ICMS Subst (R$):";
            // 
            // valorIPILabel
            // 
            valorIPILabel.AutoSize = true;
            valorIPILabel.Font = new Font("Microsoft Sans Serif", 12F);
            valorIPILabel.Location = new Point(998, 482);
            valorIPILabel.Margin = new Padding(4, 0, 4, 0);
            valorIPILabel.Name = "valorIPILabel";
            valorIPILabel.Size = new Size(109, 20);
            valorIPILabel.TabIndex = 77;
            valorIPILabel.Text = "Valor IPI (R$):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(267, 541);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 81;
            label1.Text = "Vendedor";
            // 
            // lblSaidaProdutos
            // 
            lblSaidaProdutos.AutoSize = true;
            lblSaidaProdutos.Font = new Font("Comic Sans MS", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSaidaProdutos.ForeColor = SystemColors.ControlLightLight;
            lblSaidaProdutos.Location = new Point(4, 10);
            lblSaidaProdutos.Margin = new Padding(4, 0, 4, 0);
            lblSaidaProdutos.Name = "lblSaidaProdutos";
            lblSaidaProdutos.Size = new Size(230, 26);
            lblSaidaProdutos.TabIndex = 0;
            lblSaidaProdutos.Text = "Orçamentos / Pré-Venda";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(lblFormaEntrada);
            panel1.Controls.Add(lblSaidaProdutos);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1177, 55);
            panel1.TabIndex = 20;
            // 
            // lblFormaEntrada
            // 
            lblFormaEntrada.AutoSize = true;
            lblFormaEntrada.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormaEntrada.ForeColor = Color.Red;
            lblFormaEntrada.Location = new Point(958, 25);
            lblFormaEntrada.Margin = new Padding(4, 0, 4, 0);
            lblFormaEntrada.Name = "lblFormaEntrada";
            lblFormaEntrada.Size = new Size(136, 23);
            lblFormaEntrada.TabIndex = 1;
            lblFormaEntrada.Text = "F1-MANUAL";
            // 
            // pedidoGeradoTextBox
            // 
            pedidoGeradoTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "CupomFiscal", true));
            pedidoGeradoTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pedidoGeradoTextBox.Location = new Point(575, 572);
            pedidoGeradoTextBox.Margin = new Padding(4, 3, 4, 3);
            pedidoGeradoTextBox.Name = "pedidoGeradoTextBox";
            pedidoGeradoTextBox.ReadOnly = true;
            pedidoGeradoTextBox.Size = new Size(122, 26);
            pedidoGeradoTextBox.TabIndex = 60;
            pedidoGeradoTextBox.TabStop = false;
            // 
            // saidaBindingSource
            // 
            saidaBindingSource.AllowNew = true;
            saidaBindingSource.DataSource = typeof(Dominio.Saida);
            saidaBindingSource.Sort = "";
            saidaBindingSource.CurrentItemChanged += saidaBindingSource_CurrentItemChanged;
            // 
            // codSaidaTextBox
            // 
            codSaidaTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "CodSaida", true));
            codSaidaTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codSaidaTextBox.ForeColor = Color.Red;
            codSaidaTextBox.Location = new Point(24, 571);
            codSaidaTextBox.Margin = new Padding(4, 3, 4, 3);
            codSaidaTextBox.Name = "codSaidaTextBox";
            codSaidaTextBox.ReadOnly = true;
            codSaidaTextBox.Size = new Size(101, 26);
            codSaidaTextBox.TabIndex = 54;
            codSaidaTextBox.TabStop = false;
            codSaidaTextBox.TextChanged += codSaidaTextBox_TextChanged;
            codSaidaTextBox.Enter += codSaidaTextBox_Enter;
            codSaidaTextBox.Leave += codSaidaTextBox_Leave;
            // 
            // dataSaidaDateTimePicker
            // 
            dataSaidaDateTimePicker.DataBindings.Add(new Binding("Value", saidaBindingSource, "dataSaida", true));
            dataSaidaDateTimePicker.DataBindings.Add(new Binding("Text", saidaBindingSource, "DataSaida", true));
            dataSaidaDateTimePicker.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataSaidaDateTimePicker.Format = DateTimePickerFormat.Short;
            dataSaidaDateTimePicker.Location = new Point(136, 571);
            dataSaidaDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataSaidaDateTimePicker.Name = "dataSaidaDateTimePicker";
            dataSaidaDateTimePicker.Size = new Size(126, 26);
            dataSaidaDateTimePicker.TabIndex = 56;
            dataSaidaDateTimePicker.TabStop = false;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(346, 675);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(82, 27);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(712, 675);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 27);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(101, 675);
            btnNovo.Margin = new Padding(4, 3, 4, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(82, 27);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(264, 675);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(82, 27);
            btnExcluir.TabIndex = 4;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // tb_saidaBindingNavigator
            // 
            tb_saidaBindingNavigator.AddNewItem = null;
            tb_saidaBindingNavigator.BindingSource = saidaBindingSource;
            tb_saidaBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_saidaBindingNavigator.DeleteItem = null;
            tb_saidaBindingNavigator.Dock = DockStyle.None;
            tb_saidaBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_saidaBindingNavigator.Location = new Point(940, 54);
            tb_saidaBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_saidaBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_saidaBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_saidaBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_saidaBindingNavigator.Name = "tb_saidaBindingNavigator";
            tb_saidaBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_saidaBindingNavigator.Size = new Size(219, 25);
            tb_saidaBindingNavigator.TabIndex = 21;
            tb_saidaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(37, 22);
            bindingNavigatorCountItem.Text = "de {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(23, 22);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(23, 22);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(58, 23);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(23, 22);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(23, 22);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 25);
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.AllowNew = false;
            produtoBindingSource.DataSource = typeof(Dominio.ProdutoPesquisa);
            produtoBindingSource.Sort = "";
            // 
            // quantidadeTextBox
            // 
            quantidadeTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantidadeTextBox.Location = new Point(11, 181);
            quantidadeTextBox.Margin = new Padding(4, 3, 4, 3);
            quantidadeTextBox.Name = "quantidadeTextBox";
            quantidadeTextBox.Size = new Size(196, 29);
            quantidadeTextBox.TabIndex = 32;
            quantidadeTextBox.Enter += quantidadeTextBox_Enter;
            quantidadeTextBox.Leave += quantidadeTextBox_Leave;
            // 
            // precoVendaSemDescontoTextBox
            // 
            precoVendaSemDescontoTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precoVendaSemDescontoTextBox.ForeColor = Color.Red;
            precoVendaSemDescontoTextBox.Location = new Point(11, 245);
            precoVendaSemDescontoTextBox.Margin = new Padding(4, 3, 4, 3);
            precoVendaSemDescontoTextBox.Name = "precoVendaSemDescontoTextBox";
            precoVendaSemDescontoTextBox.ReadOnly = true;
            precoVendaSemDescontoTextBox.Size = new Size(196, 29);
            precoVendaSemDescontoTextBox.TabIndex = 34;
            precoVendaSemDescontoTextBox.TabStop = false;
            // 
            // subtotalTextBox
            // 
            subtotalTextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtotalTextBox.ForeColor = Color.Red;
            subtotalTextBox.Location = new Point(11, 310);
            subtotalTextBox.Margin = new Padding(4, 3, 4, 3);
            subtotalTextBox.Name = "subtotalTextBox";
            subtotalTextBox.ReadOnly = true;
            subtotalTextBox.Size = new Size(196, 29);
            subtotalTextBox.TabIndex = 36;
            subtotalTextBox.TabStop = false;
            // 
            // tb_saida_produtoDataGridView
            // 
            tb_saida_produtoDataGridView.AllowUserToAddRows = false;
            tb_saida_produtoDataGridView.AllowUserToDeleteRows = false;
            tb_saida_produtoDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tb_saida_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tb_saida_produtoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_saida_produtoDataGridView.Columns.AddRange(new DataGridViewColumn[] { codSaidaProdutoDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, Unidade, quantidadeDataGridViewTextBoxColumn, valorVendaDataGridViewTextBoxColumn, subtotalDataGridViewTextBoxColumn, subtotalAVistaDataGridViewTextBoxColumn });
            tb_saida_produtoDataGridView.DataSource = saidaProdutoBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            tb_saida_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            tb_saida_produtoDataGridView.Location = new Point(224, 156);
            tb_saida_produtoDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_saida_produtoDataGridView.MultiSelect = false;
            tb_saida_produtoDataGridView.Name = "tb_saida_produtoDataGridView";
            tb_saida_produtoDataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_saida_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            tb_saida_produtoDataGridView.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tb_saida_produtoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_saida_produtoDataGridView.Size = new Size(952, 378);
            tb_saida_produtoDataGridView.TabIndex = 36;
            tb_saida_produtoDataGridView.TabStop = false;
            tb_saida_produtoDataGridView.Leave += tb_saida_produtoDataGridView_Leave;
            // 
            // codSaidaProdutoDataGridViewTextBoxColumn
            // 
            codSaidaProdutoDataGridViewTextBoxColumn.DataPropertyName = "CodSaidaProduto";
            codSaidaProdutoDataGridViewTextBoxColumn.HeaderText = "CodSaidaProduto";
            codSaidaProdutoDataGridViewTextBoxColumn.Name = "codSaidaProdutoDataGridViewTextBoxColumn";
            codSaidaProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            codSaidaProdutoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Unidade
            // 
            Unidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Unidade.DataPropertyName = "Unidade";
            Unidade.FillWeight = 10F;
            Unidade.HeaderText = "UN";
            Unidade.Name = "Unidade";
            Unidade.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            quantidadeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.FillWeight = 25F;
            quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorVendaDataGridViewTextBoxColumn
            // 
            valorVendaDataGridViewTextBoxColumn.DataPropertyName = "ValorVenda";
            dataGridViewCellStyle2.Format = "C2";
            valorVendaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            valorVendaDataGridViewTextBoxColumn.HeaderText = "Valor (UN)";
            valorVendaDataGridViewTextBoxColumn.Name = "valorVendaDataGridViewTextBoxColumn";
            valorVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            subtotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalAVistaDataGridViewTextBoxColumn
            // 
            subtotalAVistaDataGridViewTextBoxColumn.DataPropertyName = "SubtotalAVista";
            dataGridViewCellStyle4.Format = "C2";
            subtotalAVistaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            subtotalAVistaDataGridViewTextBoxColumn.HeaderText = "À Vista";
            subtotalAVistaDataGridViewTextBoxColumn.Name = "subtotalAVistaDataGridViewTextBoxColumn";
            subtotalAVistaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saidaProdutoBindingSource
            // 
            saidaProdutoBindingSource.DataSource = typeof(Dominio.SaidaProduto);
            // 
            // totalTextBox
            // 
            totalTextBox.BackColor = Color.Blue;
            totalTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "Total", true, DataSourceUpdateMode.OnValidation, null, "N2"));
            totalTextBox.Font = new Font("Microsoft Sans Serif", 28F);
            totalTextBox.ForeColor = Color.Yellow;
            totalTextBox.Location = new Point(934, 553);
            totalTextBox.Margin = new Padding(4, 3, 4, 3);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.ReadOnly = true;
            totalTextBox.Size = new Size(242, 50);
            totalTextBox.TabIndex = 37;
            totalTextBox.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(776, 625);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(129, 37);
            label2.TabIndex = 38;
            label2.Text = "À Vista:";
            // 
            // totalAVistaTextBox
            // 
            totalAVistaTextBox.BackColor = Color.Blue;
            totalAVistaTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "TotalAVista", true, DataSourceUpdateMode.OnValidation, null, "N2"));
            totalAVistaTextBox.Font = new Font("Microsoft Sans Serif", 28F);
            totalAVistaTextBox.ForeColor = Color.Yellow;
            totalAVistaTextBox.Location = new Point(934, 617);
            totalAVistaTextBox.Margin = new Padding(4, 3, 4, 3);
            totalAVistaTextBox.Name = "totalAVistaTextBox";
            totalAVistaTextBox.ReadOnly = true;
            totalAVistaTextBox.Size = new Size(242, 50);
            totalAVistaTextBox.TabIndex = 39;
            totalAVistaTextBox.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(18, 675);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(82, 27);
            btnBuscar.TabIndex = 10;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11F);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(1054, 135);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 18);
            label3.TabIndex = 63;
            label3.Text = "DEL - Excluir";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(922, 135);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(101, 18);
            label6.TabIndex = 62;
            label6.Text = "F12 - Navegar";
            // 
            // codProdutoComboBox
            // 
            codProdutoComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codProdutoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codProdutoComboBox.BackColor = SystemColors.Window;
            codProdutoComboBox.CausesValidation = false;
            codProdutoComboBox.DataSource = produtoBindingSource;
            codProdutoComboBox.DisplayMember = "nome";
            codProdutoComboBox.FlatStyle = FlatStyle.System;
            codProdutoComboBox.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codProdutoComboBox.FormattingEnabled = true;
            codProdutoComboBox.ImeMode = ImeMode.NoControl;
            codProdutoComboBox.IntegralHeight = false;
            codProdutoComboBox.ItemHeight = 31;
            codProdutoComboBox.Location = new Point(14, 89);
            codProdutoComboBox.Margin = new Padding(4, 3, 4, 3);
            codProdutoComboBox.MaxDropDownItems = 5;
            codProdutoComboBox.Name = "codProdutoComboBox";
            codProdutoComboBox.Size = new Size(1151, 39);
            codProdutoComboBox.TabIndex = 30;
            codProdutoComboBox.ValueMember = "codProduto";
            codProdutoComboBox.Enter += codSaidaTextBox_Enter;
            codProdutoComboBox.KeyPress += codProdutoComboBox_KeyPress;
            codProdutoComboBox.Leave += codProdutoComboBox_Leave;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(183, 675);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(82, 27);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // precoVendatextBox
            // 
            precoVendatextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precoVendatextBox.Location = new Point(11, 374);
            precoVendatextBox.Margin = new Padding(4, 3, 4, 3);
            precoVendatextBox.Name = "precoVendatextBox";
            precoVendatextBox.Size = new Size(196, 29);
            precoVendatextBox.TabIndex = 38;
            precoVendatextBox.Enter += codSaidaTextBox_Enter;
            precoVendatextBox.Leave += precoVendatextBox_Leave;
            // 
            // data_validadeDateTimePicker
            // 
            data_validadeDateTimePicker.Enabled = false;
            data_validadeDateTimePicker.Font = new Font("Microsoft Sans Serif", 14F);
            data_validadeDateTimePicker.Format = DateTimePickerFormat.Short;
            data_validadeDateTimePicker.Location = new Point(23, 504);
            data_validadeDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            data_validadeDateTimePicker.Name = "data_validadeDateTimePicker";
            data_validadeDateTimePicker.Size = new Size(187, 29);
            data_validadeDateTimePicker.TabIndex = 42;
            data_validadeDateTimePicker.Enter += codSaidaTextBox_Enter;
            data_validadeDateTimePicker.Leave += data_validadeDateTimePicker_Leave;
            // 
            // nomeClienteTextBox
            // 
            nomeClienteTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "NomeCliente", true));
            nomeClienteTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nomeClienteTextBox.Location = new Point(26, 630);
            nomeClienteTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeClienteTextBox.Name = "nomeClienteTextBox";
            nomeClienteTextBox.ReadOnly = true;
            nomeClienteTextBox.Size = new Size(536, 26);
            nomeClienteTextBox.TabIndex = 64;
            nomeClienteTextBox.TabStop = false;
            // 
            // descricaoTipoSaidaTextBox
            // 
            descricaoTipoSaidaTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "DescricaoTipoSaida", true));
            descricaoTipoSaidaTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descricaoTipoSaidaTextBox.Location = new Point(411, 571);
            descricaoTipoSaidaTextBox.Margin = new Padding(4, 3, 4, 3);
            descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            descricaoTipoSaidaTextBox.ReadOnly = true;
            descricaoTipoSaidaTextBox.Size = new Size(151, 26);
            descricaoTipoSaidaTextBox.TabIndex = 58;
            descricaoTipoSaidaTextBox.TabStop = false;
            // 
            // btnEncerrar
            // 
            btnEncerrar.Location = new Point(428, 675);
            btnEncerrar.Margin = new Padding(4, 3, 4, 3);
            btnEncerrar.Name = "btnEncerrar";
            btnEncerrar.Size = new Size(91, 27);
            btnEncerrar.TabIndex = 6;
            btnEncerrar.Text = "F7 - Encerrar";
            btnEncerrar.UseVisualStyleBackColor = true;
            btnEncerrar.Click += btnEncerrar_Click;
            // 
            // nfeTextBox
            // 
            nfeTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "Nfe", true));
            nfeTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nfeTextBox.Location = new Point(704, 573);
            nfeTextBox.Margin = new Padding(4, 3, 4, 3);
            nfeTextBox.Name = "nfeTextBox";
            nfeTextBox.ReadOnly = true;
            nfeTextBox.Size = new Size(58, 26);
            nfeTextBox.TabIndex = 62;
            nfeTextBox.TabStop = false;
            // 
            // entregaRealizadaCheckBox
            // 
            entregaRealizadaCheckBox.Checked = true;
            entregaRealizadaCheckBox.CheckState = CheckState.Checked;
            entregaRealizadaCheckBox.DataBindings.Add(new Binding("CheckState", saidaBindingSource, "entregaRealizada", true));
            entregaRealizadaCheckBox.Location = new Point(224, 129);
            entregaRealizadaCheckBox.Margin = new Padding(4, 3, 4, 3);
            entregaRealizadaCheckBox.Name = "entregaRealizadaCheckBox";
            entregaRealizadaCheckBox.Size = new Size(121, 28);
            entregaRealizadaCheckBox.TabIndex = 71;
            entregaRealizadaCheckBox.TabStop = false;
            entregaRealizadaCheckBox.Text = "Entregue";
            entregaRealizadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // descricaoSituacaoPagamentosTextBox
            // 
            descricaoSituacaoPagamentosTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "DescricaoSituacaoPagamentos", true));
            descricaoSituacaoPagamentosTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descricaoSituacaoPagamentosTextBox.Location = new Point(575, 630);
            descricaoSituacaoPagamentosTextBox.Margin = new Padding(4, 3, 4, 3);
            descricaoSituacaoPagamentosTextBox.Name = "descricaoSituacaoPagamentosTextBox";
            descricaoSituacaoPagamentosTextBox.ReadOnly = true;
            descricaoSituacaoPagamentosTextBox.Size = new Size(191, 26);
            descricaoSituacaoPagamentosTextBox.TabIndex = 66;
            descricaoSituacaoPagamentosTextBox.TabStop = false;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(519, 675);
            btnImprimir.Margin = new Padding(4, 3, 4, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(91, 27);
            btnImprimir.TabIndex = 7;
            btnImprimir.Text = "F8 - Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // subtotalAVistatextBox
            // 
            subtotalAVistatextBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtotalAVistatextBox.ForeColor = Color.FromArgb(192, 0, 0);
            subtotalAVistatextBox.Location = new Point(14, 439);
            subtotalAVistatextBox.Margin = new Padding(4, 3, 4, 3);
            subtotalAVistatextBox.Name = "subtotalAVistatextBox";
            subtotalAVistatextBox.ReadOnly = true;
            subtotalAVistatextBox.Size = new Size(196, 29);
            subtotalAVistatextBox.TabIndex = 40;
            subtotalAVistatextBox.TabStop = false;
            // 
            // lblBalcao
            // 
            lblBalcao.AutoSize = true;
            lblBalcao.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalcao.ForeColor = Color.Red;
            lblBalcao.Location = new Point(354, 9);
            lblBalcao.Margin = new Padding(4, 0, 4, 0);
            lblBalcao.Name = "lblBalcao";
            lblBalcao.Size = new Size(397, 73);
            lblBalcao.TabIndex = 0;
            lblBalcao.Text = "Balcão Livre";
            // 
            // panelBalcao
            // 
            panelBalcao.Controls.Add(lblBalcao);
            panelBalcao.Location = new Point(-1, 54);
            panelBalcao.Margin = new Padding(4, 3, 4, 3);
            panelBalcao.Name = "panelBalcao";
            panelBalcao.Size = new Size(1177, 103);
            panelBalcao.TabIndex = 72;
            // 
            // btnCfNfe
            // 
            btnCfNfe.Location = new Point(610, 675);
            btnCfNfe.Margin = new Padding(4, 3, 4, 3);
            btnCfNfe.Name = "btnCfNfe";
            btnCfNfe.Size = new Size(103, 27);
            btnCfNfe.TabIndex = 8;
            btnCfNfe.Text = "F9 -NFe/NFCe";
            btnCfNfe.UseVisualStyleBackColor = true;
            btnCfNfe.Click += btnCfNfe_Click;
            // 
            // baseCalculoICMSTextBox
            // 
            baseCalculoICMSTextBox.Font = new Font("Microsoft Sans Serif", 14F);
            baseCalculoICMSTextBox.Location = new Point(224, 505);
            baseCalculoICMSTextBox.Margin = new Padding(4, 3, 4, 3);
            baseCalculoICMSTextBox.Name = "baseCalculoICMSTextBox";
            baseCalculoICMSTextBox.ReadOnly = true;
            baseCalculoICMSTextBox.Size = new Size(157, 29);
            baseCalculoICMSTextBox.TabIndex = 44;
            baseCalculoICMSTextBox.TabStop = false;
            baseCalculoICMSTextBox.Leave += baseCalculoICMSTextBox_Leave;
            // 
            // valorICMSTextBox
            // 
            valorICMSTextBox.Font = new Font("Microsoft Sans Serif", 14F);
            valorICMSTextBox.Location = new Point(405, 505);
            valorICMSTextBox.Margin = new Padding(4, 3, 4, 3);
            valorICMSTextBox.Name = "valorICMSTextBox";
            valorICMSTextBox.ReadOnly = true;
            valorICMSTextBox.Size = new Size(182, 29);
            valorICMSTextBox.TabIndex = 46;
            valorICMSTextBox.TabStop = false;
            valorICMSTextBox.Leave += valorICMSSubstTextBox_Leave;
            // 
            // baseCalculoICMSSubstTextBox
            // 
            baseCalculoICMSSubstTextBox.Font = new Font("Microsoft Sans Serif", 14F);
            baseCalculoICMSSubstTextBox.Location = new Point(604, 504);
            baseCalculoICMSSubstTextBox.Margin = new Padding(4, 3, 4, 3);
            baseCalculoICMSSubstTextBox.Name = "baseCalculoICMSSubstTextBox";
            baseCalculoICMSSubstTextBox.ReadOnly = true;
            baseCalculoICMSSubstTextBox.Size = new Size(160, 29);
            baseCalculoICMSSubstTextBox.TabIndex = 48;
            baseCalculoICMSSubstTextBox.TabStop = false;
            baseCalculoICMSSubstTextBox.Leave += valorICMSSubstTextBox_Leave;
            // 
            // valorICMSSubstTextBox
            // 
            valorICMSSubstTextBox.Font = new Font("Microsoft Sans Serif", 14F);
            valorICMSSubstTextBox.Location = new Point(798, 504);
            valorICMSSubstTextBox.Margin = new Padding(4, 3, 4, 3);
            valorICMSSubstTextBox.Name = "valorICMSSubstTextBox";
            valorICMSSubstTextBox.ReadOnly = true;
            valorICMSSubstTextBox.Size = new Size(170, 29);
            valorICMSSubstTextBox.TabIndex = 50;
            valorICMSSubstTextBox.TabStop = false;
            valorICMSSubstTextBox.Leave += valorICMSSubstTextBox_Leave;
            // 
            // valorIPITextBox
            // 
            valorIPITextBox.Font = new Font("Microsoft Sans Serif", 14F);
            valorIPITextBox.Location = new Point(998, 505);
            valorIPITextBox.Margin = new Padding(4, 3, 4, 3);
            valorIPITextBox.Name = "valorIPITextBox";
            valorIPITextBox.ReadOnly = true;
            valorIPITextBox.Size = new Size(165, 29);
            valorIPITextBox.TabIndex = 52;
            valorIPITextBox.TabStop = false;
            valorIPITextBox.Leave += valorICMSSubstTextBox_Leave;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Microsoft Sans Serif", 11F);
            lblPreco.ForeColor = Color.Red;
            lblPreco.Location = new Point(710, 135);
            lblPreco.Margin = new Padding(4, 0, 4, 0);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(165, 18);
            lblPreco.TabIndex = 78;
            lblPreco.Text = "CTRL+P - Preço Varejo";
            // 
            // labelAtualizarPrecos
            // 
            labelAtualizarPrecos.AutoSize = true;
            labelAtualizarPrecos.Font = new Font("Microsoft Sans Serif", 11F);
            labelAtualizarPrecos.ForeColor = Color.Red;
            labelAtualizarPrecos.Location = new Point(389, 136);
            labelAtualizarPrecos.Margin = new Padding(4, 0, 4, 0);
            labelAtualizarPrecos.Name = "labelAtualizarPrecos";
            labelAtualizarPrecos.Size = new Size(267, 18);
            labelAtualizarPrecos.TabIndex = 79;
            labelAtualizarPrecos.Text = "CTRL+A - Atualizar com Preços do Dia";
            // 
            // VendedorTextBox
            // 
            VendedorTextBox.DataBindings.Add(new Binding("Text", saidaBindingSource, "LoginVendedor", true));
            VendedorTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            VendedorTextBox.Location = new Point(270, 571);
            VendedorTextBox.Margin = new Padding(4, 3, 4, 3);
            VendedorTextBox.Name = "VendedorTextBox";
            VendedorTextBox.ReadOnly = true;
            VendedorTextBox.Size = new Size(131, 26);
            VendedorTextBox.TabIndex = 80;
            VendedorTextBox.TabStop = false;
            // 
            // FrmSaida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 753);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(VendedorTextBox);
            Controls.Add(tb_saida_produtoDataGridView);
            Controls.Add(valorIPILabel);
            Controls.Add(valorIPITextBox);
            Controls.Add(valorICMSSubstLabel);
            Controls.Add(valorICMSSubstTextBox);
            Controls.Add(baseCalculoICMSSubstLabel);
            Controls.Add(baseCalculoICMSSubstTextBox);
            Controls.Add(valorICMSLabel);
            Controls.Add(valorICMSTextBox);
            Controls.Add(baseCalculoICMSLabel);
            Controls.Add(baseCalculoICMSTextBox);
            Controls.Add(btnCfNfe);
            Controls.Add(panelBalcao);
            Controls.Add(label5);
            Controls.Add(subtotalAVistatextBox);
            Controls.Add(btnImprimir);
            Controls.Add(descricaoSituacaoPagamentosLabel);
            Controls.Add(descricaoSituacaoPagamentosTextBox);
            Controls.Add(nfeLabel);
            Controls.Add(nfeTextBox);
            Controls.Add(btnCancelar);
            Controls.Add(btnEncerrar);
            Controls.Add(descricaoTipoSaidaLabel);
            Controls.Add(descricaoTipoSaidaTextBox);
            Controls.Add(nomeClienteLabel);
            Controls.Add(nomeClienteTextBox);
            Controls.Add(data_validadeLabel);
            Controls.Add(data_validadeDateTimePicker);
            Controls.Add(pedidoGeradoLabel);
            Controls.Add(label4);
            Controls.Add(pedidoGeradoTextBox);
            Controls.Add(precoVendatextBox);
            Controls.Add(codSaidaTextBox);
            Controls.Add(btnEditar);
            Controls.Add(codSaidaLabel);
            Controls.Add(dataSaidaDateTimePicker);
            Controls.Add(dataSaidaLabel);
            Controls.Add(codProdutoComboBox);
            Controls.Add(btnBuscar);
            Controls.Add(totalAVistaTextBox);
            Controls.Add(label2);
            Controls.Add(totalLabel);
            Controls.Add(totalTextBox);
            Controls.Add(subtotalLabel);
            Controls.Add(subtotalTextBox);
            Controls.Add(nomeLabel);
            Controls.Add(valorVendaLabel);
            Controls.Add(precoVendaSemDescontoTextBox);
            Controls.Add(quantidadeLabel);
            Controls.Add(quantidadeTextBox);
            Controls.Add(tb_saidaBindingNavigator);
            Controls.Add(btnSalvar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(panel1);
            Controls.Add(entregaRealizadaCheckBox);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(lblPreco);
            Controls.Add(labelAtualizarPrecos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSaida";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Saída de Produtos";
            Load += FrmSaida_Load;
            KeyDown += FrmSaida_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)saidaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_saidaBindingNavigator).EndInit();
            tb_saidaBindingNavigator.ResumeLayout(false);
            tb_saidaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_saida_produtoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)saidaProdutoBindingSource).EndInit();
            panelBalcao.ResumeLayout(false);
            panelBalcao.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSaidaProdutos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.BindingSource saidaBindingSource;
        private System.Windows.Forms.BindingNavigator tb_saidaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.TextBox quantidadeTextBox;
        private System.Windows.Forms.TextBox precoVendaSemDescontoTextBox;
        private System.Windows.Forms.DateTimePicker dataSaidaDateTimePicker;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.DataGridView tb_saida_produtoDataGridView;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalAVistaTextBox;
        private System.Windows.Forms.TextBox pedidoGeradoTextBox;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox precoVendatextBox;
        private System.Windows.Forms.DateTimePicker data_validadeDateTimePicker;
        private System.Windows.Forms.TextBox nomeClienteTextBox;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.BindingSource saidaProdutoBindingSource;
        private System.Windows.Forms.TextBox nfeTextBox;
        private System.Windows.Forms.CheckBox entregaRealizadaCheckBox;
        private System.Windows.Forms.TextBox descricaoSituacaoPagamentosTextBox;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox subtotalAVistatextBox;
        private System.Windows.Forms.Label lblBalcao;
        private System.Windows.Forms.Panel panelBalcao;
        private System.Windows.Forms.Button btnCfNfe;
        private System.Windows.Forms.Label lblFormaEntrada;
        private System.Windows.Forms.TextBox baseCalculoICMSTextBox;
        private System.Windows.Forms.TextBox valorICMSTextBox;
        private System.Windows.Forms.TextBox baseCalculoICMSSubstTextBox;
        private System.Windows.Forms.TextBox valorICMSSubstTextBox;
        private System.Windows.Forms.TextBox valorIPITextBox;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label labelAtualizarPrecos;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalAVistaDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox VendedorTextBox;
    }
}