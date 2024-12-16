namespace The_System_That_Knows_You_Better_Than_You___
{
    partial class Grafik_Formu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.sonucgrafiği = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.sonucgrafiği)).BeginInit();
            this.SuspendLayout();
            // 
            // sonucgrafiği
            // 
            chartArea1.Name = "ChartArea1";
            this.sonucgrafiği.ChartAreas.Add(chartArea1);
            this.sonucgrafiği.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.sonucgrafiği.Legends.Add(legend1);
            this.sonucgrafiği.Location = new System.Drawing.Point(0, 0);
            this.sonucgrafiği.Name = "sonucgrafiği";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.sonucgrafiği.Series.Add(series1);
            this.sonucgrafiği.Size = new System.Drawing.Size(1159, 633);
            this.sonucgrafiği.TabIndex = 0;
            this.sonucgrafiği.Text = "Sonuç Grafiği";
            this.sonucgrafiği.Click += new System.EventHandler(this.sonucgrafiği_Click);
            // 
            // Grafik_Formu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 633);
            this.Controls.Add(this.sonucgrafiği);
            this.Name = "Grafik_Formu";
            this.Text = "Grafik_Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Grafik_Formu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sonucgrafiği)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart sonucgrafiği;
    }
}