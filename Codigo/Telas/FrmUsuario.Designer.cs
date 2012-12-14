namespace Telas
{
    partial class FrmUsuario
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
            System.Windows.Forms.Label senhaLabel;
            System.Windows.Forms.Label senhaLabel1;
            System.Windows.Forms.Label perfilLabel;
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label loginLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_usuarioBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tb_pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.confirmarSenhaTextBox = new System.Windows.Forms.TextBox();
            this.senhaTextBox = new System.Windows.Forms.TextBox();
            this.perfilComboBox = new System.Windows.Forms.ComboBox();
            this.tb_PerfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_usuarioTableAdapter = new Dados.saceDataSetTableAdapters.tb_usuarioTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_perfilTableAdapter = new Dados.saceDataSetTableAdapters.tb_perfilTableAdapter();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            senhaLabel = new System.Windows.Forms.Label();
            senhaLabel1 = new System.Windows.Forms.Label();
            perfilLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            loginLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_usuarioBindingNavigator)).BeginInit();
            this.tb_usuarioBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PerfilBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // senhaLabel
            // 
            senhaLabel.AutoSize = true;
            senhaLabel.Location = new System.Drawing.Point(239, 164);
            senhaLabel.Name = "senhaLabel";
            senhaLabel.Size = new System.Drawing.Size(88, 13);
            senhaLabel.TabIndex = 33;
            senhaLabel.Text = "Confirmar Senha:";
            // 
            // senhaLabel1
            // 
            senhaLabel1.AutoSize = true;
            senhaLabel1.Location = new System.Drawing.Point(7, 164);
            senhaLabel1.Name = "senhaLabel1";
            senhaLabel1.Size = new System.Drawing.Size(41, 13);
            senhaLabel1.TabIndex = 37;
            senhaLabel1.Text = "Senha:";
            // 
            // perfilLabel
            // 
            perfilLabel.AutoSize = true;
            perfilLabel.Location = new System.Drawing.Point(7, 123);
            perfilLabel.Name = "perfilLabel";
            perfilLabel.Size = new System.Drawing.Size(33, 13);
            perfilLabel.TabIndex = 40;
            perfilLabel.Text = "Perfil:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(7, 73);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(45, 13);
            codPessoaLabel.TabIndex = 40;
            codPessoaLabel.Text = "Pessoa:";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new System.Drawing.Point(331, 123);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(36, 13);
            loginLabel.TabIndex = 41;
            loginLabel.Text = "Login:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.usuarioLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 41);
            this.panel1.TabIndex = 21;
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.usuarioLabel.Location = new System.Drawing.Point(3, 9);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(165, 23);
            this.usuarioLabel.TabIndex = 0;
            this.usuarioLabel.Text = "Cadastro de Usuários";
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_usuarioBindingSource
            // 
            this.tb_usuarioBindingSource.DataMember = "tb_usuario";
            this.tb_usuarioBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_usuarioBindingNavigator
            // 
            this.tb_usuarioBindingNavigator.AddNewItem = null;
            this.tb_usuarioBindingNavigator.BindingSource = this.tb_usuarioBindingSource;
            this.tb_usuarioBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_usuarioBindingNavigator.DeleteItem = null;
            this.tb_usuarioBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_usuarioBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_usuarioBindingNavigator.Location = new System.Drawing.Point(274, 42);
            this.tb_usuarioBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_usuarioBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_usuarioBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_usuarioBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_usuarioBindingNavigator.Name = "tb_usuarioBindingNavigator";
            this.tb_usuarioBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_usuarioBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_usuarioBindingNavigator.TabIndex = 22;
            this.tb_usuarioBindingNavigator.Text = "bindingNavigator1";
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
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(306, 210);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 210);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(387, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(81, 210);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 24;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(231, 210);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 26;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(156, 210);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 25;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // tb_pessoaBindingSource
            // 
            this.tb_pessoaBindingSource.DataMember = "tb_pessoa";
            this.tb_pessoaBindingSource.DataSource = this.saceDataSet;
            this.tb_pessoaBindingSource.Sort = "codPessoa";
            // 
            // confirmarSenhaTextBox
            // 
            this.confirmarSenhaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.confirmarSenhaTextBox.Location = new System.Drawing.Point(242, 181);
            this.confirmarSenhaTextBox.MaxLength = 20;
            this.confirmarSenhaTextBox.Name = "confirmarSenhaTextBox";
            this.confirmarSenhaTextBox.Size = new System.Drawing.Size(223, 20);
            this.confirmarSenhaTextBox.TabIndex = 38;
            this.confirmarSenhaTextBox.UseSystemPasswordChar = true;
            // 
            // senhaTextBox
            // 
            this.senhaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.senhaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_usuarioBindingSource, "senha", true));
            this.senhaTextBox.Location = new System.Drawing.Point(9, 181);
            this.senhaTextBox.MaxLength = 20;
            this.senhaTextBox.Name = "senhaTextBox";
            this.senhaTextBox.Size = new System.Drawing.Size(222, 20);
            this.senhaTextBox.TabIndex = 36;
            this.senhaTextBox.UseSystemPasswordChar = true;
            // 
            // perfilComboBox
            // 
            this.perfilComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_usuarioBindingSource, "codPerfil", true));
            this.perfilComboBox.DataSource = this.tb_PerfilBindingSource;
            this.perfilComboBox.DisplayMember = "nome";
            this.perfilComboBox.FormattingEnabled = true;
            this.perfilComboBox.Location = new System.Drawing.Point(10, 140);
            this.perfilComboBox.Name = "perfilComboBox";
            this.perfilComboBox.Size = new System.Drawing.Size(316, 21);
            this.perfilComboBox.TabIndex = 32;
            this.perfilComboBox.ValueMember = "codPerfil";
            this.perfilComboBox.Leave += new System.EventHandler(this.perfilComboBox_Leave);
            // 
            // tb_PerfilBindingSource
            // 
            this.tb_PerfilBindingSource.DataMember = "tb_perfil";
            this.tb_PerfilBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_usuarioTableAdapter
            // 
            this.tb_usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_perfilTableAdapter = this.tb_perfilTableAdapter;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = this.tb_pessoaTableAdapter;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saida_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_produtoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_saidaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = this.tb_usuarioTableAdapter;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_perfilTableAdapter
            // 
            this.tb_perfilTableAdapter.ClearBeforeFill = true;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_usuarioBindingSource, "codPessoa", true));
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_usuarioBindingSource, "nomePessoa", true));
            this.codPessoaComboBox.DataSource = this.tb_pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "nome";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(10, 90);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(455, 21);
            this.codPessoaComboBox.TabIndex = 30;
            this.codPessoaComboBox.ValueMember = "codPessoa";
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // loginTextBox
            // 
            this.loginTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.loginTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_usuarioBindingSource, "login", true));
            this.loginTextBox.Location = new System.Drawing.Point(332, 140);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(133, 20);
            this.loginTextBox.TabIndex = 34;
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 253);
            this.Controls.Add(loginLabel);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.Controls.Add(perfilLabel);
            this.Controls.Add(this.perfilComboBox);
            this.Controls.Add(senhaLabel1);
            this.Controls.Add(this.senhaTextBox);
            this.Controls.Add(senhaLabel);
            this.Controls.Add(this.confirmarSenhaTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.tb_usuarioBindingNavigator);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FrmUsuario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Usuário";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUsuario_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_usuarioBindingNavigator)).EndInit();
            this.tb_usuarioBindingNavigator.ResumeLayout(false);
            this.tb_usuarioBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PerfilBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label usuarioLabel;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_usuarioBindingSource;
        private System.Windows.Forms.BindingNavigator tb_usuarioBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.BindingSource tb_pessoaBindingSource;
        private System.Windows.Forms.TextBox confirmarSenhaTextBox;
        private System.Windows.Forms.TextBox senhaTextBox;
        private System.Windows.Forms.ComboBox perfilComboBox;
        private System.Windows.Forms.BindingSource tb_PerfilBindingSource;
        private Dados.saceDataSetTableAdapters.tb_usuarioTableAdapter tb_usuarioTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Dados.saceDataSetTableAdapters.tb_perfilTableAdapter tb_perfilTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox loginTextBox;
    }
}