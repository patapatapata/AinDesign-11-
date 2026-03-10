namespace AinDesign
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConvertRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Convert_Table = new System.Windows.Forms.Button();
            this.myMargin = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.myMarginY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.Convert_OneFrame = new System.Windows.Forms.Button();
            this.checkXY = new System.Windows.Forms.CheckBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OneCharaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用Ver切替ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.myMargin)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMarginY)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertRun
            // 
            this.ConvertRun.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.ConvertRun.Location = new System.Drawing.Point(8, 67);
            this.ConvertRun.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ConvertRun.Name = "ConvertRun";
            this.ConvertRun.Size = new System.Drawing.Size(218, 25);
            this.ConvertRun.TabIndex = 0;
            this.ConvertRun.Text = "実行";
            this.ConvertRun.UseVisualStyleBackColor = true;
            this.ConvertRun.Click += new System.EventHandler(this.ConvertRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Illustratorで選択しているテキストを\r\nInDesignに移植します。";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 67);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(216, 25);
            this.progressBar1.TabIndex = 2;
            // 
            // Convert_Table
            // 
            this.Convert_Table.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Convert_Table.Location = new System.Drawing.Point(128, 48);
            this.Convert_Table.Name = "Convert_Table";
            this.Convert_Table.Size = new System.Drawing.Size(83, 46);
            this.Convert_Table.TabIndex = 3;
            this.Convert_Table.Text = "表に変換";
            this.Convert_Table.UseVisualStyleBackColor = true;
            this.Convert_Table.Click += new System.EventHandler(this.Convert_Table_Click);
            // 
            // myMargin
            // 
            this.myMargin.DecimalPlaces = 1;
            this.myMargin.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.myMargin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.myMargin.Location = new System.Drawing.Point(9, 51);
            this.myMargin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.myMargin.Name = "myMargin";
            this.myMargin.Size = new System.Drawing.Size(47, 23);
            this.myMargin.TabIndex = 4;
            this.myMargin.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.myMargin.ValueChanged += new System.EventHandler(this.MyMargin_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "誤差許容値(mm)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.myMarginY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Convert_OneFrame);
            this.groupBox1.Controls.Add(this.checkXY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.myMargin);
            this.groupBox1.Controls.Add(this.Convert_Table);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.progressBar3);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(8, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label4.Location = new System.Drawing.Point(64, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y(タテ)";
            // 
            // myMarginY
            // 
            this.myMarginY.DecimalPlaces = 1;
            this.myMarginY.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.myMarginY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.myMarginY.Location = new System.Drawing.Point(64, 51);
            this.myMarginY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.myMarginY.Name = "myMarginY";
            this.myMarginY.Size = new System.Drawing.Size(47, 23);
            this.myMarginY.TabIndex = 9;
            this.myMarginY.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.myMarginY.ValueChanged += new System.EventHandler(this.MyMarginY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "X(ヨコ)";
            // 
            // Convert_OneFrame
            // 
            this.Convert_OneFrame.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Convert_OneFrame.Location = new System.Drawing.Point(128, 15);
            this.Convert_OneFrame.Name = "Convert_OneFrame";
            this.Convert_OneFrame.Size = new System.Drawing.Size(83, 30);
            this.Convert_OneFrame.TabIndex = 7;
            this.Convert_OneFrame.Text = "1枠に収納";
            this.Convert_OneFrame.UseVisualStyleBackColor = true;
            this.Convert_OneFrame.Click += new System.EventHandler(this.Convert_OneFrame_Click);
            // 
            // checkXY
            // 
            this.checkXY.AutoSize = true;
            this.checkXY.Location = new System.Drawing.Point(9, 80);
            this.checkXY.Name = "checkXY";
            this.checkXY.Size = new System.Drawing.Size(93, 19);
            this.checkXY.TabIndex = 6;
            this.checkXY.Text = "座標移動する";
            this.checkXY.UseVisualStyleBackColor = true;
            this.checkXY.CheckedChanged += new System.EventHandler(this.CheckXY_CheckedChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(128, 48);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(83, 46);
            this.progressBar2.TabIndex = 9;
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(128, 15);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(83, 30);
            this.progressBar3.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.設定ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(232, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.設定ToolStripMenuItem.Text = "ファイル";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ExitToolStripMenuItem.Text = "終了";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem1
            // 
            this.設定ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorConvertToolStripMenuItem,
            this.OneCharaToolStripMenuItem,
            this.OtherToolStripMenuItem,
            this.使用Ver切替ToolStripMenuItem});
            this.設定ToolStripMenuItem1.Name = "設定ToolStripMenuItem1";
            this.設定ToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem1.Text = "設定";
            // 
            // ColorConvertToolStripMenuItem
            // 
            this.ColorConvertToolStripMenuItem.Name = "ColorConvertToolStripMenuItem";
            this.ColorConvertToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.ColorConvertToolStripMenuItem.Text = "カラー適用設定";
            this.ColorConvertToolStripMenuItem.Click += new System.EventHandler(this.ColorConvertToolStripMenuItem_Click);
            // 
            // OneCharaToolStripMenuItem
            // 
            this.OneCharaToolStripMenuItem.Name = "OneCharaToolStripMenuItem";
            this.OneCharaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.OneCharaToolStripMenuItem.Text = "鈍足1文字モード設定";
            this.OneCharaToolStripMenuItem.Click += new System.EventHandler(this.OneCharaToolStripMenuItem_Click);
            // 
            // OtherToolStripMenuItem
            // 
            this.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem";
            this.OtherToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.OtherToolStripMenuItem.Text = "アプリケーション設定";
            this.OtherToolStripMenuItem.Click += new System.EventHandler(this.OtherToolStripMenuItem_Click);
            // 
            // 使用Ver切替ToolStripMenuItem
            // 
            this.使用Ver切替ToolStripMenuItem.Name = "使用Ver切替ToolStripMenuItem";
            this.使用Ver切替ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.使用Ver切替ToolStripMenuItem.Text = "使用Ver.切替";
            this.使用Ver切替ToolStripMenuItem.Click += new System.EventHandler(this.使用Ver切替ToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.label5.Location = new System.Drawing.Point(179, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "β 0.7.6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 6F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(183, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 10);
            this.label6.TabIndex = 9;
            this.label6.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DeepPink;
            this.label7.Font = new System.Drawing.Font("Meiryo UI", 6F);
            this.label7.ForeColor = System.Drawing.Color.Cyan;
            this.label7.Location = new System.Drawing.Point(194, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 10);
            this.label7.TabIndex = 10;
            this.label7.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Orange;
            this.label8.Font = new System.Drawing.Font("Meiryo UI", 6F);
            this.label8.ForeColor = System.Drawing.Color.Cyan;
            this.label8.Location = new System.Drawing.Point(205, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(8, 10);
            this.label8.TabIndex = 11;
            this.label8.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Meiryo UI", 6F);
            this.label9.ForeColor = System.Drawing.Color.Cyan;
            this.label9.Location = new System.Drawing.Point(216, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(8, 10);
            this.label9.TabIndex = 12;
            this.label9.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 173);
            this.panel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button1.Location = new System.Drawing.Point(8, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label12.Location = new System.Drawing.Point(116, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "InDesign";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label11.Location = new System.Drawing.Point(7, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Illustrator";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label10.Location = new System.Drawing.Point(7, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "使用Ver.を選択してください。";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 15;
            this.listBox2.Items.AddRange(new object[] {
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026"});
            this.listBox2.Location = new System.Drawing.Point(119, 43);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(105, 94);
            this.listBox2.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.listBox1.Location = new System.Drawing.Point(8, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(106, 94);
            this.listBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 197);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConvertRun);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AinDesign⑪";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.myMargin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myMarginY)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Convert_Table;
        private System.Windows.Forms.NumericUpDown myMargin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkXY;
        private System.Windows.Forms.Button Convert_OneFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown myMarginY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OneCharaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorConvertToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ToolStripMenuItem OtherToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 使用Ver切替ToolStripMenuItem;
    }
}

