namespace SACE.Telas
{
    partial class FrmCartaoCredito
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
            System.Windows.Forms.Label codCartaoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label diaBaseLabel;
            System.Windows.Forms.Label codContaBancoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCartaoCredito));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.tb_cartao_creditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_cartao_creditoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_cartao_creditoTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_conta_bancoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter();
            this.tb_cartao_creditoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codCartaoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.diaBaseTextBox = new System.Windows.Forms.TextBox();
            this.tbcontabancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            codCartaoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            diaBaseLabel = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingNavigator)).BeginInit();
            this.tb_cartao_creditoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbcontabancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codCartaoLabel
            // 
            codCartaoLabel.AutoSize = true;
            codCartaoLabel.Location = new System.Drawing.Point(4, 82);
            codCartaoLabel.Name = "codCartaoLabel";
            codCartaoLabel.Size = new System.Drawing.Size(43, 13);
            codCartaoLabel.TabIndex = 21;
            codCartaoLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(139, 82);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(83, 13);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome Bandeira:";
            // 
            // diaBaseLabel
            // 
            diaBaseLabel.AutoSize = true;
            diaBaseLabel.Location = new System.Drawing.Point(4, 137);
            diaBaseLabel.Name = "diaBaseLabel";
            diaBaseLabel.Size = new System.Drawing.Size(53, 13);
            diaBaseLabel.TabIndex = 25;
            diaBaseLabel.Text = "Dia Base:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Location = new System.Drawing.Point(139, 137);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(72, 13);
            codContaBancoLabel.TabIndex = 27;
            codContaBancoLabel.Text = "Conta Banco:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Cartões de Crédito";
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
            this.btnSalvar.Location = new System.Drawing.Point(305, 188);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(5, 188);
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
            this.btnCancelar.Location = new System.Drawing.Point(386, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(80, 188);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(230, 188);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(155, 188);
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
            // tb_cartao_creditoBindingSource
            // 
            this.tb_cartao_creditoBindingSource.DataMember = "tb_cartao_credito";
            this.tb_cartao_creditoBindingSource.DataSource = this.saceDataSet;
            this.tb_cartao_creditoBindingSource.Sort = "codCartao";
            // 
            // tb_cartao_creditoTableAdapter
            // 
            this.tb_cartao_creditoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = this.tb_cartao_creditoTableAdapter;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = this.tb_conta_bancoTableAdapter;
            this.tableAdapterManager.tb_conta_pagarTableAdapter = null;
            this.tableAdapterManager.tb_conta_receberTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = null;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_recebimentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SACE.Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_conta_bancoTableAdapter
            // 
            this.tb_conta_bancoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_cartao_creditoBindingNavigator
            // 
            this.tb_cartao_creditoBindingNavigator.AddNewItem = null;
            this.tb_cartao_creditoBindingNavigator.BindingSource = this.tb_cartao_creditoBindingSource;
            this.tb_cartao_creditoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_cartao_creditoBindingNavigator.DeleteItem = null;
            this.tb_cartao_creditoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_cartao_creditoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_cartao_creditoBindingNavigator.Location = new System.Drawing.Point(269, 40);
            this.tb_cartao_creditoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_cartao_creditoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_cartao_creditoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_cartao_creditoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_cartao_creditoBindingNavigator.Name = "tb_cartao_creditoBindingNavigator";
            this.tb_cartao_creditoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_cartao_creditoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_cartao_creditoBindingNavigator.TabIndex = 21;
            this.tb_cartao_creditoBindingNavigator.Text = "bindingNavigator1";
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
            // codCartaoTextBox
            // 
            this.codCartaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codCartaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_cartao_creditoBindingSource, "codCartao", true));
            this.codCartaoTextBox.Location = new System.Drawing.Point(7, 99);
            this.codCartaoTextBox.Name = "codCartaoTextBox";
            this.codCartaoTextBox.Size = new System.Drawing.Size(121, 20);
            this.codCartaoTextBox.TabIndex = 22;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_cartao_creditoBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(142, 99);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(320, 20);
            this.nomeTextBox.TabIndex = 24;
            // 
            // diaBaseTextBox
            // 
            this.diaBaseTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.diaBaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_cartao_creditoBindingSource, "diaBase", true));
            this.diaBaseTextBox.Location = new System.Drawing.Point(7, 154);
            this.diaBaseTextBox.Name = "diaBaseTextBox";
            this.diaBaseTextBox.Size = new System.Drawing.Size(121, 20);
            this.diaBaseTextBox.TabIndex = 26;
            // 
            // tbcontabancoBindingSource
            // 
            this.tbcontabancoBindingSource.DataMember = "tb_conta_banco";
            this.tbcontabancoBindingSource.DataSource = this.saceDataSetBindingSource;
            // 
            // saceDataSetBindingSource
            // 
            this.saceDataSetBindingSource.DataSource = this.saceDataSet;
            this.saceDataSetBindingSource.Position = 0;
            // 
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_cartao_creditoBindingSource, "codContaBanco", true));
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_cartao_creditoBindingSource, "codContaBanco", true));
            this.codContaBancoComboBox.DataSource = this.tbcontabancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(142, 153);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(320, 21);
            this.codContaBancoComboBox.TabIndex = 28;
            this.codContaBancoComboBox.ValueMember = "codContaBanco";
            // 
            // FrmCartaoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 215);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(codCartaoLabel);
            this.Controls.Add(this.codCartaoTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(diaBaseLabel);
            this.Controls.Add(this.diaBaseTextBox);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(this.tb_cartao_creditoBindingNavigator);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmCartaoCredito";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Cartões de Crédito";
            this.Load += new System.EventHandler(this.FrmCartaoCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCartaoCredito_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingNavigator)).EndInit();
            this.tb_cartao_creditoBindingNavigator.ResumeLayout(false);
            this.tb_cartao_creditoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbcontabancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetBindingSource)).EndInit();
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
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_cartao_creditoBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_cartao_creditoTableAdapter tb_cartao_creditoTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_cartao_creditoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codCartaoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox diaBaseTextBox;
        private SACE.Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter tb_conta_bancoTableAdapter;
        private System.Windows.Forms.BindingSource saceDataSetBindingSource;
        private System.Windows.Forms.BindingSource tbcontabancoBindingSource;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
    }
}