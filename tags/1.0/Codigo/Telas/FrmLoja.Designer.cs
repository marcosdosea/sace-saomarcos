namespace Telas
{
    partial class FrmLoja
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
            System.Windows.Forms.Label codLojaLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label cpf_CnpjLabel;
            System.Windows.Forms.Label ieLabel;
            System.Windows.Forms.Label cidadeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoja));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_lojaTableAdapter = new Dados.saceDataSetTableAdapters.tb_lojaTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_lojaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codLojaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cpf_CnpjTextBox = new System.Windows.Forms.TextBox();
            this.ieTextBox = new System.Windows.Forms.TextBox();
            this.cidadeTextBox = new System.Windows.Forms.TextBox();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            codLojaLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            cpf_CnpjLabel = new System.Windows.Forms.Label();
            ieLabel = new System.Windows.Forms.Label();
            cidadeLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingNavigator)).BeginInit();
            this.tb_lojaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codLojaLabel
            // 
            codLojaLabel.AutoSize = true;
            codLojaLabel.Location = new System.Drawing.Point(6, 72);
            codLojaLabel.Name = "codLojaLabel";
            codLojaLabel.Size = new System.Drawing.Size(43, 13);
            codLojaLabel.TabIndex = 21;
            codLojaLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(120, 72);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(6, 124);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(138, 13);
            codPessoaLabel.TabIndex = 24;
            codPessoaLabel.Text = "Pessoa Jurídica Associada:";
            // 
            // cpf_CnpjLabel
            // 
            cpf_CnpjLabel.AutoSize = true;
            cpf_CnpjLabel.Location = new System.Drawing.Point(6, 172);
            cpf_CnpjLabel.Name = "cpf_CnpjLabel";
            cpf_CnpjLabel.Size = new System.Drawing.Size(31, 13);
            cpf_CnpjLabel.TabIndex = 26;
            cpf_CnpjLabel.Text = "Cnpj:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new System.Drawing.Point(173, 172);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new System.Drawing.Size(97, 13);
            ieLabel.TabIndex = 27;
            ieLabel.Text = "Inscrição Estadual:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new System.Drawing.Point(299, 172);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new System.Drawing.Size(43, 13);
            cidadeLabel.TabIndex = 28;
            cidadeLabel.Text = "Cidade:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Lojas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(302, 219);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(2, 219);
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
            this.btnCancelar.Location = new System.Drawing.Point(383, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(77, 219);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(227, 219);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(152, 219);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_lojaBindingSource
            // 
            this.tb_lojaBindingSource.DataMember = "tb_loja";
            this.tb_lojaBindingSource.DataSource = this.saceDataSet;
            this.tb_lojaBindingSource.Sort = "codLoja";
            // 
            // tb_lojaTableAdapter
            // 
            this.tb_lojaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_cstTableAdapter = null;
            this.tableAdapterManager.tb_documento_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_entrada_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = this.tb_lojaTableAdapter;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_perfilTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = null;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saida_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_produtoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_documentoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_saidaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.tp_tipo_entradaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_lojaBindingNavigator
            // 
            this.tb_lojaBindingNavigator.AddNewItem = null;
            this.tb_lojaBindingNavigator.BindingSource = this.tb_lojaBindingSource;
            this.tb_lojaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_lojaBindingNavigator.DeleteItem = null;
            this.tb_lojaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_lojaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_lojaBindingNavigator.Location = new System.Drawing.Point(272, 41);
            this.tb_lojaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_lojaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_lojaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_lojaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_lojaBindingNavigator.Name = "tb_lojaBindingNavigator";
            this.tb_lojaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_lojaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_lojaBindingNavigator.TabIndex = 21;
            this.tb_lojaBindingNavigator.Text = "bindingNavigator1";
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
            // codLojaTextBox
            // 
            this.codLojaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_lojaBindingSource, "codLoja", true));
            this.codLojaTextBox.Location = new System.Drawing.Point(9, 89);
            this.codLojaTextBox.Name = "codLojaTextBox";
            this.codLojaTextBox.ReadOnly = true;
            this.codLojaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codLojaTextBox.TabIndex = 22;
            this.codLojaTextBox.TabStop = false;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_lojaBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(123, 89);
            this.nomeTextBox.MaxLength = 40;
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(342, 20);
            this.nomeTextBox.TabIndex = 24;
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_lojaBindingSource, "nomePessoa", true));
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_lojaBindingSource, "codPessoa", true));
            this.codPessoaComboBox.DataSource = this.tbpessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "nome";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(9, 141);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(456, 21);
            this.codPessoaComboBox.TabIndex = 25;
            this.codPessoaComboBox.ValueMember = "codPessoa";
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaComboBox_KeyPress);
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // tbpessoaBindingSource
            // 
            this.tbpessoaBindingSource.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // cpf_CnpjTextBox
            // 
            this.cpf_CnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbpessoaBindingSource, "cpf_Cnpj", true));
            this.cpf_CnpjTextBox.Location = new System.Drawing.Point(9, 190);
            this.cpf_CnpjTextBox.Name = "cpf_CnpjTextBox";
            this.cpf_CnpjTextBox.ReadOnly = true;
            this.cpf_CnpjTextBox.Size = new System.Drawing.Size(143, 20);
            this.cpf_CnpjTextBox.TabIndex = 27;
            this.cpf_CnpjTextBox.TabStop = false;
            // 
            // ieTextBox
            // 
            this.ieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbpessoaBindingSource, "ie", true));
            this.ieTextBox.Location = new System.Drawing.Point(170, 190);
            this.ieTextBox.Name = "ieTextBox";
            this.ieTextBox.ReadOnly = true;
            this.ieTextBox.Size = new System.Drawing.Size(100, 20);
            this.ieTextBox.TabIndex = 28;
            this.ieTextBox.TabStop = false;
            // 
            // cidadeTextBox
            // 
            this.cidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbpessoaBindingSource, "cidade", true));
            this.cidadeTextBox.Location = new System.Drawing.Point(302, 190);
            this.cidadeTextBox.Name = "cidadeTextBox";
            this.cidadeTextBox.ReadOnly = true;
            this.cidadeTextBox.Size = new System.Drawing.Size(163, 20);
            this.cidadeTextBox.TabIndex = 29;
            this.cidadeTextBox.TabStop = false;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmLoja
            // 
            this.AccessibleDescription = "\'";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 246);
            this.Controls.Add(cidadeLabel);
            this.Controls.Add(this.cidadeTextBox);
            this.Controls.Add(ieLabel);
            this.Controls.Add(this.ieTextBox);
            this.Controls.Add(cpf_CnpjLabel);
            this.Controls.Add(this.cpf_CnpjTextBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.Controls.Add(codLojaLabel);
            this.Controls.Add(this.tb_lojaBindingNavigator);
            this.Controls.Add(this.codLojaTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmLoja";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Lojas";
            this.Load += new System.EventHandler(this.FrmLoja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLoja_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingNavigator)).EndInit();
            this.tb_lojaBindingNavigator.ResumeLayout(false);
            this.tb_lojaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_lojaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_lojaTableAdapter tb_lojaTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_lojaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.MaskedTextBox codLojaTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox cpf_CnpjTextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
    }
}