namespace Telas
{
    partial class FrmProdutoAjusteEstoque
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
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label nomeLojaLabel;
            System.Windows.Forms.Label qtdEstoqueFiscalLabel;
            System.Windows.Forms.Label qtdEstoqueNFiscalLabel;
            System.Windows.Forms.Label localizacaoLabel;
            System.Windows.Forms.Label nomeProdutoLabel;
            System.Windows.Forms.Label localizacao2Label;
            System.Windows.Forms.Label estoqueMaximoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutoAjusteEstoque));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.produtoLojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produto_lojaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.localizacaoTextBox = new System.Windows.Forms.TextBox();
            this.qtdEstoqueTextBox = new System.Windows.Forms.TextBox();
            this.qtdEstoqueAuxTextBox = new System.Windows.Forms.TextBox();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.nomeProdutoTextBox = new System.Windows.Forms.TextBox();
            this.lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codLojaComboBox = new System.Windows.Forms.ComboBox();
            this.localizacao2TextBox = new System.Windows.Forms.TextBox();
            this.estoqueMaximoTextBox = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            codProdutoLabel = new System.Windows.Forms.Label();
            nomeLojaLabel = new System.Windows.Forms.Label();
            qtdEstoqueFiscalLabel = new System.Windows.Forms.Label();
            qtdEstoqueNFiscalLabel = new System.Windows.Forms.Label();
            localizacaoLabel = new System.Windows.Forms.Label();
            nomeProdutoLabel = new System.Windows.Forms.Label();
            localizacao2Label = new System.Windows.Forms.Label();
            estoqueMaximoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaBindingNavigator)).BeginInit();
            this.tb_produto_lojaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(6, 69);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(69, 13);
            codProdutoLabel.TabIndex = 21;
            codProdutoLabel.Text = "Cod Produto:";
            // 
            // nomeLojaLabel
            // 
            nomeLojaLabel.AutoSize = true;
            nomeLojaLabel.Location = new System.Drawing.Point(9, 112);
            nomeLojaLabel.Name = "nomeLojaLabel";
            nomeLojaLabel.Size = new System.Drawing.Size(30, 13);
            nomeLojaLabel.TabIndex = 22;
            nomeLojaLabel.Text = "Loja:";
            // 
            // qtdEstoqueFiscalLabel
            // 
            qtdEstoqueFiscalLabel.AutoSize = true;
            qtdEstoqueFiscalLabel.Location = new System.Drawing.Point(9, 159);
            qtdEstoqueFiscalLabel.Name = "qtdEstoqueFiscalLabel";
            qtdEstoqueFiscalLabel.Size = new System.Drawing.Size(69, 13);
            qtdEstoqueFiscalLabel.TabIndex = 23;
            qtdEstoqueFiscalLabel.Text = "Qtd Estoque:";
            // 
            // qtdEstoqueNFiscalLabel
            // 
            qtdEstoqueNFiscalLabel.AutoSize = true;
            qtdEstoqueNFiscalLabel.Location = new System.Drawing.Point(180, 159);
            qtdEstoqueNFiscalLabel.Name = "qtdEstoqueNFiscalLabel";
            qtdEstoqueNFiscalLabel.Size = new System.Drawing.Size(105, 13);
            qtdEstoqueNFiscalLabel.TabIndex = 25;
            qtdEstoqueNFiscalLabel.Text = "Qtd Estoque Auxiliar:";
            // 
            // localizacaoLabel
            // 
            localizacaoLabel.AutoSize = true;
            localizacaoLabel.Location = new System.Drawing.Point(6, 200);
            localizacaoLabel.Name = "localizacaoLabel";
            localizacaoLabel.Size = new System.Drawing.Size(76, 13);
            localizacaoLabel.TabIndex = 26;
            localizacaoLabel.Text = "Localização 1:";
            // 
            // nomeProdutoLabel
            // 
            nomeProdutoLabel.AutoSize = true;
            nomeProdutoLabel.Location = new System.Drawing.Point(131, 69);
            nomeProdutoLabel.Name = "nomeProdutoLabel";
            nomeProdutoLabel.Size = new System.Drawing.Size(47, 13);
            nomeProdutoLabel.TabIndex = 33;
            nomeProdutoLabel.Text = "Produto:";
            // 
            // localizacao2Label
            // 
            localizacao2Label.AutoSize = true;
            localizacao2Label.Location = new System.Drawing.Point(240, 200);
            localizacao2Label.Name = "localizacao2Label";
            localizacao2Label.Size = new System.Drawing.Size(76, 13);
            localizacao2Label.TabIndex = 34;
            localizacao2Label.Text = "Localizaçao 2:";
            // 
            // estoqueMaximoLabel
            // 
            estoqueMaximoLabel.AutoSize = true;
            estoqueMaximoLabel.Location = new System.Drawing.Point(340, 159);
            estoqueMaximoLabel.Name = "estoqueMaximoLabel";
            estoqueMaximoLabel.Size = new System.Drawing.Size(108, 13);
            estoqueMaximoLabel.TabIndex = 35;
            estoqueMaximoLabel.Text = "Qtd Máxima Estoque:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajuste de Estoque de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(234, 245);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(317, 245);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(157, 245);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 22;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(81, 245);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 21;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // produtoLojaBindingSource
            // 
            this.produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // tb_produto_lojaBindingNavigator
            // 
            this.tb_produto_lojaBindingNavigator.AddNewItem = null;
            this.tb_produto_lojaBindingNavigator.BindingSource = this.produtoLojaBindingSource;
            this.tb_produto_lojaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_produto_lojaBindingNavigator.DeleteItem = null;
            this.tb_produto_lojaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_produto_lojaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_produto_lojaBindingNavigator.Location = new System.Drawing.Point(268, 40);
            this.tb_produto_lojaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_produto_lojaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_produto_lojaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_produto_lojaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_produto_lojaBindingNavigator.Name = "tb_produto_lojaBindingNavigator";
            this.tb_produto_lojaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_produto_lojaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_produto_lojaBindingNavigator.TabIndex = 27;
            this.tb_produto_lojaBindingNavigator.Text = "bindingNavigator1";
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
            // localizacaoTextBox
            // 
            this.localizacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "Localizacao", true));
            this.localizacaoTextBox.Location = new System.Drawing.Point(9, 216);
            this.localizacaoTextBox.Name = "localizacaoTextBox";
            this.localizacaoTextBox.Size = new System.Drawing.Size(213, 20);
            this.localizacaoTextBox.TabIndex = 34;
            this.localizacaoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.localizacaoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.localizacaoTextBox_KeyPress);
            this.localizacaoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // qtdEstoqueTextBox
            // 
            this.qtdEstoqueTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "QtdEstoque", true));
            this.qtdEstoqueTextBox.Location = new System.Drawing.Point(12, 175);
            this.qtdEstoqueTextBox.Name = "qtdEstoqueTextBox";
            this.qtdEstoqueTextBox.Size = new System.Drawing.Size(146, 20);
            this.qtdEstoqueTextBox.TabIndex = 31;
            this.qtdEstoqueTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.qtdEstoqueTextBox.Leave += new System.EventHandler(this.qtdEstoqueTextBox_Leave);
            // 
            // qtdEstoqueAuxTextBox
            // 
            this.qtdEstoqueAuxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "QtdEstoqueAux", true));
            this.qtdEstoqueAuxTextBox.Location = new System.Drawing.Point(183, 175);
            this.qtdEstoqueAuxTextBox.Name = "qtdEstoqueAuxTextBox";
            this.qtdEstoqueAuxTextBox.Size = new System.Drawing.Size(138, 20);
            this.qtdEstoqueAuxTextBox.TabIndex = 32;
            this.qtdEstoqueAuxTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.qtdEstoqueAuxTextBox.Leave += new System.EventHandler(this.qtdEstoqueTextBox_Leave);
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "CodProduto", true));
            this.codProdutoTextBox.Location = new System.Drawing.Point(12, 89);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.ReadOnly = true;
            this.codProdutoTextBox.Size = new System.Drawing.Size(100, 20);
            this.codProdutoTextBox.TabIndex = 33;
            this.codProdutoTextBox.TabStop = false;
            this.codProdutoTextBox.TextChanged += new System.EventHandler(this.codProdutoTextBox_TextChanged);
            this.codProdutoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codProdutoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // nomeProdutoTextBox
            // 
            this.nomeProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "NomeProduto", true));
            this.nomeProdutoTextBox.Location = new System.Drawing.Point(134, 89);
            this.nomeProdutoTextBox.Name = "nomeProdutoTextBox";
            this.nomeProdutoTextBox.ReadOnly = true;
            this.nomeProdutoTextBox.Size = new System.Drawing.Size(328, 20);
            this.nomeProdutoTextBox.TabIndex = 34;
            this.nomeProdutoTextBox.TabStop = false;
            this.nomeProdutoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.nomeProdutoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // lojaBindingSource
            // 
            this.lojaBindingSource.DataSource = typeof(Dominio.Loja);
            // 
            // codLojaComboBox
            // 
            this.codLojaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codLojaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codLojaComboBox.CausesValidation = false;
            this.codLojaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoLojaBindingSource, "CodLoja", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codLojaComboBox.DataSource = this.lojaBindingSource;
            this.codLojaComboBox.DisplayMember = "Nome";
            this.codLojaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codLojaComboBox.Enabled = false;
            this.codLojaComboBox.FormattingEnabled = true;
            this.codLojaComboBox.Location = new System.Drawing.Point(12, 131);
            this.codLojaComboBox.Name = "codLojaComboBox";
            this.codLojaComboBox.Size = new System.Drawing.Size(450, 21);
            this.codLojaComboBox.TabIndex = 28;
            this.codLojaComboBox.ValueMember = "CodLoja";
            this.codLojaComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codLojaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.localizacaoTextBox_KeyPress);
            this.codLojaComboBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // localizacao2TextBox
            // 
            this.localizacao2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.localizacao2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "Localizacao2", true));
            this.localizacao2TextBox.Location = new System.Drawing.Point(243, 216);
            this.localizacao2TextBox.Name = "localizacao2TextBox";
            this.localizacao2TextBox.Size = new System.Drawing.Size(219, 20);
            this.localizacao2TextBox.TabIndex = 35;
            this.localizacao2TextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.localizacao2TextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // estoqueMaximoTextBox
            // 
            this.estoqueMaximoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoLojaBindingSource, "EstoqueMaximo", true));
            this.estoqueMaximoTextBox.Location = new System.Drawing.Point(343, 175);
            this.estoqueMaximoTextBox.Name = "estoqueMaximoTextBox";
            this.estoqueMaximoTextBox.Size = new System.Drawing.Size(119, 20);
            this.estoqueMaximoTextBox.TabIndex = 33;
            this.estoqueMaximoTextBox.Leave += new System.EventHandler(this.qtdEstoqueTextBox_Leave);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 245);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmProdutoAjusteEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 276);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(estoqueMaximoLabel);
            this.Controls.Add(this.estoqueMaximoTextBox);
            this.Controls.Add(localizacao2Label);
            this.Controls.Add(this.localizacao2TextBox);
            this.Controls.Add(this.codLojaComboBox);
            this.Controls.Add(nomeProdutoLabel);
            this.Controls.Add(this.nomeProdutoTextBox);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(this.qtdEstoqueAuxTextBox);
            this.Controls.Add(this.qtdEstoqueTextBox);
            this.Controls.Add(this.localizacaoTextBox);
            this.Controls.Add(this.tb_produto_lojaBindingNavigator);
            this.Controls.Add(localizacaoLabel);
            this.Controls.Add(qtdEstoqueNFiscalLabel);
            this.Controls.Add(qtdEstoqueFiscalLabel);
            this.Controls.Add(nomeLojaLabel);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmProdutoAjusteEstoque";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajuste Estoque";
            this.Load += new System.EventHandler(this.FrmProdutoAjusteEstoque_Load);
            this.Shown += new System.EventHandler(this.FrmProdutoAjusteEstoque_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoAjusteEstoque_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaBindingNavigator)).EndInit();
            this.tb_produto_lojaBindingNavigator.ResumeLayout(false);
            this.tb_produto_lojaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.BindingSource produtoLojaBindingSource;
        private System.Windows.Forms.BindingNavigator tb_produto_lojaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox localizacaoTextBox;
        private System.Windows.Forms.TextBox qtdEstoqueTextBox;
        private System.Windows.Forms.TextBox qtdEstoqueAuxTextBox;
        private System.Windows.Forms.TextBox codProdutoTextBox;
        private System.Windows.Forms.TextBox nomeProdutoTextBox;
        private System.Windows.Forms.BindingSource lojaBindingSource;
        private System.Windows.Forms.ComboBox codLojaComboBox;
        private System.Windows.Forms.TextBox localizacao2TextBox;
        private System.Windows.Forms.TextBox estoqueMaximoTextBox;
        private System.Windows.Forms.Button btnBuscar;
    }
}