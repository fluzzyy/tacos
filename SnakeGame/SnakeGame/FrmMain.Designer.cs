namespace SnakeGame
{
    partial class FrmMain
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
            this.LblMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblMenu
            // 
            this.LblMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMenu.Location = new System.Drawing.Point(0, 0);
            this.LblMenu.Name = "LblMenu";
            this.LblMenu.Size = new System.Drawing.Size(332, 203);
            this.LblMenu.TabIndex = 0;
            this.LblMenu.Text = "Snake\r\n Created by Alexander Gunnarsson\r\n\r\nUse the arrow keys to change direction" +
    "\r\nUse Space to pause\r\nPress Enter to begin";
            this.LblMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 203);
            this.Controls.Add(this.LblMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 245);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake - Score: 1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblMenu;
    }
}

