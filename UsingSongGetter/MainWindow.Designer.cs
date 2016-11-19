namespace UsingSongGetter
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleBar = new System.Windows.Forms.Panel();
            this.titleBar_Close = new System.Windows.Forms.Panel();
            this.titleBar_Minimize = new System.Windows.Forms.Panel();
            this.titleBar_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.titleBar.Controls.Add(this.pictureBox1);
            this.titleBar.Controls.Add(this.titleBar_Title);
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(470, 25);
            this.titleBar.TabIndex = 0;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // titleBar_Close
            // 
            this.titleBar_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.titleBar_Close.Location = new System.Drawing.Point(445, 0);
            this.titleBar_Close.Name = "titleBar_Close";
            this.titleBar_Close.Size = new System.Drawing.Size(25, 25);
            this.titleBar_Close.TabIndex = 1;
            this.titleBar_Close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titleBar_Close_MouseClick);
            this.titleBar_Close.MouseEnter += new System.EventHandler(this.titleBar_Close_MouseEnter);
            this.titleBar_Close.MouseLeave += new System.EventHandler(this.titleBar_Close_MouseLeave);
            // 
            // titleBar_Minimize
            // 
            this.titleBar_Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.titleBar_Minimize.Location = new System.Drawing.Point(420, 0);
            this.titleBar_Minimize.Name = "titleBar_Minimize";
            this.titleBar_Minimize.Size = new System.Drawing.Size(25, 25);
            this.titleBar_Minimize.TabIndex = 2;
            this.titleBar_Minimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.titleBar_Minimize_MouseClick);
            this.titleBar_Minimize.MouseEnter += new System.EventHandler(this.titleBar_Minimize_MouseEnter);
            this.titleBar_Minimize.MouseLeave += new System.EventHandler(this.titleBar_Minimize_MouseLeave);
            // 
            // titleBar_Title
            // 
            this.titleBar_Title.AutoSize = true;
            this.titleBar_Title.Location = new System.Drawing.Point(25, 7);
            this.titleBar_Title.Name = "titleBar_Title";
            this.titleBar_Title.Size = new System.Drawing.Size(88, 13);
            this.titleBar_Title.TabIndex = 3;
            this.titleBar_Title.Text = "UsingSongGetter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UsingSongGetter.Properties.Resources.titleLogo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(470, 670);
            this.Controls.Add(this.titleBar_Minimize);
            this.Controls.Add(this.titleBar_Close);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsingSongGetter";
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Panel titleBar_Close;
        private System.Windows.Forms.Panel titleBar_Minimize;
        private System.Windows.Forms.Label titleBar_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

