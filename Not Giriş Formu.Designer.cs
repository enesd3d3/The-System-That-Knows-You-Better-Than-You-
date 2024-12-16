using System;

namespace The_System_That_Knows_You_Better_Than_You___
{
    partial class Not_Giriş_Formu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data_gridNotlar = new System.Windows.Forms.DataGridView();
            this.Ders_adı = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Not_bilgisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_katdetvedevamet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_gridNotlar)).BeginInit();
            this.SuspendLayout();
            // 
            // data_gridNotlar
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.data_gridNotlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.data_gridNotlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_gridNotlar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.data_gridNotlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MV Boli", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_gridNotlar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_gridNotlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_gridNotlar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ders_adı,
            this.Not_bilgisi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_gridNotlar.DefaultCellStyle = dataGridViewCellStyle3;
            this.data_gridNotlar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.data_gridNotlar.Location = new System.Drawing.Point(252, 2);
            this.data_gridNotlar.Name = "data_gridNotlar";
            this.data_gridNotlar.RowHeadersVisible = false;
            this.data_gridNotlar.RowHeadersWidth = 51;
            this.data_gridNotlar.RowTemplate.Height = 24;
            this.data_gridNotlar.Size = new System.Drawing.Size(649, 202);
            this.data_gridNotlar.TabIndex = 1;
            this.data_gridNotlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_gridNotlar_CellContentClick);
            // 
            // Ders_adı
            // 
            this.Ders_adı.HeaderText = "Ders Adı";
            this.Ders_adı.MinimumWidth = 6;
            this.Ders_adı.Name = "Ders_adı";
            this.Ders_adı.ReadOnly = true;
            // 
            // Not_bilgisi
            // 
            this.Not_bilgisi.HeaderText = "Not Girişi";
            this.Not_bilgisi.MinimumWidth = 6;
            this.Not_bilgisi.Name = "Not_bilgisi";
            // 
            // btn_katdetvedevamet
            // 
            this.btn_katdetvedevamet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.btn_katdetvedevamet.Font = new System.Drawing.Font("Nirmala Text", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_katdetvedevamet.Location = new System.Drawing.Point(1034, 579);
            this.btn_katdetvedevamet.Name = "btn_katdetvedevamet";
            this.btn_katdetvedevamet.Size = new System.Drawing.Size(137, 65);
            this.btn_katdetvedevamet.TabIndex = 2;
            this.btn_katdetvedevamet.Text = "Kaydet ve Devam Et";
            this.btn_katdetvedevamet.UseVisualStyleBackColor = false;
            this.btn_katdetvedevamet.Click += new System.EventHandler(this.btn_kaydetvedevamet_Click_1);
            // 
            // Not_Giriş_Formu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::The_System_That_Knows_You_Better_Than_You___.Properties.Resources.eğitim_foto;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1183, 748);
            this.Controls.Add(this.btn_katdetvedevamet);
            this.Controls.Add(this.data_gridNotlar);
            this.Name = "Not_Giriş_Formu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Not_Giriş_Formu";
            this.Load += new System.EventHandler(this.Not_Giriş_Formu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_gridNotlar)).EndInit();
            this.ResumeLayout(false);

        }

        private void btn_kaydetvedevamet_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView data_gridNotlar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ders_adı;
        private System.Windows.Forms.DataGridViewTextBoxColumn Not_bilgisi;
        private System.Windows.Forms.Button btn_katdetvedevamet;
    }
}