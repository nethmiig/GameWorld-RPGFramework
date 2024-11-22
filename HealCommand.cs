using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class HealCommand : ICommand
    {
        private Character _character;

        public HealCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} heals!");
            _character.Health += 20; // Arbitrary healing value
            Console.WriteLine($"{_character.Name}'s health is now {_character.Health}.");
        }
    }
}

