namespace BlogControl
{
    partial class Manage_Users_Mdi
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
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Edit_Button = new System.Windows.Forms.Button();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Users_List = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.Enabled = false;
            this.Delete_Button.Location = new System.Drawing.Point(517, 70);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(86, 23);
            this.Delete_Button.TabIndex = 3;
            this.Delete_Button.Text = "Sil";
            this.Delete_Button.UseVisualStyleBackColor = true;
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.Enabled = false;
            this.Edit_Button.Location = new System.Drawing.Point(517, 41);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(86, 23);
            this.Edit_Button.TabIndex = 2;
            this.Edit_Button.Text = "Düzenle";
            this.Edit_Button.UseVisualStyleBackColor = true;
            // 
            // Add_Button
            // 
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Location = new System.Drawing.Point(517, 12);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(86, 23);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Yeni";
            this.Add_Button.UseVisualStyleBackColor = true;
            // 
            // Users_List
            // 
            this.Users_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Users_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.Users_List.FullRowSelect = true;
            this.Users_List.GridLines = true;
            this.Users_List.Location = new System.Drawing.Point(12, 12);
            this.Users_List.MultiSelect = false;
            this.Users_List.Name = "Users_List";
            this.Users_List.Size = new System.Drawing.Size(499, 378);
            this.Users_List.TabIndex = 0;
            this.Users_List.UseCompatibleStateImageBehavior = false;
            this.Users_List.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kullanıcı Adı";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 126;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 216;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Yetki";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 152;
            // 
            // Manage_Users_Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 402);
            this.Controls.Add(this.Users_List);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Edit_Button);
            this.Controls.Add(this.Add_Button);
            this.Name = "Manage_Users_Mdi";
            this.Text = "Kullanıcıları Yönet";
            this.Load += new System.EventHandler(this.Manage_Users_Mdi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Edit_Button;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.ListView Users_List;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}