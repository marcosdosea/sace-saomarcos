namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codPlanoContaLabel;
            Label descricaoLabel;
            Label diaBaseLabel;
            Label codGrupoContaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanoConta));
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            planoContaBindingSource = new BindingSource(components);
            tb_plano_contaBindingNavigator = new BindingNavigator(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            codPlanoContaTextBox = new MaskedTextBox();
            descricaoTextBox = new TextBox();
            diaBaseTextBox = new TextBox();
            codGrupoContaComboBox = new ComboBox();
            grupoContaBindingSource = new BindingSource(components);
            rbPagar = new RadioButton();
            rbReceber = new RadioButton();
            groupBox1 = new GroupBox();
            codPlanoContaLabel = new Label();
            descricaoLabel = new Label();
            diaBaseLabel = new Label();
            codGrupoContaLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)planoContaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_plano_contaBindingNavigator).BeginInit();
            tb_plano_contaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grupoContaBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // codPlanoContaLabel
            // 
            codPlanoContaLabel.AutoSize = true;
            codPlanoContaLabel.Location = new Point(5, 83);
            codPlanoContaLabel.Margin = new Padding(4, 0, 4, 0);
            codPlanoContaLabel.Name = "codPlanoContaLabel";
            codPlanoContaLabel.Size = new Size(49, 15);
            codPlanoContaLabel.TabIndex = 21;
            codPlanoContaLabel.Text = "Código:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new Point(156, 83);
            descricaoLabel.Margin = new Padding(4, 0, 4, 0);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new Size(61, 15);
            descricaoLabel.TabIndex = 23;
            descricaoLabel.Text = "Descrição:";
            // 
            // diaBaseLabel
            // 
            diaBaseLabel.AutoSize = true;
            diaBaseLabel.Location = new Point(478, 134);
            diaBaseLabel.Margin = new Padding(4, 0, 4, 0);
            diaBaseLabel.Name = "diaBaseLabel";
            diaBaseLabel.Size = new Size(54, 15);
            diaBaseLabel.TabIndex = 27;
            diaBaseLabel.Text = "Dia Base:";
            // 
            // codGrupoContaLabel
            // 
            codGrupoContaLabel.AutoSize = true;
            codGrupoContaLabel.Location = new Point(8, 134);
            codGrupoContaLabel.Margin = new Padding(4, 0, 4, 0);
            codGrupoContaLabel.Name = "codGrupoContaLabel";
            codGrupoContaLabel.Size = new Size(83, 15);
            codGrupoContaLabel.TabIndex = 28;
            codGrupoContaLabel.Text = "Grupo Contas:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(214, 23);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Plano de Contas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 47);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(355, 190);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 27);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(5, 190);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 27);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(449, 190);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 27);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(92, 190);
            btnNovo.Margin = new Padding(4, 3, 4, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 27);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(267, 190);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 27);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(180, 190);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(88, 27);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // planoContaBindingSource
            // 
            planoContaBindingSource.DataSource = typeof(Dominio.PlanoConta);
            planoContaBindingSource.Sort = "codPlanoConta";
            planoContaBindingSource.PositionChanged += tb_plano_contaBindingSource_PositionChanged;
            // 
            // tb_plano_contaBindingNavigator
            // 
            tb_plano_contaBindingNavigator.AddNewItem = null;
            tb_plano_contaBindingNavigator.BindingSource = planoContaBindingSource;
            tb_plano_contaBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_plano_contaBindingNavigator.DeleteItem = null;
            tb_plano_contaBindingNavigator.Dock = DockStyle.None;
            tb_plano_contaBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_plano_contaBindingNavigator.Location = new Point(325, 47);
            tb_plano_contaBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_plano_contaBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_plano_contaBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_plano_contaBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_plano_contaBindingNavigator.Name = "tb_plano_contaBindingNavigator";
            tb_plano_contaBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_plano_contaBindingNavigator.Size = new Size(217, 25);
            tb_plano_contaBindingNavigator.TabIndex = 21;
            tb_plano_contaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(35, 22);
            bindingNavigatorCountItem.Text = "of {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(23, 22);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(23, 22);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(58, 23);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(23, 22);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(23, 22);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 25);
            // 
            // codPlanoContaTextBox
            // 
            codPlanoContaTextBox.DataBindings.Add(new Binding("Text", planoContaBindingSource, "CodPlanoConta", true));
            codPlanoContaTextBox.Enabled = false;
            codPlanoContaTextBox.Location = new Point(8, 103);
            codPlanoContaTextBox.Margin = new Padding(4, 3, 4, 3);
            codPlanoContaTextBox.Name = "codPlanoContaTextBox";
            codPlanoContaTextBox.Size = new Size(140, 23);
            codPlanoContaTextBox.TabIndex = 22;
            // 
            // descricaoTextBox
            // 
            descricaoTextBox.CharacterCasing = CharacterCasing.Upper;
            descricaoTextBox.DataBindings.Add(new Binding("Text", planoContaBindingSource, "Descricao", true));
            descricaoTextBox.Location = new Point(160, 103);
            descricaoTextBox.Margin = new Padding(4, 3, 4, 3);
            descricaoTextBox.MaxLength = 40;
            descricaoTextBox.Name = "descricaoTextBox";
            descricaoTextBox.Size = new Size(380, 23);
            descricaoTextBox.TabIndex = 24;
            descricaoTextBox.Leave += descricaoTextBox_Leave;
            // 
            // diaBaseTextBox
            // 
            diaBaseTextBox.CharacterCasing = CharacterCasing.Upper;
            diaBaseTextBox.DataBindings.Add(new Binding("Text", planoContaBindingSource, "DiaBase", true));
            diaBaseTextBox.Location = new Point(482, 155);
            diaBaseTextBox.Margin = new Padding(4, 3, 4, 3);
            diaBaseTextBox.MaxLength = 2;
            diaBaseTextBox.Name = "diaBaseTextBox";
            diaBaseTextBox.Size = new Size(58, 23);
            diaBaseTextBox.TabIndex = 30;
            // 
            // codGrupoContaComboBox
            // 
            codGrupoContaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codGrupoContaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codGrupoContaComboBox.DataBindings.Add(new Binding("SelectedValue", planoContaBindingSource, "CodGrupoConta", true));
            codGrupoContaComboBox.DataSource = grupoContaBindingSource;
            codGrupoContaComboBox.DisplayMember = "Descricao";
            codGrupoContaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            codGrupoContaComboBox.FormattingEnabled = true;
            codGrupoContaComboBox.Location = new Point(12, 155);
            codGrupoContaComboBox.Margin = new Padding(4, 3, 4, 3);
            codGrupoContaComboBox.Name = "codGrupoContaComboBox";
            codGrupoContaComboBox.Size = new Size(290, 23);
            codGrupoContaComboBox.TabIndex = 26;
            codGrupoContaComboBox.ValueMember = "CodGrupoConta";
            codGrupoContaComboBox.KeyPress += codGrupoContaComboBox_KeyPress;
            codGrupoContaComboBox.Leave += codGrupoContaComboBox_Leave;
            // 
            // grupoContaBindingSource
            // 
            grupoContaBindingSource.DataSource = typeof(Dominio.GrupoConta);
            // 
            // rbPagar
            // 
            rbPagar.AutoSize = true;
            rbPagar.Location = new Point(15, 16);
            rbPagar.Margin = new Padding(4, 3, 4, 3);
            rbPagar.Name = "rbPagar";
            rbPagar.Size = new Size(55, 19);
            rbPagar.TabIndex = 0;
            rbPagar.TabStop = true;
            rbPagar.Text = "Pagar";
            rbPagar.UseVisualStyleBackColor = true;
            // 
            // rbReceber
            // 
            rbReceber.AutoSize = true;
            rbReceber.Location = new Point(76, 15);
            rbReceber.Margin = new Padding(4, 3, 4, 3);
            rbReceber.Name = "rbReceber";
            rbReceber.Size = new Size(67, 19);
            rbReceber.TabIndex = 1;
            rbReceber.TabStop = true;
            rbReceber.Text = "Receber";
            rbReceber.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbReceber);
            groupBox1.Controls.Add(rbPagar);
            groupBox1.Location = new Point(314, 134);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(161, 44);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo";
            // 
            // FrmPlanoConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 222);
            Controls.Add(groupBox1);
            Controls.Add(codGrupoContaLabel);
            Controls.Add(codGrupoContaComboBox);
            Controls.Add(codPlanoContaLabel);
            Controls.Add(tb_plano_contaBindingNavigator);
            Controls.Add(codPlanoContaTextBox);
            Controls.Add(descricaoLabel);
            Controls.Add(descricaoTextBox);
            Controls.Add(diaBaseLabel);
            Controls.Add(diaBaseTextBox);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmPlanoConta";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Plano de Contas";
            FormClosing += FrmPlanoConta_FormClosing;
            Load += FrmPlanoConta_Load;
            KeyDown += FrmPlanoConta_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)planoContaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_plano_contaBindingNavigator).EndInit();
            tb_plano_contaBindingNavigator.ResumeLayout(false);
            tb_plano_contaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grupoContaBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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