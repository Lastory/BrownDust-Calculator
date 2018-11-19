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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_Language = new System.Windows.Forms.ComboBox();
            this.groupBox_Defenders = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Defender = new System.Windows.Forms.TableLayoutPanel();
            this.label_DefName = new System.Windows.Forms.Label();
            this.label_DefHP = new System.Windows.Forms.Label();
            this.label_DefDEF = new System.Windows.Forms.Label();
            this.label_DefAddReamaining = new System.Windows.Forms.Label();
            this.label_DefNormalRemaining = new System.Windows.Forms.Label();
            this.label_DefWeaking = new System.Windows.Forms.Label();
            this.label_DefAGI = new System.Windows.Forms.Label();
            this.label_DefBarrier = new System.Windows.Forms.Label();
            this.groupBox_Attackers = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_Attacker = new System.Windows.Forms.TableLayoutPanel();
            this.label_AtkName = new System.Windows.Forms.Label();
            this.label_AtkSelect = new System.Windows.Forms.Label();
            this.label_AtkSumDmg = new System.Windows.Forms.Label();
            this.label_AtkAddDmg = new System.Windows.Forms.Label();
            this.label_AtkNormalDmg = new System.Windows.Forms.Label();
            this.label_AtkDEF = new System.Windows.Forms.Label();
            this.label_AtkAGI = new System.Windows.Forms.Label();
            this.label_AtkCRD = new System.Windows.Forms.Label();
            this.label_AtkCRR = new System.Windows.Forms.Label();
            this.label_AtkATK = new System.Windows.Forms.Label();
            this.label_AtkSkill = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Calculate = new System.Windows.Forms.Button();
            this.groupBox_AtkSupporters = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_AtkSupporters = new System.Windows.Forms.TableLayoutPanel();
            this.label_SupName = new System.Windows.Forms.Label();
            this.label_SupCRD = new System.Windows.Forms.Label();
            this.label_SupCRR = new System.Windows.Forms.Label();
            this.label_SupATK = new System.Windows.Forms.Label();
            this.label_SupSkill = new System.Windows.Forms.Label();
            this.label_SupSelect = new System.Windows.Forms.Label();
            this.label_SupImmune = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_Defenders.SuspendLayout();
            this.tableLayoutPanel_Defender.SuspendLayout();
            this.groupBox_Attackers.SuspendLayout();
            this.tableLayoutPanel_Attacker.SuspendLayout();
            this.groupBox_AtkSupporters.SuspendLayout();
            this.tableLayoutPanel_AtkSupporters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage1);
            this.tabControl_Main.Controls.Add(this.tabPage2);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 12);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(898, 826);
            this.tabControl_Main.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.comboBox_Language);
            this.tabPage1.Controls.Add(this.groupBox_Defenders);
            this.tabPage1.Controls.Add(this.groupBox_Attackers);
            this.tabPage1.Controls.Add(this.button_Save);
            this.tabPage1.Controls.Add(this.button_Calculate);
            this.tabPage1.Controls.Add(this.groupBox_AtkSupporters);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 800);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(780, 773);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Project Home Page";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(819, 785);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "by Lastory";
            // 
            // comboBox_Language
            // 
            this.comboBox_Language.FormattingEnabled = true;
            this.comboBox_Language.Items.AddRange(new object[] {
            "Chinese 中文简称(简体)",
            "Chinese 中文全稱(繁體)",
            "English English",
            "Japanese 日本語"});
            this.comboBox_Language.Location = new System.Drawing.Point(720, 6);
            this.comboBox_Language.Name = "comboBox_Language";
            this.comboBox_Language.Size = new System.Drawing.Size(167, 20);
            this.comboBox_Language.TabIndex = 7;
            this.comboBox_Language.SelectedIndexChanged += new System.EventHandler(this.comboBox_Language_SelectedIndexChanged);
            // 
            // groupBox_Defenders
            // 
            this.groupBox_Defenders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Defenders.Controls.Add(this.tableLayoutPanel_Defender);
            this.groupBox_Defenders.Location = new System.Drawing.Point(7, 570);
            this.groupBox_Defenders.Name = "groupBox_Defenders";
            this.groupBox_Defenders.Size = new System.Drawing.Size(677, 223);
            this.groupBox_Defenders.TabIndex = 5;
            this.groupBox_Defenders.TabStop = false;
            this.groupBox_Defenders.Text = "Defenders";
            // 
            // tableLayoutPanel_Defender
            // 
            this.tableLayoutPanel_Defender.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_Defender.ColumnCount = 8;
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Defender.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefName, 0, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefHP, 1, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefDEF, 2, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefAddReamaining, 7, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefNormalRemaining, 6, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefWeaking, 5, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefAGI, 3, 0);
            this.tableLayoutPanel_Defender.Controls.Add(this.label_DefBarrier, 4, 0);
            this.tableLayoutPanel_Defender.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel_Defender.Name = "tableLayoutPanel_Defender";
            this.tableLayoutPanel_Defender.RowCount = 5;
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Defender.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Defender.Size = new System.Drawing.Size(666, 195);
            this.tableLayoutPanel_Defender.TabIndex = 2;
            // 
            // label_DefName
            // 
            this.label_DefName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefName.AutoSize = true;
            this.label_DefName.Location = new System.Drawing.Point(7, 14);
            this.label_DefName.Name = "label_DefName";
            this.label_DefName.Size = new System.Drawing.Size(59, 12);
            this.label_DefName.TabIndex = 2;
            this.label_DefName.Text = "Character";
            // 
            // label_DefHP
            // 
            this.label_DefHP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefHP.AutoSize = true;
            this.label_DefHP.Location = new System.Drawing.Point(93, 14);
            this.label_DefHP.Name = "label_DefHP";
            this.label_DefHP.Size = new System.Drawing.Size(17, 12);
            this.label_DefHP.TabIndex = 4;
            this.label_DefHP.Text = "HP";
            // 
            // label_DefDEF
            // 
            this.label_DefDEF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefDEF.AutoSize = true;
            this.label_DefDEF.Location = new System.Drawing.Point(144, 8);
            this.label_DefDEF.Name = "label_DefDEF";
            this.label_DefDEF.Size = new System.Drawing.Size(23, 24);
            this.label_DefDEF.TabIndex = 3;
            this.label_DefDEF.Text = "DEF (%)";
            this.label_DefDEF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DefAddReamaining
            // 
            this.label_DefAddReamaining.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefAddReamaining.AutoSize = true;
            this.label_DefAddReamaining.Location = new System.Drawing.Point(505, 14);
            this.label_DefAddReamaining.Name = "label_DefAddReamaining";
            this.label_DefAddReamaining.Size = new System.Drawing.Size(155, 12);
            this.label_DefAddReamaining.TabIndex = 7;
            this.label_DefAddReamaining.Text = "HP After Additonal Attack";
            this.label_DefAddReamaining.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DefNormalRemaining
            // 
            this.label_DefNormalRemaining.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefNormalRemaining.AutoSize = true;
            this.label_DefNormalRemaining.Location = new System.Drawing.Point(355, 14);
            this.label_DefNormalRemaining.Name = "label_DefNormalRemaining";
            this.label_DefNormalRemaining.Size = new System.Drawing.Size(137, 12);
            this.label_DefNormalRemaining.TabIndex = 6;
            this.label_DefNormalRemaining.Text = "HP After Normal Attack";
            this.label_DefNormalRemaining.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DefWeaking
            // 
            this.label_DefWeaking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefWeaking.AutoSize = true;
            this.label_DefWeaking.Location = new System.Drawing.Point(296, 8);
            this.label_DefWeaking.Name = "label_DefWeaking";
            this.label_DefWeaking.Size = new System.Drawing.Size(47, 24);
            this.label_DefWeaking.TabIndex = 8;
            this.label_DefWeaking.Text = "Weakening (%)";
            this.label_DefWeaking.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DefAGI
            // 
            this.label_DefAGI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefAGI.AutoSize = true;
            this.label_DefAGI.Location = new System.Drawing.Point(196, 8);
            this.label_DefAGI.Name = "label_DefAGI";
            this.label_DefAGI.Size = new System.Drawing.Size(23, 24);
            this.label_DefAGI.TabIndex = 9;
            this.label_DefAGI.Text = "AGI (%)";
            this.label_DefAGI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_DefBarrier
            // 
            this.label_DefBarrier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DefBarrier.AutoSize = true;
            this.label_DefBarrier.Location = new System.Drawing.Point(239, 8);
            this.label_DefBarrier.Name = "label_DefBarrier";
            this.label_DefBarrier.Size = new System.Drawing.Size(47, 24);
            this.label_DefBarrier.TabIndex = 5;
            this.label_DefBarrier.Text = "Barrier (%)";
            this.label_DefBarrier.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox_Attackers
            // 
            this.groupBox_Attackers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_Attackers.Controls.Add(this.tableLayoutPanel_Attacker);
            this.groupBox_Attackers.Location = new System.Drawing.Point(6, 201);
            this.groupBox_Attackers.Name = "groupBox_Attackers";
            this.groupBox_Attackers.Size = new System.Drawing.Size(874, 363);
            this.groupBox_Attackers.TabIndex = 2;
            this.groupBox_Attackers.TabStop = false;
            this.groupBox_Attackers.Text = "Attackers";
            // 
            // tableLayoutPanel_Attacker
            // 
            this.tableLayoutPanel_Attacker.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel_Attacker.ColumnCount = 11;
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel_Attacker.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkName, 0, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkSelect, 10, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkSumDmg, 9, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkAddDmg, 8, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkNormalDmg, 7, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkDEF, 6, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkAGI, 5, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkCRD, 4, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkCRR, 3, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkATK, 2, 0);
            this.tableLayoutPanel_Attacker.Controls.Add(this.label_AtkSkill, 1, 0);
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
            // label_AtkName
            // 
            this.label_AtkName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkName.AutoSize = true;
            this.label_AtkName.Location = new System.Drawing.Point(11, 13);
            this.label_AtkName.Name = "label_AtkName";
            this.label_AtkName.Size = new System.Drawing.Size(59, 12);
            this.label_AtkName.TabIndex = 1;
            this.label_AtkName.Text = "Character";
            // 
            // label_AtkSelect
            // 
            this.label_AtkSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkSelect.AutoSize = true;
            this.label_AtkSelect.Location = new System.Drawing.Point(815, 13);
            this.label_AtkSelect.Name = "label_AtkSelect";
            this.label_AtkSelect.Size = new System.Drawing.Size(41, 12);
            this.label_AtkSelect.TabIndex = 17;
            this.label_AtkSelect.Text = "Select";
            // 
            // label_AtkSumDmg
            // 
            this.label_AtkSumDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkSumDmg.AutoSize = true;
            this.label_AtkSumDmg.Location = new System.Drawing.Point(687, 13);
            this.label_AtkSumDmg.Name = "label_AtkSumDmg";
            this.label_AtkSumDmg.Size = new System.Drawing.Size(95, 12);
            this.label_AtkSumDmg.TabIndex = 15;
            this.label_AtkSumDmg.Text = "Damage in Total";
            // 
            // label_AtkAddDmg
            // 
            this.label_AtkAddDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkAddDmg.AutoSize = true;
            this.label_AtkAddDmg.Location = new System.Drawing.Point(530, 13);
            this.label_AtkAddDmg.Name = "label_AtkAddDmg";
            this.label_AtkAddDmg.Size = new System.Drawing.Size(107, 12);
            this.label_AtkAddDmg.TabIndex = 14;
            this.label_AtkAddDmg.Text = "Additional Damage";
            // 
            // label_AtkNormalDmg
            // 
            this.label_AtkNormalDmg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkNormalDmg.AutoSize = true;
            this.label_AtkNormalDmg.Location = new System.Drawing.Point(391, 13);
            this.label_AtkNormalDmg.Name = "label_AtkNormalDmg";
            this.label_AtkNormalDmg.Size = new System.Drawing.Size(83, 12);
            this.label_AtkNormalDmg.TabIndex = 13;
            this.label_AtkNormalDmg.Text = "Normal Damage";
            // 
            // label_AtkDEF
            // 
            this.label_AtkDEF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkDEF.AutoSize = true;
            this.label_AtkDEF.Location = new System.Drawing.Point(323, 7);
            this.label_AtkDEF.Name = "label_AtkDEF";
            this.label_AtkDEF.Size = new System.Drawing.Size(23, 24);
            this.label_AtkDEF.TabIndex = 16;
            this.label_AtkDEF.Text = "DEF (%)";
            this.label_AtkDEF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AtkAGI
            // 
            this.label_AtkAGI.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkAGI.AutoSize = true;
            this.label_AtkAGI.Location = new System.Drawing.Point(277, 7);
            this.label_AtkAGI.Name = "label_AtkAGI";
            this.label_AtkAGI.Size = new System.Drawing.Size(23, 24);
            this.label_AtkAGI.TabIndex = 8;
            this.label_AtkAGI.Text = "AGI (%)";
            this.label_AtkAGI.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AtkCRD
            // 
            this.label_AtkCRD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkCRD.AutoSize = true;
            this.label_AtkCRD.Location = new System.Drawing.Point(228, 7);
            this.label_AtkCRD.Name = "label_AtkCRD";
            this.label_AtkCRD.Size = new System.Drawing.Size(29, 24);
            this.label_AtkCRD.TabIndex = 4;
            this.label_AtkCRD.Text = "CRID (%)";
            this.label_AtkCRD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AtkCRR
            // 
            this.label_AtkCRR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkCRR.AutoSize = true;
            this.label_AtkCRR.Location = new System.Drawing.Point(182, 7);
            this.label_AtkCRR.Name = "label_AtkCRR";
            this.label_AtkCRR.Size = new System.Drawing.Size(29, 24);
            this.label_AtkCRR.TabIndex = 3;
            this.label_AtkCRR.Text = "CRIR (%)";
            this.label_AtkCRR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_AtkATK
            // 
            this.label_AtkATK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkATK.AutoSize = true;
            this.label_AtkATK.Location = new System.Drawing.Point(139, 13);
            this.label_AtkATK.Name = "label_AtkATK";
            this.label_AtkATK.Size = new System.Drawing.Size(23, 12);
            this.label_AtkATK.TabIndex = 2;
            this.label_AtkATK.Text = "ATK";
            // 
            // label_AtkSkill
            // 
            this.label_AtkSkill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_AtkSkill.AutoSize = true;
            this.label_AtkSkill.Location = new System.Drawing.Point(87, 13);
            this.label_AtkSkill.Name = "label_AtkSkill";
            this.label_AtkSkill.Size = new System.Drawing.Size(35, 12);
            this.label_AtkSkill.TabIndex = 18;
            this.label_AtkSkill.Text = "Skill";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(762, 155);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(118, 40);
            this.button_Save.TabIndex = 4;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Calculate
            // 
            this.button_Calculate.Location = new System.Drawing.Point(544, 91);
            this.button_Calculate.Name = "button_Calculate";
            this.button_Calculate.Size = new System.Drawing.Size(155, 40);
            this.button_Calculate.TabIndex = 3;
            this.button_Calculate.Text = "Calculate!";
            this.button_Calculate.UseVisualStyleBackColor = true;
            this.button_Calculate.Click += new System.EventHandler(this.button_DO_Click);
            // 
            // groupBox_AtkSupporters
            // 
            this.groupBox_AtkSupporters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox_AtkSupporters.Controls.Add(this.tableLayoutPanel_AtkSupporters);
            this.groupBox_AtkSupporters.Location = new System.Drawing.Point(6, 6);
            this.groupBox_AtkSupporters.Name = "groupBox_AtkSupporters";
            this.groupBox_AtkSupporters.Size = new System.Drawing.Size(435, 189);
            this.groupBox_AtkSupporters.TabIndex = 1;
            this.groupBox_AtkSupporters.TabStop = false;
            this.groupBox_AtkSupporters.Text = "Attack Supporters";
            // 
            // tableLayoutPanel_AtkSupporters
            // 
            this.tableLayoutPanel_AtkSupporters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_AtkSupporters.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_AtkSupporters.ColumnCount = 7;
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_AtkSupporters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupName, 0, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupCRD, 4, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupCRR, 3, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupATK, 2, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupSkill, 1, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupSelect, 6, 0);
            this.tableLayoutPanel_AtkSupporters.Controls.Add(this.label_SupImmune, 5, 0);
            this.tableLayoutPanel_AtkSupporters.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel_AtkSupporters.Name = "tableLayoutPanel_AtkSupporters";
            this.tableLayoutPanel_AtkSupporters.RowCount = 5;
            this.tableLayoutPanel_AtkSupporters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_AtkSupporters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_AtkSupporters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_AtkSupporters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_AtkSupporters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_AtkSupporters.Size = new System.Drawing.Size(404, 162);
            this.tableLayoutPanel_AtkSupporters.TabIndex = 1;
            // 
            // label_SupName
            // 
            this.label_SupName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupName.AutoSize = true;
            this.label_SupName.Location = new System.Drawing.Point(12, 11);
            this.label_SupName.Name = "label_SupName";
            this.label_SupName.Size = new System.Drawing.Size(59, 12);
            this.label_SupName.TabIndex = 0;
            this.label_SupName.Text = "Character";
            // 
            // label_SupCRD
            // 
            this.label_SupCRD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupCRD.AutoSize = true;
            this.label_SupCRD.Location = new System.Drawing.Point(252, 11);
            this.label_SupCRD.Name = "label_SupCRD";
            this.label_SupCRD.Size = new System.Drawing.Size(41, 12);
            this.label_SupCRD.TabIndex = 3;
            this.label_SupCRD.Text = "CRIDup";
            // 
            // label_SupCRR
            // 
            this.label_SupCRR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupCRR.AutoSize = true;
            this.label_SupCRR.Location = new System.Drawing.Point(195, 11);
            this.label_SupCRR.Name = "label_SupCRR";
            this.label_SupCRR.Size = new System.Drawing.Size(41, 12);
            this.label_SupCRR.TabIndex = 2;
            this.label_SupCRR.Text = "CRIRup";
            this.label_SupCRR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_SupATK
            // 
            this.label_SupATK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupATK.AutoSize = true;
            this.label_SupATK.Location = new System.Drawing.Point(141, 11);
            this.label_SupATK.Name = "label_SupATK";
            this.label_SupATK.Size = new System.Drawing.Size(35, 12);
            this.label_SupATK.TabIndex = 1;
            this.label_SupATK.Text = "ATKup";
            // 
            // label_SupSkill
            // 
            this.label_SupSkill.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupSkill.AutoSize = true;
            this.label_SupSkill.Location = new System.Drawing.Point(89, 11);
            this.label_SupSkill.Name = "label_SupSkill";
            this.label_SupSkill.Size = new System.Drawing.Size(35, 12);
            this.label_SupSkill.TabIndex = 5;
            this.label_SupSkill.Text = "Skill";
            // 
            // label_SupSelect
            // 
            this.label_SupSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupSelect.AutoSize = true;
            this.label_SupSelect.Location = new System.Drawing.Point(357, 11);
            this.label_SupSelect.Name = "label_SupSelect";
            this.label_SupSelect.Size = new System.Drawing.Size(41, 12);
            this.label_SupSelect.TabIndex = 4;
            this.label_SupSelect.Text = "Select";
            // 
            // label_SupImmune
            // 
            this.label_SupImmune.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SupImmune.AutoSize = true;
            this.label_SupImmune.Location = new System.Drawing.Point(306, 11);
            this.label_SupImmune.Name = "label_SupImmune";
            this.label_SupImmune.Size = new System.Drawing.Size(41, 12);
            this.label_SupImmune.TabIndex = 6;
            this.label_SupImmune.Text = "Immune";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 800);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings (Work in Progress)";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(914, 843);
            this.Controls.Add(this.tabControl_Main);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "BrownDust Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox_Defenders.ResumeLayout(false);
            this.tableLayoutPanel_Defender.ResumeLayout(false);
            this.tableLayoutPanel_Defender.PerformLayout();
            this.groupBox_Attackers.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.ResumeLayout(false);
            this.tableLayoutPanel_Attacker.PerformLayout();
            this.groupBox_AtkSupporters.ResumeLayout(false);
            this.tableLayoutPanel_AtkSupporters.ResumeLayout(false);
            this.tableLayoutPanel_AtkSupporters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_Calculate;
        private System.Windows.Forms.GroupBox groupBox_Attackers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Attacker;
        private System.Windows.Forms.Label label_AtkSumDmg;
        private System.Windows.Forms.Label label_AtkAddDmg;
        private System.Windows.Forms.Label label_AtkNormalDmg;
        private System.Windows.Forms.Label label_AtkCRD;
        private System.Windows.Forms.Label label_AtkCRR;
        private System.Windows.Forms.Label label_AtkATK;
        private System.Windows.Forms.Label label_AtkName;
        private System.Windows.Forms.Label label_AtkAGI;
        private System.Windows.Forms.GroupBox groupBox_AtkSupporters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_AtkSupporters;
        private System.Windows.Forms.Label label_SupCRD;
        private System.Windows.Forms.Label label_SupCRR;
        private System.Windows.Forms.Label label_SupATK;
        private System.Windows.Forms.Label label_SupName;
        private System.Windows.Forms.Label label_SupSelect;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_AtkDEF;
        private System.Windows.Forms.GroupBox groupBox_Defenders;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Defender;
        private System.Windows.Forms.Label label_DefName;
        private System.Windows.Forms.Label label_DefHP;
        private System.Windows.Forms.Label label_DefDEF;
        private System.Windows.Forms.Label label_DefBarrier;
        private System.Windows.Forms.Label label_DefNormalRemaining;
        private System.Windows.Forms.Label label_DefAGI;
        private System.Windows.Forms.Label label_DefWeaking;
        private System.Windows.Forms.Label label_AtkSelect;
        private System.Windows.Forms.Label label_DefAddReamaining;
        private System.Windows.Forms.Label label_AtkSkill;
        private System.Windows.Forms.ComboBox comboBox_Language;
        private System.Windows.Forms.Label label_SupSkill;
        private System.Windows.Forms.Label label_SupImmune;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}