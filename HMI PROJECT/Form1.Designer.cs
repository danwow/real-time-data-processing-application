namespace Projeto_IB1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btIniciar = new System.Windows.Forms.Button();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.timerPlot = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lbTempo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbBytestoRead = new System.Windows.Forms.Label();
            this.lbAmp = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbEspBuf = new System.Windows.Forms.Label();
            this.btnFIM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btIniciar
            // 
            this.btIniciar.Location = new System.Drawing.Point(11, 122);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(75, 23);
            this.btIniciar.TabIndex = 0;
            this.btIniciar.Text = "Iniciar";
            this.btIniciar.UseVisualStyleBackColor = true;
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // cbCOM
            // 
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(10, 59);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(121, 21);
            this.cbCOM.TabIndex = 1;
            this.cbCOM.SelectedIndexChanged += new System.EventHandler(this.cbCOM_SelectedIndexChanged);
            this.cbCOM.Click += new System.EventHandler(this.cbCOM_Click);
            // 
            // timerPlot
            // 
            this.timerPlot.Interval = 1000;
            // 
            // grafico
            // 
            this.grafico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.grafico.Legends.Add(legend1);
            this.grafico.Location = new System.Drawing.Point(136, 90);
            this.grafico.Name = "grafico";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafico.Series.Add(series1);
            this.grafico.Size = new System.Drawing.Size(511, 186);
            this.grafico.TabIndex = 5;
            this.grafico.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Escolha a Porta Serial";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.lbTempo);
            this.groupBox5.Location = new System.Drawing.Point(270, 8);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(106, 75);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tempo";
            this.groupBox5.Visible = false;
            // 
            // lbTempo
            // 
            this.lbTempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTempo.AutoSize = true;
            this.lbTempo.Location = new System.Drawing.Point(2, 32);
            this.lbTempo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTempo.Name = "lbTempo";
            this.lbTempo.Size = new System.Drawing.Size(36, 13);
            this.lbTempo.TabIndex = 18;
            this.lbTempo.Text = "tempo";
            this.lbTempo.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbBytestoRead);
            this.groupBox3.Location = new System.Drawing.Point(380, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(108, 72);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BytesToRead";
            this.groupBox3.Visible = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lbBytestoRead
            // 
            this.lbBytestoRead.AutoSize = true;
            this.lbBytestoRead.Location = new System.Drawing.Point(4, 32);
            this.lbBytestoRead.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBytestoRead.Name = "lbBytestoRead";
            this.lbBytestoRead.Size = new System.Drawing.Size(71, 13);
            this.lbBytestoRead.TabIndex = 14;
            this.lbBytestoRead.Text = "bytesToRead";
            this.lbBytestoRead.Visible = false;
            // 
            // lbAmp
            // 
            this.lbAmp.AutoSize = true;
            this.lbAmp.Location = new System.Drawing.Point(4, 46);
            this.lbAmp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAmp.Name = "lbAmp";
            this.lbAmp.Size = new System.Drawing.Size(53, 13);
            this.lbAmp.TabIndex = 0;
            this.lbAmp.Text = "Amplitude";
            this.lbAmp.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lbAmp);
            this.groupBox4.Location = new System.Drawing.Point(160, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(106, 72);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Amplitude";
            this.groupBox4.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbEspBuf);
            this.groupBox2.Location = new System.Drawing.Point(492, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(108, 72);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ocupação do Buffer";
            this.groupBox2.Visible = false;
            // 
            // lbEspBuf
            // 
            this.lbEspBuf.AutoSize = true;
            this.lbEspBuf.Location = new System.Drawing.Point(4, 46);
            this.lbEspBuf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEspBuf.Name = "lbEspBuf";
            this.lbEspBuf.Size = new System.Drawing.Size(43, 13);
            this.lbEspBuf.TabIndex = 5;
            this.lbEspBuf.Text = "espBuff";
            this.lbEspBuf.Visible = false;
            // 
            // btnFIM
            // 
            this.btnFIM.Location = new System.Drawing.Point(11, 160);
            this.btnFIM.Margin = new System.Windows.Forms.Padding(2);
            this.btnFIM.Name = "btnFIM";
            this.btnFIM.Size = new System.Drawing.Size(75, 23);
            this.btnFIM.TabIndex = 25;
            this.btnFIM.Text = "Finalizar";
            this.btnFIM.UseVisualStyleBackColor = true;
            this.btnFIM.Click += new System.EventHandler(this.btnFIM_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 323);
            this.Controls.Add(this.btnFIM);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.cbCOM);
            this.Controls.Add(this.btIniciar);
            this.Name = "Form1";
            this.Text = "ECG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btIniciar;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Timer timerPlot;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lbTempo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbBytestoRead;
        private System.Windows.Forms.Label lbAmp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbEspBuf;
        private System.Windows.Forms.Button btnFIM;
    }
}

