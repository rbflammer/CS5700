using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    // This class observes the cheating computer.
    // This follows the observer pattern
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
            _computer.SubscribeToCheating(this);
        }

        // THE NEXT THREE METHODS ARE PART OF THE OBSERVER PATTERN
        // Updates when the cheating computer finishes its new list of cheaters
        // Checks to see if any subscribed to racers are cheaters
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
            {
                if(_screen.IsHandleCreated)
                {

                    if (_screen.InvokeRequired)
                        _screen.Invoke((MethodInvoker)delegate { _screen.Update(_cheaters); });
                    else
                        _screen.Update(_cheaters);
                }
            }
        }

        // Subscribes this observer to a racer
        public void Subscribe(Racer racer) 
        {
            if (_racers.Contains(racer)) return;

            _racers.Add(racer);
        }

        // Unsubscribes this observer from a racer
        public void Unsubscribe(Racer racer)
        {
            if (!_racers.Contains(racer)) return;

            _racers.Remove(racer);
        }

        // Returns all of the subscribed to racers
        public List<Racer> GetRacers() 
        {
            return _racers; 
        }

        // Sets the screen for this observer
        public void SetScreen(CheaterScreen screen)
        {
            _screen = screen;
            _screen.AddObserver(this);
        }

        // Sets the name of this observer
        public void SetName(string name)
        {
            _name = name;
        }

        // Returns the name of this observer
        public string GetName()
        {
            return _name;
        }

        // Updates the screen once all subscriptions are complete
        public void FinishSubscribing()
        {
            _screen.Update(_cheaters);
        }
    }
}
