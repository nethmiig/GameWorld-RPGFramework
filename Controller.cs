using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class Controller
    {
        private readonly Dictionary<ConsoleKey, ICommand> _keyCommandMap;

        public Controller()
        {
            _keyCommandMap = new Dictionary<ConsoleKey, ICommand>();
        }

        // Map a key to a specific command
        public void MapKeyToCommand(ConsoleKey key, ICommand command)
        {
            _keyCommandMap[key] = command;
        }

        // Execute a command based on key input
        public void HandleKeyPress(ConsoleKey key)
        {
            if (_keyCommandMap.TryGetValue(key, out ICommand command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine($"No action mapped to the key: {key}");
            }
        }
    }
}