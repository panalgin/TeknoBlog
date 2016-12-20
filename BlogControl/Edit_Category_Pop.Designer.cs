namespace BlogControl
{
    partial class Edit_Category_Pop
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
            this.Name_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name_Box
            // 
            this.Name_Box.Location = new System.Drawing.Point(85, 12);
            this.Name_Box.Name = "Name_Box";
            this.Name_Box.Size = new System.Drawing.Size(264, 20);
            this.Name_Box.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori Adı:";
            // 
            // Delete_Button
            // 
            this.Delete_Button.Image = global::BlogControl.Properties.Resources.cancel;
            this.Delete_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete_Button.Location = new System.Drawing.Point(251, 86);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(98, 23);
            this.Delete_Button.TabIndex = 7;
            this.Delete_Button.Text = "İptal";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::BlogControl.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(147, 86);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(98, 23);
            this.Save_Button.TabIndex = 6;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Edit_Category_Pop
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Delete_Button;
            this.ClientSize = new System.Drawing.Size(361, 121);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Name_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Category_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kategori Düzenle";
            this.Load += new System.EventHandler(this.Edit_Category_Pop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.TextBox Name_Box;
        private System.Windows.Forms.Label label1;
    }
}