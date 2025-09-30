namespace Sace
{
    partial class FrmSaidaNFe
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
            Label observacaoLabel;
            Label justificativaCancelamentoLabel1;
            Label mensagemSituacaoReciboEnvioLabel;
            Label mensagemSitucaoProtocoloCancelamentoLabel;
            Label mensagemSitucaoProtocoloUsoLabel;
            Label numeroLoteEnvioLabel;
            Label numeroProtocoloCancelamentoLabel;
            Label numeroProtocoloUsoLabel;
            Label numeroReciboLabel;
            Label situacaoProtocoloCancelamentoLabel;
            Label situacaoProtocoloUsoLabel;
            Label situacaoReciboEnvioLabel;
            Label dataEmissaoLabel;
            Label numeroProtocoloCartaCorrecaoLabel;
            Label situacaoProtocoloCartaCorrecaoLabel;
            Label mensagemSitucaoCartaCorrecaoLabel;
            Label correcaoLabel;
            Label seqCartaCorrecaoLabel;
            Label codPessoaLabel;
            btnImprimir = new Button();
            btnCancelar = new Button();
            observacaoTextBox = new TextBox();
            btnEnviar = new Button();
            nfeControleDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            DescricaoModelo = new DataGridViewTextBoxColumn();
            NumeroSequenciaNfe = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            DescricaoSituacaoNfe = new DataGridViewTextBoxColumn();
            nfeControleBindingSource = new BindingSource(components);
            btnFechar = new Button();
            justificativaCancelamentoTextBox1 = new TextBox();
            mensagemSituacaoReciboEnvioTextBox = new TextBox();
            mensagemSitucaoProtocoloCancelamentoTextBox = new TextBox();
            mensagemSitucaoProtocoloUsoTextBox = new TextBox();
            numeroLoteEnvioTextBox = new TextBox();
            numeroProtocoloCancelamentoTextBox = new TextBox();
            numeroProtocoloUsoTextBox = new TextBox();
            numeroReciboTextBox = new TextBox();
            situacaoProtocoloCancelamentoTextBox = new TextBox();
            situacaoProtocoloUsoTextBox = new TextBox();
            situacaoReciboEnvioTextBox = new TextBox();
            dataEmissaoDateTimePicker = new DateTimePicker();
            folderBrowserDialogNfe = new FolderBrowserDialog();
            btnSituacao = new Button();
            numeroProtocoloCartaCorrecaoTextBox = new TextBox();
            situacaoProtocoloCartaCorrecaoTextBox = new TextBox();
            mensagemSitucaoCartaCorrecaoTextBox = new TextBox();
            correcaoTextBox = new TextBox();
            btnCartaCorrecao = new Button();
            seqCartaCorrecaoTextBox = new TextBox();
            btnComplementar = new Button();
            btnBuscar = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            codPessoaComboBox = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            observacaoLabel = new Label();
            justificativaCancelamentoLabel1 = new Label();
            mensagemSituacaoReciboEnvioLabel = new Label();
            mensagemSitucaoProtocoloCancelamentoLabel = new Label();
            mensagemSitucaoProtocoloUsoLabel = new Label();
            numeroLoteEnvioLabel = new Label();
            numeroProtocoloCancelamentoLabel = new Label();
            numeroProtocoloUsoLabel = new Label();
            numeroReciboLabel = new Label();
            situacaoProtocoloCancelamentoLabel = new Label();
            situacaoProtocoloUsoLabel = new Label();
            situacaoReciboEnvioLabel = new Label();
            dataEmissaoLabel = new Label();
            numeroProtocoloCartaCorrecaoLabel = new Label();
            situacaoProtocoloCartaCorrecaoLabel = new Label();
            mensagemSitucaoCartaCorrecaoLabel = new Label();
            correcaoLabel = new Label();
            seqCartaCorrecaoLabel = new Label();
            codPessoaLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)nfeControleDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nfeControleBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Font = new Font("Microsoft Sans Serif", 8.25F);
            observacaoLabel.Location = new Point(4, 376);
            observacaoLabel.Margin = new Padding(4, 0, 4, 0);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new Size(92, 13);
            observacaoLabel.TabIndex = 5;
            observacaoLabel.Text = "Dados Adicionais:";
            // 
            // justificativaCancelamentoLabel1
            // 
            justificativaCancelamentoLabel1.AutoSize = true;
            justificativaCancelamentoLabel1.Location = new Point(2, 487);
            justificativaCancelamentoLabel1.Margin = new Padding(4, 0, 4, 0);
            justificativaCancelamentoLabel1.Name = "justificativaCancelamentoLabel1";
            justificativaCancelamentoLabel1.Size = new Size(297, 15);
            justificativaCancelamentoLabel1.TabIndex = 18;
            justificativaCancelamentoLabel1.Text = "Justificativa Cancelamento (Até 24 horas após o envio):";
            // 
            // mensagemSituacaoReciboEnvioLabel
            // 
            mensagemSituacaoReciboEnvioLabel.AutoSize = true;
            mensagemSituacaoReciboEnvioLabel.Location = new Point(486, 201);
            mensagemSituacaoReciboEnvioLabel.Margin = new Padding(4, 0, 4, 0);
            mensagemSituacaoReciboEnvioLabel.Name = "mensagemSituacaoReciboEnvioLabel";
            mensagemSituacaoReciboEnvioLabel.Size = new Size(69, 15);
            mensagemSituacaoReciboEnvioLabel.TabIndex = 20;
            mensagemSituacaoReciboEnvioLabel.Text = "Mensagem:";
            // 
            // mensagemSitucaoProtocoloCancelamentoLabel
            // 
            mensagemSitucaoProtocoloCancelamentoLabel.AutoSize = true;
            mensagemSitucaoProtocoloCancelamentoLabel.Location = new Point(486, 276);
            mensagemSitucaoProtocoloCancelamentoLabel.Margin = new Padding(4, 0, 4, 0);
            mensagemSitucaoProtocoloCancelamentoLabel.Name = "mensagemSitucaoProtocoloCancelamentoLabel";
            mensagemSitucaoProtocoloCancelamentoLabel.Size = new Size(69, 15);
            mensagemSitucaoProtocoloCancelamentoLabel.TabIndex = 22;
            mensagemSitucaoProtocoloCancelamentoLabel.Text = "Mensagem:";
            // 
            // mensagemSitucaoProtocoloUsoLabel
            // 
            mensagemSitucaoProtocoloUsoLabel.AutoSize = true;
            mensagemSitucaoProtocoloUsoLabel.Location = new Point(486, 237);
            mensagemSitucaoProtocoloUsoLabel.Margin = new Padding(4, 0, 4, 0);
            mensagemSitucaoProtocoloUsoLabel.Name = "mensagemSitucaoProtocoloUsoLabel";
            mensagemSitucaoProtocoloUsoLabel.Size = new Size(69, 15);
            mensagemSitucaoProtocoloUsoLabel.TabIndex = 24;
            mensagemSitucaoProtocoloUsoLabel.Text = "Mensagem:";
            // 
            // numeroLoteEnvioLabel
            // 
            numeroLoteEnvioLabel.AutoSize = true;
            numeroLoteEnvioLabel.Location = new Point(40, 170);
            numeroLoteEnvioLabel.Margin = new Padding(4, 0, 4, 0);
            numeroLoteEnvioLabel.Name = "numeroLoteEnvioLabel";
            numeroLoteEnvioLabel.Size = new Size(65, 15);
            numeroLoteEnvioLabel.TabIndex = 26;
            numeroLoteEnvioLabel.Text = "Lote Envio:";
            // 
            // numeroProtocoloCancelamentoLabel
            // 
            numeroProtocoloCancelamentoLabel.AutoSize = true;
            numeroProtocoloCancelamentoLabel.Location = new Point(-1, 276);
            numeroProtocoloCancelamentoLabel.Margin = new Padding(4, 0, 4, 0);
            numeroProtocoloCancelamentoLabel.Name = "numeroProtocoloCancelamentoLabel";
            numeroProtocoloCancelamentoLabel.Size = new Size(112, 15);
            numeroProtocoloCancelamentoLabel.TabIndex = 28;
            numeroProtocoloCancelamentoLabel.Text = "Prot Cancelamento:";
            // 
            // numeroProtocoloUsoLabel
            // 
            numeroProtocoloUsoLabel.AutoSize = true;
            numeroProtocoloUsoLabel.Location = new Point(20, 237);
            numeroProtocoloUsoLabel.Margin = new Padding(4, 0, 4, 0);
            numeroProtocoloUsoLabel.Name = "numeroProtocoloUsoLabel";
            numeroProtocoloUsoLabel.Size = new Size(85, 15);
            numeroProtocoloUsoLabel.TabIndex = 30;
            numeroProtocoloUsoLabel.Text = "Protocolo Uso:";
            // 
            // numeroReciboLabel
            // 
            numeroReciboLabel.AutoSize = true;
            numeroReciboLabel.Location = new Point(58, 201);
            numeroReciboLabel.Margin = new Padding(4, 0, 4, 0);
            numeroReciboLabel.Name = "numeroReciboLabel";
            numeroReciboLabel.Size = new Size(46, 15);
            numeroReciboLabel.TabIndex = 32;
            numeroReciboLabel.Text = "Recibo:";
            // 
            // situacaoProtocoloCancelamentoLabel
            // 
            situacaoProtocoloCancelamentoLabel.AutoSize = true;
            situacaoProtocoloCancelamentoLabel.Location = new Point(262, 276);
            situacaoProtocoloCancelamentoLabel.Margin = new Padding(4, 0, 4, 0);
            situacaoProtocoloCancelamentoLabel.Name = "situacaoProtocoloCancelamentoLabel";
            situacaoProtocoloCancelamentoLabel.Size = new Size(135, 15);
            situacaoProtocoloCancelamentoLabel.TabIndex = 36;
            situacaoProtocoloCancelamentoLabel.Text = "Situacao Cancelamento:";
            // 
            // situacaoProtocoloUsoLabel
            // 
            situacaoProtocoloUsoLabel.AutoSize = true;
            situacaoProtocoloUsoLabel.Location = new Point(265, 234);
            situacaoProtocoloUsoLabel.Margin = new Padding(4, 0, 4, 0);
            situacaoProtocoloUsoLabel.Name = "situacaoProtocoloUsoLabel";
            situacaoProtocoloUsoLabel.Size = new Size(133, 15);
            situacaoProtocoloUsoLabel.TabIndex = 38;
            situacaoProtocoloUsoLabel.Text = "Situacao Protocolo Uso:";
            // 
            // situacaoReciboEnvioLabel
            // 
            situacaoReciboEnvioLabel.AutoSize = true;
            situacaoReciboEnvioLabel.Location = new Point(301, 201);
            situacaoReciboEnvioLabel.Margin = new Padding(4, 0, 4, 0);
            situacaoReciboEnvioLabel.Name = "situacaoReciboEnvioLabel";
            situacaoReciboEnvioLabel.Size = new Size(94, 15);
            situacaoReciboEnvioLabel.TabIndex = 40;
            situacaoReciboEnvioLabel.Text = "Situacao Recibo:";
            // 
            // dataEmissaoLabel
            // 
            dataEmissaoLabel.AutoSize = true;
            dataEmissaoLabel.Location = new Point(318, 165);
            dataEmissaoLabel.Margin = new Padding(4, 0, 4, 0);
            dataEmissaoLabel.Name = "dataEmissaoLabel";
            dataEmissaoLabel.Size = new Size(80, 15);
            dataEmissaoLabel.TabIndex = 41;
            dataEmissaoLabel.Text = "Data Emissao:";
            // 
            // numeroProtocoloCartaCorrecaoLabel
            // 
            numeroProtocoloCartaCorrecaoLabel.AutoSize = true;
            numeroProtocoloCartaCorrecaoLabel.Location = new Point(-5, 316);
            numeroProtocoloCartaCorrecaoLabel.Margin = new Padding(4, 0, 4, 0);
            numeroProtocoloCartaCorrecaoLabel.Name = "numeroProtocoloCartaCorrecaoLabel";
            numeroProtocoloCartaCorrecaoLabel.Size = new Size(114, 15);
            numeroProtocoloCartaCorrecaoLabel.TabIndex = 42;
            numeroProtocoloCartaCorrecaoLabel.Text = "Prot Carta Correção:";
            // 
            // situacaoProtocoloCartaCorrecaoLabel
            // 
            situacaoProtocoloCartaCorrecaoLabel.AutoSize = true;
            situacaoProtocoloCartaCorrecaoLabel.Location = new Point(261, 312);
            situacaoProtocoloCartaCorrecaoLabel.Margin = new Padding(4, 0, 4, 0);
            situacaoProtocoloCartaCorrecaoLabel.Name = "situacaoProtocoloCartaCorrecaoLabel";
            situacaoProtocoloCartaCorrecaoLabel.Size = new Size(137, 15);
            situacaoProtocoloCartaCorrecaoLabel.TabIndex = 43;
            situacaoProtocoloCartaCorrecaoLabel.Text = "Situacao Carta Correção:";
            // 
            // mensagemSitucaoCartaCorrecaoLabel
            // 
            mensagemSitucaoCartaCorrecaoLabel.AutoSize = true;
            mensagemSitucaoCartaCorrecaoLabel.Location = new Point(486, 312);
            mensagemSitucaoCartaCorrecaoLabel.Margin = new Padding(4, 0, 4, 0);
            mensagemSitucaoCartaCorrecaoLabel.Name = "mensagemSitucaoCartaCorrecaoLabel";
            mensagemSitucaoCartaCorrecaoLabel.Size = new Size(69, 15);
            mensagemSitucaoCartaCorrecaoLabel.TabIndex = 44;
            mensagemSitucaoCartaCorrecaoLabel.Text = "Mensagem:";
            // 
            // correcaoLabel
            // 
            correcaoLabel.AutoSize = true;
            correcaoLabel.Location = new Point(2, 572);
            correcaoLabel.Margin = new Padding(4, 0, 4, 0);
            correcaoLabel.Name = "correcaoLabel";
            correcaoLabel.Size = new Size(566, 15);
            correcaoLabel.TabIndex = 45;
            correcaoLabel.Text = "Correções (Para NF-e Autorizadas e Situação previstas na legislação em vigor. Máximo de 1000 caracteres):";
            // 
            // seqCartaCorrecaoLabel
            // 
            seqCartaCorrecaoLabel.AutoSize = true;
            seqCartaCorrecaoLabel.Location = new Point(1, 352);
            seqCartaCorrecaoLabel.Margin = new Padding(4, 0, 4, 0);
            seqCartaCorrecaoLabel.Name = "seqCartaCorrecaoLabel";
            seqCartaCorrecaoLabel.Size = new Size(146, 15);
            seqCartaCorrecaoLabel.TabIndex = 47;
            seqCartaCorrecaoLabel.Text = "Sequência Carta Correção:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new Point(267, 352);
            codPessoaLabel.Margin = new Padding(4, 0, 4, 0);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new Size(47, 15);
            codPessoaLabel.TabIndex = 48;
            codPessoaLabel.Text = "Cliente:";
            // 
            // btnImprimir
            // 
            btnImprimir.Font = new Font("Microsoft Sans Serif", 10F);
            btnImprimir.Location = new Point(772, 644);
            btnImprimir.Margin = new Padding(4, 3, 4, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(122, 30);
            btnImprimir.TabIndex = 7;
            btnImprimir.Text = "F8 - Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Microsoft Sans Serif", 10F);
            btnCancelar.Location = new Point(245, 644);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(122, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "F4 - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // observacaoTextBox
            // 
            observacaoTextBox.Font = new Font("Microsoft Sans Serif", 11F);
            observacaoTextBox.Location = new Point(5, 395);
            observacaoTextBox.Margin = new Padding(4, 3, 4, 3);
            observacaoTextBox.MaxLength = 350;
            observacaoTextBox.Multiline = true;
            observacaoTextBox.Name = "observacaoTextBox";
            observacaoTextBox.Size = new Size(1018, 87);
            observacaoTextBox.TabIndex = 14;
            // 
            // btnEnviar
            // 
            btnEnviar.Font = new Font("Microsoft Sans Serif", 10F);
            btnEnviar.Location = new Point(123, 644);
            btnEnviar.Margin = new Padding(4, 3, 4, 3);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(122, 30);
            btnEnviar.TabIndex = 3;
            btnEnviar.Text = "F3 - Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // nfeControleDataGridView
            // 
            nfeControleDataGridView.AllowUserToAddRows = false;
            nfeControleDataGridView.AllowUserToDeleteRows = false;
            nfeControleDataGridView.AutoGenerateColumns = false;
            nfeControleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nfeControleDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, DescricaoModelo, NumeroSequenciaNfe, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, DescricaoSituacaoNfe });
            nfeControleDataGridView.DataSource = nfeControleBindingSource;
            nfeControleDataGridView.Location = new Point(5, 14);
            nfeControleDataGridView.Margin = new Padding(4, 3, 4, 3);
            nfeControleDataGridView.MultiSelect = false;
            nfeControleDataGridView.Name = "nfeControleDataGridView";
            nfeControleDataGridView.ReadOnly = true;
            nfeControleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            nfeControleDataGridView.Size = new Size(1018, 132);
            nfeControleDataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "CodNfe";
            dataGridViewTextBoxColumn1.FillWeight = 42.56329F;
            dataGridViewTextBoxColumn1.HeaderText = "Código NF-e";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // DescricaoModelo
            // 
            DescricaoModelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescricaoModelo.DataPropertyName = "DescricaoModelo";
            DescricaoModelo.FillWeight = 30F;
            DescricaoModelo.HeaderText = "Modelo";
            DescricaoModelo.Name = "DescricaoModelo";
            DescricaoModelo.ReadOnly = true;
            // 
            // NumeroSequenciaNfe
            // 
            NumeroSequenciaNfe.DataPropertyName = "NumeroSequenciaNfe";
            NumeroSequenciaNfe.HeaderText = "Número NF-e";
            NumeroSequenciaNfe.Name = "NumeroSequenciaNfe";
            NumeroSequenciaNfe.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "CodSaida";
            dataGridViewTextBoxColumn2.FillWeight = 36.02162F;
            dataGridViewTextBoxColumn2.HeaderText = "Saída";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "Chave";
            dataGridViewTextBoxColumn3.FillWeight = 162.4366F;
            dataGridViewTextBoxColumn3.HeaderText = "Chave";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // DescricaoSituacaoNfe
            // 
            DescricaoSituacaoNfe.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescricaoSituacaoNfe.DataPropertyName = "DescricaoSituacaoNfe";
            DescricaoSituacaoNfe.FillWeight = 78.97854F;
            DescricaoSituacaoNfe.HeaderText = "Situação";
            DescricaoSituacaoNfe.Name = "DescricaoSituacaoNfe";
            DescricaoSituacaoNfe.ReadOnly = true;
            // 
            // nfeControleBindingSource
            // 
            nfeControleBindingSource.DataSource = typeof(Dominio.NfeControle);
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Microsoft Sans Serif", 10F);
            btnFechar.Location = new Point(895, 644);
            btnFechar.Margin = new Padding(4, 3, 4, 3);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(122, 30);
            btnFechar.TabIndex = 8;
            btnFechar.Text = "ESC - Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // justificativaCancelamentoTextBox1
            // 
            justificativaCancelamentoTextBox1.CharacterCasing = CharacterCasing.Upper;
            justificativaCancelamentoTextBox1.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "JustificativaCancelamento", true));
            justificativaCancelamentoTextBox1.Font = new Font("Microsoft Sans Serif", 11F);
            justificativaCancelamentoTextBox1.Location = new Point(5, 505);
            justificativaCancelamentoTextBox1.Margin = new Padding(4, 3, 4, 3);
            justificativaCancelamentoTextBox1.Multiline = true;
            justificativaCancelamentoTextBox1.Name = "justificativaCancelamentoTextBox1";
            justificativaCancelamentoTextBox1.Size = new Size(1018, 63);
            justificativaCancelamentoTextBox1.TabIndex = 16;
            // 
            // mensagemSituacaoReciboEnvioTextBox
            // 
            mensagemSituacaoReciboEnvioTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "MensagemSituacaoReciboEnvio", true));
            mensagemSituacaoReciboEnvioTextBox.Location = new Point(566, 193);
            mensagemSituacaoReciboEnvioTextBox.Margin = new Padding(4, 3, 4, 3);
            mensagemSituacaoReciboEnvioTextBox.Name = "mensagemSituacaoReciboEnvioTextBox";
            mensagemSituacaoReciboEnvioTextBox.ReadOnly = true;
            mensagemSituacaoReciboEnvioTextBox.Size = new Size(457, 23);
            mensagemSituacaoReciboEnvioTextBox.TabIndex = 21;
            mensagemSituacaoReciboEnvioTextBox.TabStop = false;
            // 
            // mensagemSitucaoProtocoloCancelamentoTextBox
            // 
            mensagemSitucaoProtocoloCancelamentoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "MensagemSitucaoProtocoloCancelamento", true));
            mensagemSitucaoProtocoloCancelamentoTextBox.Location = new Point(566, 272);
            mensagemSitucaoProtocoloCancelamentoTextBox.Margin = new Padding(4, 3, 4, 3);
            mensagemSitucaoProtocoloCancelamentoTextBox.Name = "mensagemSitucaoProtocoloCancelamentoTextBox";
            mensagemSitucaoProtocoloCancelamentoTextBox.ReadOnly = true;
            mensagemSitucaoProtocoloCancelamentoTextBox.Size = new Size(457, 23);
            mensagemSitucaoProtocoloCancelamentoTextBox.TabIndex = 23;
            mensagemSitucaoProtocoloCancelamentoTextBox.TabStop = false;
            // 
            // mensagemSitucaoProtocoloUsoTextBox
            // 
            mensagemSitucaoProtocoloUsoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "MensagemSitucaoProtocoloUso", true));
            mensagemSitucaoProtocoloUsoTextBox.Location = new Point(566, 228);
            mensagemSitucaoProtocoloUsoTextBox.Margin = new Padding(4, 3, 4, 3);
            mensagemSitucaoProtocoloUsoTextBox.Name = "mensagemSitucaoProtocoloUsoTextBox";
            mensagemSitucaoProtocoloUsoTextBox.ReadOnly = true;
            mensagemSitucaoProtocoloUsoTextBox.Size = new Size(457, 23);
            mensagemSitucaoProtocoloUsoTextBox.TabIndex = 25;
            mensagemSitucaoProtocoloUsoTextBox.TabStop = false;
            // 
            // numeroLoteEnvioTextBox
            // 
            numeroLoteEnvioTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "NumeroLoteEnvio", true));
            numeroLoteEnvioTextBox.Location = new Point(118, 162);
            numeroLoteEnvioTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroLoteEnvioTextBox.Name = "numeroLoteEnvioTextBox";
            numeroLoteEnvioTextBox.ReadOnly = true;
            numeroLoteEnvioTextBox.Size = new Size(134, 23);
            numeroLoteEnvioTextBox.TabIndex = 27;
            numeroLoteEnvioTextBox.TabStop = false;
            // 
            // numeroProtocoloCancelamentoTextBox
            // 
            numeroProtocoloCancelamentoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "NumeroProtocoloCancelamento", true));
            numeroProtocoloCancelamentoTextBox.Location = new Point(118, 268);
            numeroProtocoloCancelamentoTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroProtocoloCancelamentoTextBox.Name = "numeroProtocoloCancelamentoTextBox";
            numeroProtocoloCancelamentoTextBox.ReadOnly = true;
            numeroProtocoloCancelamentoTextBox.Size = new Size(134, 23);
            numeroProtocoloCancelamentoTextBox.TabIndex = 29;
            numeroProtocoloCancelamentoTextBox.TabStop = false;
            // 
            // numeroProtocoloUsoTextBox
            // 
            numeroProtocoloUsoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "NumeroProtocoloUso", true));
            numeroProtocoloUsoTextBox.Location = new Point(118, 233);
            numeroProtocoloUsoTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroProtocoloUsoTextBox.Name = "numeroProtocoloUsoTextBox";
            numeroProtocoloUsoTextBox.ReadOnly = true;
            numeroProtocoloUsoTextBox.Size = new Size(134, 23);
            numeroProtocoloUsoTextBox.TabIndex = 31;
            numeroProtocoloUsoTextBox.TabStop = false;
            // 
            // numeroReciboTextBox
            // 
            numeroReciboTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "NumeroRecibo", true));
            numeroReciboTextBox.Location = new Point(118, 193);
            numeroReciboTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroReciboTextBox.Name = "numeroReciboTextBox";
            numeroReciboTextBox.ReadOnly = true;
            numeroReciboTextBox.Size = new Size(134, 23);
            numeroReciboTextBox.TabIndex = 33;
            numeroReciboTextBox.TabStop = false;
            // 
            // situacaoProtocoloCancelamentoTextBox
            // 
            situacaoProtocoloCancelamentoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "SituacaoProtocoloCancelamento", true));
            situacaoProtocoloCancelamentoTextBox.Location = new Point(412, 268);
            situacaoProtocoloCancelamentoTextBox.Margin = new Padding(4, 3, 4, 3);
            situacaoProtocoloCancelamentoTextBox.Name = "situacaoProtocoloCancelamentoTextBox";
            situacaoProtocoloCancelamentoTextBox.ReadOnly = true;
            situacaoProtocoloCancelamentoTextBox.Size = new Size(67, 23);
            situacaoProtocoloCancelamentoTextBox.TabIndex = 37;
            situacaoProtocoloCancelamentoTextBox.TabStop = false;
            // 
            // situacaoProtocoloUsoTextBox
            // 
            situacaoProtocoloUsoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "SituacaoProtocoloUso", true));
            situacaoProtocoloUsoTextBox.Location = new Point(412, 228);
            situacaoProtocoloUsoTextBox.Margin = new Padding(4, 3, 4, 3);
            situacaoProtocoloUsoTextBox.Name = "situacaoProtocoloUsoTextBox";
            situacaoProtocoloUsoTextBox.ReadOnly = true;
            situacaoProtocoloUsoTextBox.Size = new Size(67, 23);
            situacaoProtocoloUsoTextBox.TabIndex = 39;
            situacaoProtocoloUsoTextBox.TabStop = false;
            // 
            // situacaoReciboEnvioTextBox
            // 
            situacaoReciboEnvioTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "SituacaoReciboEnvio", true));
            situacaoReciboEnvioTextBox.Location = new Point(412, 193);
            situacaoReciboEnvioTextBox.Margin = new Padding(4, 3, 4, 3);
            situacaoReciboEnvioTextBox.Name = "situacaoReciboEnvioTextBox";
            situacaoReciboEnvioTextBox.ReadOnly = true;
            situacaoReciboEnvioTextBox.Size = new Size(67, 23);
            situacaoReciboEnvioTextBox.TabIndex = 41;
            situacaoReciboEnvioTextBox.TabStop = false;
            // 
            // dataEmissaoDateTimePicker
            // 
            dataEmissaoDateTimePicker.CustomFormat = "dd/MM/yyyy hh:mm";
            dataEmissaoDateTimePicker.DataBindings.Add(new Binding("Value", nfeControleBindingSource, "DataEmissao", true));
            dataEmissaoDateTimePicker.Enabled = false;
            dataEmissaoDateTimePicker.Format = DateTimePickerFormat.Custom;
            dataEmissaoDateTimePicker.Location = new Point(412, 158);
            dataEmissaoDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataEmissaoDateTimePicker.Name = "dataEmissaoDateTimePicker";
            dataEmissaoDateTimePicker.Size = new Size(156, 23);
            dataEmissaoDateTimePicker.TabIndex = 42;
            dataEmissaoDateTimePicker.TabStop = false;
            // 
            // btnSituacao
            // 
            btnSituacao.Font = new Font("Microsoft Sans Serif", 10F);
            btnSituacao.Location = new Point(490, 644);
            btnSituacao.Margin = new Padding(4, 3, 4, 3);
            btnSituacao.Name = "btnSituacao";
            btnSituacao.Size = new Size(122, 30);
            btnSituacao.TabIndex = 6;
            btnSituacao.Text = "F6 - Situação";
            btnSituacao.UseVisualStyleBackColor = true;
            btnSituacao.Click += btnSituacao_Click;
            // 
            // numeroProtocoloCartaCorrecaoTextBox
            // 
            numeroProtocoloCartaCorrecaoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "NumeroProtocoloCartaCorrecao", true));
            numeroProtocoloCartaCorrecaoTextBox.Location = new Point(118, 308);
            numeroProtocoloCartaCorrecaoTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroProtocoloCartaCorrecaoTextBox.Name = "numeroProtocoloCartaCorrecaoTextBox";
            numeroProtocoloCartaCorrecaoTextBox.ReadOnly = true;
            numeroProtocoloCartaCorrecaoTextBox.Size = new Size(134, 23);
            numeroProtocoloCartaCorrecaoTextBox.TabIndex = 43;
            numeroProtocoloCartaCorrecaoTextBox.TabStop = false;
            // 
            // situacaoProtocoloCartaCorrecaoTextBox
            // 
            situacaoProtocoloCartaCorrecaoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "SituacaoProtocoloCartaCorrecao", true));
            situacaoProtocoloCartaCorrecaoTextBox.Location = new Point(412, 308);
            situacaoProtocoloCartaCorrecaoTextBox.Margin = new Padding(4, 3, 4, 3);
            situacaoProtocoloCartaCorrecaoTextBox.Name = "situacaoProtocoloCartaCorrecaoTextBox";
            situacaoProtocoloCartaCorrecaoTextBox.ReadOnly = true;
            situacaoProtocoloCartaCorrecaoTextBox.Size = new Size(67, 23);
            situacaoProtocoloCartaCorrecaoTextBox.TabIndex = 44;
            situacaoProtocoloCartaCorrecaoTextBox.TabStop = false;
            // 
            // mensagemSitucaoCartaCorrecaoTextBox
            // 
            mensagemSitucaoCartaCorrecaoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "MensagemSitucaoCartaCorrecao", true));
            mensagemSitucaoCartaCorrecaoTextBox.Location = new Point(566, 308);
            mensagemSitucaoCartaCorrecaoTextBox.Margin = new Padding(4, 3, 4, 3);
            mensagemSitucaoCartaCorrecaoTextBox.Name = "mensagemSitucaoCartaCorrecaoTextBox";
            mensagemSitucaoCartaCorrecaoTextBox.ReadOnly = true;
            mensagemSitucaoCartaCorrecaoTextBox.Size = new Size(457, 23);
            mensagemSitucaoCartaCorrecaoTextBox.TabIndex = 45;
            mensagemSitucaoCartaCorrecaoTextBox.TabStop = false;
            // 
            // correcaoTextBox
            // 
            correcaoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "Correcao", true));
            correcaoTextBox.Location = new Point(6, 591);
            correcaoTextBox.Margin = new Padding(4, 3, 4, 3);
            correcaoTextBox.MaxLength = 1000;
            correcaoTextBox.Multiline = true;
            correcaoTextBox.Name = "correcaoTextBox";
            correcaoTextBox.Size = new Size(1017, 48);
            correcaoTextBox.TabIndex = 18;
            // 
            // btnCartaCorrecao
            // 
            btnCartaCorrecao.Font = new Font("Microsoft Sans Serif", 10F);
            btnCartaCorrecao.Location = new Point(368, 644);
            btnCartaCorrecao.Margin = new Padding(4, 3, 4, 3);
            btnCartaCorrecao.Name = "btnCartaCorrecao";
            btnCartaCorrecao.Size = new Size(122, 30);
            btnCartaCorrecao.TabIndex = 5;
            btnCartaCorrecao.Text = "F5 - Correção";
            btnCartaCorrecao.UseVisualStyleBackColor = true;
            btnCartaCorrecao.Click += btnCartaCorrecao_Click;
            // 
            // seqCartaCorrecaoTextBox
            // 
            seqCartaCorrecaoTextBox.DataBindings.Add(new Binding("Text", nfeControleBindingSource, "SeqCartaCorrecao", true));
            seqCartaCorrecaoTextBox.Location = new Point(166, 344);
            seqCartaCorrecaoTextBox.Margin = new Padding(4, 3, 4, 3);
            seqCartaCorrecaoTextBox.Name = "seqCartaCorrecaoTextBox";
            seqCartaCorrecaoTextBox.ReadOnly = true;
            seqCartaCorrecaoTextBox.Size = new Size(86, 23);
            seqCartaCorrecaoTextBox.TabIndex = 48;
            seqCartaCorrecaoTextBox.TabStop = false;
            // 
            // btnComplementar
            // 
            btnComplementar.Font = new Font("Microsoft Sans Serif", 10F);
            btnComplementar.Location = new Point(614, 644);
            btnComplementar.Margin = new Padding(4, 3, 4, 3);
            btnComplementar.Name = "btnComplementar";
            btnComplementar.Size = new Size(159, 30);
            btnComplementar.TabIndex = 50;
            btnComplementar.Text = "F7 - Complementar";
            btnComplementar.UseVisualStyleBackColor = true;
            btnComplementar.Click += btnEnviar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Microsoft Sans Serif", 10F);
            btnBuscar.Location = new Point(6, 644);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(117, 30);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // codPessoaComboBox
            // 
            codPessoaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codPessoaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codPessoaComboBox.CausesValidation = false;
            codPessoaComboBox.DataSource = pessoaBindingSource;
            codPessoaComboBox.DisplayMember = "NomeFantasia";
            codPessoaComboBox.Font = new Font("Microsoft Sans Serif", 10F);
            codPessoaComboBox.FormattingEnabled = true;
            codPessoaComboBox.Location = new Point(349, 344);
            codPessoaComboBox.Margin = new Padding(4, 3, 4, 3);
            codPessoaComboBox.Name = "codPessoaComboBox";
            codPessoaComboBox.Size = new Size(674, 24);
            codPessoaComboBox.TabIndex = 51;
            codPessoaComboBox.ValueMember = "CodPessoa";
            codPessoaComboBox.Enter += codPessoaComboBox_Enter;
            codPessoaComboBox.KeyPress += codPessoaComboBox_KeyPress;
            codPessoaComboBox.Leave += codPessoaComboBox_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.AllowNew = false;
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // FrmSaidaNFe
            // 
            AccessibleRole = AccessibleRole.Alert;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 721);
            ControlBox = false;
            Controls.Add(codPessoaComboBox);
            Controls.Add(btnBuscar);
            Controls.Add(btnComplementar);
            Controls.Add(codPessoaLabel);
            Controls.Add(seqCartaCorrecaoLabel);
            Controls.Add(seqCartaCorrecaoTextBox);
            Controls.Add(btnCartaCorrecao);
            Controls.Add(correcaoLabel);
            Controls.Add(correcaoTextBox);
            Controls.Add(mensagemSitucaoCartaCorrecaoLabel);
            Controls.Add(mensagemSitucaoCartaCorrecaoTextBox);
            Controls.Add(situacaoProtocoloCartaCorrecaoLabel);
            Controls.Add(situacaoProtocoloCartaCorrecaoTextBox);
            Controls.Add(numeroProtocoloCartaCorrecaoLabel);
            Controls.Add(numeroProtocoloCartaCorrecaoTextBox);
            Controls.Add(btnSituacao);
            Controls.Add(dataEmissaoLabel);
            Controls.Add(dataEmissaoDateTimePicker);
            Controls.Add(justificativaCancelamentoLabel1);
            Controls.Add(justificativaCancelamentoTextBox1);
            Controls.Add(mensagemSituacaoReciboEnvioLabel);
            Controls.Add(mensagemSituacaoReciboEnvioTextBox);
            Controls.Add(mensagemSitucaoProtocoloCancelamentoLabel);
            Controls.Add(mensagemSitucaoProtocoloCancelamentoTextBox);
            Controls.Add(mensagemSitucaoProtocoloUsoLabel);
            Controls.Add(mensagemSitucaoProtocoloUsoTextBox);
            Controls.Add(numeroLoteEnvioLabel);
            Controls.Add(numeroLoteEnvioTextBox);
            Controls.Add(numeroProtocoloCancelamentoTextBox);
            Controls.Add(numeroProtocoloUsoLabel);
            Controls.Add(numeroProtocoloUsoTextBox);
            Controls.Add(numeroReciboLabel);
            Controls.Add(numeroReciboTextBox);
            Controls.Add(situacaoProtocoloCancelamentoLabel);
            Controls.Add(situacaoProtocoloCancelamentoTextBox);
            Controls.Add(situacaoProtocoloUsoLabel);
            Controls.Add(situacaoProtocoloUsoTextBox);
            Controls.Add(situacaoReciboEnvioLabel);
            Controls.Add(situacaoReciboEnvioTextBox);
            Controls.Add(btnFechar);
            Controls.Add(nfeControleDataGridView);
            Controls.Add(btnEnviar);
            Controls.Add(observacaoLabel);
            Controls.Add(observacaoTextBox);
            Controls.Add(btnCancelar);
            Controls.Add(btnImprimir);
            Controls.Add(numeroProtocoloCancelamentoLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSaidaNFe";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gerenciamento de NF-e";
            KeyDown += FrmSaidaNF_KeyDown;
            ((System.ComponentModel.ISupportInitialize)nfeControleDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)nfeControleBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.BindingSource nfeControleBindingSource;
        private System.Windows.Forms.DataGridView nfeControleDataGridView;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox justificativaCancelamentoTextBox1;
        private System.Windows.Forms.TextBox mensagemSituacaoReciboEnvioTextBox;
        private System.Windows.Forms.TextBox mensagemSitucaoProtocoloCancelamentoTextBox;
        private System.Windows.Forms.TextBox mensagemSitucaoProtocoloUsoTextBox;
        private System.Windows.Forms.TextBox numeroLoteEnvioTextBox;
        private System.Windows.Forms.TextBox numeroProtocoloCancelamentoTextBox;
        private System.Windows.Forms.TextBox numeroProtocoloUsoTextBox;
        private System.Windows.Forms.TextBox numeroReciboTextBox;
        private System.Windows.Forms.TextBox situacaoProtocoloCancelamentoTextBox;
        private System.Windows.Forms.TextBox situacaoProtocoloUsoTextBox;
        private System.Windows.Forms.TextBox situacaoReciboEnvioTextBox;
        private System.Windows.Forms.DateTimePicker dataEmissaoDateTimePicker;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogNfe;
        private System.Windows.Forms.Button btnSituacao;
        private System.Windows.Forms.TextBox numeroProtocoloCartaCorrecaoTextBox;
        private System.Windows.Forms.TextBox situacaoProtocoloCartaCorrecaoTextBox;
        private System.Windows.Forms.TextBox mensagemSitucaoCartaCorrecaoTextBox;
        private System.Windows.Forms.TextBox correcaoTextBox;
        private System.Windows.Forms.Button btnCartaCorrecao;
        private System.Windows.Forms.TextBox seqCartaCorrecaoTextBox;
        private System.Windows.Forms.Button btnComplementar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSequenciaNfe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoSituacaoNfe;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
    }
}