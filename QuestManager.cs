using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class QuestManager : ISubject
    {
        private readonly List<IObserver> observers;

        public QuestManager()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
            Console.WriteLine($"{observer.GetType().Name} has subscribed to quest notifications.");
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove(observer);
            Console.WriteLine($"{observer.GetType().Name} has unsubscribed from quest notifications.");
        }

        public void NotifyObservers(string questStatus)
        {
            foreach (var observer in observers)
            {
                observer.Update(questStatus);
            }
        }

        // Simulate quest state changes
        public void ChangeQuestState(string questStatus)
        {
            Console.WriteLine($"\nQuest Status Changed: {questStatus}");
            NotifyObservers(questStatus);
        }
    }
}
