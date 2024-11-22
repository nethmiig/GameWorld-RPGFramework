using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
   
        public class Warrior : Character
        {
            public Warrior(string name) : base(name)
            {
                Health = 150;
                Mana = 30;
                Strength = 100;
                Agility = 50;
            }
        }
}
