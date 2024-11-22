using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class RangedAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} launches a precise ranged attack!");
        }
    }
}
