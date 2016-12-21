namespace BlogControl
{
    partial class Edit_Comment_Pop
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
            this.label1 = new System.Windows.Forms.Label();
            this.Comment_Box = new System.Windows.Forms.TextBox();
            this.Author_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yorum:";
            // 
            // Comment_Box
            // 
            this.Comment_Box.Location = new System.Drawing.Point(99, 39);
            this.Comment_Box.Multiline = true;
            this.Comment_Box.Name = "Comment_Box";
            this.Comment_Box.Size = new System.Drawing.Size(271, 103);
            this.Comment_Box.TabIndex = 1;
            // 
            // Author_Label
            // 
            this.Author_Label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Author_Label.Location = new System.Drawing.Point(99, 12);
            this.Author_Label.Margin = new System.Windows.Forms.Padding(3);
            this.Author_Label.Name = "Author_Label";
            this.Author_Label.Size = new System.Drawing.Size(271, 21);
            this.Author_Label.TabIndex = 0;
            this.Author_Label.Text = "label2";
            this.Author_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sahibi:";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Image = global::BlogControl.Properties.Resources.cancel;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(272, 177);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(98, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "İptal";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Image = global::BlogControl.Properties.Resources.tick;
            this.Save_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Button.Location = new System.Drawing.Point(168, 177);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(98, 23);
            this.Save_Button.TabIndex = 2;
            this.Save_Button.Text = "Kaydet";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Edit_Comment_Pop
            // 
            this.AcceptButton = this.Save_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(382, 212);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Author_Label);
            this.Controls.Add(this.Comment_Box);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit_Comment_Pop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yorumu Düzenle";
            this.Load += new System.EventHandler(this.Edit_Comment_Pop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Comment_Box;
        private System.Windows.Forms.Label Author_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Button Save_Button;
    }
}