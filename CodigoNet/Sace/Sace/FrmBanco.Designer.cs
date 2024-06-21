using Dominio;

namespace Sace
{
    partial class FrmBanco
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
            codBancoLabel = new Label();
            nomeLabel = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            bancoBindingSource = new BindingSource(components);
            codBancoTextBox = new TextBox();
            nomeTextBox = new TextBox();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            tb_bancoBindingNavigator = new BindingNavigator(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bancoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_bancoBindingNavigator).BeginInit();
            tb_bancoBindingNavigator.SuspendLayout();
            SuspendLayout();
            // 
            // codBancoLabel
            // 
            codBancoLabel.AutoSize = true;
            codBancoLabel.Location = new Point(6, 100);
            codBancoLabel.Margin = new Padding(5, 0, 5, 0);
            codBancoLabel.Name = "codBancoLabel";
            codBancoLabel.Size = new Size(61, 20);
            codBancoLabel.TabIndex = 21;
            codBancoLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(169, 100);
            nomeLabel.Margin = new Padding(5, 0, 5, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(53, 20);
            nomeLabel.TabIndex = 22;
            nomeLabel.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(5, 13);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(194, 28);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Bancos";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(5, 4, 5, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 63);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(406, 192);
            btnSalvar.Margin = new Padding(5, 4, 5, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(107, 36);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(6, 192);
            btnBuscar.Margin = new Padding(5, 4, 5, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 36);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(513, 192);
            btnCancelar.Margin = new Padding(5, 4, 5, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 36);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(105, 192);
            btnNovo.Margin = new Padding(5, 4, 5, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(101, 36);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(305, 192);
            btnExcluir.Margin = new Padding(5, 4, 5, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(101, 36);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(206, 192);
            btnEditar.Margin = new Padding(5, 4, 5, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(101, 36);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // bancoBindingSource
            // 
            bancoBindingSource.DataSource = typeof(Banco);
            bancoBindingSource.Sort = "codBanco";
            // 
            // codBancoTextBox
            // 
            codBancoTextBox.DataBindings.Add(new Binding("Text", bancoBindingSource, "CodBanco", true));
            codBancoTextBox.Location = new Point(9, 132);
            codBancoTextBox.Margin = new Padding(5, 4, 5, 4);
            codBancoTextBox.Name = "codBancoTextBox";
            codBancoTextBox.Size = new Size(132, 27);
            codBancoTextBox.TabIndex = 22;
            // 
            // nomeTextBox
            // 
            nomeTextBox.CharacterCasing = CharacterCasing.Upper;
            nomeTextBox.DataBindings.Add(new Binding("Text", bancoBindingSource, "Nome", true));
            nomeTextBox.Location = new Point(174, 132);
            nomeTextBox.Margin = new Padding(5, 4, 5, 4);
            nomeTextBox.MaxLength = 40;
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(451, 27);
            nomeTextBox.TabIndex = 23;
            nomeTextBox.Leave += nomeTextBox_Leave;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            bindingNavigatorMoveFirstItem.Enabled = false;
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(33, 24);
            bindingNavigatorMoveFirstItem.Text = "<<";
            bindingNavigatorMoveFirstItem.ToolTipText = "First item";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            bindingNavigatorMovePreviousItem.Enabled = false;
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(29, 24);
            bindingNavigatorMovePreviousItem.Text = "<";
            bindingNavigatorMovePreviousItem.ToolTipText = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Enabled = false;
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(66, 27);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Enabled = false;
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(48, 24);
            bindingNavigatorCountItem.Text = "de {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            bindingNavigatorMoveNextItem.Enabled = false;
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(29, 24);
            bindingNavigatorMoveNextItem.Text = ">";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            bindingNavigatorMoveLastItem.Enabled = false;
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(33, 24);
            bindingNavigatorMoveLastItem.Text = ">>";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 27);
            // 
            // tb_bancoBindingNavigator
            // 
            tb_bancoBindingNavigator.AddNewItem = null;
            tb_bancoBindingNavigator.BackColor = SystemColors.Control;
            tb_bancoBindingNavigator.BindingSource = bancoBindingSource;
            tb_bancoBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_bancoBindingNavigator.DeleteItem = null;
            tb_bancoBindingNavigator.Dock = DockStyle.None;
            tb_bancoBindingNavigator.ImageScalingSize = new Size(20, 20);
            tb_bancoBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_bancoBindingNavigator.Location = new Point(362, 61);
            tb_bancoBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_bancoBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_bancoBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_bancoBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_bancoBindingNavigator.Name = "tb_bancoBindingNavigator";
            tb_bancoBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_bancoBindingNavigator.Size = new Size(271, 27);
            tb_bancoBindingNavigator.TabIndex = 21;
            tb_bancoBindingNavigator.Text = "bindingNavigator1";
            // 
            // FrmBanco
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 243);
            Controls.Add(nomeLabel);
            Controls.Add(tb_bancoBindingNavigator);
            Controls.Add(nomeTextBox);
            Controls.Add(codBancoLabel);
            Controls.Add(codBancoTextBox);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(5, 4, 5, 4);
            Name = "FrmBanco";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Bancos";
            FormClosing += FrmBanco_FormClosing;
            Load += FrmBanco_Load;
            KeyDown += FrmBanco_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bancoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_bancoBindingNavigator).EndInit();
            tb_bancoBindingNavigator.ResumeLayout(false);
            tb_bancoBindingNavigator.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnSalvar;
        private Button btnBuscar;
        private Button btnCancelar;
        private Button btnNovo;
        private Button btnExcluir;
        private Button btnEditar;
        private BindingSource bancoBindingSource;
        private TextBox codBancoTextBox;
        private TextBox nomeTextBox;
        private Label codBancoLabel;
        private Label nomeLabel;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private BindingNavigator tb_bancoBindingNavigator;
    }
}