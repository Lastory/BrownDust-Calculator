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
        private class TpyeSavefile
        {
            public void LoadSavefile()
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

                            }
                        }
                    }
                }
                else { File.Create("save.save"); }  //创建一个存档文件
            }

            public void SaveSavefile()
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
        private TpyeSavefile Savefile = new TpyeSavefile();

        private static class Work
        {

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
                public uint nStatsUp = 0;
                public uint nBuffSkill = 0;
                public uint nAddDamage = 0;
                //{0-基础，1-攻击，2-防御，3-暴率，4-暴伤，5-敏捷}
                public struct TypeSkillDetail
                {
                    public string from, to;
                    public double rate;
                }

                public TypeSkillDetail[] StatusUp = new TypeSkillDetail[5];//依赖属性，增长属性，倍率
                public TypeSkillDetail[] BuffSkill = new TypeSkillDetail[5];//增长属性，buff量
                public TypeSkillDetail[] AddDamage = new TypeSkillDetail[5];//依赖属性，倍率

                public void SetStatusUp(uint n, TypeSkillDetail[] arr)
                {
                    nStatsUp = n;
                    StatusUp = arr;
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
            private TypeStats BaseStats, NowSatas, StatsUp;
            private TypeDamage BaseDamage;

            public AttackCharacter(string name)
            {
                Name = name;
            }

            private void DoStatsUp()
            {
                for (int i = 0; i < Skills.nStatsUp; i++)
                {
                    double buff = Skills.StatusUp[i].rate;
                    switch (Skills.StatusUp[i].from)
                    {
                        case "DEF": buff *= BaseStats.DEF; break;
                        case "CRR": buff *= BaseStats.CRR; break;
                        case "AGI": buff *= BaseStats.AGI; break;
                    }
                    switch (Skills.StatusUp[i].to)
                    {
                        case "ATK": BaseStats.ATK *= 1 + buff; break;
                        case "CRR": BaseStats.CRR += buff; break;
                        case "CRD": BaseStats.CRD += buff; break;
                    }
                }
            }

            private void CheckStats()
            {
                NowSatas.ATK = BaseStats.ATK * (1 + StatsUp.ATK);
                NowSatas.CRR = Math.Max(0, Math.Min(1, BaseStats.CRR + StatsUp.CRR));
                NowSatas.CRD = Math.Max(0, BaseStats.CRD + StatsUp.CRD);
                NowSatas.AGI = Math.Max(0, Math.Min(1, BaseStats.AGI + StatsUp.AGI));
                NowSatas.DEF = Math.Max(0, Math.Min(1, BaseStats.DEF + StatsUp.DEF));
            }

            public void SetStats(double atk, double crr, double crd, double agi, double def, double atkbuff, double crrbuff, double crdbuff)
            {
                BaseStats.ATK = atk; BaseStats.CRR = crr; BaseStats.CRD = crd; BaseStats.AGI = agi; BaseStats.DEF = def;
                DoStatsUp();
                StatsUp.ATK = atkbuff; StatsUp.CRR = crrbuff; StatsUp.CRD = crrbuff;

                CheckStats();
            }

            private void CheckBaseDamage()
            {
                BaseDamage.normal = NowSatas.ATK;
                BaseDamage.critical = NowSatas.ATK * (1 + NowSatas.CRD);
                BaseDamage.expected = NowSatas.ATK * (1 + NowSatas.CRR * NowSatas.CRD);
                BaseDamage.crrPer = NowSatas.CRR * 100;
            }

            public string GetBaseDamage()
            {
                CheckBaseDamage();
                string result = "";
                result += BaseDamage.normal.ToString("f0") + " " + (100 - BaseDamage.crrPer).ToString("f0") + "% | ";
                result += BaseDamage.critical.ToString("f0") + " " + BaseDamage.crrPer.ToString("f0") + "%";
                result += "\n" + BaseDamage.expected.ToString("f0");
                return result;
            }
        }

        static int SupporterNumber = 4;
        static int AttackerNumber = 1;
        static int AttackerChartHight = 8;

        private SupportCharacter[] Supporter = new SupportCharacter[SupporterNumber];
        private AttackCharacter[] Attacker = new AttackCharacter[AttackerNumber];
        private void SetCharacters()  //设定角色基本数据
        {
            Supporter[0] = new SupportCharacter("眼镜", 1.6496, 0.40, 0.05, 0.00, 0, 0);
            Supporter[1] = new SupportCharacter("弦月", 1.5118, 0.15, 0.15, 0.36, 0, 0);
            Supporter[2] = new SupportCharacter("屁股", 1.7481, 0.30, 0.00, 0.30, 0, 0);
            Supporter[3] = new SupportCharacter("琴女", 1.7481, 0.00, 0.20, 0.00, 0, 0);

            {
                Attacker[0] = new AttackCharacter("女忍");
                Attacker[0].Skills.SetStatusUp(2, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "AGI", to = "CRR", rate = 1.00 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = ""   , to = "CRD", rate = 0.50 } });
                Attacker[0].Skills.SetBuffSkill(2, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "CRD", rate =1.50 },
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { to = "ATK", rate =0.35 } });
                Attacker[0].Skills.SetAddDamage(1, new AttackCharacter.TypeSkill.TypeSkillDetail[] {
                    new AttackCharacter.TypeSkill.TypeSkillDetail() { from = "CRR", rate = 1.25 } });
            }
        }

        private Label[,] label_SupporterData = new Label[SupporterNumber, 4];
        private CheckBox[] checkBox_SupporterChoose = new CheckBox[SupporterNumber];
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

        private ComboBox[] comboBox_AttackerName = new ComboBox[AttackerChartHight];
        private TextBox[,] textBox_AttackerStats = new TextBox[AttackerChartHight, 5];  //ATK, CRR, CRD, AGI, DEF
        private Label[,] label_AttackDamage = new Label[AttackerChartHight, 3];  //Normal, Add, Sum
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
            Savefile.LoadSavefile();  //读取（不存在则创建）存档，并以此进行第一次计算
            SetCharacters();  //设定角色基本数据
            DrawSupporterData();  //绘制支援角色数据
            DrawAttackerPanel();  //绘制攻击角色数据板块
        }

        private AttackCharacter[] ComparedAttacker = new AttackCharacter[AttackerChartHight];
        private void CalculateStatus()
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

            //计算攻击角色入场状态 + 为攻击角色套用支援buff
            for (int i = 0; i < AttackerChartHight; i++)
            {
                int order = comboBox_AttackerName[i].SelectedIndex;
                if (order >= 0)
                {
                    ComparedAttacker[i] = new AttackCharacter(Attacker[order].Name);
                    ComparedAttacker[i].Skills = Attacker[order].Skills;
                    ComparedAttacker[i].SetStats(
                        textBox_AttackerStats[i, 0].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 0].Text),
                        textBox_AttackerStats[i, 1].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 1].Text) / 100,
                        textBox_AttackerStats[i, 2].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 2].Text) / 100,
                        textBox_AttackerStats[i, 3].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 3].Text) / 100,
                        textBox_AttackerStats[i, 4].Text == "" ? 0 : double.Parse(textBox_AttackerStats[i, 4].Text) / 100,
                        ATKbuff, CRRbuff, CRDbuff);
                }
            }
        }

        void Calculate()
        {
            CalculateStatus();

            //输出普伤
            for (int i = 0; i < AttackerChartHight; i++)
            {
                if (comboBox_AttackerName[i].SelectedIndex >= 0)
                {
                    label_AttackDamage[i, 0].Text = ComparedAttacker[i].GetBaseDamage();
                }
            }
        }
    }
}
