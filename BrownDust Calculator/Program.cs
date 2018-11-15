﻿using System;
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
            Application.Run(new Form_Main());

            //MyPrograme.Work();
        }
    }

    partial class Form_Main
    {
        private static class Savefile  //存档相关
        {
            public static void LoadSavefile()  //读取（不存在则创建）存档
            {
                if (File.Exists("Save.save"))
                {
                    string line;

                    using (StreamReader file = new StreamReader("save.save"))
                    {
                        //读取攻击角色面板
                        line = file.ReadLine();  //"A#"
                        line = file.ReadLine();  //DefenderChartHight
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


                        //读取防御角色面板
                        line = file.ReadLine();  //"D#"
                        line = file.ReadLine();  //AttackerChartHight
                        for (int i = 0; i < DefenderChartHight; i++)
                        {
                            line = file.ReadLine();
                            if (line != "-")
                            {
                                string[] load = line.Split('|');
                                for (int j = 0; j < 6; j++) textBox_DefenderStats[i, j].Text = load[j];
                            }
                        }
                    }
                }
                else { File.Create("save.save"); }  //创建一个存档文件
            }
            public static void SaveSavefile()  //存储存档
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

                    //存储防御角色面板
                    file.Write("#D\n{0:d}\n", DefenderChartHight);
                    for (int i = 0; i < DefenderChartHight; i++)
                    {
                        if (textBox_DefenderStats[i, 0].Text != "")
                        {
                            string line = textBox_DefenderStats[i, 0].Text;
                            for (int j = 1; j <= 5; j++) line += "|" + textBox_DefenderStats[i, j].Text;
                            file.Write(line + "\n");
                        }
                        else { file.Write("-\n"); }
                    }
                }
            }
        }

        private struct TypeDamage
        {
            int Count;
            double[] Dmg , Pr;
            double EXP;

            private void Exchange(int a, int b)
            {
                double t;
                t = Dmg[a]; Dmg[a] = Dmg[b]; Dmg[b] = t;
                t = Pr[a]; Pr[a] = Pr[b]; Pr[b] = t;
            }
            private void Sort()
            {
                for (int i = 1; i < Count; i++)
                {
                    for (int j = i; j < Count; j++)
                    {
                        if (Dmg[j - 1] == Dmg[j])
                        {
                            Pr[j - 1] += Pr[j];
                            Count--;
                            for (int k = j; k < Count; k++) { Dmg[k] = Dmg[k + 1]; Pr[k] = Pr[k + 1]; }
                        }
                        if (Dmg[j - 1] > Dmg[j])
                        {
                            double t;
                            t = Dmg[j]; Dmg[j] = Dmg[j - 1]; Dmg[j - 1] = t;
                            t = Pr[j]; Pr[j] = Pr[j - 1]; Pr[j - 1] = t;
                        }
                    }
                }
            }
            
            public TypeDamage(int size, params double[] detail)
            {
                Count = 0;
                Dmg = new double[size]; Pr = new double[size];
                EXP = 0;

                if (detail.Length > 0)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (detail[i * 2 + 1] > 0)
                        {
                            Dmg[Count] = detail[i * 2];
                            Pr[Count] = detail[i * 2 + 1];
                            EXP += Dmg[Count] * Pr[Count];
                            Count++;
                        }
                    }
                }
                Sort();
            }

            public static TypeDamage operator +(TypeDamage a, TypeDamage b)
            {
                int size = a.Count * b.Count;
                double[] detail = new double[size * 2];

                for (int i = 0; i < a.Count; i++)
                    for (int j = 0; j < b.Count; j++)
                    {
                        detail[(i * b.Count + j) * 2] = a.Dmg[i] + b.Dmg[j];
                        detail[(i * b.Count + j) * 2 + 1] = a.Pr[i] * b.Pr[j];
                    }

                return new TypeDamage(size, detail);
            }

            public void MakeReal()
            {
                Count = 1;
                Pr[0] = 1;
                EXP = Dmg[0];
            }

            public string WriteNumericalDamage()
            {
                string result = "";
                if (Count == 1)
                {
                    result = Dmg[0].ToString("f0");
                }
                else
                {
                    result += Dmg[0].ToString("f0") + " " + (Pr[0] * 100).ToString("f0") + "% | ";
                    result += Dmg[Count - 1].ToString("f0") + " " + (Pr[Count - 1] * 100).ToString("f0") + "%";
                    result += "\n" + EXP.ToString("f0");
                }
                return result;
            }
            public string WriteRatioDamage()
            {
                string result = "";
                if (Count == 1)
                {
                    result = (Dmg[0] * 100).ToString("f1") + "%";
                }
                else
                {
                    result += (Dmg[0] * 100).ToString("f1") + "% " + (Pr[0] * 100).ToString("f0") + "% | ";
                    result += (Dmg[Count - 1] * 100).ToString("f1") + "% " + (Pr[Count - 1] * 100).ToString("f0") + "%";
                    result += "\n" + (EXP * 100).ToString("f1") + "%";
                }
                return result;
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
                public int nStatsUp = 0, nBuffSkill = 0, nAddDamage = 0, nAddRatio = 0;
                public struct TypeSkillDetail
                {
                    public string from, to;
                    public double rate;
                }

                public TypeSkillDetail[] StatsUp = new TypeSkillDetail[5];  //依赖属性，增长属性，倍率
                public TypeSkillDetail[] BuffSkill = new TypeSkillDetail[5];  //增长属性，buff量
                public TypeSkillDetail AddDamage = new TypeSkillDetail();  //依赖属性，倍率
                public bool isAddRatio = false, isAddReal = false;  //追伤是否为血量比例伤害、是否为真伤
                public bool isImmunnity = false;  //是否有免疫技能

                public void SetStatusUp(params TypeSkillDetail[] arr)
                {
                    nStatsUp = arr.Length;
                    StatsUp = arr;
                }
                public void SetBuffSkill(params TypeSkillDetail[] arr)
                {
                    nBuffSkill = arr.Length; ;
                    BuffSkill = arr;
                }
                public void SetAddDamage(TypeSkillDetail detail)
                {
                    nAddDamage = 1;
                    AddDamage = detail;
                }
            }
            private struct TypeStats { public double ATK, DEF, CRR, CRD, AGI; }

            public string Name;
            private TypeStats BaseStats, NowStats, StatsUp;
            public TypeSkill Skills = new TypeSkill();
            public TypeDamage BaseDamage, AddDamage;

            public AttackCharacter(string name) { Name = name; }
            public AttackCharacter ShallowCopy() { return (AttackCharacter) MemberwiseClone(); }

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
                NowStats.ATK = Math.Max(0, BaseStats.ATK * (1 + StatsUp.ATK));
                NowStats.CRR = Math.Max(0, Math.Min(1, BaseStats.CRR + StatsUp.CRR));
                NowStats.CRD = Math.Max(0, BaseStats.CRD + StatsUp.CRD);
                NowStats.AGI = Math.Max(0, Math.Min(1, BaseStats.AGI + StatsUp.AGI));
                NowStats.DEF = Math.Max(0, Math.Min(1, BaseStats.DEF + StatsUp.DEF));
            }
            public void Weakened(double debuff)
            {
                StatsUp.ATK -= debuff; StatsUp.DEF -= debuff; StatsUp.CRR -= debuff; StatsUp.CRD -= debuff; StatsUp.AGI -= debuff;
                CheckStats();
            }

            public void SetStats(double atk, double crr, double crd, double agi, double def, double atkbuff, double crrbuff, double crdbuff)  //计算攻击角色入场属性
            {
                BaseStats = new TypeStats { ATK = atk, CRR = crr, CRD = crd, AGI = agi, DEF = def };
                DoStatsUp();
                StatsUp.ATK = atkbuff; StatsUp.CRR = crrbuff; StatsUp.CRD = crdbuff;
                CheckStats();
            }
            
            public void CheckBaseDamage()
            {
                BaseDamage = new TypeDamage(2,
                    NowStats.ATK, 1 - NowStats.CRR,
                    NowStats.ATK * (1 + NowStats.CRD), NowStats.CRR);
            }
            public void CheckAddDamage()
            {
                if (Skills.nAddDamage > 0)
                {
                    if (Skills.AddDamage.from == "EHP")
                    {
                        AddDamage = new TypeDamage(2,
                            Skills.AddDamage.rate, 1 - NowStats.CRR,
                            Skills.AddDamage.rate * (1 + NowStats.CRD), NowStats.CRR);
                    }
                    else
                    {
                        double from = 0;
                        switch (Skills.AddDamage.from)
                        {
                            case "DEF": from = NowStats.DEF; break;
                            case "CRR": from = NowStats.CRR; break;
                            case "CRD": from = NowStats.CRD; break;
                            case "AGI": from = NowStats.AGI; break;
                            case "   ": from = 1; break;
                        }
                        AddDamage = new TypeDamage(2,
                            NowStats.ATK * from * Skills.AddDamage.rate, 1 - NowStats.CRR,
                            NowStats.ATK * from * Skills.AddDamage.rate * (1 + NowStats.CRD), NowStats.CRR);
                    }
                    if (Skills.isAddReal)
                    {
                        AddDamage.MakeReal();
                    }
                }
            }
            public string WriteBaseDamage()
            {
                return BaseDamage.WriteNumericalDamage();
            }
            public string WriteAddDamage()
            {
                if (Skills.nAddDamage > 0)
                {
                    if (Skills.AddDamage.from == "EHP")
                        return AddDamage.WriteRatioDamage();
                    else
                        return AddDamage.WriteNumericalDamage();
                }
                else return "/";
            }
            public string WriteSumDamage()
            {
                if (Skills.AddDamage.from == "EHP") return "X";
                if (Skills.nAddDamage == 0) return WriteBaseDamage();

                return (BaseDamage + AddDamage).WriteNumericalDamage();
            }
        }
        private class DefendCharacter
        {
            private struct TypeStats { public double HP, DEF, AGI, CUT, Weaking; }
            private struct TypeDamage { public int normal, critical; public double expected, crr; }

            public string Name;
            private TypeStats BaseStats;
            private TypeDamage BaseIncoming, AddIncoming;

            public DefendCharacter(string name) { Name = name; }

            public void SetStats(int hp, double def, double agi, double cut, double weaking)
            {
                BaseStats = new TypeStats
                {
                    HP = Math.Max(0, hp),
                    DEF = Math.Max(0, Math.Min(1, def)),
                    AGI = Math.Max(0, Math.Min(1, agi)),
                    CUT = Math.Max(0, Math.Min(0.7, agi)),
                    Weaking = Math.Max(0, Math.Min(1, weaking))
                };
            }

            public void CheckBaseIncoming(AttackCharacter attacker)
            {
                double rate = (1 - BaseStats.DEF) * (1 - BaseStats.CUT);
                /*
                BaseIncoming.normal = (int)(attacker.BaseDamage.normal * rate);
                BaseIncoming.critical = (int)(attacker.BaseDamage.critical * rate);
                BaseIncoming.crr = attacker.BaseDamage.crr;
                BaseIncoming.expected = BaseIncoming.normal * (1 - BaseIncoming.crr) + BaseIncoming.critical * BaseIncoming.crr;
                */
            }
            private void AddIncomingPart(AttackCharacter attacker)
            {
                double rate = attacker.Skills.isAddReal ? 1 : (1 - BaseStats.DEF) * (1 - BaseStats.CUT);
                if (attacker.Skills.AddDamage.from == "EHP")
                {
                    //AddIncoming.normal = (int)(BaseStats.HP * attacker.AddDamage.normal * rate);
                    //AddIncoming.critical = (int)(BaseStats.HP * attacker.AddDamage.critical * rate);
                }
                else
                {
                    //AddIncoming.normal = (int)(attacker.AddDamage.normal * rate);
                    //AddIncoming.critical = (int)(attacker.AddDamage.critical * rate);
                }
                if (attacker.Skills.isAddReal)
                {
                    AddIncoming.crr = 0;
                    AddIncoming.expected = AddIncoming.critical = AddIncoming.normal;
                }
                else
                {
                    //AddIncoming.crr = attacker.AddDamage.crr;
                    AddIncoming.expected = AddIncoming.normal * (1 - AddIncoming.crr) + AddIncoming.critical * AddIncoming.crr;
                }
            }
            public void CheckAddIncoming(AttackCharacter attacker)
            {
                if (BaseStats.Weaking == 0)
                {
                    AddIncomingPart(attacker);
                }
                else
                {
                    AttackCharacter weak = attacker.ShallowCopy();
                    weak.Weakened(BaseStats.Weaking);
                    weak.CheckAddDamage();
                    AddIncomingPart(weak);
                }
            }
        }

        static int SupporterNumber = 4, AttackerNumber = 2;
        static int AttackerChartHight = 8, DefenderChartHight = 4;

        private static SupportCharacter[] Supporter = new SupportCharacter[SupporterNumber];
        private static AttackCharacter[] Attacker = new AttackCharacter[AttackerNumber];
        private static void SetCharacters()  //设定角色基本数据
        {
            Supporter[0] = new SupportCharacter("眼镜", 1.6496, 0.40, 0.05, 0.00, 0, 0);
            Supporter[1] = new SupportCharacter("弦月", 1.5118, 0.15, 0.15, 0.36, 0, 0);
            Supporter[2] = new SupportCharacter("屁股", 1.7481, 0.30, 0.00, 0.30, 0, 0);
            Supporter[3] = new SupportCharacter("琴女", 1.7481, 0.00, 0.20, 0.00, 0, 0);

            Attacker[0] = new AttackCharacter("女忍");
            {
                Attacker[0].Skills.SetStatusUp(
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "AGI", to = "CRR", rate = 1.00 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "   ", to = "CRD", rate = 0.50 });
                Attacker[0].Skills.SetBuffSkill(
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "CRD", rate =1.50 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "ATK", rate =0.35 });
                Attacker[0].Skills.SetAddDamage(
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "CRR", rate = 1.25 });
            }
            Attacker[1] = new AttackCharacter("修女");
            {
                Attacker[1].Skills.SetAddDamage(
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "EHP", rate = 0.20 });
                Attacker[1].Skills.isImmunnity = true;
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
        private static Label[,] label_AttackerDamage = new Label[AttackerChartHight, 3];  //Normal, Add, Sum
        private static RadioButton[] radioButton_AttackerChoose = new RadioButton[AttackerChartHight];
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
                    label_AttackerDamage[i, j] = new Label();
                    tableLayoutPanel_Attacker.Controls.Add(label_AttackerDamage[i, j], j + 6, i + 1);
                    label_AttackerDamage[i, j].Anchor = AnchorStyles.None;
                    label_AttackerDamage[i, j].AutoSize = true;
                    label_AttackerDamage[i, j].TextAlign = System.Drawing.ContentAlignment.TopCenter;
                }
                radioButton_AttackerChoose[i] = new RadioButton();
                tableLayoutPanel_Attacker.Controls.Add(radioButton_AttackerChoose[i], 9, i + 1);
                radioButton_AttackerChoose[i].Anchor = AnchorStyles.None;
                radioButton_AttackerChoose[i].AutoSize = true;
            }
        }

        private static TextBox[,] textBox_DefenderStats = new TextBox[DefenderChartHight, 6];  //Name, HP, DEF, AGI, DEF, Weaking
        private void DrawDeffenderPanel()  //绘制防御角色数据板块
        {
            for (int i = 0; i < DefenderChartHight; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    textBox_DefenderStats[i, j] = new TextBox();
                    tableLayoutPanel_Defender.Controls.Add(textBox_DefenderStats[i, j], j, i + 1);
                    textBox_DefenderStats[i, j].Anchor = AnchorStyles.None;
                    textBox_DefenderStats[i, j].TextAlign = HorizontalAlignment.Right;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCharacters();
            DrawSupporterData();
            DrawAttackerPanel();
            DrawDeffenderPanel();
            Savefile.LoadSavefile();
        }

        private static AttackCharacter[] ComparedAttacker = new AttackCharacter[AttackerChartHight];
        private static void CalcutateNormalDamage()  //计算支援&攻击角色出手前数据 + 计算普攻
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
                    label_AttackerDamage[i, 0].Text = ComparedAttacker[i].WriteBaseDamage();
                }
            }

        }
        private static void CalcutateAddDamage()  //计算攻击角色普攻后数据 + 计算追伤
        {
            for (int i = 0; i < AttackerChartHight; i++)
            {
                if (comboBox_AttackerName[i].SelectedIndex >= 0)
                {
                    ComparedAttacker[i].DoBuffSkill();

                    ComparedAttacker[i].CheckAddDamage();
                    label_AttackerDamage[i, 1].Text = ComparedAttacker[i].WriteAddDamage();
                }
            }
        }
        private static void CalcutateSumDamage()  //计算总和
        {
            for (int i = 0; i < AttackerChartHight; i++)
                if (comboBox_AttackerName[i].SelectedIndex >= 0)
                    label_AttackerDamage[i, 2].Text = ComparedAttacker[i].WriteSumDamage();
        }
        
        private static DefendCharacter[] ComparedDefender = new DefendCharacter[DefenderChartHight];
        private static void SetDefenderStats()  //计算防御角色数据
        {
            int AttackerOrder = -1;
            for (int i = 0; i < AttackerChartHight; i++)
                if (radioButton_AttackerChoose[i].Checked) { AttackerOrder = i; break; }

            if (AttackerOrder != -1)
            {
                for (int i = 0; i < DefenderChartHight; i++)
                {
                    if (textBox_DefenderStats[i, 0].Text != "")
                    {
                        //设定防御角色属性
                        ComparedDefender[i] = new DefendCharacter(textBox_DefenderStats[i, 0].Text);
                        double[] stats = new double[6];
                        for (int j = 1; j <= 5; j++) { stats[j] = textBox_DefenderStats[i, j].Text == "" ? 0 : double.Parse(textBox_DefenderStats[i, j].Text); }
                        ComparedDefender[i].SetStats(Convert.ToInt32(stats[1]), stats[2], stats[3], stats[4], stats[5]);

                        //计算防御角色承受伤害
                        ComparedDefender[i].CheckBaseIncoming(Attacker[AttackerOrder]);
                        ComparedDefender[i].CheckAddIncoming(Attacker[AttackerOrder]);
                    }
                }
            }
        }

        static void CalculateDamage()
        {
            CalcutateNormalDamage();
            CalcutateAddDamage();
            CalcutateSumDamage();
        }
    }
}