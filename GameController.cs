using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class GameController
    {
        private readonly List<ICommand> _commandHistory;

        public GameController()
        {
            _commandHistory = new List<ICommand>();
        }

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Add(command);
        }

        public void ShowCommandHistory()
        {
            Console.WriteLine("\nCommand History:");
            foreach (var command in _commandHistory)
            {
                if (command is AttackCommand)
                    Console.WriteLine($"- Attack Command executed");
                else if (command is DefendCommand)
                    Console.WriteLine($"- Defend Command executed");
                else if (command is HealCommand)
                    Console.WriteLine($"- Heal Command executed");
                else if (command is MoveCommand move)
                    Console.WriteLine($"- Move Command executed to {move.Destination}");
            }
        }

    }
}
