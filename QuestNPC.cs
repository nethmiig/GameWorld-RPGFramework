using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class QuestNPC : IObserver
    {
        public string Name { get; set; }

        public QuestNPC(string name)
        {
            Name = name;
        }

        public void Update(string questStatus)
        {
            Console.WriteLine($"{Name} received quest notification: {questStatus}");
        }
    }
}

