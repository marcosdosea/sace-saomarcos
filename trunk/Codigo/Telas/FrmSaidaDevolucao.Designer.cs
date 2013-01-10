namespace Telas
{
    partial class FrmSaidaDevolucao
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
            System.Windows.Forms.Label tipoSaidaLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label codSaidaLabel;
            System.Windows.Forms.Label baseCalculoICMSLabel;
            System.Windows.Forms.Label valorICMSLabel;
            System.Windows.Forms.Label baseCalculoICMSSubstLabel;
            System.Windows.Forms.Label valorICMSSubstLabel;
            System.Windows.Forms.Label valorFreteLabel;
            System.Windows.Forms.Label valorSeguroLabel;
            System.Windows.Forms.Label outrasDespesasLabel;
            System.Windows.Forms.Label valorIPILabel;
            System.Windows.Forms.Label totalNotaFiscalLabel;
            System.Windows.Forms.Label codEmpresaFreteLabel;
            System.Windows.Forms.Label quantidadeVolumesLabel;
            System.Windows.Forms.Label especieVolumesLabel;
            System.Windows.Forms.Label marcaLabel;
            System.Windows.Forms.Label numeroLabel;
            System.Windows.Forms.Label pesoBrutoLabel;
            System.Windows.Forms.Label pesoLiquidoLabel;
            System.Windows.Forms.Label descontoLabel;
            System.Windows.Forms.Label codClienteLabel;
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.tb_tipo_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_tipo_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter();
            this.tb_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.lojaBindingSourceOrigem = new System.Windows.Forms.BindingSource(this.components);
            this.lojaBindingSourceDestino = new System.Windows.Forms.BindingSource(this.components);
            this.baseCalculoICMSTextBox = new System.Windows.Forms.TextBox();
            this.valorICMSTextBox = new System.Windows.Forms.TextBox();
            this.baseCalculoICMSSubstTextBox = new System.Windows.Forms.TextBox();
            this.valorICMSSubstTextBox = new System.Windows.Forms.TextBox();
            this.valorFreteTextBox = new System.Windows.Forms.TextBox();
            this.valorSeguroTextBox = new System.Windows.Forms.TextBox();
            this.outrasDespesasTextBox = new System.Windows.Forms.TextBox();
            this.valorIPITextBox = new System.Windows.Forms.TextBox();
            this.totalNotaFiscalTextBox = new System.Windows.Forms.TextBox();
            this.codEmpresaFreteComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaFreteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quantidadeVolumesTextBox = new System.Windows.Forms.TextBox();
            this.especieVolumesTextBox = new System.Windows.Forms.TextBox();
            this.marcaTextBox = new System.Windows.Forms.TextBox();
            this.numeroTextBox = new System.Windows.Forms.TextBox();
            this.pesoBrutoTextBox = new System.Windows.Forms.TextBox();
            this.pesoLiquidoTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.codClienteComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaDestinoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            tipoSaidaLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            codSaidaLabel = new System.Windows.Forms.Label();
            baseCalculoICMSLabel = new System.Windows.Forms.Label();
            valorICMSLabel = new System.Windows.Forms.Label();
            baseCalculoICMSSubstLabel = new System.Windows.Forms.Label();
            valorICMSSubstLabel = new System.Windows.Forms.Label();
            valorFreteLabel = new System.Windows.Forms.Label();
            valorSeguroLabel = new System.Windows.Forms.Label();
            outrasDespesasLabel = new System.Windows.Forms.Label();
            valorIPILabel = new System.Windows.Forms.Label();
            totalNotaFiscalLabel = new System.Windows.Forms.Label();
            codEmpresaFreteLabel = new System.Windows.Forms.Label();
            quantidadeVolumesLabel = new System.Windows.Forms.Label();
            especieVolumesLabel = new System.Windows.Forms.Label();
            marcaLabel = new System.Windows.Forms.Label();
            numeroLabel = new System.Windows.Forms.Label();
            pesoBrutoLabel = new System.Windows.Forms.Label();
            pesoLiquidoLabel = new System.Windows.Forms.Label();
            descontoLabel = new System.Windows.Forms.Label();
            codClienteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceOrigem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceDestino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaFreteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaDestinoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoSaidaLabel
            // 
            tipoSaidaLabel.AutoSize = true;
            tipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoSaidaLabel.Location = new System.Drawing.Point(165, 6);
            tipoSaidaLabel.Name = "tipoSaidaLabel";
            tipoSaidaLabel.Size = new System.Drawing.Size(137, 29);
            tipoSaidaLabel.TabIndex = 12;
            tipoSaidaLabel.Text = "Tipo Saída:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(5, 3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 29);
            label3.TabIndex = 21;
            label3.Text = "Total:";
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.Location = new System.Drawing.Point(643, 3);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(81, 29);
            codSaidaLabel.TabIndex = 65;
            codSaidaLabel.Text = "Saída:";
            // 
            // baseCalculoICMSLabel
            // 
            baseCalculoICMSLabel.AutoSize = true;
            baseCalculoICMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            baseCalculoICMSLabel.Location = new System.Drawing.Point(6, 151);
            baseCalculoICMSLabel.Name = "baseCalculoICMSLabel";
            baseCalculoICMSLabel.Size = new System.Drawing.Size(90, 24);
            baseCalculoICMSLabel.TabIndex = 65;
            baseCalculoICMSLabel.Text = "BC ICMS:";
            // 
            // valorICMSLabel
            // 
            valorICMSLabel.AutoSize = true;
            valorICMSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            valorICMSLabel.Location = new System.Drawing.Point(166, 151);
            valorICMSLabel.Name = "valorICMSLabel";
            valorICMSLabel.Size = new System.Drawing.Size(109, 24);
            valorICMSLabel.TabIndex = 66;
            valorICMSLabel.Text = "Valor ICMS:";
            // 
            // baseCalculoICMSSubstLabel
            // 
            baseCalculoICMSSubstLabel.AutoSize = true;
            baseCalculoICMSSubstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            baseCalculoICMSSubstLabel.Location = new System.Drawing.Point(324, 151);
            baseCalculoICMSSubstLabel.Name = "baseCalculoICMSSubstLabel";
            baseCalculoICMSSubstLabel.Size = new System.Drawing.Size(142, 24);
            baseCalculoICMSSubstLabel.TabIndex = 67;
            baseCalculoICMSSubstLabel.Text = "BC ICMS Subst:";
            // 
            // valorICMSSubstLabel
            // 
            valorICMSSubstLabel.AutoSize = true;
            valorICMSSubstLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            valorICMSSubstLabel.Location = new System.Drawing.Point(472, 151);
            valorICMSSubstLabel.Name = "valorICMSSubstLabel";
            valorICMSSubstLabel.Size = new System.Drawing.Size(161, 24);
            valorICMSSubstLabel.TabIndex = 68;
            valorICMSSubstLabel.Text = "Valor ICMS Subst:";
            // 
            // valorFreteLabel
            // 
            valorFreteLabel.AutoSize = true;
            valorFreteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            valorFreteLabel.Location = new System.Drawing.Point(644, 151);
            valorFreteLabel.Name = "valorFreteLabel";
            valorFreteLabel.Size = new System.Drawing.Size(108, 24);
            valorFreteLabel.TabIndex = 69;
            valorFreteLabel.Text = "Valor Frete:";
            // 
            // valorSeguroLabel
            // 
            valorSeguroLabel.AutoSize = true;
            valorSeguroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            valorSeguroLabel.Location = new System.Drawing.Point(10, 236);
            valorSeguroLabel.Name = "valorSeguroLabel";
            valorSeguroLabel.Size = new System.Drawing.Size(126, 24);
            valorSeguroLabel.TabIndex = 70;
            valorSeguroLabel.Text = "Valor Seguro:";
            // 
            // outrasDespesasLabel
            // 
            outrasDespesasLabel.AutoSize = true;
            outrasDespesasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            outrasDespesasLabel.Location = new System.Drawing.Point(319, 236);
            outrasDespesasLabel.Name = "outrasDespesasLabel";
            outrasDespesasLabel.Size = new System.Drawing.Size(158, 24);
            outrasDespesasLabel.TabIndex = 71;
            outrasDespesasLabel.Text = "Outras Despesas:";
            // 
            // valorIPILabel
            // 
            valorIPILabel.AutoSize = true;
            valorIPILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            valorIPILabel.Location = new System.Drawing.Point(474, 236);
            valorIPILabel.Name = "valorIPILabel";
            valorIPILabel.Size = new System.Drawing.Size(84, 24);
            valorIPILabel.TabIndex = 72;
            valorIPILabel.Text = "Valor IPI:";
            // 
            // totalNotaFiscalLabel
            // 
            totalNotaFiscalLabel.AutoSize = true;
            totalNotaFiscalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            totalNotaFiscalLabel.Location = new System.Drawing.Point(645, 236);
            totalNotaFiscalLabel.Name = "totalNotaFiscalLabel";
            totalNotaFiscalLabel.Size = new System.Drawing.Size(154, 24);
            totalNotaFiscalLabel.TabIndex = 73;
            totalNotaFiscalLabel.Text = "Total Nota Fiscal:";
            // 
            // codEmpresaFreteLabel
            // 
            codEmpresaFreteLabel.AutoSize = true;
            codEmpresaFreteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            codEmpresaFreteLabel.Location = new System.Drawing.Point(11, 315);
            codEmpresaFreteLabel.Name = "codEmpresaFreteLabel";
            codEmpresaFreteLabel.Size = new System.Drawing.Size(140, 24);
            codEmpresaFreteLabel.TabIndex = 74;
            codEmpresaFreteLabel.Text = "Empresa Frete:";
            // 
            // quantidadeVolumesLabel
            // 
            quantidadeVolumesLabel.AutoSize = true;
            quantidadeVolumesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            quantidadeVolumesLabel.Location = new System.Drawing.Point(12, 392);
            quantidadeVolumesLabel.Name = "quantidadeVolumesLabel";
            quantidadeVolumesLabel.Size = new System.Drawing.Size(113, 24);
            quantidadeVolumesLabel.TabIndex = 75;
            quantidadeVolumesLabel.Text = "Quantidade:";
            // 
            // especieVolumesLabel
            // 
            especieVolumesLabel.AutoSize = true;
            especieVolumesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            especieVolumesLabel.Location = new System.Drawing.Point(144, 392);
            especieVolumesLabel.Name = "especieVolumesLabel";
            especieVolumesLabel.Size = new System.Drawing.Size(84, 24);
            especieVolumesLabel.TabIndex = 76;
            especieVolumesLabel.Text = "Espécie:";
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            marcaLabel.Location = new System.Drawing.Point(264, 392);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new System.Drawing.Size(67, 24);
            marcaLabel.TabIndex = 77;
            marcaLabel.Text = "Marca:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            numeroLabel.Location = new System.Drawing.Point(424, 392);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new System.Drawing.Size(84, 24);
            numeroLabel.TabIndex = 78;
            numeroLabel.Text = "Número:";
            // 
            // pesoBrutoLabel
            // 
            pesoBrutoLabel.AutoSize = true;
            pesoBrutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            pesoBrutoLabel.Location = new System.Drawing.Point(672, 392);
            pesoBrutoLabel.Name = "pesoBrutoLabel";
            pesoBrutoLabel.Size = new System.Drawing.Size(107, 24);
            pesoBrutoLabel.TabIndex = 79;
            pesoBrutoLabel.Text = "Peso Bruto:";
            // 
            // pesoLiquidoLabel
            // 
            pesoLiquidoLabel.AutoSize = true;
            pesoLiquidoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            pesoLiquidoLabel.Location = new System.Drawing.Point(541, 392);
            pesoLiquidoLabel.Name = "pesoLiquidoLabel";
            pesoLiquidoLabel.Size = new System.Drawing.Size(125, 24);
            pesoLiquidoLabel.TabIndex = 80;
            pesoLiquidoLabel.Text = "Peso Líquido:";
            // 
            // descontoLabel
            // 
            descontoLabel.AutoSize = true;
            descontoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            descontoLabel.Location = new System.Drawing.Point(166, 236);
            descontoLabel.Name = "descontoLabel";
            descontoLabel.Size = new System.Drawing.Size(95, 24);
            descontoLabel.TabIndex = 81;
            descontoLabel.Text = "Desconto:";
            // 
            // codClienteLabel
            // 
            codClienteLabel.AutoSize = true;
            codClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            codClienteLabel.Location = new System.Drawing.Point(11, 77);
            codClienteLabel.Name = "codClienteLabel";
            codClienteLabel.Size = new System.Drawing.Size(112, 24);
            codClienteLabel.TabIndex = 81;
            codClienteLabel.Text = "Destinatário:";
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida";
            this.tb_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(11, 39);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(148, 35);
            this.totalTextBox.TabIndex = 2;
            this.totalTextBox.TabStop = false;
            this.totalTextBox.Text = "999.999,99";
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(625, 467);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 50;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(712, 466);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(648, 39);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(148, 35);
            this.codSaidaTextBox.TabIndex = 6;
            this.codSaidaTextBox.TabStop = false;
            this.codSaidaTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codSaidaTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // tb_tipo_saidaBindingSource
            // 
            this.tb_tipo_saidaBindingSource.AllowNew = false;
            this.tb_tipo_saidaBindingSource.DataMember = "tb_tipo_saida";
            this.tb_tipo_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_tipo_saidaTableAdapter
            // 
            this.tb_tipo_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(169, 39);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(473, 35);
            this.descricaoTipoSaidaTextBox.TabIndex = 4;
            // 
            // lojaBindingSourceOrigem
            // 
            this.lojaBindingSourceOrigem.AllowNew = false;
            this.lojaBindingSourceOrigem.DataSource = typeof(Dominio.Loja);
            // 
            // lojaBindingSourceDestino
            // 
            this.lojaBindingSourceDestino.AllowNew = false;
            this.lojaBindingSourceDestino.DataSource = typeof(Dominio.Loja);
            // 
            // baseCalculoICMSTextBox
            // 
            this.baseCalculoICMSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "baseCalculoICMS", true));
            this.baseCalculoICMSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.baseCalculoICMSTextBox.Location = new System.Drawing.Point(11, 183);
            this.baseCalculoICMSTextBox.Name = "baseCalculoICMSTextBox";
            this.baseCalculoICMSTextBox.ReadOnly = true;
            this.baseCalculoICMSTextBox.Size = new System.Drawing.Size(148, 35);
            this.baseCalculoICMSTextBox.TabIndex = 8;
            this.baseCalculoICMSTextBox.TabStop = false;
            this.baseCalculoICMSTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.baseCalculoICMSTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // valorICMSTextBox
            // 
            this.valorICMSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "valorICMS", true));
            this.valorICMSTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.valorICMSTextBox.Location = new System.Drawing.Point(170, 183);
            this.valorICMSTextBox.Name = "valorICMSTextBox";
            this.valorICMSTextBox.ReadOnly = true;
            this.valorICMSTextBox.Size = new System.Drawing.Size(148, 35);
            this.valorICMSTextBox.TabIndex = 10;
            this.valorICMSTextBox.TabStop = false;
            this.valorICMSTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorICMSTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // baseCalculoICMSSubstTextBox
            // 
            this.baseCalculoICMSSubstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "baseCalculoICMSSubst", true));
            this.baseCalculoICMSSubstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.baseCalculoICMSSubstTextBox.Location = new System.Drawing.Point(323, 183);
            this.baseCalculoICMSSubstTextBox.Name = "baseCalculoICMSSubstTextBox";
            this.baseCalculoICMSSubstTextBox.ReadOnly = true;
            this.baseCalculoICMSSubstTextBox.Size = new System.Drawing.Size(148, 35);
            this.baseCalculoICMSSubstTextBox.TabIndex = 12;
            this.baseCalculoICMSSubstTextBox.TabStop = false;
            this.baseCalculoICMSSubstTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.baseCalculoICMSSubstTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // valorICMSSubstTextBox
            // 
            this.valorICMSSubstTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "valorICMSSubst", true));
            this.valorICMSSubstTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.valorICMSSubstTextBox.Location = new System.Drawing.Point(478, 183);
            this.valorICMSSubstTextBox.Name = "valorICMSSubstTextBox";
            this.valorICMSSubstTextBox.ReadOnly = true;
            this.valorICMSSubstTextBox.Size = new System.Drawing.Size(164, 35);
            this.valorICMSSubstTextBox.TabIndex = 14;
            this.valorICMSSubstTextBox.TabStop = false;
            this.valorICMSSubstTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorICMSSubstTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // valorFreteTextBox
            // 
            this.valorFreteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "valorFrete", true));
            this.valorFreteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.valorFreteTextBox.Location = new System.Drawing.Point(648, 183);
            this.valorFreteTextBox.Name = "valorFreteTextBox";
            this.valorFreteTextBox.Size = new System.Drawing.Size(148, 35);
            this.valorFreteTextBox.TabIndex = 16;
            this.valorFreteTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorFreteTextBox.Leave += new System.EventHandler(this.valorFreteTextBox_Leave);
            // 
            // valorSeguroTextBox
            // 
            this.valorSeguroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorSeguroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "valorSeguro", true));
            this.valorSeguroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.valorSeguroTextBox.Location = new System.Drawing.Point(10, 265);
            this.valorSeguroTextBox.Name = "valorSeguroTextBox";
            this.valorSeguroTextBox.Size = new System.Drawing.Size(148, 35);
            this.valorSeguroTextBox.TabIndex = 18;
            this.valorSeguroTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorSeguroTextBox.Leave += new System.EventHandler(this.valorFreteTextBox_Leave);
            // 
            // outrasDespesasTextBox
            // 
            this.outrasDespesasTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.outrasDespesasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "outrasDespesas", true));
            this.outrasDespesasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.outrasDespesasTextBox.Location = new System.Drawing.Point(323, 265);
            this.outrasDespesasTextBox.Name = "outrasDespesasTextBox";
            this.outrasDespesasTextBox.Size = new System.Drawing.Size(148, 35);
            this.outrasDespesasTextBox.TabIndex = 22;
            this.outrasDespesasTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.outrasDespesasTextBox.Leave += new System.EventHandler(this.valorFreteTextBox_Leave);
            // 
            // valorIPITextBox
            // 
            this.valorIPITextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorIPITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "valorIPI", true));
            this.valorIPITextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.valorIPITextBox.Location = new System.Drawing.Point(478, 265);
            this.valorIPITextBox.Name = "valorIPITextBox";
            this.valorIPITextBox.ReadOnly = true;
            this.valorIPITextBox.Size = new System.Drawing.Size(164, 35);
            this.valorIPITextBox.TabIndex = 24;
            this.valorIPITextBox.TabStop = false;
            this.valorIPITextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorIPITextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // totalNotaFiscalTextBox
            // 
            this.totalNotaFiscalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.totalNotaFiscalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "totalNotaFiscal", true));
            this.totalNotaFiscalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.totalNotaFiscalTextBox.Location = new System.Drawing.Point(648, 265);
            this.totalNotaFiscalTextBox.Name = "totalNotaFiscalTextBox";
            this.totalNotaFiscalTextBox.Size = new System.Drawing.Size(148, 35);
            this.totalNotaFiscalTextBox.TabIndex = 26;
            this.totalNotaFiscalTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.totalNotaFiscalTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // codEmpresaFreteComboBox
            // 
            this.codEmpresaFreteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codEmpresaFreteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeEmpresaFrete", true));
            this.codEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "codEmpresaFrete", true));
            this.codEmpresaFreteComboBox.DataSource = this.pessoaFreteBindingSource;
            this.codEmpresaFreteComboBox.DisplayMember = "Nome";
            this.codEmpresaFreteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.codEmpresaFreteComboBox.FormattingEnabled = true;
            this.codEmpresaFreteComboBox.Location = new System.Drawing.Point(14, 346);
            this.codEmpresaFreteComboBox.Name = "codEmpresaFreteComboBox";
            this.codEmpresaFreteComboBox.Size = new System.Drawing.Size(782, 37);
            this.codEmpresaFreteComboBox.TabIndex = 28;
            this.codEmpresaFreteComboBox.ValueMember = "CodPessoa";
            this.codEmpresaFreteComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codEmpresaFreteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codEmpresaFreteComboBox_KeyPress);
            this.codEmpresaFreteComboBox.Leave += new System.EventHandler(this.codEmpresaFreteComboBox_Leave);
            // 
            // pessoaFreteBindingSource
            // 
            this.pessoaFreteBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // quantidadeVolumesTextBox
            // 
            this.quantidadeVolumesTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.quantidadeVolumesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "quantidadeVolumes", true));
            this.quantidadeVolumesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.quantidadeVolumesTextBox.Location = new System.Drawing.Point(12, 422);
            this.quantidadeVolumesTextBox.Name = "quantidadeVolumesTextBox";
            this.quantidadeVolumesTextBox.Size = new System.Drawing.Size(124, 35);
            this.quantidadeVolumesTextBox.TabIndex = 30;
            this.quantidadeVolumesTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.quantidadeVolumesTextBox.Leave += new System.EventHandler(this.quantidadeVolumesTextBox_Leave);
            // 
            // especieVolumesTextBox
            // 
            this.especieVolumesTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.especieVolumesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "especieVolumes", true));
            this.especieVolumesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.especieVolumesTextBox.Location = new System.Drawing.Point(148, 422);
            this.especieVolumesTextBox.Name = "especieVolumesTextBox";
            this.especieVolumesTextBox.Size = new System.Drawing.Size(100, 35);
            this.especieVolumesTextBox.TabIndex = 32;
            this.especieVolumesTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.especieVolumesTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // marcaTextBox
            // 
            this.marcaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.marcaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "marca", true));
            this.marcaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.marcaTextBox.Location = new System.Drawing.Point(268, 422);
            this.marcaTextBox.Name = "marcaTextBox";
            this.marcaTextBox.Size = new System.Drawing.Size(148, 35);
            this.marcaTextBox.TabIndex = 34;
            this.marcaTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.marcaTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // numeroTextBox
            // 
            this.numeroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numeroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "numero", true));
            this.numeroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.numeroTextBox.Location = new System.Drawing.Point(428, 422);
            this.numeroTextBox.Name = "numeroTextBox";
            this.numeroTextBox.Size = new System.Drawing.Size(100, 35);
            this.numeroTextBox.TabIndex = 36;
            this.numeroTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.numeroTextBox.Leave += new System.EventHandler(this.quantidadeVolumesTextBox_Leave);
            // 
            // pesoBrutoTextBox
            // 
            this.pesoBrutoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pesoBrutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "pesoBruto", true));
            this.pesoBrutoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.pesoBrutoTextBox.Location = new System.Drawing.Point(676, 422);
            this.pesoBrutoTextBox.Name = "pesoBrutoTextBox";
            this.pesoBrutoTextBox.Size = new System.Drawing.Size(120, 35);
            this.pesoBrutoTextBox.TabIndex = 40;
            this.pesoBrutoTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.pesoBrutoTextBox.Leave += new System.EventHandler(this.quantidadeVolumesTextBox_Leave);
            // 
            // pesoLiquidoTextBox
            // 
            this.pesoLiquidoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pesoLiquidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "pesoLiquido", true));
            this.pesoLiquidoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.pesoLiquidoTextBox.Location = new System.Drawing.Point(542, 422);
            this.pesoLiquidoTextBox.Name = "pesoLiquidoTextBox";
            this.pesoLiquidoTextBox.Size = new System.Drawing.Size(124, 35);
            this.pesoLiquidoTextBox.TabIndex = 38;
            this.pesoLiquidoTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.pesoLiquidoTextBox.Leave += new System.EventHandler(this.quantidadeVolumesTextBox_Leave);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "desconto", true));
            this.descontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.descontoTextBox.Location = new System.Drawing.Point(170, 266);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(148, 35);
            this.descontoTextBox.TabIndex = 20;
            this.descontoTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.descontoTextBox.Leave += new System.EventHandler(this.valorFreteTextBox_Leave);
            // 
            // codClienteComboBox
            // 
            this.codClienteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codClienteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeCliente", true));
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "codCliente", true));
            this.codClienteComboBox.DataSource = this.pessoaDestinoBindingSource;
            this.codClienteComboBox.DisplayMember = "Nome";
            this.codClienteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.codClienteComboBox.FormattingEnabled = true;
            this.codClienteComboBox.Location = new System.Drawing.Point(10, 106);
            this.codClienteComboBox.Name = "codClienteComboBox";
            this.codClienteComboBox.Size = new System.Drawing.Size(786, 37);
            this.codClienteComboBox.TabIndex = 7;
            this.codClienteComboBox.ValueMember = "CodPessoa";
            this.codClienteComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codClienteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codEmpresaFreteComboBox_KeyPress);
            this.codClienteComboBox.Leave += new System.EventHandler(this.codClienteComboBox_Leave);
            // 
            // pessoaDestinoBindingSource
            // 
            this.pessoaDestinoBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // FrmSaidaDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 497);
            this.Controls.Add(codClienteLabel);
            this.Controls.Add(this.codClienteComboBox);
            this.Controls.Add(descontoLabel);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(pesoLiquidoLabel);
            this.Controls.Add(this.pesoLiquidoTextBox);
            this.Controls.Add(pesoBrutoLabel);
            this.Controls.Add(this.pesoBrutoTextBox);
            this.Controls.Add(numeroLabel);
            this.Controls.Add(this.numeroTextBox);
            this.Controls.Add(marcaLabel);
            this.Controls.Add(this.marcaTextBox);
            this.Controls.Add(especieVolumesLabel);
            this.Controls.Add(this.especieVolumesTextBox);
            this.Controls.Add(quantidadeVolumesLabel);
            this.Controls.Add(this.quantidadeVolumesTextBox);
            this.Controls.Add(codEmpresaFreteLabel);
            this.Controls.Add(this.codEmpresaFreteComboBox);
            this.Controls.Add(totalNotaFiscalLabel);
            this.Controls.Add(this.totalNotaFiscalTextBox);
            this.Controls.Add(valorIPILabel);
            this.Controls.Add(this.valorIPITextBox);
            this.Controls.Add(outrasDespesasLabel);
            this.Controls.Add(this.outrasDespesasTextBox);
            this.Controls.Add(valorSeguroLabel);
            this.Controls.Add(this.valorSeguroTextBox);
            this.Controls.Add(valorFreteLabel);
            this.Controls.Add(this.valorFreteTextBox);
            this.Controls.Add(valorICMSSubstLabel);
            this.Controls.Add(this.valorICMSSubstTextBox);
            this.Controls.Add(baseCalculoICMSSubstLabel);
            this.Controls.Add(this.baseCalculoICMSSubstTextBox);
            this.Controls.Add(valorICMSLabel);
            this.Controls.Add(this.valorICMSTextBox);
            this.Controls.Add(baseCalculoICMSLabel);
            this.Controls.Add(this.baseCalculoICMSTextBox);
            this.Controls.Add(this.descricaoTipoSaidaTextBox);
            this.Controls.Add(this.codSaidaTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(tipoSaidaLabel);
            this.Controls.Add(label3);
            this.Controls.Add(codSaidaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaidaDevolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerramento da Saída";
            this.Load += new System.EventHandler(this.FrmSaidaDevolucao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaDevolucao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceOrigem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceDestino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaFreteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaDestinoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.BindingSource tb_tipo_saidaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter tb_tipo_saidaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.BindingSource lojaBindingSourceOrigem;
        private System.Windows.Forms.BindingSource lojaBindingSourceDestino;
        private System.Windows.Forms.TextBox baseCalculoICMSTextBox;
        private System.Windows.Forms.TextBox valorICMSTextBox;
        private System.Windows.Forms.TextBox baseCalculoICMSSubstTextBox;
        private System.Windows.Forms.TextBox valorICMSSubstTextBox;
        private System.Windows.Forms.TextBox valorFreteTextBox;
        private System.Windows.Forms.TextBox valorSeguroTextBox;
        private System.Windows.Forms.TextBox outrasDespesasTextBox;
        private System.Windows.Forms.TextBox valorIPITextBox;
        private System.Windows.Forms.TextBox totalNotaFiscalTextBox;
        private System.Windows.Forms.ComboBox codEmpresaFreteComboBox;
        private System.Windows.Forms.TextBox quantidadeVolumesTextBox;
        private System.Windows.Forms.TextBox especieVolumesTextBox;
        private System.Windows.Forms.TextBox marcaTextBox;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox pesoBrutoTextBox;
        private System.Windows.Forms.TextBox pesoLiquidoTextBox;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.BindingSource pessoaFreteBindingSource;
        private System.Windows.Forms.ComboBox codClienteComboBox;
        private System.Windows.Forms.BindingSource pessoaDestinoBindingSource;
    }
}