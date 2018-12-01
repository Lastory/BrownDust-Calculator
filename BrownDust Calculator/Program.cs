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
            Application.Run(new Form_Main());

            //MyPrograme.Work();
        }
    }

    partial class Form_Main
    {
        private const string SaveVersion = "0.3.0";
        private const int LanguageCount = 3;
        private static int Language = 2;  //0 - 简体中文简称，1 - 繁体中文全称，2 - 英语，3 - 日语
        private static bool FlagInLanguageChang = false;
        private const int SupporterNumber = 8, AttackerNumber = 9;
        private const int AtkSupporterChartHight = 4, AttackerChartHight = 8, DefenderChartHight = 4;

        private static class Tools
        {
            public static int ToSlv(string str) { return int.Parse(str.Remove(0, 1)); }
            public static double ResultOf(string str)
            {
                double result = 0;

                string[] part = str.Split('+');
                for (int i = 0; i < part.Length; i++)
                {
                    string[] num = part[i].Split('*');

                    if (num.Length == 1) result += double.Parse(num[0]);
                    else
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            int last = num[j].IndexOf("%");
                            if (last != -1) num[j] = num[j].Remove(last);
                        }

                        result += double.Parse(num[0]) * double.Parse(num[1]) / 100;
                    }
                }

                return result;
            }
        }

        private static class Savefile  //存档相关
        {
            private const int SaveLanguage = 2;

            public static int SearchSupporter(string name)
            {
                for (int i = 0; i < SupporterNumber; i++) if (name == Supporter[i].GetName(SaveLanguage)) return i;
                return -1;
            }
            public static int SearchAttcker(string name)
            {
                for (int i = 0; i < AttackerNumber; i++) if (name == Attacker[i].GetName(SaveLanguage)) return i;
                return -1;
            }

            public static void LoadSavefile()  //读取（不存在则创建一个空的）存档
            {
                if (File.Exists("Save.save"))
                {
                    string line;

                    using (StreamReader file = new StreamReader("save.save"))
                    {
                        line = file.ReadLine();  //Ver=x.x.x
                        if (line.Remove(0, 4) != SaveVersion) return;  //判断存档兼容性

                        do
                        {
                            line = file.ReadLine();

                            if (line.Contains("Language=")) Language = int.Parse(line.Remove(0, 9));
                        }
                        while (line != "#Next");

                        while (line != "#End")
                        {
                            int minH;

                            switch (line)
                            {
                                case "#AtkSup":  //读取攻击支援角色面板
                                    minH = Math.Min(AtkSupporterChartHight, int.Parse(file.ReadLine()));
                                    for (int i = 0; i < minH; i++)
                                    {
                                        line = file.ReadLine();
                                        if (line != "-")
                                        {
                                            string[] load = line.Split('|');
                                            comboBox_AtkSupporterName[i].SelectedIndex = SearchSupporter(load[0]);
                                            comboBox_AtkSupporterSlv[i].SelectedIndex = int.Parse(load[1]);
                                            if (load[2] == "Y") checkBox_AtkSupporterChoose[i].Checked = true;
                                        }
                                    }
                                    break;
                                case "#Atk":  //读取攻击角色面板
                                    minH = Math.Min(AttackerChartHight, int.Parse(file.ReadLine()));
                                    for (int i = 0; i < minH; i++)
                                    {
                                        line = file.ReadLine();
                                        if (line != "-")
                                        {
                                            string[] load = line.Split('|');
                                            comboBox_AttackerName[i].SelectedIndex = SearchAttcker(load[0]);
                                            comboBox_AttackerSlv[i].SelectedIndex = int.Parse(load[1]);
                                            for (int j = 0; j < 5; j++) textBox_AttackerStats[i, j].Text = load[j + 2];
                                        }
                                    }
                                    break;
                                case "#Def"://读取防御角色面板
                                    minH = Math.Min(DefenderChartHight, int.Parse(file.ReadLine()));
                                    for (int i = 0; i < minH; i++)
                                    {
                                        line = file.ReadLine();
                                        if (line != "-")
                                        {
                                            string[] load = line.Split('|');
                                            for (int j = 0; j < 6; j++) textBox_DefenderStats[i, j].Text = load[j];
                                        }
                                    }
                                    break;
                            }

                            line = file.ReadLine();
                        }
                    }
                }
                else { File.Create("save.save"); }  //创建一个存档文件
            }
            public static void SaveSavefile()  //存储存档
            {
                using (StreamWriter file = new StreamWriter("save.save"))
                {
                    file.Write("Ver={0}\n", SaveVersion);
                    file.Write("Language={0:d}\n", Language);
                    file.Write("#Next\n");

                    //存储攻击支援角色面板
                    file.Write("#AtkSup\n{0:d}\n", AtkSupporterChartHight);
                    for (int i = 0; i < AtkSupporterChartHight; i++)
                    {
                        if (comboBox_AtkSupporterName[i].SelectedIndex != -1)
                        {
                            string line = Supporter[comboBox_AtkSupporterName[i].SelectedIndex].GetName(SaveLanguage) + "|";
                            line += comboBox_AtkSupporterSlv[i].SelectedIndex.ToString("d") + "|";
                            line += (checkBox_AtkSupporterChoose[i].Checked ? "Y" : "N") + "|";
                            file.Write(line + "\n");
                        }
                        else { file.Write("-\n"); }
                    }

                    //存储攻击角色面板
                    file.Write("#Atk\n{0:d}\n", AttackerChartHight);
                    for (int i = 0; i < AttackerChartHight; i++)
                    {
                        if (comboBox_AttackerName[i].SelectedIndex != -1 && comboBox_AttackerSlv[i].SelectedIndex != -1)
                        {
                            string line = Attacker[comboBox_AttackerName[i].SelectedIndex].GetName(SaveLanguage) + "|";
                            line += comboBox_AttackerSlv[i].SelectedIndex.ToString("d") + "|";
                            for (int j = 0; j < 5; j++) line += textBox_AttackerStats[i, j].Text + "|";
                            file.Write(line + "\n");
                        }
                        else { file.Write("-\n"); }
                    }

                    //存储防御角色面板
                    file.Write("#Def\n{0:d}\n", DefenderChartHight);
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

                    file.Write("#End", SaveVersion);
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
            public struct TypeSkill
            {
                public double ATKup, CRRup, CRDup, AGIup, DEFup, CUTup;
                public double All;
                public bool isImmunnity;

                public TypeSkill(double atk, double crr, double crd, double agi, double def, double cut, params string[] arr)
                {
                    ATKup = atk; CRRup = crr; CRDup = crd; AGIup = agi; DEFup = def; CUTup = cut;
                    All = 0;

                    isImmunnity = false;

                    if (arr.Length > 0)
                    {
                        for (int i = 0; i < arr.Length; i++) Set(arr[i]);
                    }
                }

                public TypeSkill ShallowCopy() { return (TypeSkill)this.MemberwiseClone(); }

                public static TypeSkill operator *(double support, TypeSkill a)
                {
                    TypeSkill result = a.ShallowCopy();
                    result.ATKup = result.ATKup * support + result.All;
                    result.CRRup = result.CRRup * support + result.All;
                    result.CRDup = result.CRDup * support + result.All;
                    result.AGIup = result.AGIup * support + result.All;
                    result.DEFup = result.DEFup * support + result.All;
                    result.CUTup = result.CUTup * support;
                    result.All = 0;
                    return result;
                }

                public void Set(string to)
                {
                    switch (to)
                    {
                        case "Immunnity": isImmunnity = true; break;
                    }
                }
                public void Set(string to, double rate)
                {
                    switch (to)
                    {
                        case "ATK": ATKup = rate; break;
                        case "CRR": CRRup = rate; break;
                        case "CRD": CRDup = rate; break;
                        case "AGI": AGIup = rate; break;
                        case "CUT": CUTup = rate; break;
                        case "ALL": All = rate; break;
                    }
                }

                public string Write(string option)  //option = {"ATK", "CRR", "CRD", "AGI", "CUT", "Immunnity"}，否则返回"Error"
                {
                    string result = "";

                    switch (option)
                    {
                        case "ATK": result = (ATKup * 100).ToString("f2") + "%"; break;
                        case "CRR": result = (CRRup * 100).ToString("f2") + "%"; break;
                        case "CRD": result = (CRDup * 100).ToString("f2") + "%"; break;
                        case "AGI": result = (AGIup * 100).ToString("f2") + "%"; break;
                        case "DEF": result = (DEFup * 100).ToString("f2") + "%"; break;
                        case "CUT": result = (CUTup * 100).ToString("f2") + "%"; break;
                        case "Immunnity": result = isImmunnity ? "Yes" : ""; break;
                        default: return "Error";
                    }

                    if (result == "0.00%") result = "";

                    return result;
                }
            }

            private string[] Name = new string[LanguageCount];
            private int SkillLevel;
            private double Support;
            public bool[] isSLvExist = new bool[11];
            private TypeSkill[] SkillList = new TypeSkill[11];
            public TypeSkill NowSkill = new TypeSkill();

            public SupportCharacter(double support, params string[] names)
            {
                Name = names;
                Support = support;
            }
            public SupportCharacter(char star, params string[] names)  //star = {'3', '4', '5', 'L'}
            {
                Name = names;
                switch (star)
                {
                    case '3': Support = 1.6496; break;
                    case '4': Support = 1.6986; break;
                    case '5': Support = 1.7481; break;
                    case 'L': Support = 1.7983; break;
                }
            }
            public SupportCharacter ShallowCopy() { return (SupportCharacter)this.MemberwiseClone(); }

            public string GetName() { return Name[Language]; }
            public string GetName(int language) { return Name[language]; }

            public void SetSkill(int level, double atk, double crr, double crd, double agi, double def, double cut, params string[] arr)
            {
                isSLvExist[level] = true;
                SkillList[level] = new TypeSkill(atk, crr, crd, agi, def, cut, arr);
            }
            public void SetSkill(int level, string to)
            {
                isSLvExist[level] = true;
                SkillList[level].Set(to);
            }
            public void SetSkill(int level, string to, double rate)
            {
                isSLvExist[level] = true;
                SkillList[level].Set(to, rate);
            }
            public void SkillCopy(int from, int to)
            {
                isSLvExist[to] = true;
                SkillList[to] = SkillList[from].ShallowCopy();
            }
            public void SkillExtend(int to) { SkillCopy(to - 1, to); }
            public void SetSkillLevel(int level)
            {
                SkillLevel = level;
                NowSkill = Support * SkillList[level];
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

                public TypeSkillDetail[] StartBuff = new TypeSkillDetail[5];  //依赖属性，增长属性，倍率
                public TypeSkillDetail[] AfterBuff = new TypeSkillDetail[5];  //增长属性，buff量
                public TypeSkillDetail AddAttackNormal, AddAttackReal;  //依赖属性，倍率
                public bool isAddRatio = false;  //追伤是否为血量比例伤害
                public bool isImmunnity = false;  //是否有免疫技能

                public TypeSkill ShallowCopy() { return (TypeSkill)this.MemberwiseClone(); }

                public void SetStartBuff(params TypeSkillDetail[] detail)
                {
                    nStatsBuff = detail.Length;
                    StartBuff = detail;
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
                public void Set(string to)
                {
                    switch (to)
                    {
                        case "Immunnity": isImmunnity = true; break;
                    }
                }
            }
            private struct TypeStats { public double ATK, DEF, CRR, CRD, AGI; }

            private string[] Name = new string[LanguageCount];
            private int SkillLevel;
            private TypeStats BaseStats, NowStats, StatsUp;
            public bool[] isSLvExist = new bool[11];
            public TypeSkill[] SkillList = new TypeSkill[11];
            public TypeSkill NowSkill = new TypeSkill();
            public TypeDamage BaseDamage, AddDamageNormal, AddDamageReal;

            public AttackCharacter(params string[] names)
            {
                Name = names;
                for (int i = 0; i <= 10; i++) SkillList[i] = new TypeSkill();
            }
            public AttackCharacter ShallowCopy() { return (AttackCharacter)this.MemberwiseClone(); }

            public void SetStats(double atk, double crr, double crd, double agi, double def, double atkbuff, double crrbuff, double crdbuff, double defbuff)  //计算攻击角色入场属性
            {
                BaseStats = new TypeStats { ATK = atk, CRR = crr, CRD = crd, AGI = agi, DEF = def };
                DoStatsUp();
                StatsUp.ATK += atkbuff; StatsUp.CRR += crrbuff; StatsUp.CRD += crdbuff; StatsUp.DEF += defbuff;
                CheckStats();
            }
            public void SetStartBuff(int level, params TypeSkill.TypeSkillDetail[] detail)
            {
                isSLvExist[level] = true;
                SkillList[level].SetStartBuff(detail);
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
            public void SkillCopy(int from, int to)
            {
                isSLvExist[to] = true;
                SkillList[to] = SkillList[from].ShallowCopy();
            }
            public void SkillExtend(int to) { SkillCopy(to - 1, to); }
            public void SetSkillLevel(int level)
            {
                SkillLevel = level;
                NowSkill = SkillList[level].ShallowCopy();
            }
            public void CheckImmunnity(bool isSupGive)
            {
                NowSkill.isImmunnity = isSupGive || SkillList[SkillLevel].isImmunnity;
            }

            public string GetName() { return Name[Language]; }
            public string GetName(int language) { return Name[language]; }

            private void DoStatsUp()
            {
                StatsUp.ATK = StatsUp.CRR = StatsUp.CRD = StatsUp.AGI = 0;

                for (int i = 0; i < NowSkill.nStatsBuff; i++)
                {
                    double buff = NowSkill.StartBuff[i].rate;
                    switch (NowSkill.StartBuff[i].from)
                    {
                        case "DEF": buff *= BaseStats.DEF; break;
                        case "CRR": buff *= BaseStats.CRR; break;
                        case "AGI": buff *= BaseStats.AGI; break;
                    }
                    switch (NowSkill.StartBuff[i].to)
                    {
                        case "ATK": StatsUp.ATK += buff; break;
                        case "CRR": StatsUp.CRR += buff; break;
                        case "CRD": StatsUp.CRD += buff; break;
                        case "AGI": StatsUp.AGI += buff; break;
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
            private TypeDamage GetAddDamage(TypeSkill.TypeSkillDetail data, bool isReal)
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
                    AddIncomingReal = 1 * attacker.AddDamageReal;
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
        
        private static SupportCharacter[] Supporter = new SupportCharacter[SupporterNumber];
        private static AttackCharacter[] Attacker = new AttackCharacter[AttackerNumber];
        private static void SetCharacters()  //设定角色基本数据
        {
            void SetSupporters()
            {
                SupportCharacter Now;
                Now = Supporter[0] = new SupportCharacter('3', "眼镜", "阿里內斯", "Arines", "アリネス");
                {
                    Now.SetSkill(9, 0.40, 0.05, 0, 0, 0, 0.15);
                    Now.SetSkill(10, 0.40, 0.05, 0, 0, 0, 0.20);
                }
                Now = Supporter[1] = new SupportCharacter('3', "弦月", "弦月", "Hyeon Wol", "弦月");
                {
                    Now.SetSkill(9, 0.15, 0.15, 0.36, 0, 0, 0);
                    Now.SetSkill(10, 0.20, 0.15, 0.36, 0, 0, 0);
                }
                Now = Supporter[2] = new SupportCharacter('5', "屁股", "貝羅尼亞", "Veronia", "ベロニア");
                {
                    Now.SetSkill(0, 0.30, 0, 0.30, 0, 0, 0);
                    Now.SetSkill(1, 0.35, 0, 0.30, 0, 0, 0);
                    Now.SetSkill(2, 0.40, 0, 0.30, 0, 0, 0);
                    Now.SetSkill(3, 0.40, 0, 0.30, 0, 0, 0, "Immunnity");
                    Now.SetSkill(4, 0.40, 0, 0.45, 0, 0, 0, "Immunnity");
                    Now.SetSkill(5, 0.40, 0, 0.60, 0, 0, 0, "Immunnity");
                    Now.SetSkill(6, 0.40, 0, 0.60, 0, 0, 0, "Immunnity");
                    Now.SetSkill(7, 0.50, 0, 0.60, 0, 0, 0, "Immunnity");
                    Now.SetSkill(8, 0.60, 0, 0.60, 0, 0, 0, "Immunnity");
                    Now.SetSkill(9, 0.60, 0.15, 0.60, 0, 0, 0, "Immunnity");
                    Now.SetSkill(10, 0.60, 0.20, 0.60, 0, 0, 0, "Immunnity");
                }
                Now = Supporter[3] = new SupportCharacter('5', "琴女", "梅里", "Mary", "メリー");
                {
                    Now.SetSkill(0, 0, 0.20, 0.30, 0, 0, 0);
                    Now.SetSkill(1, 0, 0.22, 0.30, 0, 0, 0);
                    Now.SetSkill(2, 0, 0.25, 0.30, 0, 0, 0);
                    Now.SetSkill(3, 0, 0.25, 0.30, 0, 0, 0.10);
                    Now.SetSkill(4, 0, 0.25, 0.30, 0, 0, 0.12);
                    Now.SetSkill(5, 0, 0.25, 0.30, 0, 0, 0.15);
                    Now.SetSkill(6, 0.10, 0.25, 0.30, 0, 0, 0.15);
                    Now.SetSkill(7, 0.10, 0.25, 0.35, 0, 0, 0.15);
                    Now.SetSkill(8, 0.10, 0.25, 0.40, 0, 0, 0.15);
                    Now.SetSkill(9, 0.10, 0.25, 0.30, 0, 0, 0.15);
                    Now.SetSkill(10, 0.30, 0.25, 0.30, 0, 0, 0.15);
                }
                Now = Supporter[4] = new SupportCharacter('5', "圣杯", "米歇爾", "Michaela", "ミカエラ");
                {
                    Now.SetSkill(0, 0.30, 0, 0, 0, 0, 0.30);
                    Now.SetSkill(1, 0.30, 0, 0, 0, 0, 0.30);
                    Now.SetSkill(2, 0.30, 0, 0, 0, 0, 0.30);
                    Now.SkillExtend(3);
                    Now.SetSkill(3, "ALL", 0.05);
                    Now.SkillExtend(4);
                    Now.SkillExtend(5);
                    Now.SkillExtend(6);
                    Now.SetSkill(6, "ALL", 0.10);
                    Now.SkillExtend(7);
                    Now.SetSkill(7, "ATK", 0.40);
                    Now.SkillExtend(8);
                    Now.SetSkill(8, "ATK", 0.50);
                    Now.SkillExtend(9);
                    Now.SkillExtend(10);
                }
                Now = Supporter[5] = new SupportCharacter('L', "萝莉", "芮彼泰雅", "Refithea", "レピテア");
                {
                    Now.SetSkill(0, 0.25, 0, 0, 0, 0, 0.15);
                    Now.SetSkill(1, 0.30, 0, 0, 0, 0, 0.15);
                    Now.SetSkill(2, 0.35, 0, 0, 0, 0, 0.15);
                    Now.SetSkill(3, 0.35, 0.10, 0, 0, 0, 0.15);
                    Now.SetSkill(4, 0.35, 0.15, 0, 0, 0, 0.15);
                    Now.SetSkill(5, 0.35, 0.20, 0, 0, 0, 0.15);
                    Now.SetSkill(6, 0.35, 0.20, 0, 0, 0, 0.15);
                    Now.SetSkill(7, 0.35, 0.20, 0, 0, 0, 0.15);
                    Now.SetSkill(8, 0.35, 0.20, 0, 0, 0, 0.15);
                    Now.SetSkill(9, 0.35, 0.20, 0, 0, 0, 0.15);
                    Now.SetSkill(10, 0.45, 0.25, 0, 0, 0, 0.25);
                }
                Now = Supporter[6] = new SupportCharacter('4', "灰毛", "埃保尼", "Ebony", "エボニー");
                {
                    Now.SetSkill(0, 0.10, 0, 0, 0, 0, 0, "Immunnity");
                    Now.SetSkill(1, 0.15, 0, 0, 0, 0, 0, "Immunnity");
                    Now.SetSkill(2, 0.20, 0, 0, 0, 0, 0, "Immunnity");
                    Now.SetSkill(3, 0.20, 0, 0.15, 0, 0, 0, "Immunnity");
                    Now.SetSkill(4, 0.20, 0, 0.20, 0, 0, 0, "Immunnity");
                    Now.SetSkill(5, 0.20, 0, 0.25, 0, 0, 0, "Immunnity");
                    Now.SetSkill(6, 0.20, 0.06, 0.25, 0, 0, 0, "Immunnity");
                    Now.SetSkill(7, 0.20, 0.09, 0.25, 0, 0, 0, "Immunnity");
                    Now.SetSkill(8, 0.20, 0.12, 0.25, 0, 0, 0, "Immunnity");
                    Now.SetSkill(9, 0.25, 0.12, 0.25, 0, 0, 0, "Immunnity");
                    Now.SetSkill(10, 0.25, 0.12, 0.25, 0, 0, 0, "Immunnity");
                }
                Now = Supporter[7] = new SupportCharacter('5', "歌姬", "海倫娜", "Helena", "ヘレナ");
                {
                    Now.SetSkill(0, 0, 0, 0, 0, 0, 0.10);
                    Now.SetSkill(1, 0, 0, 0, 0, 0, 0.15);
                    Now.SetSkill(2, 0, 0, 0, 0, 0, 0.20);
                    Now.SetSkill(3, 0.20, 0, 0, 0, 0, 0.20);
                    Now.SetSkill(4, 0.25, 0, 0, 0, 0, 0.20);
                    Now.SetSkill(5, 0.30, 0, 0, 0, 0, 0.20);
                    Now.SetSkill(6, 0.30, 0.05, 0, 0, 0, 0.20);
                    Now.SetSkill(7, 0.30, 0.10, 0, 0, 0, 0.20);
                    Now.SetSkill(8, 0.30, 0.15, 0, 0, 0, 0.20);
                    Now.SetSkill(9, 0.30, 0.15, 0, 0, 0, 0.20);
                    Now.SetSkill(10, 0.30, 0.15, 0, 0, 0, 0.25);
                }

            }
            void SetAttackers()
            {
                AttackCharacter Now;

                Now = Attacker[0] = new AttackCharacter("修女", "安潔利卡", "Angelica", "アンジェリカ");
                {
                    Now.SetAddAttackNormal(3, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "EHP", rate = 0.20 });
                    Now.SkillList[3].Set("Immunnity");
                    Now.SkillExtend(4);
                    Now.SetAddAttackNormal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "EHP", rate = 0.25 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackNormal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "EHP", rate = 0.30 });
                    Now.SkillExtend(6);
                    Now.SkillExtend(7);
                    Now.SetAddAttackNormal(7, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "EHP", rate = 0.35 });
                    Now.SkillExtend(8);
                    Now.SetAddAttackNormal(8, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "EHP", rate = 0.40 });
                    Now.SkillExtend(9);
                }
                Now = Attacker[1] = new AttackCharacter("海盗", "艾瑞克", "Alec", "アレック");
                {
                    Now.SetStartBuff(0, new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.50 });
                    Now.SetAddAttackReal(0, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.00 });
                    Now.SkillExtend(1);
                    Now.SetAddAttackReal(1, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.15 });
                    Now.SkillExtend(2);
                    Now.SetAddAttackReal(2, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.30 });
                    Now.SkillExtend(3);
                    Now.SetAddAttackNormal(3, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.00 });
                    Now.SkillExtend(4);
                    Now.SetAddAttackReal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.45 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackReal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.60 });
                    Now.SkillExtend(6);
                    Now.SkillExtend(7);
                    Now.SetStartBuff(7, new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.60 });
                    Now.SkillExtend(8);
                    Now.SetStartBuff(8, new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.70 });
                    Now.SkillExtend(9);
                    Now.SkillExtend(10);
                    Now.SetAddAttackNormal(10, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.50 });
                }
                Now = Attacker[2] = new AttackCharacter("女忍", "銀浪", "Eunrang", "ウンラン");
                {
                    Now.SetStartBuff(9,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "AGI", to = "CRR", rate = 1.00 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", to = "CRD", rate = 0.50 });
                    Now.SetAfterBuff(9,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRD", rate = 1.50 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.35 });
                    Now.SetAddAttackNormal(9, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "CRR", rate = 1.25 });
                }
                Now = Attacker[3] = new AttackCharacter("白剑", "西格蒙德", "Siegmund", "シグムンド");  //简化了血量依存追伤 - 血量总是100%
                {
                    Now.SetAddAttackNormal(3, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.50 });
                    Now.SkillExtend(4);
                    Now.SetAddAttackNormal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 3.00 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackNormal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 3.50 });
                    Now.SkillExtend(6);
                    Now.SetStartBuff(6, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.00 });
                    Now.SkillExtend(7);
                    Now.SetStartBuff(7, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.25 });
                    Now.SkillExtend(8);
                    Now.SetStartBuff(8, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.50 });
                    Now.SkillExtend(9);
                    Now.SetStartBuff(9,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.50 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "CRR", rate = 0.50 });
                }
                Now = Attacker[4] = new AttackCharacter("狐狸", "達非", "Dalvi", "キュウビ");
                {
                    Now.SetAddAttackNormal(0, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.00 });
                    Now.SetAddAttackNormal(1, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.25 });
                    Now.SetAddAttackNormal(2, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.50 });
                    Now.SkillExtend(3);
                    Now.SkillExtend(4);
                    Now.SkillExtend(5);
                    Now.SkillExtend(6);
                    Now.SetAddAttackNormal(7, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 1.75 });
                    Now.SetAddAttackNormal(8, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.00 });
                    Now.SkillExtend(9);
                    Now.SkillExtend(10);
                }
                Now = Attacker[5] = new AttackCharacter("黑剑", "艾丁", "Edin", "エディン");  //忽略了每回合buff
                {
                    Now.SetAddAttackNormal(0, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.50 * 0.35 });
                    Now.SkillExtend(1);
                    Now.SkillExtend(2);
                    Now.SkillExtend(3);
                    Now.SetStartBuff(3, new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.50 });
                    Now.SkillExtend(4);
                    Now.SetAddAttackNormal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 3.00 * 0.35 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackNormal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 3.50 * 0.35 });
                    Now.SkillExtend(6);
                    Now.SetStartBuff(6,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.50 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRR", rate = 0.15 });
                    Now.SkillExtend(7);
                    Now.SetStartBuff(7,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.65 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRR", rate = 0.20 });
                    Now.SkillExtend(8);
                    Now.SetStartBuff(8,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 0.80 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRR", rate = 0.25 });
                    Now.SkillExtend(9);
                    Now.SetStartBuff(9,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "ATK", rate = 1.00 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRR", rate = 0.35 });
                    Now.SkillExtend(10);
                }
                Now = Attacker[6] = new AttackCharacter("妖刀", "班塔納", "Ventana", "ヴェンタナ");  //忽略了对挑衅追伤，攻击侧所以忽略了护盾增加
                {
                    Now.SetStartBuff(0, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "AGI", to = "ATK", rate = 1.00 });
                    Now.SkillExtend(1);
                    Now.SkillExtend(2);
                    Now.SkillExtend(3);
                    Now.SetAddAttackNormal(3, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "CRR", rate = 0.50 });
                    Now.SkillExtend(4);
                    Now.SetAddAttackNormal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "CRR", rate = 0.75 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackNormal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "CRR", rate = 1.00 });
                    Now.SkillExtend(6);
                    Now.SkillExtend(7);
                    Now.SetStartBuff(7, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "AGI", to = "ATK", rate = 1.10 });
                    Now.SkillExtend(8);
                    Now.SetStartBuff(8, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "AGI", to = "ATK", rate = 1.25 });
                    Now.SkillExtend(9);
                    Now.SkillExtend(10);
                    Now.SetStartBuff(10, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "AGI", to = "ATK", rate = 1.75 });
                }
                Now = Attacker[7] = new AttackCharacter("锤妹", "阿爾彩", "Alche", "アーチェ");  //忽略了解除护盾，简化了对防御追伤 - 总是触发
                {
                    Now.SetAfterBuff(9, new AttackCharacter.TypeSkill.TypeSkillDetail { to = "CRD", rate = 1.50 });
                    Now.SetAddAttackNormal(9, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.50 });
                    Now.SkillExtend(10);
                    Now.SetAddAttackNormal(10, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "   ", rate = 2.75 });
                }
                Now = Attacker[8] = new AttackCharacter("机械盾", "拉菲娜", "Rafina", "ラフィーナ");  //忽略了解除护盾
                {
                    Now.SetAddAttackNormal(0, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", rate = 1.50 });
                    Now.SetAddAttackNormal(1, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", rate = 1.75 });
                    Now.SetAddAttackNormal(2, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", rate = 2.00 });
                    Now.SkillExtend(3);
                    Now.SetStartBuff(3, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.00 });
                    Now.SkillExtend(4);
                    Now.SetAddAttackNormal(4, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", rate = 2.25 });
                    Now.SkillExtend(5);
                    Now.SetAddAttackNormal(5, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", rate = 2.50 });
                    Now.SkillExtend(6);
                    Now.SkillExtend(7);
                    Now.SetStartBuff(7, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.25 });
                    Now.SkillExtend(7);
                    Now.SetStartBuff(8, new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.50 });
                    Now.SkillExtend(9);
                    Now.SetStartBuff(9,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.50 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "CRR", rate = 0.50 });
                    Now.SkillExtend(10);
                    Now.SetStartBuff(10,
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "ATK", rate = 1.50 },
                        new AttackCharacter.TypeSkill.TypeSkillDetail { from = "DEF", to = "CRR", rate = 0.75 });
                }
            }

            SetSupporters();
            SetAttackers();
        }

        //定义UI控件
        private static ComboBox[] comboBox_AtkSupporterName = new ComboBox[AtkSupporterChartHight];
        private static ComboBox[] comboBox_AtkSupporterSlv = new ComboBox[AtkSupporterChartHight];
        private static Label[,] label_AtkSupporterBuff = new Label[AtkSupporterChartHight, 5];  //ATKup, CRRip, CRDup, DEFup, Immune
        private static CheckBox[] checkBox_AtkSupporterChoose = new CheckBox[AtkSupporterChartHight];

        private static ComboBox[] comboBox_AttackerName = new ComboBox[AttackerChartHight];
        private static ComboBox[] comboBox_AttackerSlv = new ComboBox[AttackerChartHight];
        private static TextBox[,] textBox_AttackerStats = new TextBox[AttackerChartHight, 5];  //ATK, CRR, CRD, AGI, DEF
        private static Label[,] label_AttackerDamage = new Label[AttackerChartHight, 3];  //Normal, Add, Sum
        private static RadioButton[] radioButton_AttackerChoose = new RadioButton[AttackerChartHight];

        private static TextBox[,] textBox_DefenderStats = new TextBox[DefenderChartHight, 6];  //Name, HP, DEF, AGI, DEF, Weaking
        private static Label[,] label_DefenderHP = new Label[DefenderChartHight, 2];  //Normal, Add, Sum

        private static class RefreshData
        {
            public class TpyeRefresher_AttackerSlv
            {
                int order;

                public TpyeRefresher_AttackerSlv(int order) { this.order = order; }

                public void Refresh(object sender, EventArgs e)
                {
                    if (!FlagInLanguageChang)
                    {
                        comboBox_AttackerSlv[order].Items.Clear();
                        comboBox_AttackerSlv[order].Text = "";

                        int AttackerID = comboBox_AttackerName[order].SelectedIndex;
                        if (AttackerID != -1)
                        {
                            for (int j = 0; j <= 10; j++)
                            {
                                if (Attacker[AttackerID].isSLvExist[j])
                                    comboBox_AttackerSlv[order].Items.Add("+" + j.ToString("d"));
                            }
                        }
                    }
                }
            }
            public static TpyeRefresher_AttackerSlv[] Refresher_AttackerSlv = new TpyeRefresher_AttackerSlv[AttackerChartHight];

            public class TpyeRefresher_AtkSupporterSlv
            {
                int order;

                public TpyeRefresher_AtkSupporterSlv(int order) { this.order = order; }

                public void Refresh(object sender, EventArgs e)
                {
                    if (!FlagInLanguageChang)
                    {
                        comboBox_AtkSupporterSlv[order].Items.Clear();
                        comboBox_AtkSupporterSlv[order].Text = "";

                        int AtkSupporterID = comboBox_AtkSupporterName[order].SelectedIndex;
                        if (AtkSupporterID != -1)
                        {
                            for (int j = 0; j <= 10; j++)
                            {
                                if (Supporter[AtkSupporterID].isSLvExist[j])
                                    comboBox_AtkSupporterSlv[order].Items.Add("+" + j.ToString("d"));
                            }
                        }
                        
                        label_AtkSupporterBuff[order, 0].Text = label_AtkSupporterBuff[order, 1].Text = label_AtkSupporterBuff[order, 2].Text = label_AtkSupporterBuff[order, 3].Text = "";
                    }
                }
            }
            public static TpyeRefresher_AtkSupporterSlv[] Refresher_AtkSupporterSlv = new TpyeRefresher_AtkSupporterSlv[AtkSupporterChartHight];

            public class TypeRefrsher_AtkSupportBuff
            {
                int order;

                public TypeRefrsher_AtkSupportBuff(int order) { this.order = order; }

                public void Refresh(object sender, EventArgs e)  //同时计算了ComparedAtkSupporter
                {
                    if (!FlagInLanguageChang)
                    {
                        int AtkSupporterID = comboBox_AtkSupporterName[order].SelectedIndex;

                        if (AtkSupporterID != -1 && comboBox_AtkSupporterSlv[order].SelectedIndex != -1)
                        {
                            int Slv = Tools.ToSlv((string)comboBox_AtkSupporterSlv[order].SelectedItem);
                            ComparedAtkSupporter[order] = Supporter[AtkSupporterID].ShallowCopy();
                            ComparedAtkSupporter[order].SetSkillLevel(Slv);

                            label_AtkSupporterBuff[order, 0].Text = ComparedAtkSupporter[order].NowSkill.Write("ATK");
                            label_AtkSupporterBuff[order, 1].Text = ComparedAtkSupporter[order].NowSkill.Write("CRR");
                            label_AtkSupporterBuff[order, 2].Text = ComparedAtkSupporter[order].NowSkill.Write("CRD");
                            label_AtkSupporterBuff[order, 3].Text = ComparedAtkSupporter[order].NowSkill.Write("DEF");
                            label_AtkSupporterBuff[order, 4].Text = ComparedAtkSupporter[order].NowSkill.Write("Immunnity");
                        }
                    }
                }
            }
            public static TypeRefrsher_AtkSupportBuff[] Refrsher_AtkSupportBuff = new TypeRefrsher_AtkSupportBuff[AtkSupporterChartHight];
        }

        public void DrawAtkSupporterData()  //绘制攻击支援角色数据板块
        {
            object[] NameList = new object[SupporterNumber];
            for (int i = 0; i < SupporterNumber; i++) NameList[i] = Supporter[i].GetName();

            for (int i = 0; i < AtkSupporterChartHight; i++)
            {
                comboBox_AtkSupporterName[i] = new ComboBox();
                tableLayoutPanel_AtkSupporters.Controls.Add(comboBox_AtkSupporterName[i], 0, i + 1);
                comboBox_AtkSupporterName[i].Anchor = AnchorStyles.None;
                comboBox_AtkSupporterName[i].Items.AddRange(NameList);

                //角色下拉选框更改事件 - 刷新技能等级下拉选框
                RefreshData.Refresher_AtkSupporterSlv[i] = new RefreshData.TpyeRefresher_AtkSupporterSlv(i);
                comboBox_AtkSupporterName[i].SelectedIndexChanged += new EventHandler(RefreshData.Refresher_AtkSupporterSlv[i].Refresh);

                comboBox_AtkSupporterSlv[i] = new ComboBox();
                tableLayoutPanel_AtkSupporters.Controls.Add(comboBox_AtkSupporterSlv[i], 1, i + 1);
                comboBox_AtkSupporterSlv[i].Anchor = AnchorStyles.None;

                //技能等级下拉选框更改事件 - 刷新技能显示
                RefreshData.Refrsher_AtkSupportBuff[i] = new RefreshData.TypeRefrsher_AtkSupportBuff(i);
                comboBox_AtkSupporterSlv[i].SelectedIndexChanged += new EventHandler(RefreshData.Refrsher_AtkSupportBuff[i].Refresh);

                for (int j = 0; j < 5; j++)
                {
                    label_AtkSupporterBuff[i, j] = new Label();
                    tableLayoutPanel_AtkSupporters.Controls.Add(label_AtkSupporterBuff[i, j], j + 2, i + 1);
                    label_AtkSupporterBuff[i, j].Anchor = AnchorStyles.None;
                    label_AtkSupporterBuff[i, j].AutoSize = true;
                }

                checkBox_AtkSupporterChoose[i] = new CheckBox();
                tableLayoutPanel_AtkSupporters.Controls.Add(checkBox_AtkSupporterChoose[i], 7, i + 1);
                checkBox_AtkSupporterChoose[i].Anchor = AnchorStyles.None;
                checkBox_AtkSupporterChoose[i].AutoSize = true;
            }
        }
        public void DrawAttackerPanel()  //绘制攻击角色数据板块
        {
            object[] NameList = new object[AttackerNumber];
            for (int i = 0; i < AttackerNumber; i++) NameList[i] = Attacker[i].GetName();

            for (int i = 0; i < AttackerChartHight; i++)
            {
                comboBox_AttackerName[i] = new ComboBox();
                tableLayoutPanel_Attacker.Controls.Add(comboBox_AttackerName[i], 0, i + 1);
                comboBox_AttackerName[i].Anchor = AnchorStyles.None;
                comboBox_AttackerName[i].Items.AddRange(NameList);

                //角色下拉选框更改事件 - 刷新技能等级下拉选框
                RefreshData.Refresher_AttackerSlv[i] = new RefreshData.TpyeRefresher_AttackerSlv(i);
                comboBox_AttackerName[i].SelectedIndexChanged += new EventHandler(RefreshData.Refresher_AttackerSlv[i].Refresh);

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
        public void DrawDeffenderPanel()  //绘制防御角色数据板块
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

        private void UILanguageChange()  //切换语言
        {
            FlagInLanguageChang = true;

            string GetText(params string[] list) { return list[Language]; }

            object[] NameList;

            //重绘固定UI文本
            tabPage1.Text = GetText("主界面", "主界面", "Main", "メイン");
            //tabPage2.Text = GetText("设定(开发中)", "設定(開發中)", "Setting (Work in Progress)", "設定(開発中)");
            groupBox_AtkSupporters.Text = GetText("攻击侧支援角色", "攻擊側支援角色", "Attack Supporters", "攻撃側支援役");
            groupBox_Attackers.Text = GetText("攻击角色", "攻擊角色", "Attackers", "攻撃役");
            groupBox_Defenders.Text = GetText("被击角色", "被擊角色", "Defenders", "防御役");
            label_SupName.Text = label_AtkName.Text = label_DefName.Text = GetText("角色", "角色", "Character", "キャラ");
            label_SupSkill.Text = label_AtkSkill.Text = GetText("技能", "技能", "Skill", "ｽｷﾙ");
            label_SupATK.Text = GetText("攻击up", "攻擊up", "ATKup", "攻撃up");
            label_SupCRR.Text = GetText("暴率up", "爆率up", "CRRup", "ｸﾘ率up");
            label_SupCRD.Text = GetText("暴伤up", "暴傷up", "CRDup", "ｸﾘﾀﾞﾒup");
            label_SupDEF.Text = GetText("防御up", "防禦up", "DEFup", "防御up");
            label_SupImmune.Text = GetText("免疫", "免疫", "Immune", "免疫");
            label_AtkATK.Text = GetText("攻击", "攻擊", "ATK", "攻撃");
            label_AtkCRR.Text = GetText("暴率 (%)", "爆率 (%)", "CRIR (%)", "ｸﾘ率 (%)");
            label_AtkCRD.Text = GetText("暴伤 (%)", "暴傷 (%)", "CRID (%)", "ｸﾘﾀﾞﾒ (%)");
            label_AtkAGI.Text = label_DefAGI.Text = GetText("敏捷 (%)", "敏捷 (%)", "AGI (%)", "敏捷 (%)");
            label_AtkDEF.Text = label_DefDEF.Text = GetText("防御 (%)", "防禦 (%)", "DEF (%)", "防御 (%)");
            label_DefBarrier.Text = GetText("防护罩 (%)", "防護罩 (%)", "Barrier (%)", "バリア (%)");
            label_DefWeaking.Text = GetText("诅咒 (%)", "詛咒 (%)", "Weakening (%)", "呪い (%)");
            label_SupSelect.Text = label_AtkSelect.Text = GetText("选中", "选中", "Select", "選択");
            label_AtkNormalDmg.Text = GetText("普攻伤害", "普攻傷害", "Normal Damage", "基本ダメージ");
            label_AtkAddDmg.Text = GetText("追伤伤害", "追傷傷害", "Additional Damage", "追加ダメージ");
            label_AtkSumDmg.Text = GetText("总计伤害", "總計傷害", "Damage in Total", "合計ダメージ");
            label_DefNormalRemaining.Text = GetText("普攻后剩余HP", "普攻后剩餘HP", "HP After Normal Attack", "基本攻撃の後のHP");
            label_DefAddReamaining.Text = GetText("追伤后剩余HP", "追傷后剩餘HP", "HP After Additonal Attack", "追加攻撃の後のHP");
            button_Calculate.Text = GetText("计算", "計算", "Calculate!", "計算する");
            button_Save.Text = GetText("保存", "保存", "Save", "保存する");
            linkLabel_Homepage.Text = GetText("项目主页", "項目主頁", "Project Homepage", "ホームページ");

            //重绘攻击支援角色面板
            NameList = new object[SupporterNumber];
            for (int i = 0; i < SupporterNumber; i++) NameList[i] = Supporter[i].GetName();

            for (int i = 0; i < AtkSupporterChartHight; i++)
            {
                int ID = comboBox_AtkSupporterName[i].SelectedIndex;
                comboBox_AtkSupporterName[i].Items.Clear();
                comboBox_AtkSupporterName[i].Items.AddRange(NameList);
                if (ID != -1) comboBox_AtkSupporterName[i].Text = Supporter[ID].GetName();
            }

            //重绘攻击角色面板
            NameList = new object[AttackerNumber];
            for (int i = 0; i < AttackerNumber; i++) NameList[i] = Attacker[i].GetName();
            for (int i = 0; i < AttackerChartHight; i++)
            {
                int ID = comboBox_AttackerName[i].SelectedIndex;
                comboBox_AttackerName[i].Items.Clear();
                comboBox_AttackerName[i].Items.AddRange(NameList);
                if (ID != -1) comboBox_AttackerName[i].Text = Attacker[ID].GetName();
            }

            FlagInLanguageChang = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCharacters();

            DrawAtkSupporterData();
            DrawAttackerPanel();
            DrawDeffenderPanel();

            Savefile.LoadSavefile();
            comboBox_Language.SelectedIndex = Language;
            UILanguageChange();
        }

        private static SupportCharacter[] ComparedAtkSupporter = new SupportCharacter[AtkSupporterChartHight];
        private static AttackCharacter[] ComparedAttacker = new AttackCharacter[AttackerChartHight];
        private static void CalcutateDamage()  //计算支援&攻击角色出手前数据 + 计算普攻
        {
            //计算选中的支援角色提供的buff量
            
            double ATKbuff = 0, CRRbuff = 0, CRDbuff = 0, DEFbuff = 0;
            bool Immunnity = false;
            
            for (int i = 0; i < AtkSupporterChartHight; i++)
            {
                if (checkBox_AtkSupporterChoose[i].Checked && comboBox_AtkSupporterName[i].SelectedIndex != -1)
                {
                    ATKbuff += ComparedAtkSupporter[i].NowSkill.ATKup;
                    CRRbuff += ComparedAtkSupporter[i].NowSkill.CRRup;
                    CRDbuff += ComparedAtkSupporter[i].NowSkill.CRDup;
                    DEFbuff += ComparedAtkSupporter[i].NowSkill.DEFup;
                    Immunnity |= ComparedAtkSupporter[i].NowSkill.isImmunnity;
                }
            }
            
            for (int i = 0; i < AttackerChartHight; i++)
            {
                int ID = comboBox_AttackerName[i].SelectedIndex;
                if (ID != -1 && comboBox_AttackerSlv[i].SelectedIndex != -1)
                {
                    //计算攻击角色入场状态 + 为攻击角色套用支援buff
                    int Slv = Tools.ToSlv((string)comboBox_AttackerSlv[i].SelectedItem);
                    ComparedAttacker[i] = Attacker[ID].ShallowCopy();
                    ComparedAttacker[i].SetSkillLevel(Slv);

                    double[] stats = new double[5];
                    for (int j = 0; j < 5; j++) stats[j] = textBox_AttackerStats[i, j].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, j].Text);
                    ComparedAttacker[i].SetStats(stats[0], stats[1] / 100, stats[2] / 100, stats[3] / 100, stats[4] / 100, ATKbuff, CRRbuff, CRDbuff, DEFbuff);
                    ComparedAttacker[i].CheckImmunnity(Immunnity);

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
                        for (int j = 1; j <= 5; j++)
                        {
                            if (j != 4)  //Barrier
                                stats[j - 1] = textBox_DefenderStats[i, j].Text == "" ? 0 : double.Parse(textBox_DefenderStats[i, j].Text);
                        }
                        ComparedDefender[i].SetStats(Convert.ToInt32(stats[0]), stats[1] / 100, stats[2] / 100, Tools.ResultOf(textBox_DefenderStats[i, 4].Text) / 100, stats[4] / 100);

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