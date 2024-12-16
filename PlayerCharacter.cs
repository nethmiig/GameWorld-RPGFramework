using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class PlayerCharacter : Character, IObserver
    {
        private List<Quest> activeQuests;

        public PlayerCharacter(string name) : base(name)
        {
            activeQuests = new List<Quest>();
        }

        public void AcceptQuest(Quest quest)
        {
            if (quest != null)
            {
                activeQuests.Add(quest);
                Console.WriteLine($"{Name} has accepted the quest: {quest.Title}");
            }
        }

        public void DisplayActiveQuests()
        {
            Console.WriteLine("\nActive Quests:");
            if (activeQuests.Count == 0)
            {
                Console.WriteLine("No active quests.");
            }
            else
            {
                foreach (var quest in activeQuests)
                {
                    Console.WriteLine($"- {quest.Title}: {quest.Description} (Reward: {quest.RewardGold} gold)");
                }
            }
        }

        public void Update(string questStatus)
        {
            Console.WriteLine($"{Name} received quest notification: {questStatus}");
        }
    }

}
