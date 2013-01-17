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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label baseCalculoICMSLabel;
            System.Windows.Forms.Label valorICMSLabel;
            System.Windows.Forms.Label baseCalculoICMSSubstLabel;
            System.Windows.Forms.Label valorICMSSubstLabel;
            System.Windows.Forms.Label valorIPILabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaida));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSaidaProdutos = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFormaEntrada = new System.Windows.Forms.Label();
            this.pedidoGeradoTextBox = new System.Windows.Forms.TextBox();
            this.saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaSemDescontoTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.tb_saida_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.codSaidaProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVendaAVistaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalAVistaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataValidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseCalculoICMSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorICMSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorICMSSubstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorIPIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saidaProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.totalAVistaTextBox = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.codProdutoComboBox = new System.Windows.Forms.ComboBox();
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
            this.subtotalAVistatextBox = new System.Windows.Forms.TextBox();
            this.lblBalcao = new System.Windows.Forms.Label();
            this.panelBalcao = new System.Windows.Forms.Panel();
            this.btnCfNfe = new System.Windows.Forms.Button();
            this.baseCalculoICMSTextBox = new System.Windows.Forms.TextBox();
            this.valorICMSTextBox = new System.Windows.Forms.TextBox();
            this.baseCalculoICMSSubstTextBox = new System.Windows.Forms.TextBox();
            this.valorICMSSubstTextBox = new System.Windows.Forms.TextBox();
            this.valorIPITextBox = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            codSaidaLabel = new System.Windows.Forms.Label();
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
            label5 = new System.Windows.Forms.Label();
            baseCalculoICMSLabel = new System.Windows.Forms.Label();
            valorICMSLabel = new System.Windows.Forms.Label();
            baseCalculoICMSSubstLabel = new System.Windows.Forms.Label();
            valorICMSSubstLabel = new System.Windows.Forms.Label();
            valorIPILabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingNavigator)).BeginInit();
            this.tb_saidaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saidaProdutoBindingSource)).BeginInit();
            this.panelBalcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.ForeColor = System.Drawing.Color.Black;
            codSaidaLabel.Location = new System.Drawing.Point(10, 534);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(62, 20);
            codSaidaLabel.TabIndex = 21;
            codSaidaLabel.Text = "Pedido:";
            // 
            // quantidadeLabel
            // 
            quantidadeLabel.AutoSize = true;
            quantidadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            quantidadeLabel.Location = new System.Drawing.Point(10, 152);
            quantidadeLabel.Name = "quantidadeLabel";
            quantidadeLabel.Size = new System.Drawing.Size(96, 20);
            quantidadeLabel.TabIndex = 23;
            quantidadeLabel.Text = "Quantidade:";
            // 
            // valorVendaLabel
            // 
            valorVendaLabel.AutoSize = true;
            valorVendaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            valorVendaLabel.Location = new System.Drawing.Point(10, 214);
            valorVendaLabel.Name = "valorVendaLabel";
            valorVendaLabel.Size = new System.Drawing.Size(89, 20);
            valorVendaLabel.TabIndex = 25;
            valorVendaLabel.Text = "Preço (R$):";
            // 
            // dataSaidaLabel
            // 
            dataSaidaLabel.AutoSize = true;
            dataSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataSaidaLabel.ForeColor = System.Drawing.Color.Black;
            dataSaidaLabel.Location = new System.Drawing.Point(104, 534);
            dataSaidaLabel.Name = "dataSaidaLabel";
            dataSaidaLabel.Size = new System.Drawing.Size(48, 20);
            dataSaidaLabel.TabIndex = 27;
            dataSaidaLabel.Text = "Data:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeLabel.Location = new System.Drawing.Point(10, 55);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(69, 20);
            nomeLabel.TabIndex = 29;
            nomeLabel.Text = "Produto:";
            // 
            // subtotalLabel
            // 
            subtotalLabel.AutoSize = true;
            subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            subtotalLabel.Location = new System.Drawing.Point(8, 273);
            subtotalLabel.Name = "subtotalLabel";
            subtotalLabel.Size = new System.Drawing.Size(108, 20);
            subtotalLabel.TabIndex = 30;
            subtotalLabel.Text = "Subtotal (R$):";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            totalLabel.Location = new System.Drawing.Point(655, 551);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(131, 37);
            totalLabel.TabIndex = 36;
            totalLabel.Text = "TOTAL:";
            // 
            // pedidoGeradoLabel
            // 
            pedidoGeradoLabel.AutoSize = true;
            pedidoGeradoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pedidoGeradoLabel.ForeColor = System.Drawing.Color.Black;
            pedidoGeradoLabel.Location = new System.Drawing.Point(348, 534);
            pedidoGeradoLabel.Name = "pedidoGeradoLabel";
            pedidoGeradoLabel.Size = new System.Drawing.Size(34, 20);
            pedidoGeradoLabel.TabIndex = 27;
            pedidoGeradoLabel.Text = "CF:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(10, 333);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(142, 20);
            label4.TabIndex = 65;
            label4.Text = "Preço à Vista (R$):";
            // 
            // data_validadeLabel
            // 
            data_validadeLabel.AutoSize = true;
            data_validadeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            data_validadeLabel.Location = new System.Drawing.Point(10, 461);
            data_validadeLabel.Name = "data_validadeLabel";
            data_validadeLabel.Size = new System.Drawing.Size(114, 20);
            data_validadeLabel.TabIndex = 66;
            data_validadeLabel.Text = "Data Validade:";
            // 
            // nomeClienteLabel
            // 
            nomeClienteLabel.AutoSize = true;
            nomeClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeClienteLabel.Location = new System.Drawing.Point(10, 598);
            nomeClienteLabel.Name = "nomeClienteLabel";
            nomeClienteLabel.Size = new System.Drawing.Size(62, 20);
            nomeClienteLabel.TabIndex = 67;
            nomeClienteLabel.Text = "Cliente:";
            // 
            // descricaoTipoSaidaLabel
            // 
            descricaoTipoSaidaLabel.AutoSize = true;
            descricaoTipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descricaoTipoSaidaLabel.ForeColor = System.Drawing.Color.Black;
            descricaoTipoSaidaLabel.Location = new System.Drawing.Point(212, 534);
            descricaoTipoSaidaLabel.Name = "descricaoTipoSaidaLabel";
            descricaoTipoSaidaLabel.Size = new System.Drawing.Size(39, 20);
            descricaoTipoSaidaLabel.TabIndex = 68;
            descricaoTipoSaidaLabel.Text = "Tipo";
            // 
            // nfeLabel
            // 
            nfeLabel.AutoSize = true;
            nfeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nfeLabel.ForeColor = System.Drawing.Color.Black;
            nfeLabel.Location = new System.Drawing.Point(480, 534);
            nfeLabel.Name = "nfeLabel";
            nfeLabel.Size = new System.Drawing.Size(38, 20);
            nfeLabel.TabIndex = 69;
            nfeLabel.Text = "Nfe:";
            // 
            // descricaoSituacaoPagamentosLabel
            // 
            descricaoSituacaoPagamentosLabel.AutoSize = true;
            descricaoSituacaoPagamentosLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descricaoSituacaoPagamentosLabel.Location = new System.Drawing.Point(480, 598);
            descricaoSituacaoPagamentosLabel.Name = "descricaoSituacaoPagamentosLabel";
            descricaoSituacaoPagamentosLabel.Size = new System.Drawing.Size(103, 20);
            descricaoSituacaoPagamentosLabel.TabIndex = 71;
            descricaoSituacaoPagamentosLabel.Text = "Pagamentos:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(7, 396);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(157, 20);
            label5.TabIndex = 73;
            label5.Text = "Subtotal à Vista(R$):";
            // 
            // baseCalculoICMSLabel
            // 
            baseCalculoICMSLabel.AutoSize = true;
            baseCalculoICMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            baseCalculoICMSLabel.Location = new System.Drawing.Point(197, 463);
            baseCalculoICMSLabel.Name = "baseCalculoICMSLabel";
            baseCalculoICMSLabel.Size = new System.Drawing.Size(114, 20);
            baseCalculoICMSLabel.TabIndex = 73;
            baseCalculoICMSLabel.Text = "BC ICMS (R$):";
            // 
            // valorICMSLabel
            // 
            valorICMSLabel.AutoSize = true;
            valorICMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            valorICMSLabel.Location = new System.Drawing.Point(348, 461);
            valorICMSLabel.Name = "valorICMSLabel";
            valorICMSLabel.Size = new System.Drawing.Size(129, 20);
            valorICMSLabel.TabIndex = 74;
            valorICMSLabel.Text = "Valor ICMS (R$):";
            // 
            // baseCalculoICMSSubstLabel
            // 
            baseCalculoICMSSubstLabel.AutoSize = true;
            baseCalculoICMSSubstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            baseCalculoICMSSubstLabel.Location = new System.Drawing.Point(511, 461);
            baseCalculoICMSSubstLabel.Name = "baseCalculoICMSSubstLabel";
            baseCalculoICMSSubstLabel.Size = new System.Drawing.Size(160, 20);
            baseCalculoICMSSubstLabel.TabIndex = 75;
            baseCalculoICMSSubstLabel.Text = "BC ICMS Subst (R$):";
            // 
            // valorICMSSubstLabel
            // 
            valorICMSSubstLabel.AutoSize = true;
            valorICMSSubstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            valorICMSSubstLabel.Location = new System.Drawing.Point(673, 461);
            valorICMSSubstLabel.Name = "valorICMSSubstLabel";
            valorICMSSubstLabel.Size = new System.Drawing.Size(175, 20);
            valorICMSSubstLabel.TabIndex = 76;
            valorICMSSubstLabel.Text = "Valor ICMS Subst (R$):";
            // 
            // valorIPILabel
            // 
            valorIPILabel.AutoSize = true;
            valorIPILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            valorIPILabel.Location = new System.Drawing.Point(853, 461);
            valorIPILabel.Name = "valorIPILabel";
            valorIPILabel.Size = new System.Drawing.Size(109, 20);
            valorIPILabel.TabIndex = 77;
            valorIPILabel.Text = "Valor IPI (R$):";
            // 
            // lblSaidaProdutos
            // 
            this.lblSaidaProdutos.AutoSize = true;
            this.lblSaidaProdutos.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaidaProdutos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSaidaProdutos.Location = new System.Drawing.Point(3, 9);
            this.lblSaidaProdutos.Name = "lblSaidaProdutos";
            this.lblSaidaProdutos.Size = new System.Drawing.Size(230, 26);
            this.lblSaidaProdutos.TabIndex = 0;
            this.lblSaidaProdutos.Text = "Orçamentos / Pré-Venda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblFormaEntrada);
            this.panel1.Controls.Add(this.lblSaidaProdutos);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 48);
            this.panel1.TabIndex = 20;
            // 
            // lblFormaEntrada
            // 
            this.lblFormaEntrada.AutoSize = true;
            this.lblFormaEntrada.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaEntrada.ForeColor = System.Drawing.Color.Red;
            this.lblFormaEntrada.Location = new System.Drawing.Point(821, 22);
            this.lblFormaEntrada.Name = "lblFormaEntrada";
            this.lblFormaEntrada.Size = new System.Drawing.Size(136, 23);
            this.lblFormaEntrada.TabIndex = 1;
            this.lblFormaEntrada.Text = "F1-MANUAL";
            // 
            // pedidoGeradoTextBox
            // 
            this.pedidoGeradoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "pedidoGerado", true));
            this.pedidoGeradoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pedidoGeradoTextBox.Location = new System.Drawing.Point(352, 561);
            this.pedidoGeradoTextBox.Name = "pedidoGeradoTextBox";
            this.pedidoGeradoTextBox.ReadOnly = true;
            this.pedidoGeradoTextBox.Size = new System.Drawing.Size(122, 26);
            this.pedidoGeradoTextBox.TabIndex = 60;
            this.pedidoGeradoTextBox.TabStop = false;
            // 
            // saidaBindingSource
            // 
            this.saidaBindingSource.DataSource = typeof(Dominio.Saida);
            this.saidaBindingSource.Sort = "codSaida";
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.ForeColor = System.Drawing.Color.Red;
            this.codSaidaTextBox.Location = new System.Drawing.Point(12, 560);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(87, 26);
            this.codSaidaTextBox.TabIndex = 54;
            this.codSaidaTextBox.TabStop = false;
            this.codSaidaTextBox.TextChanged += new System.EventHandler(this.codSaidaTextBox_TextChanged);
            this.codSaidaTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codSaidaTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // dataSaidaDateTimePicker
            // 
            this.dataSaidaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.saidaBindingSource, "dataSaida", true));
            this.dataSaidaDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSaidaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataSaidaDateTimePicker.Location = new System.Drawing.Point(108, 560);
            this.dataSaidaDateTimePicker.Name = "dataSaidaDateTimePicker";
            this.dataSaidaDateTimePicker.Size = new System.Drawing.Size(109, 26);
            this.dataSaidaDateTimePicker.TabIndex = 56;
            this.dataSaidaDateTimePicker.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(322, 661);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(653, 661);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(82, 661);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(81, 23);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(247, 661);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 4;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // tb_saidaBindingNavigator
            // 
            this.tb_saidaBindingNavigator.AddNewItem = null;
            this.tb_saidaBindingNavigator.BindingSource = this.saidaBindingSource;
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
            this.tb_saidaBindingNavigator.Location = new System.Drawing.Point(806, 47);
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
            // produtoBindingSource
            // 
            this.produtoBindingSource.AllowNew = false;
            this.produtoBindingSource.DataSource = typeof(Dominio.ProdutoPesquisa);
            this.produtoBindingSource.Sort = "nome";
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeTextBox.Location = new System.Drawing.Point(13, 177);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(169, 29);
            this.quantidadeTextBox.TabIndex = 32;
            this.quantidadeTextBox.Enter += new System.EventHandler(this.quantidadeTextBox_Enter);
            this.quantidadeTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // precoVendaSemDescontoTextBox
            // 
            this.precoVendaSemDescontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "precoVendaVarejoSemDesconto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precoVendaSemDescontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaSemDescontoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaSemDescontoTextBox.Location = new System.Drawing.Point(13, 239);
            this.precoVendaSemDescontoTextBox.Name = "precoVendaSemDescontoTextBox";
            this.precoVendaSemDescontoTextBox.ReadOnly = true;
            this.precoVendaSemDescontoTextBox.Size = new System.Drawing.Size(169, 29);
            this.precoVendaSemDescontoTextBox.TabIndex = 34;
            this.precoVendaSemDescontoTextBox.TabStop = false;
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalTextBox.ForeColor = System.Drawing.Color.Red;
            this.subtotalTextBox.Location = new System.Drawing.Point(13, 298);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.ReadOnly = true;
            this.subtotalTextBox.Size = new System.Drawing.Size(169, 29);
            this.subtotalTextBox.TabIndex = 36;
            this.subtotalTextBox.TabStop = false;
            // 
            // tb_saida_produtoDataGridView
            // 
            this.tb_saida_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_saida_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_saida_produtoDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_saida_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tb_saida_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_saida_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSaidaProdutoDataGridViewTextBoxColumn,
            this.codProdutoDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.valorVendaDataGridViewTextBoxColumn,
            this.valorVendaAVistaDataGridViewTextBoxColumn,
            this.descontoDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.subtotalAVistaDataGridViewTextBoxColumn,
            this.dataValidadeDataGridViewTextBoxColumn,
            this.codCSTDataGridViewTextBoxColumn,
            this.unidadeDataGridViewTextBoxColumn,
            this.baseCalculoICMSDataGridViewTextBoxColumn,
            this.valorICMSDataGridViewTextBoxColumn,
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn,
            this.valorICMSSubstDataGridViewTextBoxColumn,
            this.valorIPIDataGridViewTextBoxColumn});
            this.tb_saida_produtoDataGridView.DataSource = this.saidaProdutoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_saida_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.tb_saida_produtoDataGridView.Location = new System.Drawing.Point(194, 150);
            this.tb_saida_produtoDataGridView.MultiSelect = false;
            this.tb_saida_produtoDataGridView.Name = "tb_saida_produtoDataGridView";
            this.tb_saida_produtoDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_saida_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.tb_saida_produtoDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_saida_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_saida_produtoDataGridView.Size = new System.Drawing.Size(806, 300);
            this.tb_saida_produtoDataGridView.TabIndex = 36;
            this.tb_saida_produtoDataGridView.TabStop = false;
            this.tb_saida_produtoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_saida_produtoDataGridView_CellContentClick);
            this.tb_saida_produtoDataGridView.Leave += new System.EventHandler(this.tb_saida_produtoDataGridView_Leave);
            // 
            // codSaidaProdutoDataGridViewTextBoxColumn
            // 
            this.codSaidaProdutoDataGridViewTextBoxColumn.DataPropertyName = "CodSaidaProduto";
            this.codSaidaProdutoDataGridViewTextBoxColumn.HeaderText = "CodSaidaProduto";
            this.codSaidaProdutoDataGridViewTextBoxColumn.Name = "codSaidaProdutoDataGridViewTextBoxColumn";
            this.codSaidaProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codProdutoDataGridViewTextBoxColumn
            // 
            this.codProdutoDataGridViewTextBoxColumn.DataPropertyName = "CodProduto";
            this.codProdutoDataGridViewTextBoxColumn.HeaderText = "CodProduto";
            this.codProdutoDataGridViewTextBoxColumn.Name = "codProdutoDataGridViewTextBoxColumn";
            this.codProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "CodSaida";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorVendaDataGridViewTextBoxColumn
            // 
            this.valorVendaDataGridViewTextBoxColumn.DataPropertyName = "ValorVenda";
            this.valorVendaDataGridViewTextBoxColumn.HeaderText = "ValorVenda";
            this.valorVendaDataGridViewTextBoxColumn.Name = "valorVendaDataGridViewTextBoxColumn";
            this.valorVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorVendaAVistaDataGridViewTextBoxColumn
            // 
            this.valorVendaAVistaDataGridViewTextBoxColumn.DataPropertyName = "ValorVendaAVista";
            this.valorVendaAVistaDataGridViewTextBoxColumn.HeaderText = "ValorVendaAVista";
            this.valorVendaAVistaDataGridViewTextBoxColumn.Name = "valorVendaAVistaDataGridViewTextBoxColumn";
            this.valorVendaAVistaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descontoDataGridViewTextBoxColumn
            // 
            this.descontoDataGridViewTextBoxColumn.DataPropertyName = "Desconto";
            this.descontoDataGridViewTextBoxColumn.HeaderText = "Desconto";
            this.descontoDataGridViewTextBoxColumn.Name = "descontoDataGridViewTextBoxColumn";
            this.descontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalAVistaDataGridViewTextBoxColumn
            // 
            this.subtotalAVistaDataGridViewTextBoxColumn.DataPropertyName = "SubtotalAVista";
            this.subtotalAVistaDataGridViewTextBoxColumn.HeaderText = "SubtotalAVista";
            this.subtotalAVistaDataGridViewTextBoxColumn.Name = "subtotalAVistaDataGridViewTextBoxColumn";
            this.subtotalAVistaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataValidadeDataGridViewTextBoxColumn
            // 
            this.dataValidadeDataGridViewTextBoxColumn.DataPropertyName = "DataValidade";
            this.dataValidadeDataGridViewTextBoxColumn.HeaderText = "DataValidade";
            this.dataValidadeDataGridViewTextBoxColumn.Name = "dataValidadeDataGridViewTextBoxColumn";
            this.dataValidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codCSTDataGridViewTextBoxColumn
            // 
            this.codCSTDataGridViewTextBoxColumn.DataPropertyName = "CodCST";
            this.codCSTDataGridViewTextBoxColumn.HeaderText = "CodCST";
            this.codCSTDataGridViewTextBoxColumn.Name = "codCSTDataGridViewTextBoxColumn";
            this.codCSTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadeDataGridViewTextBoxColumn
            // 
            this.unidadeDataGridViewTextBoxColumn.DataPropertyName = "Unidade";
            this.unidadeDataGridViewTextBoxColumn.HeaderText = "Unidade";
            this.unidadeDataGridViewTextBoxColumn.Name = "unidadeDataGridViewTextBoxColumn";
            this.unidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baseCalculoICMSDataGridViewTextBoxColumn
            // 
            this.baseCalculoICMSDataGridViewTextBoxColumn.DataPropertyName = "BaseCalculoICMS";
            this.baseCalculoICMSDataGridViewTextBoxColumn.HeaderText = "BaseCalculoICMS";
            this.baseCalculoICMSDataGridViewTextBoxColumn.Name = "baseCalculoICMSDataGridViewTextBoxColumn";
            this.baseCalculoICMSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorICMSDataGridViewTextBoxColumn
            // 
            this.valorICMSDataGridViewTextBoxColumn.DataPropertyName = "ValorICMS";
            this.valorICMSDataGridViewTextBoxColumn.HeaderText = "ValorICMS";
            this.valorICMSDataGridViewTextBoxColumn.Name = "valorICMSDataGridViewTextBoxColumn";
            this.valorICMSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baseCalculoICMSSubstDataGridViewTextBoxColumn
            // 
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn.DataPropertyName = "BaseCalculoICMSSubst";
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn.HeaderText = "BaseCalculoICMSSubst";
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn.Name = "baseCalculoICMSSubstDataGridViewTextBoxColumn";
            this.baseCalculoICMSSubstDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorICMSSubstDataGridViewTextBoxColumn
            // 
            this.valorICMSSubstDataGridViewTextBoxColumn.DataPropertyName = "ValorICMSSubst";
            this.valorICMSSubstDataGridViewTextBoxColumn.HeaderText = "ValorICMSSubst";
            this.valorICMSSubstDataGridViewTextBoxColumn.Name = "valorICMSSubstDataGridViewTextBoxColumn";
            this.valorICMSSubstDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorIPIDataGridViewTextBoxColumn
            // 
            this.valorIPIDataGridViewTextBoxColumn.DataPropertyName = "ValorIPI";
            this.valorIPIDataGridViewTextBoxColumn.HeaderText = "ValorIPI";
            this.valorIPIDataGridViewTextBoxColumn.Name = "valorIPIDataGridViewTextBoxColumn";
            this.valorIPIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saidaProdutoBindingSource
            // 
            this.saidaProdutoBindingSource.DataSource = typeof(Dominio.SaidaProduto);
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(792, 544);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(208, 50);
            this.totalTextBox.TabIndex = 37;
            this.totalTextBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(657, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 37);
            this.label2.TabIndex = 38;
            this.label2.Text = "À Vista:";
            // 
            // totalAVistaTextBox
            // 
            this.totalAVistaTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalAVistaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "totalAVista", true));
            this.totalAVistaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.totalAVistaTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalAVistaTextBox.Location = new System.Drawing.Point(792, 611);
            this.totalAVistaTextBox.Name = "totalAVistaTextBox";
            this.totalAVistaTextBox.ReadOnly = true;
            this.totalAVistaTextBox.Size = new System.Drawing.Size(208, 50);
            this.totalAVistaTextBox.TabIndex = 39;
            this.totalAVistaTextBox.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(7, 661);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(905, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 63;
            this.label3.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(792, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 62;
            this.label6.Text = "F12 - Navegar";
            // 
            // codProdutoComboBox
            // 
            this.codProdutoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProdutoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProdutoComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.codProdutoComboBox.CausesValidation = false;
            this.codProdutoComboBox.DataSource = this.produtoBindingSource;
            this.codProdutoComboBox.DisplayMember = "nome";
            this.codProdutoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.codProdutoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProdutoComboBox.FormattingEnabled = true;
            this.codProdutoComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.codProdutoComboBox.IntegralHeight = false;
            this.codProdutoComboBox.ItemHeight = 31;
            this.codProdutoComboBox.Location = new System.Drawing.Point(12, 77);
            this.codProdutoComboBox.MaxDropDownItems = 5;
            this.codProdutoComboBox.Name = "codProdutoComboBox";
            this.codProdutoComboBox.Size = new System.Drawing.Size(987, 39);
            this.codProdutoComboBox.TabIndex = 30;
            this.codProdutoComboBox.ValueMember = "codProduto";
            this.codProdutoComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codProdutoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codProdutoComboBox_KeyPress);
            this.codProdutoComboBox.Leave += new System.EventHandler(this.codProdutoComboBox_Leave);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(163, 661);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(83, 23);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // precoVendatextBox
            // 
            this.precoVendatextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendatextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendatextBox.Location = new System.Drawing.Point(13, 358);
            this.precoVendatextBox.Name = "precoVendatextBox";
            this.precoVendatextBox.Size = new System.Drawing.Size(169, 29);
            this.precoVendatextBox.TabIndex = 38;
            this.precoVendatextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.precoVendatextBox.Leave += new System.EventHandler(this.precoVendatextBox_Leave);
            // 
            // data_validadeDateTimePicker
            // 
            this.data_validadeDateTimePicker.Enabled = false;
            this.data_validadeDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.data_validadeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_validadeDateTimePicker.Location = new System.Drawing.Point(13, 486);
            this.data_validadeDateTimePicker.Name = "data_validadeDateTimePicker";
            this.data_validadeDateTimePicker.Size = new System.Drawing.Size(169, 29);
            this.data_validadeDateTimePicker.TabIndex = 42;
            this.data_validadeDateTimePicker.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.data_validadeDateTimePicker.Leave += new System.EventHandler(this.data_validadeDateTimePicker_Leave);
            // 
            // nomeClienteTextBox
            // 
            this.nomeClienteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "nomeCliente", true));
            this.nomeClienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeClienteTextBox.Location = new System.Drawing.Point(14, 622);
            this.nomeClienteTextBox.Name = "nomeClienteTextBox";
            this.nomeClienteTextBox.ReadOnly = true;
            this.nomeClienteTextBox.Size = new System.Drawing.Size(460, 26);
            this.nomeClienteTextBox.TabIndex = 64;
            this.nomeClienteTextBox.TabStop = false;
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(223, 561);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.ReadOnly = true;
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(122, 26);
            this.descricaoTipoSaidaTextBox.TabIndex = 58;
            this.descricaoTipoSaidaTextBox.TabStop = false;
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Location = new System.Drawing.Point(403, 661);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(81, 23);
            this.btnEncerrar.TabIndex = 6;
            this.btnEncerrar.Text = "F7 - Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // nfeTextBox
            // 
            this.nfeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "nfe", true));
            this.nfeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nfeTextBox.Location = new System.Drawing.Point(484, 562);
            this.nfeTextBox.Name = "nfeTextBox";
            this.nfeTextBox.ReadOnly = true;
            this.nfeTextBox.Size = new System.Drawing.Size(165, 26);
            this.nfeTextBox.TabIndex = 62;
            this.nfeTextBox.TabStop = false;
            // 
            // entregaRealizadaCheckBox
            // 
            this.entregaRealizadaCheckBox.Checked = true;
            this.entregaRealizadaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entregaRealizadaCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.saidaBindingSource, "entregaRealizada", true));
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
            this.descricaoSituacaoPagamentosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "descricaoSituacaoPagamentos", true));
            this.descricaoSituacaoPagamentosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoSituacaoPagamentosTextBox.Location = new System.Drawing.Point(484, 622);
            this.descricaoSituacaoPagamentosTextBox.Name = "descricaoSituacaoPagamentosTextBox";
            this.descricaoSituacaoPagamentosTextBox.ReadOnly = true;
            this.descricaoSituacaoPagamentosTextBox.Size = new System.Drawing.Size(164, 26);
            this.descricaoSituacaoPagamentosTextBox.TabIndex = 66;
            this.descricaoSituacaoPagamentosTextBox.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(484, 661);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(81, 23);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "F8 - Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // subtotalAVistatextBox
            // 
            this.subtotalAVistatextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalAVistatextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.subtotalAVistatextBox.Location = new System.Drawing.Point(12, 421);
            this.subtotalAVistatextBox.Name = "subtotalAVistatextBox";
            this.subtotalAVistatextBox.ReadOnly = true;
            this.subtotalAVistatextBox.Size = new System.Drawing.Size(169, 29);
            this.subtotalAVistatextBox.TabIndex = 40;
            this.subtotalAVistatextBox.TabStop = false;
            // 
            // lblBalcao
            // 
            this.lblBalcao.AutoSize = true;
            this.lblBalcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalcao.ForeColor = System.Drawing.Color.Red;
            this.lblBalcao.Location = new System.Drawing.Point(303, 8);
            this.lblBalcao.Name = "lblBalcao";
            this.lblBalcao.Size = new System.Drawing.Size(397, 73);
            this.lblBalcao.TabIndex = 0;
            this.lblBalcao.Text = "Balcão Livre";
            // 
            // panelBalcao
            // 
            this.panelBalcao.Controls.Add(this.lblBalcao);
            this.panelBalcao.Location = new System.Drawing.Point(0, 47);
            this.panelBalcao.Name = "panelBalcao";
            this.panelBalcao.Size = new System.Drawing.Size(1009, 102);
            this.panelBalcao.TabIndex = 72;
            // 
            // btnCfNfe
            // 
            this.btnCfNfe.Location = new System.Drawing.Point(565, 661);
            this.btnCfNfe.Name = "btnCfNfe";
            this.btnCfNfe.Size = new System.Drawing.Size(88, 23);
            this.btnCfNfe.TabIndex = 8;
            this.btnCfNfe.Text = "F9 - CF / NF-e";
            this.btnCfNfe.UseVisualStyleBackColor = true;
            this.btnCfNfe.Click += new System.EventHandler(this.btnCfNfe_Click);
            // 
            // baseCalculoICMSTextBox
            // 
            this.baseCalculoICMSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.baseCalculoICMSTextBox.Location = new System.Drawing.Point(201, 487);
            this.baseCalculoICMSTextBox.Name = "baseCalculoICMSTextBox";
            this.baseCalculoICMSTextBox.ReadOnly = true;
            this.baseCalculoICMSTextBox.Size = new System.Drawing.Size(135, 29);
            this.baseCalculoICMSTextBox.TabIndex = 44;
            this.baseCalculoICMSTextBox.TabStop = false;
            this.baseCalculoICMSTextBox.Leave += new System.EventHandler(this.baseCalculoICMSTextBox_Leave);
            // 
            // valorICMSTextBox
            // 
            this.valorICMSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.valorICMSTextBox.Location = new System.Drawing.Point(352, 487);
            this.valorICMSTextBox.Name = "valorICMSTextBox";
            this.valorICMSTextBox.ReadOnly = true;
            this.valorICMSTextBox.Size = new System.Drawing.Size(157, 29);
            this.valorICMSTextBox.TabIndex = 46;
            this.valorICMSTextBox.TabStop = false;
            // 
            // baseCalculoICMSSubstTextBox
            // 
            this.baseCalculoICMSSubstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.baseCalculoICMSSubstTextBox.Location = new System.Drawing.Point(515, 487);
            this.baseCalculoICMSSubstTextBox.Name = "baseCalculoICMSSubstTextBox";
            this.baseCalculoICMSSubstTextBox.ReadOnly = true;
            this.baseCalculoICMSSubstTextBox.Size = new System.Drawing.Size(156, 29);
            this.baseCalculoICMSSubstTextBox.TabIndex = 48;
            this.baseCalculoICMSSubstTextBox.TabStop = false;
            this.baseCalculoICMSSubstTextBox.Leave += new System.EventHandler(this.baseCalculoICMSTextBox_Leave);
            // 
            // valorICMSSubstTextBox
            // 
            this.valorICMSSubstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.valorICMSSubstTextBox.Location = new System.Drawing.Point(677, 487);
            this.valorICMSSubstTextBox.Name = "valorICMSSubstTextBox";
            this.valorICMSSubstTextBox.ReadOnly = true;
            this.valorICMSSubstTextBox.Size = new System.Drawing.Size(171, 29);
            this.valorICMSSubstTextBox.TabIndex = 50;
            this.valorICMSSubstTextBox.TabStop = false;
            this.valorICMSSubstTextBox.Leave += new System.EventHandler(this.valorICMSSubstTextBox_Leave);
            // 
            // valorIPITextBox
            // 
            this.valorIPITextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.valorIPITextBox.Location = new System.Drawing.Point(855, 487);
            this.valorIPITextBox.Name = "valorIPITextBox";
            this.valorIPITextBox.ReadOnly = true;
            this.valorIPITextBox.Size = new System.Drawing.Size(142, 29);
            this.valorIPITextBox.TabIndex = 52;
            this.valorIPITextBox.TabStop = false;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblPreco.ForeColor = System.Drawing.Color.Red;
            this.lblPreco.Location = new System.Drawing.Point(598, 131);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(165, 18);
            this.lblPreco.TabIndex = 78;
            this.lblPreco.Text = "CTRL+P - Preço Varejo";
            // 
            // FrmSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 686);
            this.ControlBox = false;
            this.Controls.Add(this.tb_saida_produtoDataGridView);
            this.Controls.Add(valorIPILabel);
            this.Controls.Add(this.valorIPITextBox);
            this.Controls.Add(valorICMSSubstLabel);
            this.Controls.Add(this.valorICMSSubstTextBox);
            this.Controls.Add(baseCalculoICMSSubstLabel);
            this.Controls.Add(this.baseCalculoICMSSubstTextBox);
            this.Controls.Add(valorICMSLabel);
            this.Controls.Add(this.valorICMSTextBox);
            this.Controls.Add(baseCalculoICMSLabel);
            this.Controls.Add(this.baseCalculoICMSTextBox);
            this.Controls.Add(this.btnCfNfe);
            this.Controls.Add(this.panelBalcao);
            this.Controls.Add(label5);
            this.Controls.Add(this.subtotalAVistatextBox);
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
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.totalAVistaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(subtotalLabel);
            this.Controls.Add(this.subtotalTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(valorVendaLabel);
            this.Controls.Add(this.precoVendaSemDescontoTextBox);
            this.Controls.Add(quantidadeLabel);
            this.Controls.Add(this.quantidadeTextBox);
            this.Controls.Add(this.tb_saidaBindingNavigator);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.entregaRealizadaCheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPreco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaida";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Saída de Produtos";
            this.Load += new System.EventHandler(this.FrmSaida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaida_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingNavigator)).EndInit();
            this.tb_saidaBindingNavigator.ResumeLayout(false);
            this.tb_saidaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saidaProdutoBindingSource)).EndInit();
            this.panelBalcao.ResumeLayout(false);
            this.panelBalcao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.BindingSource produtoBindingSource;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVendaAVistaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalAVistaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseCalculoICMSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorICMSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseCalculoICMSSubstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorICMSSubstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorIPIDataGridViewTextBoxColumn;
    }
}