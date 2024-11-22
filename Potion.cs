using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class Potion : Item
    {
        public string Effect { get; set; }
        public int Duration { get; set; } // Duration in seconds

        // Constructor corrected to include "itemType"
        public Potion(string name, ItemRarity rarity, string effect, int duration)
            : base(name, rarity, "Potion") // Pass "Potion" as the itemType
        {
            Effect = effect;
            Duration = duration;
        }

        // Override DisplayStats to display potion details
        public override void DisplayStats()
        {
            Console.WriteLine($"Potion: {Name} | Rarity: {Rarity} | Effect: {Effect} | Duration: {Duration}s");
        }
    }
}

