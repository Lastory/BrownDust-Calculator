namespace BrownDust_Calculator
{
    partial class Form_Main
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
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox_Defender = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Defender = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox_Attacker = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Attacker = new System.Windows.Forms.TableLayoutPanel();
            this.label_AttaCRD = new System.Windows.Forms.Label();
            this.label_AttaCRR = new System.Windows.Forms.Label();
            this.label_AttaATK = new System.Windows.Forms.Label();
            this.label_AttaName = new System.Windows.Forms.Label();
            this.label_AttaAGI = new System.Windows.Forms.Label();
            this.label__AttaSumDmg = new System.Windows.Forms.Label();
            this.label_AttaAddDmg = new System.Windows.Forms.Label();
            this.label_AttaNormalDmg = new System.Windows.Forms.Label();
            this.label_AttaDEF = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.groupBox_Supporter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Supporter = new System.Windows.Forms.TableLayoutPanel();
            this.label_SuppCRD = new System.Windows.Forms.Label();
            this.label_SuppCRR = new System.Windows.Forms.Label();
            this.label_SuppATK = new System.Windows.Forms.Label();
            this.label_SuppName = new System.Windows.Forms.Label();
            this.label_SuppChoose = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_Defender.SuspendLayout();
            this.tableLayoutPanel_Defender.SuspendLayout();
            this.groupBox_Attacker.SuspendLayout();
            this.tableLayoutPanel_Attacker.SuspendLayout();
            this.groupBox_Supporter.SuspendLayout();
            this.tableLayoutPanel_Supporter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage1);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1159, 632);
            this.tabControl_Main.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.groupBox_Defender);
            this.tabPage1.Controls.Add(this.groupBox_Attacker);
            this.tabPage1.Controls.Add(this.button_Save);
            this.tabPage1.Controls.Add(this.button_Calculate);
            this.tabPage1.Controls.Add(this.groupBox_Supporter);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1151, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // groupBox_Defender
            // 
            this.groupBox_Defender.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Defender.Controls.Add(this.tableLayoutPanel_Defender);
            this.groupBox_Defender.Location = new System.Drawing.Point(355, 6);
            this.groupBox_Defender.Name = "groupBox_Defender";
            this.groupBox_Defender.Size = new System.Drawing.Size(790, 188);
            this.groupBox_Defender.TabIndex = 5;
            this.groupBox_Defender.TabStop = false;
            this.groupBox_Defender.Text = "防御角色数据";
            // 
            // tableLayoutPanel_Defender
            // 
            this.tableLayoutPanel_Defender.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_Defender.ColumnCount = 9;
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Defender.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label6, 7, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label5, 6, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel_Defender.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel_Defender.Name = "tableLayoutPanel_Defender";
            this.tableLayoutPanel_Defender.RowCount = 5;
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Defender.Size = new System.Drawing.Size(659, 162);
            this.tableLayoutPanel_Defender.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "角色";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "血量";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "防御(%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "护盾(%)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(539, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "击杀概率";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "剩余血量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "敏捷(%)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "诅咒(%)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_Attacker
            // 
            this.groupBox_Attacker.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Attacker.Controls.Add(this.tableLayoutPanel_Attacker);
            this.groupBox_Attacker.Location = new System.Drawing.Point(12, 200);
            this.groupBox_Attacker.Name = "groupBox_Attacker";
            this.groupBox_Attacker.Size = new System.Drawing.Size(874, 367);
            this.groupBox_Attacker.TabIndex = 2;
            this.groupBox_Attacker.TabStop = false;
            this.groupBox_Attacker.Text = "攻击角色";
            // 
            // tableLayoutPanel_Attacker
            // 
            this.tableLayoutPanel_Attacker.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_Attacker.ColumnCount = 10;
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaCRD, 3, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaCRR, 2, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaATK, 1, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaName, 0, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaAGI, 4, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label__AttaSumDmg, 8, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaAddDmg, 7, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaNormalDmg, 6, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AttaDEF, 5, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label9, 9, 0);
            this.tableLayoutPanel_Attacker.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel_Attacker.Name = "tableLayoutPanel_Attacker";
            this.tableLayoutPanel_Attacker.RowCount = 9;
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Attacker.Size = new System.Drawing.Size(862, 336);
            this.tableLayoutPanel_Attacker.TabIndex = 2;
            // 
            // label_AttaCRD
            // 
            this.label_AttaCRD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaCRD.AutoSize = true;
            this.label_AttaCRD.Location = new System.Drawing.Point(193, 13);
            this.label_AttaCRD.Name = "label_AttaCRD";
            this.label_AttaCRD.Size = new System.Drawing.Size(47, 12);
            this.label_AttaCRD.TabIndex = 4;
            this.label_AttaCRD.Text = "暴伤(%)";
            this.label_AttaCRD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AttaCRR
            // 
            this.label_AttaCRR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaCRR.AutoSize = true;
            this.label_AttaCRR.Location = new System.Drawing.Point(137, 13);
            this.label_AttaCRR.Name = "label_AttaCRR";
            this.label_AttaCRR.Size = new System.Drawing.Size(47, 12);
            this.label_AttaCRR.TabIndex = 3;
            this.label_AttaCRR.Text = "暴率(%)";
            this.label_AttaCRR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AttaATK
            // 
            this.label_AttaATK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaATK.AutoSize = true;
            this.label_AttaATK.Location = new System.Drawing.Point(87, 13);
            this.label_AttaATK.Name = "label_AttaATK";
            this.label_AttaATK.Size = new System.Drawing.Size(29, 12);
            this.label_AttaATK.TabIndex = 2;
            this.label_AttaATK.Text = "攻击";
            // 
            // label_AttaName
            // 
            this.label_AttaName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaName.AutoSize = true;
            this.label_AttaName.Location = new System.Drawing.Point(21, 13);
            this.label_AttaName.Name = "label_AttaName";
            this.label_AttaName.Size = new System.Drawing.Size(29, 12);
            this.label_AttaName.TabIndex = 1;
            this.label_AttaName.Text = "角色";
            // 
            // label_AttaAGI
            // 
            this.label_AttaAGI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaAGI.AutoSize = true;
            this.label_AttaAGI.Location = new System.Drawing.Point(249, 13);
            this.label_AttaAGI.Name = "label_AttaAGI";
            this.label_AttaAGI.Size = new System.Drawing.Size(47, 12);
            this.label_AttaAGI.TabIndex = 8;
            this.label_AttaAGI.Text = "敏捷(%)";
            this.label_AttaAGI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label__AttaSumDmg
            // 
            this.label__AttaSumDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label__AttaSumDmg.AutoSize = true;
            this.label__AttaSumDmg.Location = new System.Drawing.Point(719, 13);
            this.label__AttaSumDmg.Name = "label__AttaSumDmg";
            this.label__AttaSumDmg.Size = new System.Drawing.Size(29, 12);
            this.label__AttaSumDmg.TabIndex = 15;
            this.label__AttaSumDmg.Text = "合计";
            // 
            // label_AttaAddDmg
            // 
            this.label_AttaAddDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaAddDmg.AutoSize = true;
            this.label_AttaAddDmg.Location = new System.Drawing.Point(568, 13);
            this.label_AttaAddDmg.Name = "label_AttaAddDmg";
            this.label_AttaAddDmg.Size = new System.Drawing.Size(29, 12);
            this.label_AttaAddDmg.TabIndex = 14;
            this.label_AttaAddDmg.Text = "追伤";
            // 
            // label_AttaNormalDmg
            // 
            this.label_AttaNormalDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaNormalDmg.AutoSize = true;
            this.label_AttaNormalDmg.Location = new System.Drawing.Point(417, 13);
            this.label_AttaNormalDmg.Name = "label_AttaNormalDmg";
            this.label_AttaNormalDmg.Size = new System.Drawing.Size(29, 12);
            this.label_AttaNormalDmg.TabIndex = 13;
            this.label_AttaNormalDmg.Text = "普伤";
            // 
            // label_AttaDEF
            // 
            this.label_AttaDEF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AttaDEF.AutoSize = true;
            this.label_AttaDEF.Location = new System.Drawing.Point(305, 13);
            this.label_AttaDEF.Name = "label_AttaDEF";
            this.label_AttaDEF.Size = new System.Drawing.Size(47, 12);
            this.label_AttaDEF.TabIndex = 16;
            this.label_AttaDEF.Text = "防御(%)";
            this.label_AttaDEF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(1007, 560);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(138, 40);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.Location = new System.Drawing.Point(1007, 456);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(138, 40);
            this.button_Calculate.TabIndex = 3;
            this.button_Calculate.Text = "Do it!";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_DO_Click);
            // 
            // groupBox_Supporter
            // 
            this.groupBox_Supporter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Supporter.Controls.Add(this.tableLayoutPanel_Supporter);
            this.groupBox_Supporter.Location = new System.Drawing.Point(6, 6);
            this.groupBox_Supporter.Name = "groupBox_Supporter";
            this.groupBox_Supporter.Size = new System.Drawing.Size(342, 188);
            this.groupBox_Supporter.TabIndex = 1;
            this.groupBox_Supporter.TabStop = false;
            this.groupBox_Supporter.Text = "支援角色";
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
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_SuppCRD, 3, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_SuppCRR, 2, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_SuppATK, 1, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_SuppName, 0, 0);
            this.tableLayoutPanel_Supporter.Controls.Add(this.label_SuppChoose, 4, 0);
            this.tableLayoutPanel_Supporter.Location = new System.Drawing.Point(6, 20);
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
            // label_SuppCRD
            // 
            this.label_SuppCRD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SuppCRD.AutoSize = true;
            this.label_SuppCRD.Location = new System.Drawing.Point(221, 11);
            this.label_SuppCRD.Name = "label_SuppCRD";
            this.label_SuppCRD.Size = new System.Drawing.Size(53, 12);
            this.label_SuppCRD.TabIndex = 3;
            this.label_SuppCRD.Text = "暴伤buff";
            // 
            // label_SuppCRR
            // 
            this.label_SuppCRR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SuppCRR.AutoSize = true;
            this.label_SuppCRR.Location = new System.Drawing.Point(159, 11);
            this.label_SuppCRR.Name = "label_SuppCRR";
            this.label_SuppCRR.Size = new System.Drawing.Size(53, 12);
            this.label_SuppCRR.TabIndex = 2;
            this.label_SuppCRR.Text = "暴率buff";
            // 
            // label_SuppATK
            // 
            this.label_SuppATK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SuppATK.AutoSize = true;
            this.label_SuppATK.Location = new System.Drawing.Point(97, 11);
            this.label_SuppATK.Name = "label_SuppATK";
            this.label_SuppATK.Size = new System.Drawing.Size(53, 12);
            this.label_SuppATK.TabIndex = 1;
            this.label_SuppATK.Text = "攻击buff";
            // 
            // label_SuppName
            // 
            this.label_SuppName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SuppName.AutoSize = true;
            this.label_SuppName.Location = new System.Drawing.Point(32, 11);
            this.label_SuppName.Name = "label_SuppName";
            this.label_SuppName.Size = new System.Drawing.Size(29, 12);
            this.label_SuppName.TabIndex = 0;
            this.label_SuppName.Text = "角色";
            // 
            // label_SuppChoose
            // 
            this.label_SuppChoose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SuppChoose.AutoSize = true;
            this.label_SuppChoose.Location = new System.Drawing.Point(288, 11);
            this.label_SuppChoose.Name = "label_SuppChoose";
            this.label_SuppChoose.Size = new System.Drawing.Size(29, 12);
            this.label_SuppChoose.TabIndex = 4;
            this.label_SuppChoose.Text = "选中";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1151, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Supporter Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(821, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "选中";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 661);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "Form_Main";
            this.Text = "BrownDust Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox_Defender.ResumeLayout(false);
            this.tableLayoutPanel_Defender.ResumeLayout(false);
            this.tableLayoutPanel_Defender.PerformLayout();
            this.groupBox_Attacker.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.PerformLayout();
            this.groupBox_Supporter.ResumeLayout(false);
            this.tableLayoutPanel_Supporter.ResumeLayout(false);
            this.tableLayoutPanel_Supporter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.GroupBox groupBox_Attacker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Attacker;
        private System.Windows.Forms.Label label__AttaSumDmg;
        private System.Windows.Forms.Label label_AttaAddDmg;
        private System.Windows.Forms.Label label_AttaNormalDmg;
        private System.Windows.Forms.Label label_AttaCRD;
        private System.Windows.Forms.Label label_AttaCRR;
        private System.Windows.Forms.Label label_AttaATK;
        private System.Windows.Forms.Label label_AttaName;
        private System.Windows.Forms.Label label_AttaAGI;
        private System.Windows.Forms.GroupBox groupBox_Supporter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Supporter;
        private System.Windows.Forms.Label label_SuppCRD;
        private System.Windows.Forms.Label label_SuppCRR;
        private System.Windows.Forms.Label label_SuppATK;
        private System.Windows.Forms.Label label_SuppName;
        private System.Windows.Forms.Label label_SuppChoose;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_AttaDEF;
        private System.Windows.Forms.GroupBox groupBox_Defender;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Defender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}