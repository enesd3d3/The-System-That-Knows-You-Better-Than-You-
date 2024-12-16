namespace The_System_That_Knows_You_Better_Than_You___
{
    partial class Buraya_tıkla
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
            this.mesa_txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mesa_txtbox
            // 
            this.mesa_txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mesa_txtbox.Location = new System.Drawing.Point(0, 0);
            this.mesa_txtbox.Multiline = true;
            this.mesa_txtbox.Name = "mesa_txtbox";
            this.mesa_txtbox.ReadOnly = true;
            this.mesa_txtbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mesa_txtbox.Size = new System.Drawing.Size(800, 450);
            this.mesa_txtbox.TabIndex = 0;
            // 
            // Buraya_tıkla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mesa_txtbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Buraya_tıkla";
            this.Text = "Merhaba";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mesa_txtbox;
    }
}