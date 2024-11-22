using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{

    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            Health = 100;
            Mana = 50;
            Strength = 60;
            Agility = 120;
        }
    }
}
