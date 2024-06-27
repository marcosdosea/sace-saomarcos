namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codCartaoLabel;
            Label nomeLabel;
            Label codContaBancoLabel;
            Label diaBaseLabel;
            Label codPessoaLabel;
            Label mapeamentoLabel;
            Label descontoLabel;
            Label mapeamentoCapptaLabel;
            Label tipoCartaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCartaoCredito));
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            tb_cartao_creditoBindingNavigator = new BindingNavigator(components);
            cartaoCreditoBindingSource = new BindingSource(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            codCartaoTextBox = new TextBox();
            nomeTextBox = new TextBox();
            diaBaseTextBox = new TextBox();
            codContaBancoComboBox = new ComboBox();
            contaBancoBindingSource = new BindingSource(components);
            codPessoaComboBox = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            mapeamentoTextBox = new TextBox();
            descontoTextBox = new TextBox();
            mapeamentoCapptaTextBox = new TextBox();
            tipoCartaoComboBox = new ComboBox();
            codCartaoLabel = new Label();
            nomeLabel = new Label();
            codContaBancoLabel = new Label();
            diaBaseLabel = new Label();
            codPessoaLabel = new Label();
            mapeamentoLabel = new Label();
            descontoLabel = new Label();
            mapeamentoCapptaLabel = new Label();
            tipoCartaoLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_cartao_creditoBindingNavigator).BeginInit();
            tb_cartao_creditoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cartaoCreditoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contaBancoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // codCartaoLabel
            // 
            codCartaoLabel.AutoSize = true;
            codCartaoLabel.Location = new Point(11, 83);
            codCartaoLabel.Margin = new Padding(4, 0, 4, 0);
            codCartaoLabel.Name = "codCartaoLabel";
            codCartaoLabel.Size = new Size(87, 20);
            codCartaoLabel.TabIndex = 20;
            codCartaoLabel.Text = "Cód Cartão:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(173, 83);
            nomeLabel.Margin = new Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(53, 20);
            nomeLabel.TabIndex = 21;
            nomeLabel.Text = "Nome:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Location = new Point(11, 231);
            codContaBancoLabel.Margin = new Padding(4, 0, 4, 0);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new Size(96, 20);
            codContaBancoLabel.TabIndex = 22;
            codContaBancoLabel.Text = "Conta Banco:";
            // 
            // diaBaseLabel
            // 
            diaBaseLabel.AutoSize = true;
            diaBaseLabel.Location = new Point(477, 235);
            diaBaseLabel.Margin = new Padding(4, 0, 4, 0);
            diaBaseLabel.Name = "diaBaseLabel";
            diaBaseLabel.Size = new Size(143, 20);
            diaBaseLabel.TabIndex = 23;
            diaBaseLabel.Text = "Qtd Dias Para Pagar:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new Point(173, 162);
            codPessoaLabel.Margin = new Padding(4, 0, 4, 0);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new Size(155, 20);
            codPessoaLabel.TabIndex = 31;
            codPessoaLabel.Text = "Empresa Responsável:";
            // 
            // mapeamentoLabel
            // 
            mapeamentoLabel.AutoSize = true;
            mapeamentoLabel.Location = new Point(11, 298);
            mapeamentoLabel.Margin = new Padding(4, 0, 4, 0);
            mapeamentoLabel.Name = "mapeamentoLabel";
            mapeamentoLabel.Size = new Size(176, 20);
            mapeamentoLabel.TabIndex = 33;
            mapeamentoLabel.Text = "Mapeamento Markssyste:";
            // 
            // descontoLabel
            // 
            descontoLabel.AutoSize = true;
            descontoLabel.Location = new Point(385, 232);
            descontoLabel.Margin = new Padding(4, 0, 4, 0);
            descontoLabel.Name = "descontoLabel";
            descontoLabel.Size = new Size(75, 20);
            descontoLabel.TabIndex = 34;
            descontoLabel.Text = "Desconto:";
            // 
            // mapeamentoCapptaLabel
            // 
            mapeamentoCapptaLabel.AutoSize = true;
            mapeamentoCapptaLabel.Location = new Point(201, 298);
            mapeamentoCapptaLabel.Margin = new Padding(4, 0, 4, 0);
            mapeamentoCapptaLabel.Name = "mapeamentoCapptaLabel";
            mapeamentoCapptaLabel.Size = new Size(153, 20);
            mapeamentoCapptaLabel.TabIndex = 34;
            mapeamentoCapptaLabel.Text = "Mapeamento Cappta:";
            // 
            // tipoCartaoLabel
            // 
            tipoCartaoLabel.AutoSize = true;
            tipoCartaoLabel.Location = new Point(11, 162);
            tipoCartaoLabel.Margin = new Padding(4, 0, 4, 0);
            tipoCartaoLabel.Name = "tipoCartaoLabel";
            tipoCartaoLabel.Size = new Size(90, 20);
            tipoCartaoLabel.TabIndex = 35;
            tipoCartaoLabel.Text = "Tipo Cartao:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(307, 28);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Cartões de Crédito";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 63);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(405, 380);
            btnSalvar.Margin = new Padding(4, 5, 4, 5);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(108, 35);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(5, 380);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 35);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(513, 380);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 35);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(105, 380);
            btnNovo.Margin = new Padding(4, 5, 4, 5);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 35);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(305, 380);
            btnExcluir.Margin = new Padding(4, 5, 4, 5);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 35);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(205, 380);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // tb_cartao_creditoBindingNavigator
            // 
            tb_cartao_creditoBindingNavigator.AddNewItem = null;
            tb_cartao_creditoBindingNavigator.BindingSource = cartaoCreditoBindingSource;
            tb_cartao_creditoBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_cartao_creditoBindingNavigator.DeleteItem = null;
            tb_cartao_creditoBindingNavigator.Dock = DockStyle.None;
            tb_cartao_creditoBindingNavigator.ImageScalingSize = new Size(20, 20);
            tb_cartao_creditoBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_cartao_creditoBindingNavigator.Location = new Point(360, 62);
            tb_cartao_creditoBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_cartao_creditoBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_cartao_creditoBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_cartao_creditoBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_cartao_creditoBindingNavigator.Name = "tb_cartao_creditoBindingNavigator";
            tb_cartao_creditoBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_cartao_creditoBindingNavigator.Size = new Size(262, 27);
            tb_cartao_creditoBindingNavigator.TabIndex = 24;
            tb_cartao_creditoBindingNavigator.Text = "bindingNavigator1";
            // 
            // cartaoCreditoBindingSource
            // 
            cartaoCreditoBindingSource.DataSource = typeof(Dominio.CartaoCredito);
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(48, 24);
            bindingNavigatorCountItem.Text = "de {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(29, 24);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(29, 24);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(65, 27);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(29, 24);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(29, 24);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 27);
            // 
            // codCartaoTextBox
            // 
            codCartaoTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "CodCartao", true));
            codCartaoTextBox.Location = new Point(15, 111);
            codCartaoTextBox.Margin = new Padding(4, 5, 4, 5);
            codCartaoTextBox.Name = "codCartaoTextBox";
            codCartaoTextBox.Size = new Size(149, 27);
            codCartaoTextBox.TabIndex = 25;
            codCartaoTextBox.Enter += codCartaoTextBox_Enter;
            codCartaoTextBox.Leave += codCartaoTextBox_Leave;
            // 
            // nomeTextBox
            // 
            nomeTextBox.CharacterCasing = CharacterCasing.Upper;
            nomeTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "Nome", true));
            nomeTextBox.Location = new Point(177, 111);
            nomeTextBox.Margin = new Padding(4, 5, 4, 5);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(447, 27);
            nomeTextBox.TabIndex = 27;
            nomeTextBox.Enter += codCartaoTextBox_Enter;
            nomeTextBox.Leave += nomeTextBox_Leave;
            // 
            // diaBaseTextBox
            // 
            diaBaseTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "DiaBase", true));
            diaBaseTextBox.Location = new Point(481, 260);
            diaBaseTextBox.Margin = new Padding(4, 5, 4, 5);
            diaBaseTextBox.Name = "diaBaseTextBox";
            diaBaseTextBox.Size = new Size(137, 27);
            diaBaseTextBox.TabIndex = 33;
            diaBaseTextBox.Enter += codCartaoTextBox_Enter;
            diaBaseTextBox.Leave += codCartaoTextBox_Leave;
            // 
            // codContaBancoComboBox
            // 
            codContaBancoComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codContaBancoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codContaBancoComboBox.DataBindings.Add(new Binding("SelectedValue", cartaoCreditoBindingSource, "CodContaBanco", true));
            codContaBancoComboBox.DataSource = contaBancoBindingSource;
            codContaBancoComboBox.DisplayMember = "Descricao";
            codContaBancoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            codContaBancoComboBox.FormattingEnabled = true;
            codContaBancoComboBox.Location = new Point(15, 258);
            codContaBancoComboBox.Margin = new Padding(4, 5, 4, 5);
            codContaBancoComboBox.Name = "codContaBancoComboBox";
            codContaBancoComboBox.Size = new Size(365, 28);
            codContaBancoComboBox.TabIndex = 31;
            codContaBancoComboBox.ValueMember = "codContaBanco";
            codContaBancoComboBox.Enter += codCartaoTextBox_Enter;
            codContaBancoComboBox.KeyPress += codContaBancoComboBox_KeyPress;
            codContaBancoComboBox.Leave += codCartaoTextBox_Leave;
            // 
            // contaBancoBindingSource
            // 
            contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
            // 
            // codPessoaComboBox
            // 
            codPessoaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codPessoaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codPessoaComboBox.DataBindings.Add(new Binding("SelectedValue", cartaoCreditoBindingSource, "CodPessoa", true));
            codPessoaComboBox.DataSource = pessoaBindingSource;
            codPessoaComboBox.DisplayMember = "NomeFantasia";
            codPessoaComboBox.FormattingEnabled = true;
            codPessoaComboBox.Location = new Point(177, 186);
            codPessoaComboBox.Margin = new Padding(4, 5, 4, 5);
            codPessoaComboBox.Name = "codPessoaComboBox";
            codPessoaComboBox.Size = new Size(447, 28);
            codPessoaComboBox.TabIndex = 29;
            codPessoaComboBox.ValueMember = "CodPessoa";
            codPessoaComboBox.Enter += codCartaoTextBox_Enter;
            codPessoaComboBox.KeyPress += codContaBancoComboBox_KeyPress;
            codPessoaComboBox.Leave += codPessoaComboBox_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // mapeamentoTextBox
            // 
            mapeamentoTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "Mapeamento", true));
            mapeamentoTextBox.Location = new Point(15, 326);
            mapeamentoTextBox.Margin = new Padding(4, 5, 4, 5);
            mapeamentoTextBox.Name = "mapeamentoTextBox";
            mapeamentoTextBox.Size = new Size(165, 27);
            mapeamentoTextBox.TabIndex = 34;
            mapeamentoTextBox.Enter += codCartaoTextBox_Enter;
            mapeamentoTextBox.Leave += codCartaoTextBox_Leave;
            // 
            // descontoTextBox
            // 
            descontoTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "Desconto", true, DataSourceUpdateMode.OnValidation, null, "N2"));
            descontoTextBox.Location = new Point(389, 260);
            descontoTextBox.Margin = new Padding(4, 5, 4, 5);
            descontoTextBox.Name = "descontoTextBox";
            descontoTextBox.Size = new Size(83, 27);
            descontoTextBox.TabIndex = 32;
            descontoTextBox.Enter += codCartaoTextBox_Enter;
            descontoTextBox.Leave += codCartaoTextBox_Leave;
            // 
            // mapeamentoCapptaTextBox
            // 
            mapeamentoCapptaTextBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "MapeamentoCappta", true));
            mapeamentoCapptaTextBox.Location = new Point(205, 326);
            mapeamentoCapptaTextBox.Margin = new Padding(4, 5, 4, 5);
            mapeamentoCapptaTextBox.Name = "mapeamentoCapptaTextBox";
            mapeamentoCapptaTextBox.Size = new Size(419, 27);
            mapeamentoCapptaTextBox.TabIndex = 35;
            // 
            // tipoCartaoComboBox
            // 
            tipoCartaoComboBox.DataBindings.Add(new Binding("Text", cartaoCreditoBindingSource, "TipoCartao", true));
            tipoCartaoComboBox.DataBindings.Add(new Binding("SelectedValue", cartaoCreditoBindingSource, "TipoCartao", true));
            tipoCartaoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tipoCartaoComboBox.FormattingEnabled = true;
            tipoCartaoComboBox.Items.AddRange(new object[] { "CREDITO", "DEBITO" });
            tipoCartaoComboBox.Location = new Point(15, 186);
            tipoCartaoComboBox.Margin = new Padding(4, 5, 4, 5);
            tipoCartaoComboBox.Name = "tipoCartaoComboBox";
            tipoCartaoComboBox.Size = new Size(149, 28);
            tipoCartaoComboBox.TabIndex = 28;
            // 
            // FrmCartaoCredito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 446);
            Controls.Add(tipoCartaoLabel);
            Controls.Add(tipoCartaoComboBox);
            Controls.Add(mapeamentoCapptaLabel);
            Controls.Add(mapeamentoCapptaTextBox);
            Controls.Add(descontoLabel);
            Controls.Add(descontoTextBox);
            Controls.Add(mapeamentoLabel);
            Controls.Add(mapeamentoTextBox);
            Controls.Add(codPessoaLabel);
            Controls.Add(codPessoaComboBox);
            Controls.Add(codContaBancoComboBox);
            Controls.Add(tb_cartao_creditoBindingNavigator);
            Controls.Add(codCartaoTextBox);
            Controls.Add(nomeTextBox);
            Controls.Add(diaBaseTextBox);
            Controls.Add(diaBaseLabel);
            Controls.Add(codContaBancoLabel);
            Controls.Add(nomeLabel);
            Controls.Add(codCartaoLabel);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmCartaoCredito";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Cartões de Crédito";
            Load += FrmCartaoCredito_Load;
            KeyDown += FrmCartaoCredito_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_cartao_creditoBindingNavigator).EndInit();
            tb_cartao_creditoBindingNavigator.ResumeLayout(false);
            tb_cartao_creditoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cartaoCreditoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)contaBancoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
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
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox mapeamentoTextBox;
        private System.Windows.Forms.BindingSource cartaoCreditoBindingSource;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox mapeamentoCapptaTextBox;
        private System.Windows.Forms.ComboBox tipoCartaoComboBox;
    }
}