namespace SACE.Telas
{
    partial class FrmPreVenda
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
            this.qtdProdutoLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.nomeProdutoLabel = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.produtoTextBox = new System.Windows.Forms.TextBox();
            this.tb_saida_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.codProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorVendaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalLabel = new System.Windows.Forms.Label();
            this.aVistaLabel = new System.Windows.Forms.Label();
            this.volumesLabel = new System.Windows.Forms.Label();
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.precoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtOrcamento = new System.Windows.Forms.RadioButton();
            this.rbtPreVenda = new System.Windows.Forms.RadioButton();
            this.codigoLabel = new System.Windows.Forms.Label();
            this.btnInsereProduto = new System.Windows.Forms.Button();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_saidaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.tb_saida_produtoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_saida_produtoTableAdapter();
            this.tb_produtoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // qtdProdutoLabel
            // 
            this.qtdProdutoLabel.AutoSize = true;
            this.qtdProdutoLabel.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdProdutoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.qtdProdutoLabel.Location = new System.Drawing.Point(9, 15);
            this.qtdProdutoLabel.Name = "qtdProdutoLabel";
            this.qtdProdutoLabel.Size = new System.Drawing.Size(0, 42);
            this.qtdProdutoLabel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nomeProdutoLabel);
            this.panel1.Controls.Add(this.qtdProdutoLabel);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 71);
            this.panel1.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(80, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 42);
            this.label6.TabIndex = 2;
            this.label6.Text = "X";
            // 
            // nomeProdutoLabel
            // 
            this.nomeProdutoLabel.AutoSize = true;
            this.nomeProdutoLabel.Font = new System.Drawing.Font("Comic Sans MS", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeProdutoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nomeProdutoLabel.Location = new System.Drawing.Point(126, 15);
            this.nomeProdutoLabel.Name = "nomeProdutoLabel";
            this.nomeProdutoLabel.Size = new System.Drawing.Size(0, 42);
            this.nomeProdutoLabel.TabIndex = 1;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(312, 511);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(12, 511);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(393, 511);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(87, 511);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(237, 511);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(162, 511);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Produto";
            // 
            // produtoTextBox
            // 
            this.produtoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.tb_saida_produtoBindingSource, "codProduto", true));
            this.produtoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saida_produtoBindingSource, "codProduto", true));
            this.produtoTextBox.Location = new System.Drawing.Point(16, 183);
            this.produtoTextBox.MaxLength = 40;
            this.produtoTextBox.Name = "produtoTextBox";
            this.produtoTextBox.Size = new System.Drawing.Size(146, 20);
            this.produtoTextBox.TabIndex = 10;
            this.produtoTextBox.Leave += new System.EventHandler(this.produtoTextBox_Leave);
            // 
            // tb_saida_produtoBindingSource
            // 
            this.tb_saida_produtoBindingSource.DataMember = "tb_saida_produto";
            this.tb_saida_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Volumes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "À Vista";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codProdutoDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.valorVendaDataGridViewTextBoxColumn,
            this.descontoDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.tb_saida_produtoBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(225, 111);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(554, 375);
            this.dataGridView.TabIndex = 20;
            // 
            // codProdutoDataGridViewTextBoxColumn
            // 
            this.codProdutoDataGridViewTextBoxColumn.DataPropertyName = "codProduto";
            this.codProdutoDataGridViewTextBoxColumn.HeaderText = "codProduto";
            this.codProdutoDataGridViewTextBoxColumn.Name = "codProdutoDataGridViewTextBoxColumn";
            this.codProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorVendaDataGridViewTextBoxColumn
            // 
            this.valorVendaDataGridViewTextBoxColumn.DataPropertyName = "valorVenda";
            this.valorVendaDataGridViewTextBoxColumn.HeaderText = "valorVenda";
            this.valorVendaDataGridViewTextBoxColumn.Name = "valorVendaDataGridViewTextBoxColumn";
            this.valorVendaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descontoDataGridViewTextBoxColumn
            // 
            this.descontoDataGridViewTextBoxColumn.DataPropertyName = "desconto";
            this.descontoDataGridViewTextBoxColumn.HeaderText = "desconto";
            this.descontoDataGridViewTextBoxColumn.Name = "descontoDataGridViewTextBoxColumn";
            this.descontoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(10, 389);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 31);
            this.totalLabel.TabIndex = 30;
            // 
            // aVistaLabel
            // 
            this.aVistaLabel.AutoSize = true;
            this.aVistaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aVistaLabel.Location = new System.Drawing.Point(10, 455);
            this.aVistaLabel.Name = "aVistaLabel";
            this.aVistaLabel.Size = new System.Drawing.Size(0, 31);
            this.aVistaLabel.TabIndex = 31;
            // 
            // volumesLabel
            // 
            this.volumesLabel.AutoSize = true;
            this.volumesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumesLabel.Location = new System.Drawing.Point(12, 120);
            this.volumesLabel.Name = "volumesLabel";
            this.volumesLabel.Size = new System.Drawing.Size(29, 31);
            this.volumesLabel.TabIndex = 32;
            this.volumesLabel.Text = "0";
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.Location = new System.Drawing.Point(16, 238);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(174, 20);
            this.quantidadeTextBox.TabIndex = 12;
            this.quantidadeTextBox.TextChanged += new System.EventHandler(this.quantidadeTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Quantidade";
            // 
            // precoTextBox
            // 
            this.precoTextBox.Location = new System.Drawing.Point(16, 303);
            this.precoTextBox.Name = "precoTextBox";
            this.precoTextBox.ReadOnly = true;
            this.precoTextBox.Size = new System.Drawing.Size(174, 20);
            this.precoTextBox.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Preço (UN)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(221, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Código:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtOrcamento);
            this.groupBox1.Controls.Add(this.rbtPreVenda);
            this.groupBox1.Location = new System.Drawing.Point(540, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 40);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // rbtOrcamento
            // 
            this.rbtOrcamento.AutoSize = true;
            this.rbtOrcamento.Location = new System.Drawing.Point(134, 12);
            this.rbtOrcamento.Name = "rbtOrcamento";
            this.rbtOrcamento.Size = new System.Drawing.Size(77, 17);
            this.rbtOrcamento.TabIndex = 1;
            this.rbtOrcamento.Text = "Orçamento";
            this.rbtOrcamento.UseVisualStyleBackColor = true;
            // 
            // rbtPreVenda
            // 
            this.rbtPreVenda.AutoSize = true;
            this.rbtPreVenda.Checked = true;
            this.rbtPreVenda.Location = new System.Drawing.Point(16, 12);
            this.rbtPreVenda.Name = "rbtPreVenda";
            this.rbtPreVenda.Size = new System.Drawing.Size(75, 17);
            this.rbtPreVenda.TabIndex = 0;
            this.rbtPreVenda.TabStop = true;
            this.rbtPreVenda.Text = "Pré-Venda";
            this.rbtPreVenda.UseVisualStyleBackColor = true;
            this.rbtPreVenda.CheckedChanged += new System.EventHandler(this.rbtPreVenda_CheckedChanged);
            // 
            // codigoLabel
            // 
            this.codigoLabel.AutoSize = true;
            this.codigoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoLabel.Location = new System.Drawing.Point(282, 85);
            this.codigoLabel.Name = "codigoLabel";
            this.codigoLabel.Size = new System.Drawing.Size(0, 24);
            this.codigoLabel.TabIndex = 39;
            // 
            // btnInsereProduto
            // 
            this.btnInsereProduto.Location = new System.Drawing.Point(47, 329);
            this.btnInsereProduto.Name = "btnInsereProduto";
            this.btnInsereProduto.Size = new System.Drawing.Size(102, 36);
            this.btnInsereProduto.TabIndex = 16;
            this.btnInsereProduto.Text = "Inserir Produto";
            this.btnInsereProduto.UseVisualStyleBackColor = true;
            this.btnInsereProduto.Click += new System.EventHandler(this.insereProdutoButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Pr";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida_produto";
            this.tb_saidaBindingSource.DataSource = typeof(SACE.Dados.saceDataSet);
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saida_produtoTableAdapter
            // 
            this.tb_saida_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPreVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 544);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInsereProduto);
            this.Controls.Add(this.codigoLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.precoTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.quantidadeTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.volumesLabel);
            this.Controls.Add(this.aVistaLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.produtoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmPreVenda";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de PreVendas";
            this.Load += new System.EventHandler(this.FrmPreVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPreVenda_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label qtdProdutoLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox produtoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label aVistaLabel;
        private System.Windows.Forms.Label volumesLabel;
        private System.Windows.Forms.TextBox quantidadeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox precoTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtOrcamento;
        private System.Windows.Forms.RadioButton rbtPreVenda;
        private System.Windows.Forms.Label codigoLabel;
        private SACE.Dados.saceDataSet saceDataSet;
        private SACE.Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.tb_saida_produtoTableAdapter tb_saida_produtoTableAdapter;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.BindingSource tb_saida_produtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorVendaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnInsereProduto;
        private SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label nomeProdutoLabel;
        private System.Windows.Forms.Button button1;
    }
}