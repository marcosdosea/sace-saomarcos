﻿namespace Sace
{
    partial class FrmPlanoConta
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
            System.Windows.Forms.Label codPlanoContaLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label diaBaseLabel;
            System.Windows.Forms.Label codGrupoContaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanoConta));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.planoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_plano_contaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codPlanoContaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.diaBaseTextBox = new System.Windows.Forms.TextBox();
            this.codGrupoContaComboBox = new System.Windows.Forms.ComboBox();
            this.grupoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbPagar = new System.Windows.Forms.RadioButton();
            this.rbReceber = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            codPlanoContaLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            diaBaseLabel = new System.Windows.Forms.Label();
            codGrupoContaLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_plano_contaBindingNavigator)).BeginInit();
            this.tb_plano_contaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codPlanoContaLabel
            // 
            codPlanoContaLabel.AutoSize = true;
            codPlanoContaLabel.Location = new System.Drawing.Point(4, 72);
            codPlanoContaLabel.Name = "codPlanoContaLabel";
            codPlanoContaLabel.Size = new System.Drawing.Size(43, 13);
            codPlanoContaLabel.TabIndex = 21;
            codPlanoContaLabel.Text = "Código:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(134, 72);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(58, 13);
            descricaoLabel.TabIndex = 23;
            descricaoLabel.Text = "Descrição:";
            // 
            // diaBaseLabel
            // 
            diaBaseLabel.AutoSize = true;
            diaBaseLabel.Location = new System.Drawing.Point(410, 116);
            diaBaseLabel.Name = "diaBaseLabel";
            diaBaseLabel.Size = new System.Drawing.Size(53, 13);
            diaBaseLabel.TabIndex = 27;
            diaBaseLabel.Text = "Dia Base:";
            // 
            // codGrupoContaLabel
            // 
            codGrupoContaLabel.AutoSize = true;
            codGrupoContaLabel.Location = new System.Drawing.Point(7, 116);
            codGrupoContaLabel.Name = "codGrupoContaLabel";
            codGrupoContaLabel.Size = new System.Drawing.Size(75, 13);
            codGrupoContaLabel.TabIndex = 28;
            codGrupoContaLabel.Text = "Grupo Contas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Plano de Contas";
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
            this.btnSalvar.Location = new System.Drawing.Point(304, 165);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 165);
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
            this.btnCancelar.Location = new System.Drawing.Point(385, 165);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 165);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 165);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 165);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // planoContaBindingSource
            // 
            this.planoContaBindingSource.DataSource = typeof(Dominio.PlanoConta);
            this.planoContaBindingSource.Sort = "codPlanoConta";
            this.planoContaBindingSource.PositionChanged += new System.EventHandler(this.tb_plano_contaBindingSource_PositionChanged);
            // 
            // tb_plano_contaBindingNavigator
            // 
            this.tb_plano_contaBindingNavigator.AddNewItem = null;
            this.tb_plano_contaBindingNavigator.BindingSource = this.planoContaBindingSource;
            this.tb_plano_contaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_plano_contaBindingNavigator.DeleteItem = null;
            this.tb_plano_contaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_plano_contaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_plano_contaBindingNavigator.Location = new System.Drawing.Point(269, 40);
            this.tb_plano_contaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_plano_contaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_plano_contaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_plano_contaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_plano_contaBindingNavigator.Name = "tb_plano_contaBindingNavigator";
            this.tb_plano_contaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_plano_contaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_plano_contaBindingNavigator.TabIndex = 21;
            this.tb_plano_contaBindingNavigator.Text = "bindingNavigator1";
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
            // codPlanoContaTextBox
            // 
            this.codPlanoContaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planoContaBindingSource, "CodPlanoConta", true));
            this.codPlanoContaTextBox.Enabled = false;
            this.codPlanoContaTextBox.Location = new System.Drawing.Point(7, 89);
            this.codPlanoContaTextBox.Name = "codPlanoContaTextBox";
            this.codPlanoContaTextBox.Size = new System.Drawing.Size(121, 20);
            this.codPlanoContaTextBox.TabIndex = 22;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planoContaBindingSource, "Descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(137, 89);
            this.descricaoTextBox.MaxLength = 40;
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(326, 20);
            this.descricaoTextBox.TabIndex = 24;
            this.descricaoTextBox.Leave += new System.EventHandler(this.descricaoTextBox_Leave);
            // 
            // diaBaseTextBox
            // 
            this.diaBaseTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.diaBaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planoContaBindingSource, "DiaBase", true));
            this.diaBaseTextBox.Location = new System.Drawing.Point(413, 134);
            this.diaBaseTextBox.MaxLength = 2;
            this.diaBaseTextBox.Name = "diaBaseTextBox";
            this.diaBaseTextBox.Size = new System.Drawing.Size(50, 20);
            this.diaBaseTextBox.TabIndex = 30;
            // 
            // codGrupoContaComboBox
            // 
            this.codGrupoContaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codGrupoContaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codGrupoContaComboBox.CausesValidation = false;
            this.codGrupoContaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.planoContaBindingSource, "CodGrupoConta", true));
            this.codGrupoContaComboBox.DataSource = this.grupoContaBindingSource;
            this.codGrupoContaComboBox.DisplayMember = "Descricao";
            this.codGrupoContaComboBox.FormattingEnabled = true;
            this.codGrupoContaComboBox.Location = new System.Drawing.Point(10, 134);
            this.codGrupoContaComboBox.Name = "codGrupoContaComboBox";
            this.codGrupoContaComboBox.Size = new System.Drawing.Size(249, 21);
            this.codGrupoContaComboBox.TabIndex = 26;
            this.codGrupoContaComboBox.ValueMember = "CodGrupoConta";
            this.codGrupoContaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codGrupoContaComboBox_KeyPress);
            this.codGrupoContaComboBox.Leave += new System.EventHandler(this.codGrupoContaComboBox_Leave);
            // 
            // grupoContaBindingSource
            // 
            this.grupoContaBindingSource.DataSource = typeof(Dominio.GrupoConta);
            // 
            // rbPagar
            // 
            this.rbPagar.AutoSize = true;
            this.rbPagar.Location = new System.Drawing.Point(13, 14);
            this.rbPagar.Name = "rbPagar";
            this.rbPagar.Size = new System.Drawing.Size(53, 17);
            this.rbPagar.TabIndex = 0;
            this.rbPagar.TabStop = true;
            this.rbPagar.Text = "Pagar";
            this.rbPagar.UseVisualStyleBackColor = true;
            // 
            // rbReceber
            // 
            this.rbReceber.AutoSize = true;
            this.rbReceber.Location = new System.Drawing.Point(65, 13);
            this.rbReceber.Name = "rbReceber";
            this.rbReceber.Size = new System.Drawing.Size(66, 17);
            this.rbReceber.TabIndex = 1;
            this.rbReceber.TabStop = true;
            this.rbReceber.Text = "Receber";
            this.rbReceber.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbReceber);
            this.groupBox1.Controls.Add(this.rbPagar);
            this.groupBox1.Location = new System.Drawing.Point(269, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 38);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // FrmPlanoConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 192);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(codGrupoContaLabel);
            this.Controls.Add(this.codGrupoContaComboBox);
            this.Controls.Add(codPlanoContaLabel);
            this.Controls.Add(this.tb_plano_contaBindingNavigator);
            this.Controls.Add(this.codPlanoContaTextBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(diaBaseLabel);
            this.Controls.Add(this.diaBaseTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmPlanoConta";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Plano de Contas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanoConta_FormClosing);
            this.Load += new System.EventHandler(this.FrmPlanoConta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPlanoConta_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_plano_contaBindingNavigator)).EndInit();
            this.tb_plano_contaBindingNavigator.ResumeLayout(false);
            this.tb_plano_contaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.BindingSource planoContaBindingSource;
        private System.Windows.Forms.BindingNavigator tb_plano_contaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.MaskedTextBox codPlanoContaTextBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox diaBaseTextBox;
        private System.Windows.Forms.ComboBox codGrupoContaComboBox;
        private System.Windows.Forms.BindingSource grupoContaBindingSource;
        private System.Windows.Forms.RadioButton rbPagar;
        private System.Windows.Forms.RadioButton rbReceber;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}