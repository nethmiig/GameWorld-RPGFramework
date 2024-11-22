using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class DefendCommand : ICommand
    {
        private Character _character;

        public DefendCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            Console.WriteLine($"{_character.Name} enters a defensive stance!");
            _character.ChangeState(new DefendingState()); // Use State Pattern for Defend
            _character.HandleState();
        }
    }
}
