using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    public interface RacerObserver
    {
        void Notify();
        void Unsubscribe(Racer racer);
        List<Racer> GetRacers();
        void Subscribe(Racer racer);
        string GetName();
        void SetName(string name);
        void FinishSubscribing();
    }
}
