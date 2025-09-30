namespace Sace
{
    partial class FrmSaidaPesquisa
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            tb_saidaDataGridView = new DataGridView();
            codSaidaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DescricaoTipoSaida = new DataGridViewTextBoxColumn();
            dataSaida = new DataGridViewTextBoxColumn();
            nomeCliente = new DataGridViewTextBoxColumn();
            pedidoGerado = new DataGridViewTextBoxColumn();
            totalAVista = new DataGridViewTextBoxColumn();
            saidaBindingSource = new BindingSource(components);
            txtTexto = new TextBox();
            label2 = new Label();
            cmbBusca = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)tb_saidaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saidaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tb_saidaDataGridView
            // 
            tb_saidaDataGridView.AllowUserToAddRows = false;
            tb_saidaDataGridView.AllowUserToDeleteRows = false;
            tb_saidaDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tb_saidaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tb_saidaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_saidaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codSaidaDataGridViewTextBoxColumn, DescricaoTipoSaida, dataSaida, nomeCliente, pedidoGerado, totalAVista });
            tb_saidaDataGridView.DataSource = saidaBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tb_saidaDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            tb_saidaDataGridView.Location = new Point(9, 68);
            tb_saidaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_saidaDataGridView.MultiSelect = false;
            tb_saidaDataGridView.Name = "tb_saidaDataGridView";
            tb_saidaDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tb_saidaDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            tb_saidaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_saidaDataGridView.Size = new Size(1134, 290);
            tb_saidaDataGridView.TabIndex = 8;
            tb_saidaDataGridView.TabStop = false;
            tb_saidaDataGridView.CellContentClick += tb_saidaDataGridView_CellClick;
            tb_saidaDataGridView.CellDoubleClick += tb_saidaDataGridView_CellClick;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            codSaidaDataGridViewTextBoxColumn.HeaderText = "CodSaida";
            codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DescricaoTipoSaida
            // 
            DescricaoTipoSaida.DataPropertyName = "DescricaoTipoSaida";
            DescricaoTipoSaida.FillWeight = 70F;
            DescricaoTipoSaida.HeaderText = "Tipo";
            DescricaoTipoSaida.Name = "DescricaoTipoSaida";
            DescricaoTipoSaida.ReadOnly = true;
            // 
            // dataSaida
            // 
            dataSaida.DataPropertyName = "DataSaida";
            dataSaida.HeaderText = "Data";
            dataSaida.Name = "dataSaida";
            dataSaida.ReadOnly = true;
            // 
            // nomeCliente
            // 
            nomeCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeCliente.DataPropertyName = "NomeCliente";
            nomeCliente.HeaderText = "Cliente";
            nomeCliente.Name = "nomeCliente";
            nomeCliente.ReadOnly = true;
            // 
            // pedidoGerado
            // 
            pedidoGerado.DataPropertyName = "CupomFiscal";
            pedidoGerado.HeaderText = "CF";
            pedidoGerado.Name = "pedidoGerado";
            pedidoGerado.ReadOnly = true;
            // 
            // totalAVista
            // 
            totalAVista.DataPropertyName = "TotalAVista";
            totalAVista.HeaderText = "Total a Vista";
            totalAVista.Name = "totalAVista";
            totalAVista.ReadOnly = true;
            // 
            // saidaBindingSource
            // 
            saidaBindingSource.AllowNew = false;
            saidaBindingSource.DataSource = typeof(Dominio.SaidaPesquisa);
            // 
            // txtTexto
            // 
            txtTexto.CharacterCasing = CharacterCasing.Upper;
            txtTexto.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTexto.Location = new Point(329, 31);
            txtTexto.Margin = new Padding(4, 3, 4, 3);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(814, 24);
            txtTexto.TabIndex = 5;
            txtTexto.TextChanged += txtTexto_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(326, 7);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 18);
            label2.TabIndex = 9;
            label2.Text = "Texto:";
            // 
            // cmbBusca
            // 
            cmbBusca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusca.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBusca.FormattingEnabled = true;
            cmbBusca.ImeMode = ImeMode.On;
            cmbBusca.Items.AddRange(new object[] { "Pré-Vendas Pendentes", "Código", "Cupom Fiscal", "Nome Cliente", "Data Pedido" });
            cmbBusca.Location = new Point(9, 31);
            cmbBusca.Margin = new Padding(4, 3, 4, 3);
            cmbBusca.Name = "cmbBusca";
            cmbBusca.Size = new Size(312, 26);
            cmbBusca.TabIndex = 7;
            cmbBusca.SelectedIndexChanged += cmbBusca_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 7);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 18);
            label1.TabIndex = 6;
            label1.Text = "Buscar Por:";
            // 
            // FrmSaidaPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 367);
            Controls.Add(tb_saidaDataGridView);
            Controls.Add(txtTexto);
            Controls.Add(label2);
            Controls.Add(cmbBusca);
            Controls.Add(label1);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSaidaPesquisa";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pesquisa Saídas";
            Load += FrmSaidaPesquisa_Load;
            KeyDown += FrmSaidaPesquisa_KeyDown;
            ((System.ComponentModel.ISupportInitialize)tb_saidaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)saidaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tb_saidaDataGridView;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource saidaBindingSource;
        private DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DescricaoTipoSaida;
        private DataGridViewTextBoxColumn dataSaida;
        private DataGridViewTextBoxColumn nomeCliente;
        private DataGridViewTextBoxColumn pedidoGerado;
        private DataGridViewTextBoxColumn totalAVista;
    }
}