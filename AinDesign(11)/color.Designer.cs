namespace AinDesign
{
    partial class color
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
            this.colorConvert = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CMYK0 = new System.Windows.Forms.CheckBox();
            this.CMY0 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorConvert
            // 
            this.colorConvert.AutoSize = true;
            this.colorConvert.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.colorConvert.Location = new System.Drawing.Point(13, 12);
            this.colorConvert.Name = "colorConvert";
            this.colorConvert.Size = new System.Drawing.Size(198, 19);
            this.colorConvert.TabIndex = 0;
            this.colorConvert.Text = "スウォッチを追加してカラーを適用する";
            this.colorConvert.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CMYK0);
            this.groupBox1.Controls.Add(this.CMY0);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "オプション";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "スポットカラー(特色・グローバルカラー)が適用\r\nされているものは[黒][紙色]処理されません";
            // 
            // CMYK0
            // 
            this.CMYK0.AutoSize = true;
            this.CMYK0.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.CMYK0.Location = new System.Drawing.Point(12, 48);
            this.CMYK0.Name = "CMYK0";
            this.CMYK0.Size = new System.Drawing.Size(198, 19);
            this.CMYK0.TabIndex = 1;
            this.CMYK0.Text = "CMYK値が0の時[紙色]で処理する";
            this.CMYK0.UseVisualStyleBackColor = true;
            // 
            // CMY0
            // 
            this.CMY0.AutoSize = true;
            this.CMY0.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.CMY0.Location = new System.Drawing.Point(12, 23);
            this.CMY0.Name = "CMY0";
            this.CMY0.Size = new System.Drawing.Size(178, 19);
            this.CMY0.TabIndex = 0;
            this.CMY0.Text = "CMY値が0の時[黒]で処理する";
            this.CMY0.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button2.Location = new System.Drawing.Point(123, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button1.Location = new System.Drawing.Point(24, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "カラーはすべてプロセスCMYKで処理されます。\r\n特色もプロセスカラーとして処理されます。";
            // 
            // color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 218);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.colorConvert);
            this.Font = new System.Drawing.Font("Meiryo UI", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "color";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "カラー適用設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colorConvert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CMY0;
        private System.Windows.Forms.CheckBox CMYK0;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}