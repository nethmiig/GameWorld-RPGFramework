using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class PlayerCharacter : Character, IObserver
    {
        public PlayerCharacter(string name) : base(name) { }

        public void Update(string questStatus)
        {
            Console.WriteLine($"{Name} received quest notification: {questStatus}");
        }
    }
}
