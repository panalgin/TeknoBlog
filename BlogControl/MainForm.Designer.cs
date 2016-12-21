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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool_Strip = new System.Windows.Forms.ToolStrip();
            this.Posts_Button = new System.Windows.Forms.ToolStripButton();
            this.Users_Button = new System.Windows.Forms.ToolStripButton();
            this.Categories_Button = new System.Windows.Forms.ToolStripButton();
            this.Comments_Button = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.Tool_Strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.çıkışToolStripMenuItem});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Tool_Strip
            // 
            this.Tool_Strip.AutoSize = false;
            this.Tool_Strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tool_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Posts_Button,
            this.Users_Button,
            this.Categories_Button,
            this.Comments_Button});
            this.Tool_Strip.Location = new System.Drawing.Point(0, 24);
            this.Tool_Strip.Name = "Tool_Strip";
            this.Tool_Strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Tool_Strip.Size = new System.Drawing.Size(897, 38);
            this.Tool_Strip.TabIndex = 4;
            this.Tool_Strip.Text = "toolStrip1";
            // 
            // Posts_Button
            // 
            this.Posts_Button.AutoSize = false;
            this.Posts_Button.Image = global::BlogControl.Properties.Resources.layout_content;
            this.Posts_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Posts_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Posts_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Posts_Button.Name = "Posts_Button";
            this.Posts_Button.Size = new System.Drawing.Size(125, 33);
            this.Posts_Button.Text = "İçerik Yönetimi";
            this.Posts_Button.Click += new System.EventHandler(this.Posts_Button_Click);
            // 
            // Users_Button
            // 
            this.Users_Button.AutoSize = false;
            this.Users_Button.Image = global::BlogControl.Properties.Resources.users_men_women;
            this.Users_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Users_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Users_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Users_Button.Name = "Users_Button";
            this.Users_Button.Size = new System.Drawing.Size(125, 33);
            this.Users_Button.Text = "Kullanıcılar";
            this.Users_Button.Click += new System.EventHandler(this.Users_Button_Click);
            // 
            // Categories_Button
            // 
            this.Categories_Button.AutoSize = false;
            this.Categories_Button.Image = global::BlogControl.Properties.Resources.category;
            this.Categories_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Categories_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Categories_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Categories_Button.Name = "Categories_Button";
            this.Categories_Button.Size = new System.Drawing.Size(125, 33);
            this.Categories_Button.Text = "Kategoriler";
            this.Categories_Button.Click += new System.EventHandler(this.Categories_Button_Click);
            // 
            // Comments_Button
            // 
            this.Comments_Button.AutoSize = false;
            this.Comments_Button.Image = global::BlogControl.Properties.Resources.comment;
            this.Comments_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Comments_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Comments_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Comments_Button.Name = "Comments_Button";
            this.Comments_Button.Size = new System.Drawing.Size(125, 33);
            this.Comments_Button.Text = "Yorumlar";
            this.Comments_Button.Click += new System.EventHandler(this.Comments_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 596);
            this.Controls.Add(this.Tool_Strip);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlogControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Tool_Strip.ResumeLayout(false);
            this.Tool_Strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStrip Tool_Strip;
        private System.Windows.Forms.ToolStripButton Posts_Button;
        private System.Windows.Forms.ToolStripButton Users_Button;
        private System.Windows.Forms.ToolStripButton Categories_Button;
        private System.Windows.Forms.ToolStripButton Comments_Button;
    }
}

