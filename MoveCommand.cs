using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class MoveCommand : ICommand
    {
        private Character _character;
        public string Destination { get; private set; } // Add a public property

        public MoveCommand(Character character, string destination)
        {
            _character = character;
            Destination = destination; // Assign to the property
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} moves to {Destination}.");
        }
    }
}
