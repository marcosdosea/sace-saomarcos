namespace Sace
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
            components = new System.ComponentModel.Container();
            Label senhaLabel;
            Label senhaLabel1;
            Label perfilLabel;
            Label codPessoaLabel;
            Label loginLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            panel1 = new Panel();
            usuarioLabel = new Label();
            usuarioBindingSource = new BindingSource(components);
            tb_usuarioBindingNavigator = new BindingNavigator(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            pessoaBindingSource = new BindingSource(components);
            confirmarSenhaTextBox = new TextBox();
            senhaTextBox = new TextBox();
            perfilComboBox = new ComboBox();
            perfilBindingSource = new BindingSource(components);
            codPessoaComboBox = new ComboBox();
            loginTextBox = new TextBox();
            senhaLabel = new Label();
            senhaLabel1 = new Label();
            perfilLabel = new Label();
            codPessoaLabel = new Label();
            loginLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_usuarioBindingNavigator).BeginInit();
            tb_usuarioBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)perfilBindingSource).BeginInit();
            SuspendLayout();
            // 
            // senhaLabel
            // 
            senhaLabel.AutoSize = true;
            senhaLabel.Location = new Point(279, 189);
            senhaLabel.Margin = new Padding(4, 0, 4, 0);
            senhaLabel.Name = "senhaLabel";
            senhaLabel.Size = new Size(99, 15);
            senhaLabel.TabIndex = 33;
            senhaLabel.Text = "Confirmar Senha:";
            // 
            // senhaLabel1
            // 
            senhaLabel1.AutoSize = true;
            senhaLabel1.Location = new Point(8, 189);
            senhaLabel1.Margin = new Padding(4, 0, 4, 0);
            senhaLabel1.Name = "senhaLabel1";
            senhaLabel1.Size = new Size(42, 15);
            senhaLabel1.TabIndex = 37;
            senhaLabel1.Text = "Senha:";
            // 
            // perfilLabel
            // 
            perfilLabel.AutoSize = true;
            perfilLabel.Location = new Point(8, 142);
            perfilLabel.Margin = new Padding(4, 0, 4, 0);
            perfilLabel.Name = "perfilLabel";
            perfilLabel.Size = new Size(37, 15);
            perfilLabel.TabIndex = 40;
            perfilLabel.Text = "Perfil:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new Point(8, 84);
            codPessoaLabel.Margin = new Padding(4, 0, 4, 0);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new Size(46, 15);
            codPessoaLabel.TabIndex = 40;
            codPessoaLabel.Text = "Pessoa:";
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(386, 142);
            loginLabel.Margin = new Padding(4, 0, 4, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(40, 15);
            loginLabel.TabIndex = 41;
            loginLabel.Text = "Login:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(usuarioLabel);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(556, 47);
            panel1.TabIndex = 21;
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usuarioLabel.ForeColor = SystemColors.ControlLightLight;
            usuarioLabel.Location = new Point(4, 10);
            usuarioLabel.Margin = new Padding(4, 0, 4, 0);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(165, 23);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Cadastro de Usuários";
            // 
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Dominio.Usuario);
            // 
            // tb_usuarioBindingNavigator
            // 
            tb_usuarioBindingNavigator.AddNewItem = null;
            tb_usuarioBindingNavigator.BindingSource = usuarioBindingSource;
            tb_usuarioBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_usuarioBindingNavigator.DeleteItem = null;
            tb_usuarioBindingNavigator.Dock = DockStyle.None;
            tb_usuarioBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_usuarioBindingNavigator.Location = new Point(320, 48);
            tb_usuarioBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_usuarioBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_usuarioBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_usuarioBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_usuarioBindingNavigator.Name = "tb_usuarioBindingNavigator";
            tb_usuarioBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_usuarioBindingNavigator.Size = new Size(217, 25);
            tb_usuarioBindingNavigator.TabIndex = 22;
            tb_usuarioBindingNavigator.Text = "bindingNavigator1";
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
            // btnSalvar
            // 
            btnSalvar.Location = new Point(358, 242);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 27);
            btnSalvar.TabIndex = 27;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(7, 242);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 27);
            btnBuscar.TabIndex = 23;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(452, 242);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 27);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(95, 242);
            btnNovo.Margin = new Padding(4, 3, 4, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 27);
            btnNovo.TabIndex = 24;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(271, 242);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 27);
            btnExcluir.TabIndex = 26;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(183, 242);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(88, 27);
            btnEditar.TabIndex = 25;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.AllowNew = false;
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            pessoaBindingSource.Sort = "codPessoa";
            // 
            // confirmarSenhaTextBox
            // 
            confirmarSenhaTextBox.CharacterCasing = CharacterCasing.Upper;
            confirmarSenhaTextBox.Location = new Point(282, 209);
            confirmarSenhaTextBox.Margin = new Padding(4, 3, 4, 3);
            confirmarSenhaTextBox.MaxLength = 20;
            confirmarSenhaTextBox.Name = "confirmarSenhaTextBox";
            confirmarSenhaTextBox.Size = new Size(259, 23);
            confirmarSenhaTextBox.TabIndex = 38;
            confirmarSenhaTextBox.UseSystemPasswordChar = true;
            // 
            // senhaTextBox
            // 
            senhaTextBox.CharacterCasing = CharacterCasing.Upper;
            senhaTextBox.DataBindings.Add(new Binding("Text", usuarioBindingSource, "senha", true));
            senhaTextBox.Location = new Point(10, 209);
            senhaTextBox.Margin = new Padding(4, 3, 4, 3);
            senhaTextBox.MaxLength = 20;
            senhaTextBox.Name = "senhaTextBox";
            senhaTextBox.Size = new Size(258, 23);
            senhaTextBox.TabIndex = 36;
            senhaTextBox.UseSystemPasswordChar = true;
            // 
            // perfilComboBox
            // 
            perfilComboBox.DataBindings.Add(new Binding("SelectedValue", usuarioBindingSource, "CodPerfil", true));
            perfilComboBox.DataSource = perfilBindingSource;
            perfilComboBox.DisplayMember = "NomePerfil";
            perfilComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            perfilComboBox.FormattingEnabled = true;
            perfilComboBox.Location = new Point(12, 162);
            perfilComboBox.Margin = new Padding(4, 3, 4, 3);
            perfilComboBox.Name = "perfilComboBox";
            perfilComboBox.Size = new Size(368, 23);
            perfilComboBox.TabIndex = 32;
            perfilComboBox.ValueMember = "IdPerfil";
            perfilComboBox.KeyPress += codPessoaComboBox_KeyPress;
            // 
            // perfilBindingSource
            // 
            perfilBindingSource.AllowNew = false;
            perfilBindingSource.DataSource = typeof(Dominio.Perfil);
            // 
            // codPessoaComboBox
            // 
            codPessoaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codPessoaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codPessoaComboBox.DataBindings.Add(new Binding("SelectedValue", usuarioBindingSource, "CodPessoa", true, DataSourceUpdateMode.OnPropertyChanged));
            codPessoaComboBox.DataSource = pessoaBindingSource;
            codPessoaComboBox.DisplayMember = "Nome";
            codPessoaComboBox.FormattingEnabled = true;
            codPessoaComboBox.Location = new Point(12, 104);
            codPessoaComboBox.Margin = new Padding(4, 3, 4, 3);
            codPessoaComboBox.Name = "codPessoaComboBox";
            codPessoaComboBox.Size = new Size(530, 23);
            codPessoaComboBox.TabIndex = 30;
            codPessoaComboBox.ValueMember = "CodPessoa";
            codPessoaComboBox.KeyPress += codPessoaComboBox_KeyPress;
            // 
            // loginTextBox
            // 
            loginTextBox.CharacterCasing = CharacterCasing.Upper;
            loginTextBox.DataBindings.Add(new Binding("Text", usuarioBindingSource, "login", true));
            loginTextBox.Location = new Point(387, 162);
            loginTextBox.Margin = new Padding(4, 3, 4, 3);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(154, 23);
            loginTextBox.TabIndex = 34;
            loginTextBox.Leave += loginTextBox_Leave;
            // 
            // FrmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 273);
            Controls.Add(loginLabel);
            Controls.Add(loginTextBox);
            Controls.Add(codPessoaLabel);
            Controls.Add(codPessoaComboBox);
            Controls.Add(perfilLabel);
            Controls.Add(perfilComboBox);
            Controls.Add(senhaLabel1);
            Controls.Add(senhaTextBox);
            Controls.Add(senhaLabel);
            Controls.Add(confirmarSenhaTextBox);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(tb_usuarioBindingNavigator);
            Controls.Add(panel1);
            ImeMode = ImeMode.On;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmUsuario";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro Usuário";
            Load += FrmUsuario_Load;
            KeyDown += FrmUsuario_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_usuarioBindingNavigator).EndInit();
            tb_usuarioBindingNavigator.ResumeLayout(false);
            tb_usuarioBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)perfilBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label usuarioLabel;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
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
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.TextBox confirmarSenhaTextBox;
        private System.Windows.Forms.TextBox senhaTextBox;
        private System.Windows.Forms.ComboBox perfilComboBox;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox loginTextBox;
    }
}