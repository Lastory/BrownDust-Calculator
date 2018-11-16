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
            public static void LoadSavefile()  //读取（不存在则创建一个空的）存档
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
                                comboBox_AttackerSlv[i].SelectedIndex = int.Parse(load[1]);
                                for (int j = 0; j < 5; j++) textBox_AttackerStats[i, j].Text = load[j + 2];
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
                            line += comboBox_AttackerSlv[i].SelectedIndex.ToString("d") + "|";
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
            private struct TypePossbility : IComparable
            {
                public double Point, Rate;

                public int CompareTo(object obj)
                {
                    return this.Point.CompareTo(((TypePossbility)obj).Point);
                }
            }

            private int Count;
            private TypePossbility[] Poss;
            private double EXP;

            private void Exchange(int a, int b)
            {
                TypePossbility t = Poss[a];
                Poss[a] = Poss[b];
                Poss[b] = t;
            }
            private void Sort()
            {
                Array.Sort(Poss, 0, Count);

                for (int i = Count - 1; i > 0; i--)
                {
                    if (Poss[i - 1].Point == Poss[i].Point)
                    {
                        Poss[i - 1].Rate += Poss[i].Rate;
                        for (int j = i + 1; j < Count; j++) Poss[j - 1] = Poss[j];
                        Count--;
                    }
                }
            }

            public TypeDamage(int size, params double[] detail)
            {
                Count = 0;
                Poss = new TypePossbility[size];
                EXP = 0;

                if (detail.Length > 0)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (detail[i * 2 + 1] > 0)
                        {
                            Poss[Count].Point = detail[i * 2];
                            Poss[Count].Rate = detail[i * 2 + 1];
                            EXP += Poss[Count].Point * Poss[Count].Rate;
                            Count++;
                        }
                    }
                }
                Sort();
            }
            private TypeDamage(int size, TypePossbility[] detail)
            {
                Count = 0;
                Poss = new TypePossbility[size];
                EXP = 0;

                for (int i = 0; i < size; i++)
                {
                    if (detail[i].Rate > 0)
                    {
                        Poss[Count] = detail[i];
                        EXP += Poss[Count].Point * Poss[Count].Rate;
                        Count++;
                    }
                }
                Sort();
            }
            public TypeDamage ShallowCopy() { return (TypeDamage)this.MemberwiseClone(); }

            public void Push(double damage, double probability)  //注意数组设定的上界，Push之后需要Sort
            {
                Poss[Count].Point = damage;
                Poss[Count].Rate = probability;

                EXP += Poss[Count].Point * Poss[Count].Rate;
                Count++;
            }

            public static TypeDamage operator +(TypeDamage a, TypeDamage b)  //伤害整数化后再相加
            {
                if (b.Count == 0) return a.ShallowCopy();
                if (a.Count == 0) return b.ShallowCopy();

                int size = a.Count * b.Count;
                double[] detail = new double[size * 2];

                for (int i = 0; i < a.Count; i++)
                    for (int j = 0; j < b.Count; j++)
                    {
                        detail[(i * b.Count + j) * 2] = (int)a.Poss[i].Point + (int)b.Poss[j].Point;
                        detail[(i * b.Count + j) * 2 + 1] = a.Poss[i].Rate * b.Poss[j].Rate;
                    }

                return new TypeDamage(size, detail);
            }
            public static TypeDamage operator *(double rate, TypeDamage a)
            {
                int size = a.Count;
                double[] detail = new double[size * 2];

                for (int i = 0; i < size; i++)
                {
                    detail[i * 2] = a.Poss[i].Point * rate;
                    detail[i * 2 + 1] = a.Poss[i].Rate;
                }

                return new TypeDamage(size, detail);
            }
            public static TypeDamage operator -(double HP, TypeDamage Damage)  //伤害整数化后再相减
            {

                TypePossbility[] arr = new TypePossbility[Damage.Count];
                for (int i = 0; i < Damage.Count; i++)
                {
                    arr[i].Point = Math.Max(0, HP - (int)Damage.Poss[i].Point);
                    arr[i].Rate = Damage.Poss[i].Rate;
                }

                return new TypeDamage(Damage.Count, arr);
            }
            public static TypeDamage operator -(TypeDamage HP, TypeDamage Damage)  //伤害整数化后再相减
            {
                if (Damage.Count == 0) return HP.ShallowCopy();
                if (HP.Count == 0) return new TypeDamage(0);

                int size = HP.Count * Damage.Count;
                double[] detail = new double[size * 2];

                for (int i = 0; i < HP.Count; i++)
                    for (int j = 0; j < Damage.Count; j++)
                    {
                        detail[(i * Damage.Count + j) * 2] = Math.Max(0, (int)HP.Poss[i].Point - (int)Damage.Poss[j].Point);
                        detail[(i * Damage.Count + j) * 2 + 1] = HP.Poss[i].Rate * Damage.Poss[j].Rate;
                    }

                return new TypeDamage(size, detail);
            }

            public void BecomeReal()
            {
                Count = 1;
                Poss[0].Rate = 1;
                EXP = Poss[0].Point;
            }
            public void CountAGI(double agi)
            {
                if (agi == 0) return;
                if (agi == 1)
                {
                    for (int i = 0; i < Count; i++) Poss[i].Point *= 0.65;
                    EXP *= 0.65;
                    return;
                }

                TypePossbility[] arr = new TypePossbility[Count * 2];

                for (int i = 0; i < Count; i++)
                {
                    arr[i * 2].Point = Poss[i].Point * 0.65;
                    arr[i * 2].Rate = Poss[i].Rate * agi;
                    arr[i * 2 + 1].Point = Poss[i].Point;
                    arr[i * 2 + 1].Rate = Poss[i].Rate * (1 - agi);
                }

                this = new TypeDamage(Count * 2, arr);
            }

            public string WriteNumericalDamage()
            {
                if (Count == 0) return "/";

                string result = "";
                if (Count == 1)
                {
                    result = Poss[0].Point.ToString("f0");
                }
                else
                {
                    result += Poss[0].Point.ToString("f0") + " " + (Poss[0].Rate * 100).ToString("f0") + "% | ";
                    result += Poss[Count - 1].Point.ToString("f0") + " " + (Poss[Count - 1].Rate * 100).ToString("f0") + "%";
                    result += "\n" + EXP.ToString("f0");
                }
                return result;
            }
            public string WriteRatioDamage()
            {
                if (Count == 0) return "/";

                string result = "";
                if (Count == 1)
                {
                    result = (Poss[0].Point * 100).ToString("f1") + "%";
                }
                else
                {
                    result += (Poss[0].Point * 100).ToString("f1") + "% " + (Poss[0].Rate * 100).ToString("f0") + "% | ";
                    result += (Poss[Count - 1].Point * 100).ToString("f1") + "% " + (Poss[Count - 1].Rate * 100).ToString("f0") + "%";
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
                public int nStatsBuff = 0, nAfterBuff = 0, nAddAttackNormal = 0, nAddAttackReal = 0;
                public struct TypeSkillDetail
                {
                    public string from, to;
                    public double rate;
                }

                public TypeSkillDetail[] StatsBuff = new TypeSkillDetail[5];  //依赖属性，增长属性，倍率
                public TypeSkillDetail[] AfterBuff = new TypeSkillDetail[5];  //增长属性，buff量
                public TypeSkillDetail AddAttackNormal, AddAttackReal;  //依赖属性，倍率
                public bool isAddRatio = false;  //追伤是否为血量比例伤害
                public bool isImmunnity = false;  //是否有免疫技能

                public TypeSkill ShallowCopy() { return (TypeSkill)this.MemberwiseClone(); }

                public void SetStatsBuff(params TypeSkillDetail[] detail)
                {
                    nStatsBuff = detail.Length;
                    StatsBuff = detail;
                }
                public void SetAfterBuff(params TypeSkillDetail[] detail)
                {
                    nAfterBuff = detail.Length; ;
                    AfterBuff = detail;
                }
                public void SetAddAttackNormal(TypeSkillDetail detail)
                {
                    nAddAttackNormal = 1;
                    AddAttackNormal = detail;
                    if (detail.from == "EHP") isAddRatio = true;
                }
                public void SetAddAttackReal(TypeSkillDetail detail)
                {
                    nAddAttackReal = 1;
                    AddAttackReal = detail;
                    if (detail.from == "EHP") isAddRatio = true;
                }
            }
            private struct TypeStats { public double ATK, DEF, CRR, CRD, AGI; }

            public string Name;
            private int SkillLevel;
            private TypeStats BaseStats, NowStats, StatsUp;
            public bool[] isSLvExist = new bool[11];
            public TypeSkill[] SkillList = new TypeSkill[11];
            public TypeSkill NowSkill = new TypeSkill();
            public TypeDamage BaseDamage, AddDamageNormal, AddDamageReal;

            public AttackCharacter(string name)
            {
                Name = name;
                for (int i = 1; i <= 10; i++) SkillList[i] = new TypeSkill();
            }
            public AttackCharacter ShallowCopy() { return (AttackCharacter)this.MemberwiseClone(); }

            public void SetStats(double atk, double crr, double crd, double agi, double def, double atkbuff, double crrbuff, double crdbuff)  //计算攻击角色入场属性
            {
                BaseStats = new TypeStats { ATK = atk, CRR = crr, CRD = crd, AGI = agi, DEF = def };
                DoStatsUp();
                StatsUp.ATK = atkbuff; StatsUp.CRR = crrbuff; StatsUp.CRD = crdbuff;
                CheckStats();
            }
            public void SetStatsBuff(int level, params TypeSkill.TypeSkillDetail[] detail)
            {
                isSLvExist[level] = true;
                SkillList[level].SetStatsBuff(detail);
            }
            public void SetAfterBuff(int level, params TypeSkill.TypeSkillDetail[] detail)
            {
                isSLvExist[level] = true;
                SkillList[level].SetAfterBuff(detail);
            }
            public void SetAddAttackNormal(int level, TypeSkill.TypeSkillDetail detail)
            {
                isSLvExist[level] = true;
                SkillList[level].SetAddAttackNormal(detail);
            }
            public void SetAddAttackReal(int level, TypeSkill.TypeSkillDetail detail)
            {
                isSLvExist[level] = true;
                SkillList[level].SetAddAttackReal(detail);
            }
            public void CopySkill(int from, int to)
            {
                isSLvExist[to] = true;
                SkillList[to] = SkillList[from].ShallowCopy();
            }
            public void SetSkillLevel(int level)
            {
                SkillLevel = level;
                NowSkill = SkillList[level];
            }

            private void DoStatsUp()
            {
                for (int i = 0; i < NowSkill.nStatsBuff; i++)
                {
                    double buff = NowSkill.StatsBuff[i].rate;
                    switch (NowSkill.StatsBuff[i].from)
                    {
                        case "DEF": buff *= BaseStats.DEF; break;
                        case "CRR": buff *= BaseStats.CRR; break;
                        case "AGI": buff *= BaseStats.AGI; break;
                    }
                    switch (NowSkill.StatsBuff[i].to)
                    {
                        case "ATK": BaseStats.ATK *= 1 + buff; break;
                        case "CRR": BaseStats.CRR += buff; break;
                        case "CRD": BaseStats.CRD += buff; break;
                    }
                }
            }
            public void DoBuffSkill()
            {
                for (int i = 0; i < NowSkill.nAfterBuff; i++)
                {
                    double buff = NowSkill.AfterBuff[i].rate;
                    switch (NowSkill.AfterBuff[i].to)
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

            public void CheckBaseDamage()
            {
                BaseDamage = new TypeDamage(2,
                    NowStats.ATK, 1 - NowStats.CRR,
                    NowStats.ATK * (1 + NowStats.CRD), NowStats.CRR);
            }
            public TypeDamage GetAddDamage(TypeSkill.TypeSkillDetail data, bool isReal)
            {
                TypeDamage result;

                if (data.from == "EHP")
                {
                    result = new TypeDamage(2,
                        data.rate, 1 - NowStats.CRR,
                        data.rate * (1 + NowStats.CRD), NowStats.CRR);
                }
                else
                {
                    double from = 0;
                    switch (data.from)
                    {
                        case "DEF": from = NowStats.DEF; break;
                        case "CRR": from = NowStats.CRR; break;
                        case "CRD": from = NowStats.CRD; break;
                        case "AGI": from = NowStats.AGI; break;
                        case "   ": from = 1; break;
                    }
                    result = new TypeDamage(2,
                        NowStats.ATK * from * data.rate, 1 - NowStats.CRR,
                        NowStats.ATK * from * data.rate * (1 + NowStats.CRD), NowStats.CRR);
                }

                if (isReal) result.BecomeReal();

                return result;
            }
            public void CheckAddDamage()
            {
                AddDamageNormal = NowSkill.nAddAttackNormal == 0 ? new TypeDamage(0) : GetAddDamage(NowSkill.AddAttackNormal, false);
                AddDamageReal = NowSkill.nAddAttackReal == 0 ? new TypeDamage(0) : GetAddDamage(NowSkill.AddAttackReal, true);
            }
            public string WriteBaseDamage()
            {
                return BaseDamage.WriteNumericalDamage();
            }
            public string WriteAddDamage()  //【注意】没有考虑比例追伤+数值追伤
            {
                if (NowSkill.isAddRatio)
                    return (AddDamageNormal + AddDamageReal).WriteRatioDamage();
                else
                    return (AddDamageNormal + AddDamageReal).WriteNumericalDamage();
            }
            public string WriteSumDamage()
            {
                if (NowSkill.isAddRatio) return "X";

                return (BaseDamage + AddDamageNormal + AddDamageReal).WriteNumericalDamage();
            }
        }
        private class DefendCharacter
        {
            private struct TypeStats { public double HP, DEF, AGI, CUT, Weaking; }

            public string Name;
            private TypeStats BaseStats;
            private TypeDamage BaseIncoming, AddIncomingNormal, AddIncomingReal;
            private TypeDamage MidHP, FinalHP;

            public DefendCharacter(string name) { Name = name; }

            public void SetStats(int hp, double def, double agi, double cut, double weaking)
            {
                BaseStats = new TypeStats
                {
                    HP = Math.Max(0, hp),
                    DEF = Math.Max(0, Math.Min(1, def)),
                    AGI = Math.Max(0, Math.Min(1, agi)),
                    CUT = Math.Max(0, Math.Min(0.7, cut)),
                    Weaking = Math.Max(0, Math.Min(1, weaking))
                };
            }

            public void CheckBaseIncoming(AttackCharacter attacker)
            {
                BaseIncoming = (1 - BaseStats.DEF) * (1 - BaseStats.CUT) * attacker.BaseDamage;
                BaseIncoming.CountAGI(BaseStats.AGI);
            }
            private void CheckAddIncomingPart(AttackCharacter attacker)
            {
                double rate = (1 - BaseStats.DEF) * (1 - BaseStats.CUT);

                if (attacker.NowSkill.isAddRatio)
                {
                    AddIncomingNormal = BaseStats.HP * rate * attacker.AddDamageNormal;
                    AddIncomingReal = BaseStats.HP * 1 * attacker.AddDamageReal;
                }
                else
                {
                    AddIncomingNormal = rate * attacker.AddDamageNormal;
                    AddIncomingReal = rate * attacker.AddDamageReal;
                }
                AddIncomingNormal.CountAGI(BaseStats.AGI);
                AddIncomingReal.CountAGI(BaseStats.AGI);
            }
            public void CheckAddIncoming(AttackCharacter attacker)
            {
                if (BaseStats.Weaking == 0 || attacker.NowSkill.isImmunnity)
                {
                    CheckAddIncomingPart(attacker);
                }
                else
                {
                    AttackCharacter weak = attacker.ShallowCopy();
                    weak.Weakened(BaseStats.Weaking);
                    weak.CheckAddDamage();
                    CheckAddIncomingPart(weak);
                }
            }

            public void CheckMidHP() { MidHP = BaseStats.HP - BaseIncoming; }
            public void CheckFinalHP() { FinalHP = MidHP - AddIncomingNormal - AddIncomingReal; }
            public string WriteMidHP() { return MidHP.WriteNumericalDamage(); }
            public string WriteFinalHP() { return FinalHP.WriteNumericalDamage(); }
        }

        static int SupporterNumber = 4, AttackerNumber = 3;
        static int AttackerChartHight = 8, DefenderChartHight = 4;

        private static SupportCharacter[] Supporter = new SupportCharacter[SupporterNumber];
        private static AttackCharacter[] Attacker = new AttackCharacter[AttackerNumber];
        private static void SetCharacters()  //设定角色基本数据
        {
            Supporter[0] = new SupportCharacter("眼镜", 1.6496, 0.40, 0.05, 0.00, 0, 0);
            Supporter[1] = new SupportCharacter("弦月", 1.5118, 0.15, 0.15, 0.36, 0, 0);
            Supporter[2] = new SupportCharacter("屁股", 1.7481, 0.30, 0.00, 0.30, 0, 0);
            Supporter[3] = new SupportCharacter("琴女", 1.7481, 0.00, 0.20, 0.30, 0, 0);

            Attacker[0] = new AttackCharacter("女忍");
            {
                Attacker[0].SetStatsBuff(9,
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "AGI", to = "CRR", rate = 1.00 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "   ", to = "CRD", rate = 0.50 });
                Attacker[0].SetAfterBuff(9,
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "CRD", rate = 1.50 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "ATK", rate = 0.35 });
                Attacker[0].SetAddAttackNormal(9,
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "CRR", rate = 1.25 });
            }
            Attacker[1] = new AttackCharacter("修女");
            {
                Attacker[1].SetAddAttackNormal(3,
                     new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "EHP", rate = 0.20 });
                Attacker[1].SkillList[3].isImmunnity = true;
            }
            Attacker[2] = new AttackCharacter("海盗");
            {
                Attacker[2].SetStatsBuff(3,
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "ATK", rate = 0.50 });
                Attacker[2].SetAddAttackReal(3,
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "   ", rate = 1.30 });
            }
        }

        private static class RefreshUI
        {
            public class TpyeComboBox_AttackerSlv
            {
                int order;

                public TpyeComboBox_AttackerSlv(int order) { this.order = order; }

                public void Refresh(object sender, EventArgs e)
                {
                    comboBox_AttackerSlv[order].Items.Clear();
                    comboBox_AttackerSlv[order].Text = "";

                    int AttackerOrder = comboBox_AttackerName[order].SelectedIndex;
                    if (AttackerOrder >= 0)
                    {
                        for (int j = 0; j <= 10; j++)
                        {
                            if (Attacker[AttackerOrder].isSLvExist[j])
                                comboBox_AttackerSlv[order].Items.Add("+" + j.ToString("d"));
                        }
                    }
                }
            }
            public static TpyeComboBox_AttackerSlv[] Refresher_AttackerSlv = new TpyeComboBox_AttackerSlv[AttackerChartHight];
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
        private static ComboBox[] comboBox_AttackerSlv = new ComboBox[AttackerChartHight];
        private static TextBox[,] textBox_AttackerStats = new TextBox[AttackerChartHight, 5];  //ATK, CRR, CRD, AGI, DEF
        private static Label[,] label_AttackerDamage = new Label[AttackerChartHight, 3];  //Normal, Add, Sum
        private static RadioButton[] radioButton_AttackerChoose = new RadioButton[AttackerChartHight];
        private void DrawAttackerPanel()  //绘制攻击角色数据板块
        {
            object[] NameList = new object[AttackerNumber];
            for (int i = 0; i < AttackerNumber; i++) NameList[i] = Attacker[i].Name;

            for (int i = 0; i < AttackerChartHight; i++)
            {
                comboBox_AttackerName[i] = new ComboBox();
                tableLayoutPanel_Attacker.Controls.Add(comboBox_AttackerName[i], 0, i + 1);
                comboBox_AttackerName[i].Anchor = AnchorStyles.None;
                comboBox_AttackerName[i].Items.AddRange(NameList);

                RefreshUI.Refresher_AttackerSlv[i] = new RefreshUI.TpyeComboBox_AttackerSlv(i);
                comboBox_AttackerName[i].SelectedIndexChanged += new EventHandler(RefreshUI.Refresher_AttackerSlv[i].Refresh);

                comboBox_AttackerSlv[i] = new ComboBox();
                tableLayoutPanel_Attacker.Controls.Add(comboBox_AttackerSlv[i], 1, i + 1);
                comboBox_AttackerSlv[i].Anchor = AnchorStyles.None;

                for (int j = 0; j < 5; j++)
                {
                    textBox_AttackerStats[i, j] = new TextBox();
                    tableLayoutPanel_Attacker.Controls.Add(textBox_AttackerStats[i, j], j + 2, i + 1);
                    textBox_AttackerStats[i, j].Anchor = AnchorStyles.None;
                    textBox_AttackerStats[i, j].TextAlign = HorizontalAlignment.Right;
                }
                for (int j = 0; j < 3; j++)
                {
                    label_AttackerDamage[i, j] = new Label();
                    tableLayoutPanel_Attacker.Controls.Add(label_AttackerDamage[i, j], j + 7, i + 1);
                    label_AttackerDamage[i, j].Anchor = AnchorStyles.None;
                    label_AttackerDamage[i, j].AutoSize = true;
                    label_AttackerDamage[i, j].TextAlign = System.Drawing.ContentAlignment.TopCenter;
                }
                radioButton_AttackerChoose[i] = new RadioButton();
                tableLayoutPanel_Attacker.Controls.Add(radioButton_AttackerChoose[i], 10, i + 1);
                radioButton_AttackerChoose[i].Anchor = AnchorStyles.None;
                radioButton_AttackerChoose[i].AutoSize = true;
            }
        }

        private static TextBox[,] textBox_DefenderStats = new TextBox[DefenderChartHight, 6];  //Name, HP, DEF, AGI, DEF, Weaking
        private static Label[,] label_DefenderHP = new Label[DefenderChartHight, 2];  //Normal, Add, Sum
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
                for (int j = 0; j < 2; j++)
                {
                    label_DefenderHP[i, j] = new Label();
                    tableLayoutPanel_Defender.Controls.Add(label_DefenderHP[i, j], j + 6, i + 1);
                    label_DefenderHP[i, j].Anchor = AnchorStyles.None;
                    label_DefenderHP[i, j].AutoSize = true;
                    label_DefenderHP[i, j].TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
        private static void CalcutateDamage()  //计算支援&攻击角色出手前数据 + 计算普攻
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
                int order = comboBox_AttackerName[i].SelectedIndex, Slv = comboBox_AttackerSlv[i].SelectedIndex;
                if (order >= 0 && Slv >= 0)
                {
                    //计算攻击角色入场状态 + 为攻击角色套用支援buff
                    Slv = ((string)comboBox_AttackerSlv[i].SelectedItem)[1] - '0';
                    ComparedAttacker[i] = Attacker[order].ShallowCopy();
                    ComparedAttacker[i].SetSkillLevel(Slv);

                    double[] stats = new double[5];
                    for (int j = 0; j < 5; j++) stats[j] = textBox_AttackerStats[i, j].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, j].Text);
                    ComparedAttacker[i].SetStats(stats[0], stats[1] / 100, stats[2] / 100, stats[3] / 100, stats[4] / 100, ATKbuff, CRRbuff, CRDbuff);

                    //输出普攻伤害
                    ComparedAttacker[i].CheckBaseDamage();
                    label_AttackerDamage[i, 0].Text = ComparedAttacker[i].WriteBaseDamage();

                    //计算普攻后数据
                    ComparedAttacker[i].DoBuffSkill();

                    //计算追伤
                    ComparedAttacker[i].CheckAddDamage();
                    label_AttackerDamage[i, 1].Text = ComparedAttacker[i].WriteAddDamage();

                    //计算总和
                    label_AttackerDamage[i, 2].Text = ComparedAttacker[i].WriteSumDamage();
                }
                else
                {
                    label_AttackerDamage[i, 0].Text = label_AttackerDamage[i, 1].Text = label_AttackerDamage[i, 2].Text = "";
                }
            }

        }

        private static DefendCharacter[] ComparedDefender = new DefendCharacter[DefenderChartHight];
        private static void CalcutateLeftHP()  //计算防御角色剩余血量
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
                        double[] stats = new double[5];
                        for (int j = 1; j <= 5; j++) { stats[j - 1] = textBox_DefenderStats[i, j].Text == "" ? 0 : double.Parse(textBox_DefenderStats[i, j].Text); }
                        ComparedDefender[i].SetStats(Convert.ToInt32(stats[0]), stats[1] / 100, stats[2] / 100, stats[3] / 100, stats[4] / 100);

                        //计算防御角色承受伤害
                        ComparedDefender[i].CheckBaseIncoming(ComparedAttacker[AttackerOrder]);
                        ComparedDefender[i].CheckAddIncoming(ComparedAttacker[AttackerOrder]);

                        //计算剩余血量
                        ComparedDefender[i].CheckMidHP();
                        ComparedDefender[i].CheckFinalHP();
                        label_DefenderHP[i, 0].Text = ComparedDefender[i].WriteMidHP();
                        label_DefenderHP[i, 1].Text = ComparedDefender[i].WriteFinalHP();
                    }
                }
            }
        }

        static void CalculateDamage()
        {
            CalcutateDamage();

            CalcutateLeftHP();
        }
    }
}