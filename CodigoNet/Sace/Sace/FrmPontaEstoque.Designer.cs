namespace Telas
 {
     partial class FrmPontaEstoque
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
            System.Windows.Forms.Label caracteristicaLabel;
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label nomeProdutoLabel;
            System.Windows.Forms.Label quantidadeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPontaEstoque));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.pontaEstoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pontaEstoqueDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.caracteristicaTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.tb_produtoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            caracteristicaLabel = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            nomeProdutoLabel = new System.Windows.Forms.Label();
            quantidadeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).BeginInit();
            this.tb_produtoBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // caracteristicaLabel
            // 
            caracteristicaLabel.AutoSize = true;
            caracteristicaLabel.Location = new System.Drawing.Point(132, 115);
            caracteristicaLabel.Name = "caracteristicaLabel";
            caracteristicaLabel.Size = new System.Drawing.Size(74, 13);
            caracteristicaLabel.TabIndex = 22;
            caracteristicaLabel.Text = "Caracteristica:";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(4, 64);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(69, 13);
            codProdutoLabel.TabIndex = 23;
            codProdutoLabel.Text = "Cod Produto:";
            // 
            // nomeProdutoLabel
            // 
            nomeProdutoLabel.AutoSize = true;
            nomeProdutoLabel.Location = new System.Drawing.Point(128, 64);
            nomeProdutoLabel.Name = "nomeProdutoLabel";
            nomeProdutoLabel.Size = new System.Drawing.Size(78, 13);
            nomeProdutoLabel.TabIndex = 24;
            nomeProdutoLabel.Text = "Nome Produto:";
            // 
            // quantidadeLabel
            // 
            quantidadeLabel.AutoSize = true;
            quantidadeLabel.Location = new System.Drawing.Point(4, 115);
            quantidadeLabel.Name = "quantidadeLabel";
            quantidadeLabel.Size = new System.Drawing.Size(65, 13);
            quantidadeLabel.TabIndex = 25;
            quantidadeLabel.Text = "Quantidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Ponta de Estoque";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(164, 368);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(247, 368);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(88, 368);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // pontaEstoqueBindingSource
            // 
            this.pontaEstoqueBindingSource.DataSource = typeof(Dominio.PontaEstoque);
            // 
            // pontaEstoqueDataGridView
            // 
            this.pontaEstoqueDataGridView.AllowUserToAddRows = false;
            this.pontaEstoqueDataGridView.AllowUserToDeleteRows = false;
            this.pontaEstoqueDataGridView.AutoGenerateColumns = false;
            this.pontaEstoqueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pontaEstoqueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.pontaEstoqueDataGridView.DataSource = this.pontaEstoqueBindingSource;
            this.pontaEstoqueDataGridView.Location = new System.Drawing.Point(7, 178);
            this.pontaEstoqueDataGridView.Name = "pontaEstoqueDataGridView";
            this.pontaEstoqueDataGridView.ReadOnly = true;
            this.pontaEstoqueDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pontaEstoqueDataGridView.Size = new System.Drawing.Size(531, 184);
            this.pontaEstoqueDataGridView.TabIndex = 21;
            this.pontaEstoqueDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodPontaEstoque";
            this.dataGridViewTextBoxColumn1.HeaderText = "CodPontaEstoque";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CodProduto";
            this.dataGridViewTextBoxColumn2.HeaderText = "CodProduto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Quantidade";
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Caracteristica";
            this.dataGridViewTextBoxColumn4.HeaderText = "Característica";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(12, 368);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // caracteristicaTextBox
            // 
            this.caracteristicaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.caracteristicaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pontaEstoqueBindingSource, "Caracteristica", true));
            this.caracteristicaTextBox.Location = new System.Drawing.Point(131, 131);
            this.caracteristicaTextBox.Name = "caracteristicaTextBox";
            this.caracteristicaTextBox.Size = new System.Drawing.Size(407, 20);
            this.caracteristicaTextBox.TabIndex = 16;
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pontaEstoqueBindingSource, "Quantidade", true));
            this.quantidadeTextBox.Location = new System.Drawing.Point(7, 131);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(100, 20);
            this.quantidadeTextBox.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(466, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(385, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "F12 - Navegar";
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "CodProduto", true));
            this.codProdutoTextBox.Location = new System.Drawing.Point(7, 80);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.ReadOnly = true;
            this.codProdutoTextBox.Size = new System.Drawing.Size(100, 20);
            this.codProdutoTextBox.TabIndex = 66;
            this.codProdutoTextBox.TabStop = false;
            this.codProdutoTextBox.TextChanged += new System.EventHandler(this.codProdutoTextBox_TextChanged);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(131, 80);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.ReadOnly = true;
            this.nomeTextBox.Size = new System.Drawing.Size(407, 20);
            this.nomeTextBox.TabIndex = 67;
            this.nomeTextBox.TabStop = false;
            // 
            // tb_produtoBindingNavigator
            // 
            this.tb_produtoBindingNavigator.AddNewItem = null;
            this.tb_produtoBindingNavigator.BindingSource = this.produtoBindingSource;
            this.tb_produtoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_produtoBindingNavigator.DeleteItem = null;
            this.tb_produtoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_produtoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_produtoBindingNavigator.Location = new System.Drawing.Point(342, 42);
            this.tb_produtoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_produtoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_produtoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_produtoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_produtoBindingNavigator.Name = "tb_produtoBindingNavigator";
            this.tb_produtoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_produtoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_produtoBindingNavigator.TabIndex = 90;
            this.tb_produtoBindingNavigator.Text = "bindingNavigator1";
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
            // FrmPontaEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 394);
            this.Controls.Add(this.tb_produtoBindingNavigator);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(quantidadeLabel);
            this.Controls.Add(this.quantidadeTextBox);
            this.Controls.Add(nomeProdutoLabel);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(caracteristicaLabel);
            this.Controls.Add(this.caracteristicaTextBox);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pontaEstoqueDataGridView);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmPontaEstoque";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Ponta Estoques de Produtos";
            this.Load += new System.EventHandler(this.FrmPontaEstoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPontaEstoque_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).EndInit();
            this.tb_produtoBindingNavigator.ResumeLayout(false);
            this.tb_produtoBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.Panel panel1;
         private System.Windows.Forms.Button btnSalvar;
         private System.Windows.Forms.Button btnCancelar;
         private System.Windows.Forms.Button btnNovo;
         private System.Windows.Forms.BindingSource pontaEstoqueBindingSource;
         private System.Windows.Forms.DataGridView pontaEstoqueDataGridView;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
         private System.Windows.Forms.Button btnBuscar;
         private System.Windows.Forms.TextBox caracteristicaTextBox;
         private System.Windows.Forms.TextBox quantidadeTextBox;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.Label label6;
         private System.Windows.Forms.BindingSource produtoBindingSource;
         private System.Windows.Forms.TextBox codProdutoTextBox;
         private System.Windows.Forms.TextBox nomeTextBox;
         private System.Windows.Forms.BindingNavigator tb_produtoBindingNavigator;
         private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
         private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
     }
 }