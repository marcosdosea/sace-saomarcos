namespace Telas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codSaidaLabel;
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label quantidadeLabel;
            System.Windows.Forms.Label valorVendaLabel;
            System.Windows.Forms.Label dataSaidaLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label subtotalLabel;
            System.Windows.Forms.Label totalLabel;
            System.Windows.Forms.Label pedidoGeradoLabel;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label data_validadeLabel;
            System.Windows.Forms.Label nomeClienteLabel;
            System.Windows.Forms.Label descricaoTipoSaidaLabel;
            System.Windows.Forms.Label nfeLabel;
            System.Windows.Forms.Label descricaoSituacaoPagamentosLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaida));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pedidoGeradoTextBox = new System.Windows.Forms.TextBox();
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.dataSaidaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.tb_saidaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaSemDescontoTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.tb_saida_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.codSaidaProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalAVistaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavalidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbsaidaprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalAVistaTextBox = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.codProdutoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.tb_saida_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_saida_produtoTableAdapter();
            this.btnEditar = new System.Windows.Forms.Button();
            this.precoVendatextBox = new System.Windows.Forms.TextBox();
            this.data_validadeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nomeClienteTextBox = new System.Windows.Forms.TextBox();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.nfeTextBox = new System.Windows.Forms.TextBox();
            this.entregaRealizadaCheckBox = new System.Windows.Forms.CheckBox();
            this.descricaoSituacaoPagamentosTextBox = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            codSaidaLabel = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            quantidadeLabel = new System.Windows.Forms.Label();
            valorVendaLabel = new System.Windows.Forms.Label();
            dataSaidaLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            subtotalLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            pedidoGeradoLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            data_validadeLabel = new System.Windows.Forms.Label();
            nomeClienteLabel = new System.Windows.Forms.Label();
            descricaoTipoSaidaLabel = new System.Windows.Forms.Label();
            nfeLabel = new System.Windows.Forms.Label();
            descricaoSituacaoPagamentosLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingNavigator)).BeginInit();
            this.tb_saidaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsaidaprodutoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            codSaidaLabel.Location = new System.Drawing.Point(309, 428);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(85, 17);
            codSaidaLabel.TabIndex = 21;
            codSaidaLabel.Text = "Cod Pedido:";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codProdutoLabel.Location = new System.Drawing.Point(4, 57);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(91, 17);
            codProdutoLabel.TabIndex = 22;
            codProdutoLabel.Text = "Cod Produto:";
            // 
            // quantidadeLabel
            // 
            quantidadeLabel.AutoSize = true;
            quantidadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            quantidadeLabel.Location = new System.Drawing.Point(9, 116);
            quantidadeLabel.Name = "quantidadeLabel";
            quantidadeLabel.Size = new System.Drawing.Size(86, 17);
            quantidadeLabel.TabIndex = 23;
            quantidadeLabel.Text = "Quantidade:";
            // 
            // valorVendaLabel
            // 
            valorVendaLabel.AutoSize = true;
            valorVendaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valorVendaLabel.Location = new System.Drawing.Point(14, 187);
            valorVendaLabel.Name = "valorVendaLabel";
            valorVendaLabel.Size = new System.Drawing.Size(81, 17);
            valorVendaLabel.TabIndex = 25;
            valorVendaLabel.Text = "Preço (R$):";
            // 
            // dataSaidaLabel
            // 
            dataSaidaLabel.AutoSize = true;
            dataSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataSaidaLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataSaidaLabel.Location = new System.Drawing.Point(191, 429);
            dataSaidaLabel.Name = "dataSaidaLabel";
            dataSaidaLabel.Size = new System.Drawing.Size(42, 17);
            dataSaidaLabel.TabIndex = 27;
            dataSaidaLabel.Text = "Data:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeLabel.Location = new System.Drawing.Point(191, 57);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(62, 17);
            nomeLabel.TabIndex = 29;
            nomeLabel.Text = "Produto:";
            // 
            // subtotalLabel
            // 
            subtotalLabel.AutoSize = true;
            subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            subtotalLabel.Location = new System.Drawing.Point(14, 299);
            subtotalLabel.Name = "subtotalLabel";
            subtotalLabel.Size = new System.Drawing.Size(108, 20);
            subtotalLabel.TabIndex = 30;
            subtotalLabel.Text = "Subtotal (R$):";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            totalLabel.Location = new System.Drawing.Point(604, 438);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(131, 37);
            totalLabel.TabIndex = 36;
            totalLabel.Text = "TOTAL:";
            // 
            // pedidoGeradoLabel
            // 
            pedidoGeradoLabel.AutoSize = true;
            pedidoGeradoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pedidoGeradoLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            pedidoGeradoLabel.Location = new System.Drawing.Point(400, 429);
            pedidoGeradoLabel.Name = "pedidoGeradoLabel";
            pedidoGeradoLabel.Size = new System.Drawing.Size(29, 17);
            pedidoGeradoLabel.TabIndex = 27;
            pedidoGeradoLabel.Text = "CF:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(14, 247);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(128, 17);
            label4.TabIndex = 65;
            label4.Text = "Preço à Vista (R$):";
            // 
            // data_validadeLabel
            // 
            data_validadeLabel.AutoSize = true;
            data_validadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            data_validadeLabel.Location = new System.Drawing.Point(14, 371);
            data_validadeLabel.Name = "data_validadeLabel";
            data_validadeLabel.Size = new System.Drawing.Size(101, 17);
            data_validadeLabel.TabIndex = 66;
            data_validadeLabel.Text = "Data Validade:";
            // 
            // nomeClienteLabel
            // 
            nomeClienteLabel.AutoSize = true;
            nomeClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeClienteLabel.Location = new System.Drawing.Point(15, 484);
            nomeClienteLabel.Name = "nomeClienteLabel";
            nomeClienteLabel.Size = new System.Drawing.Size(55, 17);
            nomeClienteLabel.TabIndex = 67;
            nomeClienteLabel.Text = "Cliente:";
            // 
            // descricaoTipoSaidaLabel
            // 
            descricaoTipoSaidaLabel.AutoSize = true;
            descricaoTipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descricaoTipoSaidaLabel.Location = new System.Drawing.Point(14, 431);
            descricaoTipoSaidaLabel.Name = "descricaoTipoSaidaLabel";
            descricaoTipoSaidaLabel.Size = new System.Drawing.Size(36, 17);
            descricaoTipoSaidaLabel.TabIndex = 68;
            descricaoTipoSaidaLabel.Text = "Tipo";
            descricaoTipoSaidaLabel.Click += new System.EventHandler(this.descricaoTipoSaidaLabel_Click);
            // 
            // nfeLabel
            // 
            nfeLabel.AutoSize = true;
            nfeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            nfeLabel.Location = new System.Drawing.Point(481, 429);
            nfeLabel.Name = "nfeLabel";
            nfeLabel.Size = new System.Drawing.Size(34, 17);
            nfeLabel.TabIndex = 69;
            nfeLabel.Text = "Nfe:";
            // 
            // descricaoSituacaoPagamentosLabel
            // 
            descricaoSituacaoPagamentosLabel.AutoSize = true;
            descricaoSituacaoPagamentosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            descricaoSituacaoPagamentosLabel.Location = new System.Drawing.Point(481, 484);
            descricaoSituacaoPagamentosLabel.Name = "descricaoSituacaoPagamentosLabel";
            descricaoSituacaoPagamentosLabel.Size = new System.Drawing.Size(91, 17);
            descricaoSituacaoPagamentosLabel.TabIndex = 71;
            descricaoSituacaoPagamentosLabel.Text = "Pagamentos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orçamentos / Pré-Venda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 48);
            this.panel1.TabIndex = 20;
            // 
            // pedidoGeradoTextBox
            // 
            this.pedidoGeradoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "pedidoGerado", true));
            this.pedidoGeradoTextBox.Enabled = false;
            this.pedidoGeradoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidoGeradoTextBox.Location = new System.Drawing.Point(403, 451);
            this.pedidoGeradoTextBox.Name = "pedidoGeradoTextBox";
            this.pedidoGeradoTextBox.Size = new System.Drawing.Size(69, 23);
            this.pedidoGeradoTextBox.TabIndex = 46;
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida";
            this.tb_saidaBindingSource.DataSource = this.saceDataSet;
            this.tb_saidaBindingSource.Sort = "codSaida";
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Enabled = false;
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(311, 451);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.Size = new System.Drawing.Size(83, 23);
            this.codSaidaTextBox.TabIndex = 44;
            this.codSaidaTextBox.TabStop = false;
            this.codSaidaTextBox.TextChanged += new System.EventHandler(this.codSaidaTextBox_TextChanged);
            // 
            // dataSaidaDateTimePicker
            // 
            this.dataSaidaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_saidaBindingSource, "dataSaida", true));
            this.dataSaidaDateTimePicker.Enabled = false;
            this.dataSaidaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSaidaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataSaidaDateTimePicker.Location = new System.Drawing.Point(194, 449);
            this.dataSaidaDateTimePicker.Name = "dataSaidaDateTimePicker";
            this.dataSaidaDateTimePicker.Size = new System.Drawing.Size(102, 23);
            this.dataSaidaDateTimePicker.TabIndex = 42;
            this.dataSaidaDateTimePicker.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(322, 552);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(564, 552);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(82, 552);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(81, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(247, 552);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // tb_saidaBindingNavigator
            // 
            this.tb_saidaBindingNavigator.AddNewItem = null;
            this.tb_saidaBindingNavigator.BindingSource = this.tb_saidaBindingSource;
            this.tb_saidaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_saidaBindingNavigator.DeleteItem = null;
            this.tb_saidaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_saidaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_saidaBindingNavigator.Location = new System.Drawing.Point(754, 47);
            this.tb_saidaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_saidaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_saidaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_saidaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_saidaBindingNavigator.Name = "tb_saidaBindingNavigator";
            this.tb_saidaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_saidaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_saidaBindingNavigator.TabIndex = 21;
            this.tb_saidaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "codProduto", true));
            this.codProdutoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProdutoTextBox.Location = new System.Drawing.Point(7, 77);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.ReadOnly = true;
            this.codProdutoTextBox.Size = new System.Drawing.Size(174, 38);
            this.codProdutoTextBox.TabIndex = 28;
            this.codProdutoTextBox.TabStop = false;
            this.codProdutoTextBox.TextChanged += new System.EventHandler(this.codProdutoTextBox_TextChanged);
            // 
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.AllowNew = false;
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.saceDataSet;
            this.tb_produtoBindingSource.Sort = "nome";
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeTextBox.Location = new System.Drawing.Point(12, 147);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(169, 29);
            this.quantidadeTextBox.TabIndex = 32;
            this.quantidadeTextBox.Enter += new System.EventHandler(this.quantidadeTextBox_Enter);
            this.quantidadeTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // precoVendaSemDescontoTextBox
            // 
            this.precoVendaSemDescontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaSemDescontoTextBox.Location = new System.Drawing.Point(12, 207);
            this.precoVendaSemDescontoTextBox.Name = "precoVendaSemDescontoTextBox";
            this.precoVendaSemDescontoTextBox.ReadOnly = true;
            this.precoVendaSemDescontoTextBox.Size = new System.Drawing.Size(169, 29);
            this.precoVendaSemDescontoTextBox.TabIndex = 36;
            this.precoVendaSemDescontoTextBox.TabStop = false;
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.subtotalTextBox.Location = new System.Drawing.Point(17, 329);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.ReadOnly = true;
            this.subtotalTextBox.Size = new System.Drawing.Size(164, 29);
            this.subtotalTextBox.TabIndex = 36;
            this.subtotalTextBox.TabStop = false;
            // 
            // tb_saida_produtoDataGridView
            // 
            this.tb_saida_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_saida_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_saida_produtoDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_saida_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tb_saida_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_saida_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSaidaProdutoDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.valorVendaDataGridViewTextBoxColumn,
            this.descontoDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.subtotalAVistaDataGridViewTextBoxColumn,
            this.datavalidadeDataGridViewTextBoxColumn});
            this.tb_saida_produtoDataGridView.DataSource = this.tbsaidaprodutoBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_saida_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.tb_saida_produtoDataGridView.Location = new System.Drawing.Point(194, 147);
            this.tb_saida_produtoDataGridView.MultiSelect = false;
            this.tb_saida_produtoDataGridView.Name = "tb_saida_produtoDataGridView";
            this.tb_saida_produtoDataGridView.ReadOnly = true;
            this.tb_saida_produtoDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_saida_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_saida_produtoDataGridView.Size = new System.Drawing.Size(753, 275);
            this.tb_saida_produtoDataGridView.TabIndex = 36;
            this.tb_saida_produtoDataGridView.TabStop = false;
            // 
            // codSaidaProdutoDataGridViewTextBoxColumn
            // 
            this.codSaidaProdutoDataGridViewTextBoxColumn.DataPropertyName = "codSaidaProduto";
            this.codSaidaProdutoDataGridViewTextBoxColumn.HeaderText = "codSaidaProduto";
            this.codSaidaProdutoDataGridViewTextBoxColumn.Name = "codSaidaProdutoDataGridViewTextBoxColumn";
            this.codSaidaProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codSaidaProdutoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorVendaDataGridViewTextBoxColumn
            // 
            this.valorVendaDataGridViewTextBoxColumn.DataPropertyName = "valorVenda";
            this.valorVendaDataGridViewTextBoxColumn.HeaderText = "Valor (R$)";
            this.valorVendaDataGridViewTextBoxColumn.Name = "valorVendaDataGridViewTextBoxColumn";
            this.valorVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descontoDataGridViewTextBoxColumn
            // 
            this.descontoDataGridViewTextBoxColumn.DataPropertyName = "desconto";
            this.descontoDataGridViewTextBoxColumn.HeaderText = "desconto";
            this.descontoDataGridViewTextBoxColumn.Name = "descontoDataGridViewTextBoxColumn";
            this.descontoDataGridViewTextBoxColumn.ReadOnly = true;
            this.descontoDataGridViewTextBoxColumn.Visible = false;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalAVistaDataGridViewTextBoxColumn
            // 
            this.subtotalAVistaDataGridViewTextBoxColumn.DataPropertyName = "subtotalAVista";
            this.subtotalAVistaDataGridViewTextBoxColumn.HeaderText = "subtotalAVista";
            this.subtotalAVistaDataGridViewTextBoxColumn.Name = "subtotalAVistaDataGridViewTextBoxColumn";
            this.subtotalAVistaDataGridViewTextBoxColumn.ReadOnly = true;
            this.subtotalAVistaDataGridViewTextBoxColumn.Visible = false;
            // 
            // datavalidadeDataGridViewTextBoxColumn
            // 
            this.datavalidadeDataGridViewTextBoxColumn.DataPropertyName = "data_validade";
            this.datavalidadeDataGridViewTextBoxColumn.HeaderText = "data_validade";
            this.datavalidadeDataGridViewTextBoxColumn.Name = "datavalidadeDataGridViewTextBoxColumn";
            this.datavalidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datavalidadeDataGridViewTextBoxColumn.Visible = false;
            // 
            // tbsaidaprodutoBindingSource
            // 
            this.tbsaidaprodutoBindingSource.DataMember = "tb_saida_produto";
            this.tbsaidaprodutoBindingSource.DataSource = this.saceDataSet;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(738, 435);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(209, 44);
            this.totalTextBox.TabIndex = 37;
            this.totalTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(606, 509);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 38;
            this.label2.Text = "À Vista:";
            // 
            // totalAVistaTextBox
            // 
            this.totalAVistaTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalAVistaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "totalAVista", true));
            this.totalAVistaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAVistaTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalAVistaTextBox.Location = new System.Drawing.Point(738, 507);
            this.totalAVistaTextBox.Name = "totalAVistaTextBox";
            this.totalAVistaTextBox.ReadOnly = true;
            this.totalAVistaTextBox.Size = new System.Drawing.Size(209, 44);
            this.totalAVistaTextBox.TabIndex = 39;
            this.totalAVistaTextBox.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(7, 552);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(881, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(800, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "F12 - Navegar";
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // codProdutoComboBox
            // 
            this.codProdutoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProdutoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProdutoComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.codProdutoComboBox.CausesValidation = false;
            this.codProdutoComboBox.DataSource = this.tb_produtoBindingSource;
            this.codProdutoComboBox.DisplayMember = "nome";
            this.codProdutoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProdutoComboBox.FormattingEnabled = true;
            this.codProdutoComboBox.Location = new System.Drawing.Point(194, 77);
            this.codProdutoComboBox.Name = "codProdutoComboBox";
            this.codProdutoComboBox.Size = new System.Drawing.Size(753, 39);
            this.codProdutoComboBox.TabIndex = 30;
            this.codProdutoComboBox.ValueMember = "codProduto";
            this.codProdutoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codProdutoComboBox_KeyPress);
            this.codProdutoComboBox.Leave += new System.EventHandler(this.codProdutoComboBox_Leave);
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saida_produtoTableAdapter
            // 
            this.tb_saida_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(163, 552);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(83, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // precoVendatextBox
            // 
            this.precoVendatextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendatextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendatextBox.Location = new System.Drawing.Point(12, 267);
            this.precoVendatextBox.Name = "precoVendatextBox";
            this.precoVendatextBox.Size = new System.Drawing.Size(169, 29);
            this.precoVendatextBox.TabIndex = 34;
            this.precoVendatextBox.Leave += new System.EventHandler(this.precoVendatextBox_Leave);
            // 
            // data_validadeDateTimePicker
            // 
            this.data_validadeDateTimePicker.Enabled = false;
            this.data_validadeDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.data_validadeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_validadeDateTimePicker.Location = new System.Drawing.Point(12, 391);
            this.data_validadeDateTimePicker.Name = "data_validadeDateTimePicker";
            this.data_validadeDateTimePicker.Size = new System.Drawing.Size(169, 29);
            this.data_validadeDateTimePicker.TabIndex = 38;
            this.data_validadeDateTimePicker.Leave += new System.EventHandler(this.data_validadeDateTimePicker_Leave);
            // 
            // nomeClienteTextBox
            // 
            this.nomeClienteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeCliente", true));
            this.nomeClienteTextBox.Enabled = false;
            this.nomeClienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeClienteTextBox.Location = new System.Drawing.Point(17, 507);
            this.nomeClienteTextBox.Name = "nomeClienteTextBox";
            this.nomeClienteTextBox.Size = new System.Drawing.Size(455, 23);
            this.nomeClienteTextBox.TabIndex = 50;
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(12, 451);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(169, 23);
            this.descricaoTipoSaidaTextBox.TabIndex = 40;
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Location = new System.Drawing.Point(403, 552);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(81, 23);
            this.btnEncerrar.TabIndex = 5;
            this.btnEncerrar.Text = "F7 - Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // nfeTextBox
            // 
            this.nfeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nfe", true));
            this.nfeTextBox.Enabled = false;
            this.nfeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nfeTextBox.Location = new System.Drawing.Point(478, 451);
            this.nfeTextBox.Name = "nfeTextBox";
            this.nfeTextBox.Size = new System.Drawing.Size(100, 23);
            this.nfeTextBox.TabIndex = 48;
            // 
            // entregaRealizadaCheckBox
            // 
            this.entregaRealizadaCheckBox.Checked = true;
            this.entregaRealizadaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entregaRealizadaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_saidaBindingSource, "entregaRealizada", true));
            this.entregaRealizadaCheckBox.Location = new System.Drawing.Point(194, 125);
            this.entregaRealizadaCheckBox.Name = "entregaRealizadaCheckBox";
            this.entregaRealizadaCheckBox.Size = new System.Drawing.Size(104, 24);
            this.entregaRealizadaCheckBox.TabIndex = 71;
            this.entregaRealizadaCheckBox.TabStop = false;
            this.entregaRealizadaCheckBox.Text = "Entregue";
            this.entregaRealizadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // descricaoSituacaoPagamentosTextBox
            // 
            this.descricaoSituacaoPagamentosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "descricaoSituacaoPagamentos", true));
            this.descricaoSituacaoPagamentosTextBox.Enabled = false;
            this.descricaoSituacaoPagamentosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.descricaoSituacaoPagamentosTextBox.Location = new System.Drawing.Point(478, 509);
            this.descricaoSituacaoPagamentosTextBox.Name = "descricaoSituacaoPagamentosTextBox";
            this.descricaoSituacaoPagamentosTextBox.Size = new System.Drawing.Size(100, 23);
            this.descricaoSituacaoPagamentosTextBox.TabIndex = 52;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(484, 552);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(81, 23);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "F8 - Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 579);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(descricaoSituacaoPagamentosLabel);
            this.Controls.Add(this.descricaoSituacaoPagamentosTextBox);
            this.Controls.Add(nfeLabel);
            this.Controls.Add(this.nfeTextBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEncerrar);
            this.Controls.Add(descricaoTipoSaidaLabel);
            this.Controls.Add(this.descricaoTipoSaidaTextBox);
            this.Controls.Add(nomeClienteLabel);
            this.Controls.Add(this.nomeClienteTextBox);
            this.Controls.Add(data_validadeLabel);
            this.Controls.Add(this.data_validadeDateTimePicker);
            this.Controls.Add(pedidoGeradoLabel);
            this.Controls.Add(label4);
            this.Controls.Add(this.pedidoGeradoTextBox);
            this.Controls.Add(this.precoVendatextBox);
            this.Controls.Add(this.codSaidaTextBox);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(codSaidaLabel);
            this.Controls.Add(this.dataSaidaDateTimePicker);
            this.Controls.Add(dataSaidaLabel);
            this.Controls.Add(this.codProdutoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.totalAVistaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.tb_saida_produtoDataGridView);
            this.Controls.Add(subtotalLabel);
            this.Controls.Add(this.subtotalTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(valorVendaLabel);
            this.Controls.Add(this.precoVendaSemDescontoTextBox);
            this.Controls.Add(quantidadeLabel);
            this.Controls.Add(this.quantidadeTextBox);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(this.tb_saidaBindingNavigator);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.entregaRealizadaCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaida";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saída de Produtos";
            this.Load += new System.EventHandler(this.FrmSaida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaida_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingNavigator)).EndInit();
            this.tb_saidaBindingNavigator.ResumeLayout(false);
            this.tb_saidaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsaidaprodutoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
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
        private System.Windows.Forms.TextBox codProdutoTextBox;
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
        private Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
        private Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saida_produtoTableAdapter tb_saida_produtoTableAdapter;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox precoVendatextBox;
        private System.Windows.Forms.DateTimePicker data_validadeDateTimePicker;
        private System.Windows.Forms.TextBox nomeClienteTextBox;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.BindingSource tbsaidaprodutoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalAVistaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavalidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private System.Windows.Forms.TextBox nfeTextBox;
        private System.Windows.Forms.CheckBox entregaRealizadaCheckBox;
        private System.Windows.Forms.TextBox descricaoSituacaoPagamentosTextBox;
        private System.Windows.Forms.Button btnImprimir;
    }
}