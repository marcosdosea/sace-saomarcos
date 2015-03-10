namespace Telas
{
    partial class FrmGrupoEstatistica
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
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.vendasPorGrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.codGrupoComboBox = new System.Windows.Forms.ComboBox();
            this.grupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataInicioTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataFimTimePicker = new System.Windows.Forms.DateTimePicker();
            codProdutoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorGrupoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codProdutoLabel.Location = new System.Drawing.Point(7, 46);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(175, 24);
            codProdutoLabel.TabIndex = 126;
            codProdutoLabel.Text = "Grupo de Produtos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estatísticas por Grupo de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 41);
            this.panel1.TabIndex = 20;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkDownwardDiagonal;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.vendasPorGrupoBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 142);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(858, 412);
            this.chart1.TabIndex = 113;
            this.chart1.Text = "chart1";
            // 
            // vendasPorGrupoBindingSource
            // 
            this.vendasPorGrupoBindingSource.DataMember = "VendasPorGrupo";
            this.vendasPorGrupoBindingSource.DataSource = typeof(Dados.saceDataSetConsultas);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 18);
            this.label5.TabIndex = 115;
            this.label5.Text = "Gráfico Mensal de Vendas:";
            // 
            // codGrupoComboBox
            // 
            this.codGrupoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codGrupoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codGrupoComboBox.CausesValidation = false;
            this.codGrupoComboBox.DataSource = this.grupoBindingSource;
            this.codGrupoComboBox.DisplayMember = "Descricao";
            this.codGrupoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codGrupoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codGrupoComboBox.FormattingEnabled = true;
            this.codGrupoComboBox.Location = new System.Drawing.Point(9, 73);
            this.codGrupoComboBox.Name = "codGrupoComboBox";
            this.codGrupoComboBox.Size = new System.Drawing.Size(540, 32);
            this.codGrupoComboBox.TabIndex = 5;
            this.codGrupoComboBox.ValueMember = "CodGrupo";
            this.codGrupoComboBox.SelectedIndexChanged += new System.EventHandler(this.codGrupoComboBox_SelectedIndexChanged);
            this.codGrupoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codProdutoComboBox_KeyPress);
            // 
            // grupoBindingSource
            // 
            this.grupoBindingSource.DataSource = typeof(Dominio.Grupo);
            // 
            // dataInicioTimePicker
            // 
            this.dataInicioTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dataInicioTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicioTimePicker.Location = new System.Drawing.Point(567, 76);
            this.dataInicioTimePicker.Name = "dataInicioTimePicker";
            this.dataInicioTimePicker.Size = new System.Drawing.Size(132, 29);
            this.dataInicioTimePicker.TabIndex = 127;
            this.dataInicioTimePicker.Leave += new System.EventHandler(this.codGrupoComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(563, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 128;
            this.label2.Text = "Data Início:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(722, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 24);
            this.label3.TabIndex = 130;
            this.label3.Text = "Data Fim:";
            // 
            // dataFimTimePicker
            // 
            this.dataFimTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dataFimTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFimTimePicker.Location = new System.Drawing.Point(726, 76);
            this.dataFimTimePicker.Name = "dataFimTimePicker";
            this.dataFimTimePicker.Size = new System.Drawing.Size(132, 29);
            this.dataFimTimePicker.TabIndex = 129;
            this.dataFimTimePicker.Leave += new System.EventHandler(this.codGrupoComboBox_SelectedIndexChanged);
            // 
            // FrmGrupoEstatistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 566);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataFimTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataInicioTimePicker);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.codGrupoComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmGrupoEstatistica";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estatísticas por Grupo";
            this.Load += new System.EventHandler(this.FrmGrupoEstatistica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGrupoEstatistica_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasPorGrupoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox codGrupoComboBox;
        private System.Windows.Forms.BindingSource grupoBindingSource;
        private System.Windows.Forms.DateTimePicker dataInicioTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataFimTimePicker;
        private System.Windows.Forms.BindingSource vendasPorGrupoBindingSource;
    }
}