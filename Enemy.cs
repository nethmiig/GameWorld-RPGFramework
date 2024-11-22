using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public string Rank { get; set; } // E.g., "Normal", "Elite", "Boss"

        public Enemy(string name, string rank)
        {
            Name = name;
            Rank = rank;
        }

        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} attacks with {Strength} strength.");
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine($"Enemy: {Name} (Rank: {Rank})");
            Console.WriteLine($"Health: {Health}, Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength}, Agility: {Agility}");
        }
    }
}
