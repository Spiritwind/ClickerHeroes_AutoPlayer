using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerheroes.autoplayer
{
    public partial class TaskList : Form
    {
        public TaskList()
        {
            InitializeComponent();
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            string ret = PlayerEngine.ParseTasklist(Properties.Settings.Default.taskList);
            if (ret != null)
            {
                MessageBox.Show(string.Format("Error parsing task list: {0}", ret));
            }

            TaskBox.Text = Properties.Settings.Default.taskList;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string ret = PlayerEngine.ParseTasklist(TaskBox.Text);
            if (ret != null)
            {
                MessageBox.Show(string.Format("Error parsing task list: {0}", ret));
            }
            else
            {
                Properties.Settings.Default.taskList = TaskBox.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("Tasklist Saved!");
            }
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            TaskBox.Text = Properties.Settings.Default.taskList;
        }

        private void activeBtn_Click(object sender, EventArgs e)
        {
            calculateMostEfficientPath(true);
        }

        private void idleBtn_Click(object sender, EventArgs e)
        {
            calculateMostEfficientPath(false);
        }

        /// <summary>
        /// Will find the most cost efficient hero to level up at any given time.
        /// Assumes all upgrades except ASCENSION will be purchased as soon as possible.
        /// </summary>
        /// <param name="active"></param>
        private void calculateMostEfficientPath(bool active)
        {
            var result = new StringBuilder();
            result.AppendLine(active ? "Active" : "Idle");
            double prevTotal = 0;
            double clicksPerSecond = active ? 30 : 0;

            var heroes = new List<HeroStats>();
            foreach (var hero in GameEngine.HeroList)
            {
                heroes.Add(new HeroStats() { Hero = hero, Level = 0, UpgradeBitfield = 0 });
            }

            while (heroes.Any(h => h.Level < 4100))
            {
                int bestIndex = -1;
                double bestEfficiency = -1;
                double nextDamage = -1;
                double totalDamage = 0;
                double dpsDamage = 0;
                double clickDamage = 0;
                double criticalMultiplier = 0;
                double criticalChance = 0;
                double dpsToClick = 0;
            
                // Efficiency = (newDmg - totalDmg) / cost;
                for (int i = 0; i < heroes.Count; i++)
                {
                    if (heroes[i].Level == 4100) { continue; }
                    // Calculate damage if we level this hero
                    double cost = heroes[i].Hero.GetCostToLevel(heroes[i].Level + 1, heroes[i].Level);
                    heroes[i].Level++;
                    for (var j = 0; j < heroes[i].Hero.Upgrades.Length; j++)
                    {
                        if (heroes[i].Hero.Upgrades[j].Level <= heroes[i].Level && heroes[i].HasUpgrade(j) == 0)
                        {
                            cost += heroes[i].Hero.Upgrades[j].Cost;
                            heroes[i].UpgradeBitfield += (byte)(j == 0 ? 1 : 1 << j - 1);
                        }
                    }
                    dpsDamage = heroes.Skip(1).Sum(h => h.DPS);
                    clickDamage += heroes[0].DPS;

                    foreach (var hero in heroes)
                    {
                        dpsDamage *= hero.AllDpsMultiplier;
                        dpsToClick += hero.DpsToClick;
                        criticalChance += hero.CriticalChance;
                        criticalMultiplier += hero.CriticalMultiplierIncrease;
                    }

                    clickDamage = clickDamage * (1 + dpsToClick);
                    clickDamage = (1 - criticalChance) * clickDamage + (criticalChance * clickDamage * criticalMultiplier);
                    totalDamage = dpsDamage + clickDamage * clicksPerSecond;

                    var efficiency = (totalDamage - prevTotal) / cost;
                    if (efficiency > bestEfficiency)
                    {
                        bestEfficiency = efficiency;
                        bestIndex = i;
                        nextDamage = totalDamage;
                    }

                    heroes[i].Level--;
                    for (var j = 0; j < heroes[i].Hero.Upgrades.Length; j++)
                    {
                        if (heroes[i].Hero.Upgrades[j].Level > heroes[i].Level && heroes[i].HasUpgrade(j) == 1)
                        {
                            heroes[i].UpgradeBitfield -= (byte)(j == 0 ? 1 : 1 << j - 1);
                        }
                    }

                }
                if (bestIndex >= 0)
                {
                    heroes[bestIndex].Level++;
                    int maxUpgrade = -1;
                    for (var j = 0; j < heroes[bestIndex].Hero.Upgrades.Length; j++)
                    {
                        if (heroes[bestIndex].Hero.Upgrades[j].Level <= heroes[bestIndex].Level && heroes[bestIndex].HasUpgrade(j) == 0)
                        {
                            heroes[bestIndex].UpgradeBitfield += (byte)(j == 0 ? 1 : 1 << j - 1);
                            maxUpgrade = j;
                        }
                    }
                    result.AppendLine(string.Format("{0}, {1}, {2}", bestIndex, heroes[bestIndex].Level, maxUpgrade));
                    prevTotal = nextDamage;
                }
                else
                {
                    break;
                }

            }
            result.AppendLine("Ascend");
            TaskBox.Text = result.ToString();
        }

        private void costBtn_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            
            for (var idx = 0; idx < GameEngine.HeroList.Length; idx++)
            {
                var hero = GameEngine.HeroList[idx];
                result.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", idx, 1, hero.Upgrades.Count(u => u.Level <= 1), hero.GetCostToLevel(1, 0)));
                result.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", idx, 10, hero.Upgrades.Count(u => u.Level <= 10), hero.GetCostToLevel(10, 1)));
                result.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", idx, 25, hero.Upgrades.Count(u => u.Level <= 25), hero.GetCostToLevel(25, 10)));
                for (int lvl = 50; lvl <= 200; lvl = lvl + 25)
                {
                    result.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", idx, lvl, hero.Upgrades.Count(u => u.Level <= lvl), hero.GetCostToLevel(lvl, lvl - 25)));
                }
                for (int lvl = 300; lvl <= 4100; lvl = lvl + 100)
                {
                    result.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}", idx, lvl, hero.Upgrades.Count(u => u.Level <= lvl), hero.GetCostToLevel(lvl, lvl - 100)));
                }
            }

            result.AppendLine("");
            result.AppendLine("");
            result.AppendLine("19, 150, 3");
            result.AppendLine("Ascend");
            TaskBox.Text = result.ToString();
        }

    }
}
