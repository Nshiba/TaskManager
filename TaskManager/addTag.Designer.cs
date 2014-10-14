namespace TaskManager
{
    partial class addTag
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
            this.tagName = new System.Windows.Forms.TextBox();
            this.cansel = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "タグ名を入力してください";
            // 
            // tagName
            // 
            this.tagName.Location = new System.Drawing.Point(18, 44);
            this.tagName.Name = "tagName";
            this.tagName.Size = new System.Drawing.Size(260, 19);
            this.tagName.TabIndex = 1;
            // 
            // cansel
            // 
            this.cansel.Location = new System.Drawing.Point(202, 80);
            this.cansel.Name = "cansel";
            this.cansel.Size = new System.Drawing.Size(75, 23);
            this.cansel.TabIndex = 2;
            this.cansel.Text = "キャンセル";
            this.cansel.UseVisualStyleBackColor = true;
            this.cansel.Click += new System.EventHandler(this.cansel_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(121, 79);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 3;
            this.add.Text = "追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // addTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 114);
            this.Controls.Add(this.add);
            this.Controls.Add(this.cansel);
            this.Controls.Add(this.tagName);
            this.Controls.Add(this.label1);
            this.Name = "addTag";
            this.Text = "タグの追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tagName;
        private System.Windows.Forms.Button cansel;
        private System.Windows.Forms.Button add;
    }
}