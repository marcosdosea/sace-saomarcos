namespace Telas
{
    partial class FrmContaBanco
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
            System.Windows.Forms.Label agenciaLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label saldoLabel;
            System.Windows.Forms.Label codBancoLabel;
            System.Windows.Forms.Label numerocontaLabel;
            System.Windows.Forms.Label codContaBancoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContaBanco));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tb_conta_bancoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.contaBancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.agenciaTextBox = new System.Windows.Forms.TextBox();
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.saldoTextBox = new System.Windows.Forms.TextBox();
            this.codBancoComboBox = new System.Windows.Forms.ComboBox();
            this.bancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numerocontaTextBox = new System.Windows.Forms.TextBox();
            this.codContaBancoTextBox = new System.Windows.Forms.TextBox();
            agenciaLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            saldoLabel = new System.Windows.Forms.Label();
            codBancoLabel = new System.Windows.Forms.Label();
            numerocontaLabel = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingNavigator)).BeginInit();
            this.tb_conta_bancoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // agenciaLabel
            // 
            agenciaLabel.AutoSize = true;
            agenciaLabel.Location = new System.Drawing.Point(302, 79);
            agenciaLabel.Name = "agenciaLabel";
            agenciaLabel.Size = new System.Drawing.Size(49, 13);
            agenciaLabel.TabIndex = 25;
            agenciaLabel.Text = "Agência:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(4, 125);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(58, 13);
            descricaoLabel.TabIndex = 27;
            descricaoLabel.Text = "Descrição:";
            // 
            // saldoLabel
            // 
            saldoLabel.AutoSize = true;
            saldoLabel.Location = new System.Drawing.Point(4, 168);
            saldoLabel.Name = "saldoLabel";
            saldoLabel.Size = new System.Drawing.Size(37, 13);
            saldoLabel.TabIndex = 29;
            saldoLabel.Text = "Saldo:";
            // 
            // codBancoLabel
            // 
            codBancoLabel.AutoSize = true;
            codBancoLabel.Location = new System.Drawing.Point(130, 169);
            codBancoLabel.Name = "codBancoLabel";
            codBancoLabel.Size = new System.Drawing.Size(41, 13);
            codBancoLabel.TabIndex = 31;
            codBancoLabel.Text = "Banco:";
            // 
            // numerocontaLabel
            // 
            numerocontaLabel.AutoSize = true;
            numerocontaLabel.Location = new System.Drawing.Point(134, 79);
            numerocontaLabel.Name = "numerocontaLabel";
            numerocontaLabel.Size = new System.Drawing.Size(78, 13);
            numerocontaLabel.TabIndex = 32;
            numerocontaLabel.Text = "Número Conta:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Location = new System.Drawing.Point(5, 79);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(43, 13);
            codContaBancoLabel.TabIndex = 33;
            codContaBancoLabel.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Contas Bancárias / Caixas";
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
            this.btnSalvar.Location = new System.Drawing.Point(304, 214);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 214);
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
            this.btnCancelar.Location = new System.Drawing.Point(385, 214);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 214);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 214);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 214);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // tb_conta_bancoBindingNavigator
            // 
            this.tb_conta_bancoBindingNavigator.AddNewItem = null;
            this.tb_conta_bancoBindingNavigator.BindingSource = this.contaBancoBindingSource;
            this.tb_conta_bancoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_conta_bancoBindingNavigator.DeleteItem = null;
            this.tb_conta_bancoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_conta_bancoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_conta_bancoBindingNavigator.Location = new System.Drawing.Point(269, 40);
            this.tb_conta_bancoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_conta_bancoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_conta_bancoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_conta_bancoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_conta_bancoBindingNavigator.Name = "tb_conta_bancoBindingNavigator";
            this.tb_conta_bancoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_conta_bancoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_conta_bancoBindingNavigator.TabIndex = 21;
            this.tb_conta_bancoBindingNavigator.Text = "bindingNavigator1";
            // 
            // contaBancoBindingSource
            // 
            this.contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
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
            // agenciaTextBox
            // 
            this.agenciaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.agenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "Agencia", true));
            this.agenciaTextBox.Location = new System.Drawing.Point(304, 96);
            this.agenciaTextBox.MaxLength = 20;
            this.agenciaTextBox.Name = "agenciaTextBox";
            this.agenciaTextBox.Size = new System.Drawing.Size(158, 20);
            this.agenciaTextBox.TabIndex = 26;
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "Descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(7, 143);
            this.descricaoTextBox.MaxLength = 40;
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(455, 20);
            this.descricaoTextBox.TabIndex = 28;
            this.descricaoTextBox.Leave += new System.EventHandler(this.descricaoTextBox_Leave);
            // 
            // saldoTextBox
            // 
            this.saldoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.saldoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "Saldo", true));
            this.saldoTextBox.Enabled = false;
            this.saldoTextBox.Location = new System.Drawing.Point(7, 185);
            this.saldoTextBox.MaxLength = 12;
            this.saldoTextBox.Name = "saldoTextBox";
            this.saldoTextBox.Size = new System.Drawing.Size(109, 20);
            this.saldoTextBox.TabIndex = 30;
            // 
            // codBancoComboBox
            // 
            this.codBancoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codBancoComboBox.CausesValidation = false;
            this.codBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contaBancoBindingSource, "CodBanco", true));
            this.codBancoComboBox.DataSource = this.bancoBindingSource;
            this.codBancoComboBox.DisplayMember = "Nome";
            this.codBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codBancoComboBox.FormattingEnabled = true;
            this.codBancoComboBox.Location = new System.Drawing.Point(133, 185);
            this.codBancoComboBox.Name = "codBancoComboBox";
            this.codBancoComboBox.Size = new System.Drawing.Size(329, 21);
            this.codBancoComboBox.TabIndex = 32;
            this.codBancoComboBox.ValueMember = "CodBanco";
            this.codBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codBancoComboBox_KeyPress);
            this.codBancoComboBox.Leave += new System.EventHandler(this.codBancoComboBox_Leave);
            // 
            // bancoBindingSource
            // 
            this.bancoBindingSource.DataSource = typeof(Dominio.Banco);
            this.bancoBindingSource.CurrentItemChanged += new System.EventHandler(this.bancoBindingSource_CurrentItemChanged);
            // 
            // numerocontaTextBox
            // 
            this.numerocontaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numerocontaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "NumeroConta", true));
            this.numerocontaTextBox.Location = new System.Drawing.Point(137, 96);
            this.numerocontaTextBox.Name = "numerocontaTextBox";
            this.numerocontaTextBox.Size = new System.Drawing.Size(147, 20);
            this.numerocontaTextBox.TabIndex = 24;
            // 
            // codContaBancoTextBox
            // 
            this.codContaBancoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "CodContaBanco", true));
            this.codContaBancoTextBox.Location = new System.Drawing.Point(7, 96);
            this.codContaBancoTextBox.Name = "codContaBancoTextBox";
            this.codContaBancoTextBox.ReadOnly = true;
            this.codContaBancoTextBox.Size = new System.Drawing.Size(109, 20);
            this.codContaBancoTextBox.TabIndex = 22;
            this.codContaBancoTextBox.TabStop = false;
            // 
            // FrmContaBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 238);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(this.codContaBancoTextBox);
            this.Controls.Add(numerocontaLabel);
            this.Controls.Add(this.numerocontaTextBox);
            this.Controls.Add(this.codBancoComboBox);
            this.Controls.Add(this.tb_conta_bancoBindingNavigator);
            this.Controls.Add(agenciaLabel);
            this.Controls.Add(this.agenciaTextBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(saldoLabel);
            this.Controls.Add(this.saldoTextBox);
            this.Controls.Add(codBancoLabel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmContaBanco";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Contas Bancárias / Caixas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmContaBanco_FormClosing);
            this.Load += new System.EventHandler(this.FrmContaBanco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContaBanco_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingNavigator)).EndInit();
            this.tb_conta_bancoBindingNavigator.ResumeLayout(false);
            this.tb_conta_bancoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancoBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingNavigator tb_conta_bancoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox agenciaTextBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox saldoTextBox;
        private System.Windows.Forms.ComboBox codBancoComboBox;
        private System.Windows.Forms.TextBox numerocontaTextBox;
        private System.Windows.Forms.TextBox codContaBancoTextBox;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
        private System.Windows.Forms.BindingSource bancoBindingSource;
    }
}