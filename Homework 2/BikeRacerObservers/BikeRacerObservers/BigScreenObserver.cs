using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    public class BigScreenObserver : RacerObserver
    {
        private Dictionary<int, Racer> _racers;
        private string _name;
        private BigScreenForm _screen;

        public BigScreenObserver()
        {
            _racers = new Dictionary<int, Racer>();
        }
        public List<Racer> GetRacers()
        {
            List<Racer> output = new List<Racer>();
            foreach (var racer in _racers.Values)
            {
                output.Add(racer);
            }
            return output;
        }

        public void Subscribe(Racer racer)
        {
            // If already subscribed to this racer
            if (_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Add(racer.BibNumber, racer);
            racer.Subscribe(this);
            _screen.Subscribe(racer);
        }

        public void Unsubscribe(Racer racer)
        {
            if (!_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Remove(racer.BibNumber);
            racer.Unsubscribe(this);
            _screen.Unsubscribe(racer);
        }

        public void FinishSubscribing()
        {
            _screen.FinsishedContentLoading = true;
            _screen.Update();
        }

        public void Notify()
        {
            _screen.Update();
        }

        public void SetScreen(BigScreenForm screen)
        {
            _screen = screen;
            _screen.Update();
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
