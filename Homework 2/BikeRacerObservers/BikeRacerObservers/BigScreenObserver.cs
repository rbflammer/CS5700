using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    // RacerObserver used as a support class for the BigScreen Form
    // THIS CLASS IS PART OF THE OBSERVER PATTERN
    public class BigScreenObserver : RacerObserver
    {
        private Dictionary<int, Racer> _racers;
        private string _name;
        private BigScreenForm _screen;
        bool _finalized;

        public BigScreenObserver()
        {
            _racers = new Dictionary<int, Racer>();
            _finalized= false;
        }

        // Returns all racers subscribed to by this observer
        public List<Racer> GetRacers()
        {
            List<Racer> output = new List<Racer>();
            foreach (var racer in _racers.Values)
            {
                output.Add(racer);
            }
            return output;
        }

        // THE NEXT 3 METHODS ARE PART OF THE OBSERVER PATTERN
        // Subscribes this observer to a racer
        public void Subscribe(Racer racer)
        {
            // If already subscribed to this racer
            if (_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Add(racer.BibNumber, racer);
            racer.Subscribe(this);
            _screen.Subscribe(racer);
        }

        // Unsubscribes this observer from a racer
        public void Unsubscribe(Racer racer)
        {
            // If not already subscribed to this racer
            if (!_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Remove(racer.BibNumber);
            racer.Unsubscribe(this);
            _screen.Unsubscribe(racer);
        }

        // Used for updating this observer its observed racer updates
        public void Notify()
        {
            _finalized = false;
            _screen.Update();
        }

        // Finishes the subscription process. This makes the screen
        // refresh with all of the subscribed to racers
        public void FinishSubscribing()
        {
            _screen.FinsishedContentLoading = true;
            _screen.Update();
        }

        // Sets the screen for this observer to update
        public void SetScreen(BigScreenForm screen)
        {
            _screen = screen;
            _screen.Update();
        }

        // Returns the name of this observer
        public string GetName()
        {
            return _name;
        }

        // Sets the name of this observer
        public void SetName(string name)
        {
            _name = name;
        }

        // Refreshes the screen once the race is finalized
        public void FinalizeRace()
        {
            if (!_finalized)
            {
                _finalized= true;
                _screen.FinalizeRace();
            }
        }
    }
}
