using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class MagicAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} casts a powerful magic spell!");
        }
    }
}
