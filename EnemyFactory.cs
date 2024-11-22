using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(string type, string rank)
        {
            return type.ToLower() switch
            {
                "slime" => CreateSlime(rank),
                "goblin" => CreateGoblin(rank),
                "dragon" => CreateDragon(rank),
                _ => throw new ArgumentException("Invalid enemy type")
            };
        }

        private static Enemy CreateSlime(string rank)
        {
            return rank.ToLower() switch
            {
                "normal" => new Slime("Slime", "Normal", 50, 10, 5, 2),
                "elite" => new Slime("Slime", "Elite", 100, 20, 10, 5),
                "boss" => new Slime("King Slime", "Boss", 200, 30, 20, 10),
                _ => throw new ArgumentException("Invalid rank")
            };
        }

        private static Enemy CreateGoblin(string rank)
        {
            return rank.ToLower() switch
            {
                "normal" => new Goblin("Goblin", "Normal", 80, 15, 10, 8),
                "elite" => new Goblin("Goblin Warrior", "Elite", 150, 25, 20, 15),
                "boss" => new Goblin("Goblin King", "Boss", 250, 40, 30, 20),
                _ => throw new ArgumentException("Invalid rank")
            };
        }

        private static Enemy CreateDragon(string rank)
        {
            return rank.ToLower() switch
            {
                "normal" => new Dragon("Young Dragon", "Normal", 300, 50, 40, 25),
                "elite" => new Dragon("Adult Dragon", "Elite", 500, 70, 60, 40),
                "boss" => new Dragon("Ancient Dragon", "Boss", 1000, 100, 80, 50),
                _ => throw new ArgumentException("Invalid rank")
            };
        }
    }
}
