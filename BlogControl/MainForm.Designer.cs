namespace BlogControl
{
    using Custom;

    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Tool_Strip = new BlogControl.Custom.ToolStripEx();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.Categories_Button = new System.Windows.Forms.ToolStripButton();
            this.Comments_Button = new System.Windows.Forms.ToolStripButton();
            this.Users_Button = new System.Windows.Forms.ToolStripButton();
            this.Tool_Strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tool_Strip
            // 
            this.Tool_Strip.AutoSize = false;
            this.Tool_Strip.CanOverflow = false;
            this.Tool_Strip.Enabled = false;
            this.Tool_Strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tool_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.Categories_Button,
            this.Comments_Button,
            this.Users_Button});
            this.Tool_Strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.Tool_Strip.Location = new System.Drawing.Point(0, 0);
            this.Tool_Strip.Name = "Tool_Strip";
            this.Tool_Strip.Size = new System.Drawing.Size(897, 38);
            this.Tool_Strip.TabIndex = 0;
            this.Tool_Strip.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(126, 32);
            this.toolStripButton4.Text = "İçerik Yönetimi";
            // 
            // Categories_Button
            // 
            this.Categories_Button.AutoSize = false;
            this.Categories_Button.Image = ((System.Drawing.Image)(resources.GetObject("Categories_Button.Image")));
            this.Categories_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Categories_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Categories_Button.Name = "Categories_Button";
            this.Categories_Button.Size = new System.Drawing.Size(126, 32);
            this.Categories_Button.Text = "Kategoriler";
            this.Categories_Button.Click += new System.EventHandler(this.Categories_Button_Click);
            // 
            // Comments_Button
            // 
            this.Comments_Button.AutoSize = false;
            this.Comments_Button.Image = ((System.Drawing.Image)(resources.GetObject("Comments_Button.Image")));
            this.Comments_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Comments_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Comments_Button.Name = "Comments_Button";
            this.Comments_Button.Size = new System.Drawing.Size(126, 32);
            this.Comments_Button.Text = "Yorumlar";
            this.Comments_Button.Click += new System.EventHandler(this.Comments_Button_Click);
            // 
            // Users_Button
            // 
            this.Users_Button.AutoSize = false;
            this.Users_Button.Image = ((System.Drawing.Image)(resources.GetObject("Users_Button.Image")));
            this.Users_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Users_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Users_Button.Name = "Users_Button";
            this.Users_Button.Size = new System.Drawing.Size(126, 32);
            this.Users_Button.Text = "Kullanıcılar";
            this.Users_Button.Click += new System.EventHandler(this.Users_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 596);
            this.Controls.Add(this.Tool_Strip);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlogControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Tool_Strip.ResumeLayout(false);
            this.Tool_Strip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripEx Tool_Strip;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton Categories_Button;
        private System.Windows.Forms.ToolStripButton Comments_Button;
        private System.Windows.Forms.ToolStripButton Users_Button;
    }
}

