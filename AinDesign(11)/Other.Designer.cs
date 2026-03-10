namespace AinDesign
{
    partial class Other
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
            this.ShowMessage = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MultiPara = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MultiChara = new System.Windows.Forms.NumericUpDown();
            this.MultiFrame = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MultiPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiChara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowMessage
            // 
            this.ShowMessage.AutoSize = true;
            this.ShowMessage.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.ShowMessage.Location = new System.Drawing.Point(12, 12);
            this.ShowMessage.Name = "ShowMessage";
            this.ShowMessage.Size = new System.Drawing.Size(171, 19);
            this.ShowMessage.TabIndex = 1;
            this.ShowMessage.Text = "処理終了メッセージを表示する";
            this.ShowMessage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button2.Location = new System.Drawing.Point(118, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button1.Location = new System.Drawing.Point(19, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.MultiPara);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.MultiChara);
            this.groupBox1.Controls.Add(this.MultiFrame);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(11, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 213);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "マルチスレッド制限";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label6.Location = new System.Drawing.Point(74, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 19;
            this.label6.Text = "(1～64)";
            // 
            // MultiPara
            // 
            this.MultiPara.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MultiPara.Location = new System.Drawing.Point(10, 138);
            this.MultiPara.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.MultiPara.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MultiPara.Name = "MultiPara";
            this.MultiPara.Size = new System.Drawing.Size(58, 23);
            this.MultiPara.TabIndex = 4;
            this.MultiPara.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MultiPara.ValueChanged += new System.EventHandler(this.MultiPara_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "同時に処理する段落数";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label5.Location = new System.Drawing.Point(73, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "(1～1024)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label4.Location = new System.Drawing.Point(73, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "(1～16)";
            // 
            // MultiChara
            // 
            this.MultiChara.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MultiChara.Location = new System.Drawing.Point(9, 185);
            this.MultiChara.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.MultiChara.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MultiChara.Name = "MultiChara";
            this.MultiChara.Size = new System.Drawing.Size(58, 23);
            this.MultiChara.TabIndex = 5;
            this.MultiChara.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // MultiFrame
            // 
            this.MultiFrame.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MultiFrame.Location = new System.Drawing.Point(9, 89);
            this.MultiFrame.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.MultiFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MultiFrame.Name = "MultiFrame";
            this.MultiFrame.Size = new System.Drawing.Size(58, 23);
            this.MultiFrame.TabIndex = 3;
            this.MultiFrame.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MultiFrame.ValueChanged += new System.EventHandler(this.MultiFrame_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "同時に処理するテキストフレーム数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "同時に処理する文字数(1文字モード)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "処理の速度を調整を行います。\r\nハードスペックに合わせて調整してください。\r\n[表に変換][1枠に収納]には影響しません。";
            // 
            // Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 291);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowMessage);
            this.Font = new System.Drawing.Font("Meiryo UI", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Other";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "アプリケーション設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MultiPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiChara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowMessage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MultiChara;
        private System.Windows.Forms.NumericUpDown MultiFrame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown MultiPara;
        private System.Windows.Forms.Label label7;
    }
}