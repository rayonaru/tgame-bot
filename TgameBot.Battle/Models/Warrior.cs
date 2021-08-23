using System;

namespace TgameBot.Battle.Models
{
    public class Warrior
    {
        private readonly Int32 _helath = 100;

        public Warrior() { }
        public Warrior(String name, Int32 damage) { Name = name; Helath = _helath; Damage = damage; }

        public String Name { get; private set; }
        public Int32 Helath { get; private set; }
        public Int32 Damage { get; private set; }

        public void Attack(Warrior attacked)
        {
            attacked.Helath -= this.Damage;
        }

        public void MirrorAttack(Warrior attacked)
        {
            attacked.Helath += this.Damage;
        }
    }
}

