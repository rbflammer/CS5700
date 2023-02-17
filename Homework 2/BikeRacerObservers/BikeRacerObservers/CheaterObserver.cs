using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    public class CheaterObserver
    {
        private CheatingComputer _computer;
        private List<Racer> _racers;
        private List<(Racer cheater, Racer cheatingWith)> _cheaters;

        private CheaterScreen _screen;

        private string _name;

        public CheaterObserver(CheatingComputer computer)
        {
            _racers= new List<Racer>();
            _cheaters= new List<(Racer cheater, Racer cheatingWith)>();

            _computer= computer;
        }
        public void Notify()
        {
            foreach (var cheater in _computer.getCheaters())
            {
                if (!_cheaters.Contains(cheater)) 
                { 
                    if (_racers.Contains(cheater.cheater) || _racers.Contains(cheater.cheatingWith))
                    {
                        _cheaters.Add(cheater);
                    }
                }
            }
            if (_screen != null)
                _screen.Update();
        }

        public void Subscribe(Racer racer) 
        {
            if (_racers.Contains(racer)) return;

            _racers.Add(racer);
        }

        public void Unsubscribe(Racer racer)
        {
            if (!_racers.Contains(racer)) return;

            _racers.Remove(racer);
        }

        public List<Racer> GetRacers() 
        {
            return _racers; 
        }

        public List<(Racer cheater, Racer cheatingWith)> GetCheaters()
        {
            return _cheaters;
        }

        public void SetScreen(CheaterScreen screen)
        {
            _screen = screen;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void FinishSubscribing()
        {
            _screen.Update(_cheaters);
        }
    }
}
