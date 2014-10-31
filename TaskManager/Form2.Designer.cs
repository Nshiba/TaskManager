namespace TaskManager
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.nametext = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.outlineBox = new System.Windows.Forms.RichTextBox();
            this.cansel = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.addTag = new System.Windows.Forms.Button();
            this.tagBox = new System.Windows.Forms.ComboBox();
            this.kigen = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "期限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "タスク名";
            // 
            // nametext
            // 
            this.nametext.Location = new System.Drawing.Point(17, 101);
            this.nametext.MaxLength = 10;
            this.nametext.Name = "nametext";
            this.nametext.Size = new System.Drawing.Size(121, 19);
            this.nametext.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(13, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "内容";
            // 
            // outlineBox
            // 
            this.outlineBox.Location = new System.Drawing.Point(17, 145);
            this.outlineBox.Name = "outlineBox";
            this.outlineBox.Size = new System.Drawing.Size(249, 96);
            this.outlineBox.TabIndex = 6;
            this.outlineBox.Text = "";
            // 
            // cansel
            // 
            this.cansel.Location = new System.Drawing.Point(197, 247);
            this.cansel.Name = "cansel";
            this.cansel.Size = new System.Drawing.Size(75, 23);
            this.cansel.TabIndex = 7;
            this.cansel.Text = "キャンセル";
            this.cansel.UseVisualStyleBackColor = true;
            this.cansel.Click += new System.EventHandler(this.cansel_Click_1);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(116, 247);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 8;
            this.add.Text = "追加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(145, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "タグ";
            // 
            // addTag
            // 
            this.addTag.Location = new System.Drawing.Point(197, 72);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(75, 23);
            this.addTag.TabIndex = 12;
            this.addTag.Text = "タグを追加";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // tagBox
            // 
            this.tagBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tagBox.FormattingEnabled = true;
            this.tagBox.Location = new System.Drawing.Point(150, 101);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(121, 20);
            this.tagBox.TabIndex = 13;
            // 
            // kigen
            // 
            this.kigen.Location = new System.Drawing.Point(17, 45);
            this.kigen.Name = "kigen";
            this.kigen.Size = new System.Drawing.Size(174, 19);
            this.kigen.TabIndex = 14;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(284, 282);
            this.Controls.Add(this.kigen);
            this.Controls.Add(this.tagBox);
            this.Controls.Add(this.addTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.add);
            this.Controls.Add(this.cansel);
            this.Controls.Add(this.outlineBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nametext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "タスクの追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox outlineBox;
        private System.Windows.Forms.Button cansel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.ComboBox tagBox;
        private System.Windows.Forms.DateTimePicker kigen;


    }
}