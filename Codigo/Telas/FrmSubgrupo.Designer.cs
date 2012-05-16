namespace Telas
{
    partial class FrmSubgrupo
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
            System.Windows.Forms.Label codSubgrupoLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label codGrupoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSubgrupo));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_subgrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_subgrupoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codSubgrupoTextBox = new System.Windows.Forms.TextBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.codGrupoComboBox = new System.Windows.Forms.ComboBox();
            this.tbgrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_grupoTableAdapter = new Dados.saceDataSetTableAdapters.tb_grupoTableAdapter();
            this.tb_subgrupoTableAdapter = new Dados.saceDataSetTableAdapters.tb_subgrupoTableAdapter();
            codSubgrupoLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            codGrupoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoBindingNavigator)).BeginInit();
            this.tb_subgrupoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbgrupoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codSubgrupoLabel
            // 
            codSubgrupoLabel.AutoSize = true;
            codSubgrupoLabel.Location = new System.Drawing.Point(4, 64);
            codSubgrupoLabel.Name = "codSubgrupoLabel";
            codSubgrupoLabel.Size = new System.Drawing.Size(43, 13);
            codSubgrupoLabel.TabIndex = 21;
            codSubgrupoLabel.Text = "Código:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(120, 64);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(58, 13);
            descricaoLabel.TabIndex = 22;
            descricaoLabel.Text = "Descrição:";
            // 
            // codGrupoLabel
            // 
            codGrupoLabel.AutoSize = true;
            codGrupoLabel.Location = new System.Drawing.Point(8, 114);
            codGrupoLabel.Name = "codGrupoLabel";
            codGrupoLabel.Size = new System.Drawing.Size(39, 13);
            codGrupoLabel.TabIndex = 23;
            codGrupoLabel.Text = "Grupo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Subgrupos de Produtos";
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
            this.btnSalvar.Location = new System.Drawing.Point(304, 162);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 162);
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
            this.btnCancelar.Location = new System.Drawing.Point(385, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 162);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 162);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 162);
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
            // tb_subgrupoBindingSource
            // 
            this.tb_subgrupoBindingSource.DataMember = "tb_subgrupo";
            this.tb_subgrupoBindingSource.DataSource = this.saceDataSet;
            this.tb_subgrupoBindingSource.Sort = "codSubgrupo";
            // 
            // tb_subgrupoBindingNavigator
            // 
            this.tb_subgrupoBindingNavigator.AddNewItem = null;
            this.tb_subgrupoBindingNavigator.BindingSource = this.tb_subgrupoBindingSource;
            this.tb_subgrupoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_subgrupoBindingNavigator.DeleteItem = null;
            this.tb_subgrupoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_subgrupoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_subgrupoBindingNavigator.Location = new System.Drawing.Point(270, 41);
            this.tb_subgrupoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_subgrupoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_subgrupoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_subgrupoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_subgrupoBindingNavigator.Name = "tb_subgrupoBindingNavigator";
            this.tb_subgrupoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_subgrupoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_subgrupoBindingNavigator.TabIndex = 21;
            this.tb_subgrupoBindingNavigator.Text = "bindingNavigator1";
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
            // codSubgrupoTextBox
            // 
            this.codSubgrupoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_subgrupoBindingSource, "codSubgrupo", true));
            this.codSubgrupoTextBox.Location = new System.Drawing.Point(7, 84);
            this.codSubgrupoTextBox.Name = "codSubgrupoTextBox";
            this.codSubgrupoTextBox.ReadOnly = true;
            this.codSubgrupoTextBox.Size = new System.Drawing.Size(100, 20);
            this.codSubgrupoTextBox.TabIndex = 22;
            this.codSubgrupoTextBox.TabStop = false;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_subgrupoBindingSource, "descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(123, 85);
            this.descricaoTextBox.MaxLength = 40;
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(346, 20);
            this.descricaoTextBox.TabIndex = 23;
            this.descricaoTextBox.TextChanged += new System.EventHandler(this.descricaoTextBox_TextChanged);
            // 
            // codGrupoComboBox
            // 
            this.codGrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_subgrupoBindingSource, "codGrupo", true));
            this.codGrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_subgrupoBindingSource, "descricaoGrupo", true));
            this.codGrupoComboBox.DataSource = this.tbgrupoBindingSource;
            this.codGrupoComboBox.DisplayMember = "descricao";
            this.codGrupoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codGrupoComboBox.FormattingEnabled = true;
            this.codGrupoComboBox.Location = new System.Drawing.Point(7, 130);
            this.codGrupoComboBox.Name = "codGrupoComboBox";
            this.codGrupoComboBox.Size = new System.Drawing.Size(462, 21);
            this.codGrupoComboBox.TabIndex = 24;
            this.codGrupoComboBox.ValueMember = "codGrupo";
            this.codGrupoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codGrupoComboBox_KeyPress);
            this.codGrupoComboBox.Leave += new System.EventHandler(this.codGrupoComboBox_Leave);
            // 
            // tbgrupoBindingSource
            // 
            this.tbgrupoBindingSource.DataMember = "tb_grupo";
            this.tbgrupoBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_grupoTableAdapter
            // 
            this.tb_grupoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_subgrupoTableAdapter
            // 
            this.tb_subgrupoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmSubgrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 190);
            this.Controls.Add(codGrupoLabel);
            this.Controls.Add(this.codGrupoComboBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(codSubgrupoLabel);
            this.Controls.Add(this.codSubgrupoTextBox);
            this.Controls.Add(this.tb_subgrupoBindingNavigator);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSubgrupo";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Subgrupos de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSubgrupo_FormClosing);
            this.Load += new System.EventHandler(this.FrmSubgrupo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSubgrupo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoBindingNavigator)).EndInit();
            this.tb_subgrupoBindingNavigator.ResumeLayout(false);
            this.tb_subgrupoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbgrupoBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tb_subgrupoBindingSource;
        private System.Windows.Forms.BindingNavigator tb_subgrupoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codSubgrupoTextBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.ComboBox codGrupoComboBox;
        private System.Windows.Forms.BindingSource tbgrupoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_grupoTableAdapter tb_grupoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_subgrupoTableAdapter tb_subgrupoTableAdapter;
    }
}