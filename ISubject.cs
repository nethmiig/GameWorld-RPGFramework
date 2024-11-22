using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void NotifyObservers(string questStatus);
    }
}
