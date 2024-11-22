using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class UtilityItem : Item
    {
        public string Effect { get; set; }

        public UtilityItem(string name, ItemRarity rarity, string effect)
            : base(name, rarity, "Utility Item")
        {
            Effect = effect;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Utility Item: {Name} | Rarity: {Rarity} | Effect: {Effect}");
        }
    }
}
