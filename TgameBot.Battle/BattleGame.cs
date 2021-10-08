using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgameBot.Battle.Models;

namespace TgameBot.Battle
{
    public class BattleGame
    {
        private StringBuilder battleResult = new StringBuilder();

        public List<Warrior> CreateWarriors(String[] names)
        {
            Random random = new Random();
            List<Warrior> warriors = new List<Warrior>();

            foreach (var name in names)
            {
                warriors.Add(new Warrior(name, random.Next(10, 30)));
            }

            return warriors;
        }

        public string StartFight(List<Warrior> warriors)
        {
            ShowWarriorsInformation(warriors);

            battleResult.AppendLine(" --- Fight started! --- ");

            while (!(warriors.Where(x => x.Helath > 0).Count() == 1))
                RandomizeAttacks(warriors);

            ShowWarriorsInformation(warriors, true);

            return battleResult.ToString();
        }

        private void RandomizeAttacks(List<Warrior> warriors)
        {
            Random random = new Random();

            var attacker = random.Next(warriors.Count());
            var attacked = random.Next(warriors.Count());

            if (attacker != attacked && warriors[attacker].Helath >= 0 && warriors[attacked].Helath >= 0)
            {
                warriors[attacker].Attack(warriors[attacked]);
                battleResult.AppendLine($"{warriors[attacked].Name} attacked by {warriors[attacker].Name}");

                if (random.Next(0, 10) == 5)
                {
                    warriors[attacker].MirrorAttack(warriors[attacked]);
                    battleResult.AppendLine($"{warriors[attacked].Name} attacked by {warriors[attacker].Name}. But {warriors[attacked].Name} mirrored his attack!");
                }
            }
        }

        private void ShowWarriorsInformation(List<Warrior> warriors, Boolean afterFight = false)
        {
            if (!afterFight)
                battleResult.AppendLine($" --- Warriors ready to fight! --- {Environment.NewLine}");
            else
                battleResult.AppendLine($"{Environment.NewLine} --- Fight finished! Winner: {warriors.SingleOrDefault(x => x.Helath > 0).Name} --- {Environment.NewLine}");

            battleResult.AppendLine($" --- Warriors information --- ");
            foreach (var warrior in warriors)
            {
                var status = warrior.Helath <= 0 ? "died" : $"{warrior.Helath}%";
                if (!afterFight)
                    battleResult.AppendLine($"Name: {warrior.Name}. Health: {status}. Damage: {warrior.Damage}%");
                else
                    battleResult.AppendLine($"Name: {warrior.Name}. Health: {status}.");
            }
            battleResult.AppendLine(Environment.NewLine);
        }
    }
}
