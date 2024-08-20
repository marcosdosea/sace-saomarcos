namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codProdutoLabel;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            panel1 = new Panel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            vendasPorGrupoBindingSource = new BindingSource(components);
            label5 = new Label();
            codGrupoComboBox = new ComboBox();
            grupoBindingSource = new BindingSource(components);
            dataInicioTimePicker = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dataFimTimePicker = new DateTimePicker();
            codProdutoLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vendasPorGrupoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grupoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codProdutoLabel.Location = new Point(8, 53);
            codProdutoLabel.Margin = new Padding(4, 0, 4, 0);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new Size(175, 24);
            codProdutoLabel.TabIndex = 126;
            codProdutoLabel.Text = "Grupo de Produtos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(265, 23);
            label1.TabIndex = 0;
            label1.Text = "Estatísticas por Grupo de Produtos";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(5, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1216, 47);
            panel1.TabIndex = 20;
            // 
            // chart1
            // 
            chart1.BackColor = Color.LightGray;
            chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkDownwardDiagonal;
            chart1.BackImageTransparentColor = Color.FromArgb(224, 224, 224);
            chart1.BackSecondaryColor = Color.FromArgb(224, 224, 224);
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.DataSource = vendasPorGrupoBindingSource;
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(5, 164);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1161, 414);
            chart1.TabIndex = 113;
            chart1.Text = "chart1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(7, 140);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(186, 18);
            label5.TabIndex = 115;
            label5.Text = "Gráfico Mensal de Vendas:";
            // 
            // codGrupoComboBox
            // 
            codGrupoComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codGrupoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codGrupoComboBox.CausesValidation = false;
            codGrupoComboBox.DataSource = grupoBindingSource;
            codGrupoComboBox.DisplayMember = "Descricao";
            codGrupoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            codGrupoComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codGrupoComboBox.FormattingEnabled = true;
            codGrupoComboBox.Location = new Point(10, 84);
            codGrupoComboBox.Margin = new Padding(4, 3, 4, 3);
            codGrupoComboBox.Name = "codGrupoComboBox";
            codGrupoComboBox.Size = new Size(629, 32);
            codGrupoComboBox.TabIndex = 5;
            codGrupoComboBox.ValueMember = "CodGrupo";
            codGrupoComboBox.SelectedIndexChanged += codGrupoComboBox_SelectedIndexChanged;
            codGrupoComboBox.KeyPress += codProdutoComboBox_KeyPress;
            // 
            // grupoBindingSource
            // 
            grupoBindingSource.DataSource = typeof(Dominio.Grupo);
            // 
            // dataInicioTimePicker
            // 
            dataInicioTimePicker.Font = new Font("Microsoft Sans Serif", 14F);
            dataInicioTimePicker.Format = DateTimePickerFormat.Short;
            dataInicioTimePicker.Location = new Point(662, 88);
            dataInicioTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataInicioTimePicker.Name = "dataInicioTimePicker";
            dataInicioTimePicker.Size = new Size(153, 29);
            dataInicioTimePicker.TabIndex = 127;
            dataInicioTimePicker.Leave += codGrupoComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14F);
            label2.Location = new Point(657, 53);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 24);
            label2.TabIndex = 128;
            label2.Text = "Data Início:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14F);
            label3.Location = new Point(842, 51);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(89, 24);
            label3.TabIndex = 130;
            label3.Text = "Data Fim:";
            // 
            // dataFimTimePicker
            // 
            dataFimTimePicker.Font = new Font("Microsoft Sans Serif", 14F);
            dataFimTimePicker.Format = DateTimePickerFormat.Short;
            dataFimTimePicker.Location = new Point(847, 88);
            dataFimTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataFimTimePicker.Name = "dataFimTimePicker";
            dataFimTimePicker.Size = new Size(153, 29);
            dataFimTimePicker.TabIndex = 129;
            dataFimTimePicker.Leave += codGrupoComboBox_SelectedIndexChanged;
            // 
            // FrmGrupoEstatistica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1220, 653);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(dataFimTimePicker);
            Controls.Add(label2);
            Controls.Add(dataInicioTimePicker);
            Controls.Add(codProdutoLabel);
            Controls.Add(codGrupoComboBox);
            Controls.Add(label5);
            Controls.Add(chart1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmGrupoEstatistica";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Estatísticas por Grupo";
            Load += FrmGrupoEstatistica_Load;
            KeyDown += FrmGrupoEstatistica_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)vendasPorGrupoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)grupoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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