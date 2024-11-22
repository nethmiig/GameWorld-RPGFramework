using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class IdleState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is idle, not performing any actions.");
        }
    }
}
