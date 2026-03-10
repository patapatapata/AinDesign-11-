namespace AinDesign
{
    partial class Setting
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
            this.Rotation = new System.Windows.Forms.CheckBox();
            this.Position = new System.Windows.Forms.CheckBox();
            this.Tracking = new System.Windows.Forms.CheckBox();
            this.Tsume = new System.Windows.Forms.CheckBox();
            this.Italics = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Stroke = new System.Windows.Forms.CheckBox();
            this.Underline = new System.Windows.Forms.CheckBox();
            this.Aki = new System.Windows.Forms.CheckBox();
            this.NoBreak = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OneCharaMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Rotation
            // 
            this.Rotation.AutoSize = true;
            this.Rotation.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Rotation.Location = new System.Drawing.Point(11, 21);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(74, 19);
            this.Rotation.TabIndex = 1;
            this.Rotation.Text = "文字回転";
            this.Rotation.UseVisualStyleBackColor = true;
            // 
            // Position
            // 
            this.Position.AutoSize = true;
            this.Position.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Position.Location = new System.Drawing.Point(132, 21);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(92, 19);
            this.Position.TabIndex = 2;
            this.Position.Text = "上付き下付き";
            this.Position.UseVisualStyleBackColor = true;
            // 
            // Tracking
            // 
            this.Tracking.AutoSize = true;
            this.Tracking.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Tracking.Location = new System.Drawing.Point(11, 44);
            this.Tracking.Name = "Tracking";
            this.Tracking.Size = new System.Drawing.Size(77, 19);
            this.Tracking.TabIndex = 3;
            this.Tracking.Text = "トラッキング";
            this.Tracking.UseVisualStyleBackColor = true;
            // 
            // Tsume
            // 
            this.Tsume.AutoSize = true;
            this.Tsume.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Tsume.Location = new System.Drawing.Point(132, 44);
            this.Tsume.Name = "Tsume";
            this.Tsume.Size = new System.Drawing.Size(67, 19);
            this.Tsume.TabIndex = 4;
            this.Tsume.Text = "文字ツメ";
            this.Tsume.UseVisualStyleBackColor = true;
            // 
            // Italics
            // 
            this.Italics.AutoSize = true;
            this.Italics.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Italics.Location = new System.Drawing.Point(132, 90);
            this.Italics.Name = "Italics";
            this.Italics.Size = new System.Drawing.Size(89, 19);
            this.Italics.TabIndex = 8;
            this.Italics.Text = "欧文イタリック";
            this.Italics.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Stroke);
            this.groupBox1.Controls.Add(this.Underline);
            this.groupBox1.Controls.Add(this.Aki);
            this.groupBox1.Controls.Add(this.NoBreak);
            this.groupBox1.Controls.Add(this.Italics);
            this.groupBox1.Controls.Add(this.Rotation);
            this.groupBox1.Controls.Add(this.Position);
            this.groupBox1.Controls.Add(this.Tsume);
            this.groupBox1.Controls.Add(this.Tracking);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 8F);
            this.groupBox1.Location = new System.Drawing.Point(6, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 139);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "移植する設定にチェックを入れてください";
            // 
            // Stroke
            // 
            this.Stroke.AutoSize = true;
            this.Stroke.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Stroke.Location = new System.Drawing.Point(11, 115);
            this.Stroke.Name = "Stroke";
            this.Stroke.Size = new System.Drawing.Size(38, 19);
            this.Stroke.TabIndex = 9;
            this.Stroke.Text = "線";
            this.Stroke.UseVisualStyleBackColor = true;
            // 
            // Underline
            // 
            this.Underline.AutoSize = true;
            this.Underline.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Underline.Location = new System.Drawing.Point(11, 91);
            this.Underline.Name = "Underline";
            this.Underline.Size = new System.Drawing.Size(110, 19);
            this.Underline.TabIndex = 7;
            this.Underline.Text = "下線・打ち消し線";
            this.Underline.UseVisualStyleBackColor = true;
            // 
            // Aki
            // 
            this.Aki.AutoSize = true;
            this.Aki.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.Aki.Location = new System.Drawing.Point(11, 67);
            this.Aki.Name = "Aki";
            this.Aki.Size = new System.Drawing.Size(115, 19);
            this.Aki.TabIndex = 5;
            this.Aki.Text = "文字前後のアキ量";
            this.Aki.UseVisualStyleBackColor = true;
            // 
            // NoBreak
            // 
            this.NoBreak.AutoSize = true;
            this.NoBreak.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.NoBreak.Location = new System.Drawing.Point(132, 67);
            this.NoBreak.Name = "NoBreak";
            this.NoBreak.Size = new System.Drawing.Size(74, 19);
            this.NoBreak.TabIndex = 6;
            this.NoBreak.Text = "分離禁止";
            this.NoBreak.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button1.Location = new System.Drawing.Point(26, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.button2.Location = new System.Drawing.Point(125, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OneCharaMode
            // 
            this.OneCharaMode.AutoSize = true;
            this.OneCharaMode.Font = new System.Drawing.Font("Meiryo UI", 10F);
            this.OneCharaMode.Location = new System.Drawing.Point(14, 7);
            this.OneCharaMode.Name = "OneCharaMode";
            this.OneCharaMode.Size = new System.Drawing.Size(157, 22);
            this.OneCharaMode.TabIndex = 9;
            this.OneCharaMode.Text = "鈍足１文字モード有効";
            this.OneCharaMode.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.label1.Location = new System.Drawing.Point(11, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "1文字毎に設定を移植します。\r\n時間が掛かっても移植精度を上げたい場合に\r\n有効にしてください。";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 265);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OneCharaMode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Meiryo UI", 7F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Setting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "鈍足1文字モード設定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Rotation;
        private System.Windows.Forms.CheckBox Position;
        private System.Windows.Forms.CheckBox Tracking;
        private System.Windows.Forms.CheckBox Tsume;
        private System.Windows.Forms.CheckBox Italics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox NoBreak;
        private System.Windows.Forms.CheckBox Aki;
        private System.Windows.Forms.CheckBox Underline;
        private System.Windows.Forms.CheckBox Stroke;
        private System.Windows.Forms.CheckBox OneCharaMode;
        private System.Windows.Forms.Label label1;
    }
}