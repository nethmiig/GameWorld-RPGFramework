using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            Health = 80;
            Mana = 150;
            Strength = 30;
            Agility = 40;
        }
    }
}
