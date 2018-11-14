namespace BrownDust_Calculator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Attacker = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox_Supporter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Supporter = new System.Windows.Forms.TableLayoutPanel();
            this.label_S03 = new System.Windows.Forms.Label();
            this.label_S02 = new System.Windows.Forms.Label();
            this.label_S01 = new System.Windows.Forms.Label();
            this.label_S00 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel_Attacker.SuspendLayout();
            this.groupBox_Supporter.SuspendLayout();
            this.tableLayoutPanel_Supporter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(888, 660);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.button_Save);
            this.tabPage1.Controls.Add(this.button_Calculate);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox_Supporter);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(880, 634);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(682, 37);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(138, 40);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.Location = new System.Drawing.Point(482, 37);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(138, 40);
            this.button_Calculate.TabIndex = 3;
            this.button_Calculate.Text = "Do it!";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_DO_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.tableLayoutPanel_Attacker);
            this.groupBox1.Location = new System.Drawing.Point(6, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 415);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "攻击角色数据";
            // 
            // tableLayoutPanel_Attacker
            // 
            this.tableLayoutPanel_Attacker.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_Attacker.ColumnCount = 9;
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Attacker.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label8, 8, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label7, 7, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label10, 5, 0);
            this.tableLayoutPanel_Attacker.Location = new System.Drawing.Point(30, 30);
            this.tableLayoutPanel_Attacker.Name = "tableLayoutPanel_Attacker";
            this.tableLayoutPanel_Attacker.RowCount = 9;
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Attacker.Size = new System.Drawing.Size(816, 373);
            this.tableLayoutPanel_Attacker.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "暴伤(%)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "暴率(%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "攻击";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "角色";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "敏捷(%)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(717, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "合计";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(553, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "追伤";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "普伤";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 24);
            this.label10.TabIndex = 16;
            this.label10.Text = "防御(%)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_Supporter
            // 
            this.groupBox_Supporter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Supporter.Controls.Add(this.tableLayoutPanel_Supporter);
            this.groupBox_Supporter.Location = new System.Drawing.Point(6, 6);
            this.groupBox_Supporter.Name = "groupBox_Supporter";
            this.groupBox_Supporter.Size = new System.Drawing.Size(384, 199);
            this.groupBox_Supporter.TabIndex = 1;
            this.groupBox_Supporter.TabStop = false;
            this.groupBox_Supporter.Text = "支援角色数据";
            // 
            // tableLayoutPanel_Supporter
            // 
            this.tableLayoutPanel_Supporter.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_Supporter.ColumnCount = 5;
            this.tableLayoutPanel_Supporter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_Supporter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_Supporter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_Supporter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_Supporter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_S03, 3, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_S02, 2, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_S01, 1, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_S00, 0, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel_Supporter.Location = new System.Drawing.Point(30, 20);
            this.tableLayoutPanel_Supporter.Name = "tableLayoutPanel_Supporter";
            this.tableLayoutPanel_Supporter.RowCount = 5;
            this.tableLayoutPanel_Supporter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Supporter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Supporter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Supporter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Supporter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Supporter.Size = new System.Drawing.Size(327, 162);
            this.tableLayoutPanel_Supporter.TabIndex = 1;
            // 
            // label_S03
            // 
            this.label_S03.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_S03.AutoSize = true;
            this.label_S03.Location = new System.Drawing.Point(221, 11);
            this.label_S03.Name = "label_S03";
            this.label_S03.Size = new System.Drawing.Size(53, 12);
            this.label_S03.TabIndex = 3;
            this.label_S03.Text = "暴伤buff";
            // 
            // label_S02
            // 
            this.label_S02.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_S02.AutoSize = true;
            this.label_S02.Location = new System.Drawing.Point(159, 11);
            this.label_S02.Name = "label_S02";
            this.label_S02.Size = new System.Drawing.Size(53, 12);
            this.label_S02.TabIndex = 2;
            this.label_S02.Text = "暴率buff";
            // 
            // label_S01
            // 
            this.label_S01.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_S01.AutoSize = true;
            this.label_S01.Location = new System.Drawing.Point(97, 11);
            this.label_S01.Name = "label_S01";
            this.label_S01.Size = new System.Drawing.Size(53, 12);
            this.label_S01.TabIndex = 1;
            this.label_S01.Text = "攻击buff";
            // 
            // label_S00
            // 
            this.label_S00.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_S00.AutoSize = true;
            this.label_S00.Location = new System.Drawing.Point(32, 11);
            this.label_S00.Name = "label_S00";
            this.label_S00.Size = new System.Drawing.Size(29, 12);
            this.label_S00.TabIndex = 0;
            this.label_S00.Text = "角色";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(288, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "选中";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(880, 634);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Supporter Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 687);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "BrownDust Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.PerformLayout();
            this.groupBox_Supporter.ResumeLayout(false);
            this.tableLayoutPanel_Supporter.ResumeLayout(false);
            this.tableLayoutPanel_Supporter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Attacker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_Supporter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Supporter;
        private System.Windows.Forms.Label label_S03;
        private System.Windows.Forms.Label label_S02;
        private System.Windows.Forms.Label label_S01;
        private System.Windows.Forms.Label label_S00;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label10;
    }
}