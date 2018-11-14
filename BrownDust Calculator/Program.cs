using System;
using System.IO;
using System.Windows.Forms;

namespace BrownDust_Calculator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //MyPrograme.Work();
        }
    }

    partial class Form1
    {
        private static class Savefile
        {
            public static void LoadSavefile()
            {
                if (File.Exists("Save.save"))
                {
                    string line;

                    using (StreamReader file = new StreamReader("save.save"))
                    {
                        line = file.ReadLine();  //"A#"
                        line = file.ReadLine();  //AttackerChartHight
                        for (int i = 0; i < AttackerChartHight; i++)
                        {
                            line = file.ReadLine();
                            if (line != "-")
                            {
                                string[] load = line.Split('|');
                                comboBox_AttackerName[i].SelectedIndex = int.Parse(load[0]);
                                for (int j = 0; j < 5; j++) textBox_AttackerStats[i, j].Text = load[j + 1];
                            }
                        }
                    }
                }
                else { File.Create("save.save"); }  //创建一个存档文件
            }

            public static void SaveSavefile()
            {
                using (StreamWriter file = new StreamWriter("save.save"))
                {
                    //存储攻击角色面板
                    file.Write("#A\n{0:d}\n", AttackerChartHight);
                    for (int i = 0; i < AttackerChartHight; i++)
                    {
                        if (comboBox_AttackerName[i].SelectedIndex >= 0)
                        {
                            string line = comboBox_AttackerName[i].SelectedIndex.ToString("d") + "|";
                            for (int j = 0; j < 5; j++) line += textBox_AttackerStats[i, j].Text + "|";
                            file.Write(line + "\n");
                        }
                        else { file.Write("-\n"); }
                    }
                }
            }
        }

        private class SupportCharacter
        {
            public string Name;
            double Support;
            public double ATKup, CRRup, CRDup, AGIup, CUTup;

            public SupportCharacter(string name, double sup, double atk, double crir, double crid, double agi, double cut)
            {
                Name = name; Support = sup;
                ATKup = atk * sup; CRRup = crir * sup; CRDup = crid * sup; AGIup = agi * sup; CUTup = cut * sup;
            }
        }
        private class AttackCharacter
        {
            public class TypeSkill
            {
                public uint nStatsUp = 0, nBuffSkill = 0, nAddDamage = 0, nAddRatio = 0;
                public struct TypeSkillDetail
                {
                    public string from, to;
                    public double rate;
                }

                public TypeSkillDetail[] StatsUp = new TypeSkillDetail[5];  //依赖属性，增长属性，倍率
                public TypeSkillDetail[] BuffSkill = new TypeSkillDetail[5];  //增长属性，buff量
                public TypeSkillDetail[] AddDamage = new TypeSkillDetail[5];  //依赖属性，倍率
                public bool isAddRatio = false, isAddReal = false;  //追伤是否为血量比例伤害、是否为真伤

                public void SetStatusUp(uint n, TypeSkillDetail[] arr)
                {
                    nStatsUp = n;
                    StatsUp = arr;
                }
                public void SetBuffSkill(uint n, TypeSkillDetail[] arr)
                {
                    nBuffSkill = n;
                    BuffSkill = arr;
                }
                public void SetAddDamage(uint n, TypeSkillDetail[] arr)
                {
                    nAddDamage = n;
                    AddDamage = arr;
                }
            }
            private struct TypeStats { public double ATK, DEF, CRR, CRD, AGI, CUT; }
            public struct TypeDamage
            {
                public double normal, critical, expected;
                public double crrPer;
            }

            public string Name;
            public TypeSkill Skills = new TypeSkill();
            private TypeStats BaseStats, NowStats, StatsUp;
            public TypeDamage BaseDamage, AddDamage;

            public AttackCharacter(string name)
            {
                Name = name;
            }

            private void DoStatsUp()
            {
                for (int i = 0; i < Skills.nStatsUp; i++)
                {
                    double buff = Skills.StatsUp[i].rate;
                    switch (Skills.StatsUp[i].from)
                    {
                        case "DEF": buff *= BaseStats.DEF; break;
                        case "CRR": buff *= BaseStats.CRR; break;
                        case "AGI": buff *= BaseStats.AGI; break;
                    }
                    switch (Skills.StatsUp[i].to)
                    {
                        case "ATK": BaseStats.ATK *= 1 + buff; break;
                        case "CRR": BaseStats.CRR += buff; break;
                        case "CRD": BaseStats.CRD += buff; break;
                    }
                }
            }

            public void DoBuffSkill()
            {
                for (int i = 0; i < Skills.nBuffSkill; i++)
                {
                    double buff = Skills.BuffSkill[i].rate;
                    switch (Skills.BuffSkill[i].to)
                    {
                        case "ATK": StatsUp.ATK += buff; break;
                        case "CRR": StatsUp.CRR += buff; break;
                        case "CRD": StatsUp.CRD += buff; break;
                        case "AGI": StatsUp.AGI += buff; break;
                    }
                }
                CheckStats();
            }

            private void CheckStats()
            {
                NowStats.ATK = BaseStats.ATK * (1 + StatsUp.ATK);
                NowStats.CRR = Math.Max(0, Math.Min(1, BaseStats.CRR + StatsUp.CRR));
                NowStats.CRD = Math.Max(0, BaseStats.CRD + StatsUp.CRD);
                NowStats.AGI = Math.Max(0, Math.Min(1, BaseStats.AGI + StatsUp.AGI));
                NowStats.DEF = Math.Max(0, Math.Min(1, BaseStats.DEF + StatsUp.DEF));
            }

            public void SetStats(double atk, double crr, double crd, double agi, double def, double atkbuff, double crrbuff, double crdbuff)  //计算攻击角色入场属性
            {
                BaseStats.ATK = atk; BaseStats.CRR = crr; BaseStats.CRD = crd; BaseStats.AGI = agi; BaseStats.DEF = def;
                DoStatsUp();
                StatsUp.ATK = atkbuff; StatsUp.CRR = crrbuff; StatsUp.CRD = crdbuff;
                CheckStats();
            }

            public void CheckBaseDamage()
            {
                BaseDamage.normal = NowStats.ATK;
                BaseDamage.critical = BaseDamage.normal * (1 + NowStats.CRD);
                BaseDamage.expected = BaseDamage.normal * (1 + NowStats.CRR * NowStats.CRD);
                BaseDamage.crrPer = NowStats.CRR * 100;
            }

            public string GetBaseDamage()
            {
                string result = "";
                result += BaseDamage.normal.ToString("f0") + " " + (100 - BaseDamage.crrPer).ToString("f0") + "% | ";
                result += BaseDamage.critical.ToString("f0") + " " + BaseDamage.crrPer.ToString("f0") + "%";
                result += "\n" + BaseDamage.expected.ToString("f0");
                return result;
            }

            public void CheckAddDamage()
            {
                if (Skills.nAddDamage > 0)
                {
                    AddDamage.normal = 0;
                    if (Skills.isAddRatio)
                        for (int i = 0; i < Skills.nAddDamage; i++) AddDamage.normal += Skills.AddDamage[i].rate;
                    else
                    {
                        for (int i = 0; i < Skills.nAddDamage; i++)
                        {
                            double from;
                            switch (Skills.AddDamage[i].from)
                            {
                                case "DEF": from = NowStats.DEF; break;
                                case "CRR": from = NowStats.CRR; break;
                                case "CRD": from = NowStats.CRD; break;
                                case "AGI": from = NowStats.AGI; break;
                                default: from = 1; break;
                            }
                            AddDamage.normal += NowStats.ATK * from * Skills.AddDamage[i].rate;
                        }
                    }

                    AddDamage.critical = AddDamage.normal * (1 + NowStats.CRD);
                    AddDamage.expected = AddDamage.normal * (1 + NowStats.CRR * NowStats.CRD);
                    AddDamage.crrPer = NowStats.CRR * 100;
                }
            }

            public string GetAddDamage()
            {
                string result = "";
                if (Skills.nAddDamage > 0)
                {
                    if (Skills.isAddRatio)
                    {
                        result += (AddDamage.normal * 100).ToString("f1") + "% " + (100 - AddDamage.crrPer).ToString("f0") + "% | ";
                        result += (AddDamage.critical * 100).ToString("f1") + "% " + AddDamage.crrPer.ToString("f0") + "%";
                        result += "\n" + (AddDamage.expected * 100).ToString("f1") + "%";
                    }
                    else
                    {
                        result += AddDamage.normal.ToString("f0") + " " + (100 - AddDamage.crrPer).ToString("f0") + "% | ";
                        result += AddDamage.critical.ToString("f0") + " " + AddDamage.crrPer.ToString("f0") + "%";
                        result += "\n" + AddDamage.expected.ToString("f0");
                    }
                }
                else result = "/";
                return result;
            }

            public string GetSumDamage()
            {
                if (Skills.isAddRatio) return "X";
                if (Skills.nAddDamage == 0) return GetBaseDamage();

                string result = "";
                result += (BaseDamage.normal + AddDamage.normal).ToString("f0") + " ";
                result += ((100 - BaseDamage.crrPer) * (100 - AddDamage.crrPer) / 100).ToString("f0") + "% | ";
                result += (BaseDamage.critical + AddDamage.critical).ToString("f0") + " ";
                result += (BaseDamage.crrPer * AddDamage.crrPer / 100).ToString("f0") + "%\n";
                result += (BaseDamage.expected + AddDamage.expected).ToString("f0");

                return result;
            }
        }

        
        static int SupporterNumber = 4;
        static int AttackerNumber = 2;
        static int AttackerChartHight = 8;

        private static SupportCharacter[] Supporter = new SupportCharacter[SupporterNumber];
        private static AttackCharacter[] Attacker = new AttackCharacter[AttackerNumber];
        private static void SetCharacters()  //设定角色基本数据
        {
            Supporter[0] = new SupportCharacter("眼镜", 1.6496, 0.40, 0.05, 0.00, 0, 0);
            Supporter[1] = new SupportCharacter("弦月", 1.5118, 0.15, 0.15, 0.36, 0, 0);
            Supporter[2] = new SupportCharacter("屁股", 1.7481, 0.30, 0.00, 0.30, 0, 0);
            Supporter[3] = new SupportCharacter("琴女", 1.7481, 0.00, 0.20, 0.00, 0, 0);

            {
                Attacker[0] = new AttackCharacter("女忍");
                Attacker[0].Skills.SetStatusUp(2, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "AGI", to = "CRR", rate = 1.00 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "   ", to = "CRD", rate = 0.50 } });
                Attacker[0].Skills.SetBuffSkill(2, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "CRD", rate =1.50 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "ATK", rate =0.35 } });
                Attacker[0].Skills.SetAddDamage(1, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "CRR", rate = 1.25 } });
            }
            {
                Attacker[1] = new AttackCharacter("修女");
                Attacker[1].Skills.SetAddDamage(1, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "   ", rate = 0.20 } });
                Attacker[1].Skills.isAddRatio = true;
            }
        }

        private static Label[,] label_SupporterData = new Label[SupporterNumber, 4];
        private static CheckBox[] checkBox_SupporterChoose = new CheckBox[SupporterNumber];
        private void DrawSupporterData()  //绘制支援角色数据板块
        {
            string SupportAmount(double buff)
            {
                return buff > 0.01 ? (buff * 100).ToString("f2") + "%" : "/";
            }

            for (int i = 0; i < SupporterNumber; i++)
            {
                checkBox_SupporterChoose[i] = new CheckBox();
                tableLayoutPanel_Supporter.Controls.Add(checkBox_SupporterChoose[i], 5, i + 1);
                checkBox_SupporterChoose[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                checkBox_SupporterChoose[i].AutoSize = true;
                for (int j = 0; j < 4; j++)
                {
                    label_SupporterData[i, j] = new Label();
                    tableLayoutPanel_Supporter.Controls.Add(label_SupporterData[i, j], j, i + 1);
                    label_SupporterData[i, j].Anchor = System.Windows.Forms.AnchorStyles.None;
                    label_SupporterData[i, j].AutoSize = true;
                }

                label_SupporterData[i, 0].Text = Supporter[i].Name;
                label_SupporterData[i, 1].Text = SupportAmount(Supporter[i].ATKup);
                label_SupporterData[i, 2].Text = SupportAmount(Supporter[i].CRRup);
                label_SupporterData[i, 3].Text = SupportAmount(Supporter[i].CRDup);
            }
        }

        private static ComboBox[] comboBox_AttackerName = new ComboBox[AttackerChartHight];
        private static TextBox[,] textBox_AttackerStats = new TextBox[AttackerChartHight, 5];  //ATK, CRR, CRD, AGI, DEF
        private static Label[,] label_AttackDamage = new Label[AttackerChartHight, 3];  //Normal, Add, Sum
        private void DrawAttackerPanel()  //绘制攻击角色数据板块
        {
            object[] list = new object[AttackerNumber];
            for (int i = 0; i < AttackerNumber; i++)
            {
                list[i] = Attacker[i].Name;
            }

            for (int i = 0; i < AttackerChartHight; i++)
            {
                comboBox_AttackerName[i] = new ComboBox();
                tableLayoutPanel_Attacker.Controls.Add(comboBox_AttackerName[i], 0, i + 1);
                comboBox_AttackerName[i].Anchor = AnchorStyles.None;
                comboBox_AttackerName[i].Items.AddRange(list);
                for (int j = 0; j < 5; j++)
                {
                    textBox_AttackerStats[i, j] = new TextBox();
                    tableLayoutPanel_Attacker.Controls.Add(textBox_AttackerStats[i, j], j + 1, i + 1);
                    textBox_AttackerStats[i, j].Anchor = AnchorStyles.None;
                    textBox_AttackerStats[i, j].TextAlign = HorizontalAlignment.Right;
                }
                for (int j = 0; j < 3; j++)
                {
                    label_AttackDamage[i, j] = new Label();
                    tableLayoutPanel_Attacker.Controls.Add(label_AttackDamage[i, j], j + 6, i + 1);
                    label_AttackDamage[i, j].Anchor = AnchorStyles.None;
                    label_AttackDamage[i, j].AutoSize = true;
                    label_AttackDamage[i, j].TextAlign = System.Drawing.ContentAlignment.TopCenter;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCharacters();  //设定角色基本数据
            DrawSupporterData();  //绘制支援角色数据
            DrawAttackerPanel();  //绘制攻击角色数据板块
            Savefile.LoadSavefile();  //读取（不存在则创建）存档，并以此进行第一次计算
        }

        private static AttackCharacter[] ComparedAttacker = new AttackCharacter[AttackerChartHight];
        private static void CalcutateNormalDamage()  //普攻
        {
            //计算选中的支援角色提供的buff量
            double ATKbuff = 0, CRRbuff = 0, CRDbuff = 0;
            for (int i = 0; i < SupporterNumber; i++)
            {
                if (checkBox_SupporterChoose[i].Checked)
                {
                    ATKbuff += Supporter[i].ATKup;
                    CRRbuff += Supporter[i].CRRup;
                    CRDbuff += Supporter[i].CRDup;
                }
            }
            
            for (int i = 0; i < AttackerChartHight; i++)
            {
                int order = comboBox_AttackerName[i].SelectedIndex;
                if (order >= 0)
                {
                    //计算攻击角色入场状态 + 为攻击角色套用支援buff
                    ComparedAttacker[i] = new AttackCharacter(Attacker[order].Name) { Skills = Attacker[order].Skills };
                    ComparedAttacker[i].SetStats(
                        textBox_AttackerStats[i, 0].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 0].Text),
                        textBox_AttackerStats[i, 1].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 1].Text) / 100,
                        textBox_AttackerStats[i, 2].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 2].Text) / 100,
                        textBox_AttackerStats[i, 3].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 3].Text) / 100,
                        textBox_AttackerStats[i, 4].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 4].Text) / 100,
                        ATKbuff, CRRbuff, CRDbuff);

                    //输出普攻伤害
                    ComparedAttacker[i].CheckBaseDamage();
                    label_AttackDamage[i, 0].Text = ComparedAttacker[i].GetBaseDamage();
                }
            }
            
        }

        private static void CalcutateAddDamage()  //追伤
        {
            for (int i = 0; i < AttackerChartHight; i++)
            {
                if (comboBox_AttackerName[i].SelectedIndex >= 0)
                {
                    ComparedAttacker[i].DoBuffSkill();

                    ComparedAttacker[i].CheckAddDamage();
                    label_AttackDamage[i, 1].Text = ComparedAttacker[i].GetAddDamage();
                }
            }
        }

        private static void CalcutateSumAttack()  //总和
        {
            for (int i = 0; i < AttackerChartHight; i++)
                if (comboBox_AttackerName[i].SelectedIndex >= 0)
                        label_AttackDamage[i, 2].Text = ComparedAttacker[i].GetSumDamage();
        }

        static void Calculate()
        {
            CalcutateNormalDamage();  //普攻  
            CalcutateAddDamage();  //追伤
            CalcutateSumAttack();  //总和
        }
    }
}
