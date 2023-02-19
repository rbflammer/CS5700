using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    // RacerObserver class that computes all of the cheaters of the race
    // THIS FOLLOWS THE OBSERVER PATTERN
    public class CheatingComputer : RacerObserver
    {
        private Dictionary<int, Racer> _racers;
        private string _name;
        private Dictionary<int, List<long>> _racerTimes;// Times of the racers. key is bib number, list is times at each sensor

        private List<(Racer cheater, Racer cheatingWith)> _cheaters; // Pair of cheater racers
        private List<Racer> _recentlyUpdated;

        private Thread _cheaterThread;
        private bool _cheaterCheckRunning;

        private List<CheaterObserver> _cheaterObservers;
        private bool _notifyObservers;

        private bool _finalized;

        public CheatingComputer()
        {
            _racers = new Dictionary<int, Racer>();
            _racerTimes= new Dictionary<int, List<long>>();

            _cheaters = new List<(Racer cheater, Racer cheatingWith)>();
            _recentlyUpdated = new List<Racer>();

            _cheaterCheckRunning = false;

            _cheaterObservers = new List<CheaterObserver>();
            _notifyObservers = false;
            _finalized = false;
        }

        // Returns all of the racers subscribed to by this observer
        public List<Racer> GetRacers()
        {
            List<Racer> output = new List<Racer>();
            foreach (var racer in _racers.Values)
            {
                output.Add(racer);
            }
            return output;
        }

        // THE NEXT THREE METHODS ARE PART OF THE OBSERVER PATTERN
        // Subscribes this observer to a racer
        public void Subscribe(Racer racer)
        {
            // If already subscribed to this racer
            if (_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Add(racer.BibNumber, racer);
            _racerTimes.Add(racer.BibNumber, new List<long>());
            racer.Subscribe(this);
        }

        // Unsubscribes this observer from a racer
        public void Unsubscribe(Racer racer)
        {
            // If not subsribed to this racer
            if (!_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Remove(racer.BibNumber);
            racer.Unsubscribe(this);
        }

        // Updates the data in this observer when a subscribed to racer updates
        public void Notify()
        {
            if (_cheaterCheckRunning) return;
            _finalized= false;

            notifyObservers();

            foreach (var racer in _racers.Values)
            {
                if (_racerTimes[racer.BibNumber].Count < racer.CurrentSensorNumber + 1)
                {
                    _racerTimes[racer.BibNumber].Add((long)racer.CurrentSensorTime);
                    _recentlyUpdated.Add(racer);
                }
            }

            _cheaterThread = new Thread(new ThreadStart(checkCheaters));
            _cheaterThread.Start();
            _cheaterCheckRunning= true;
        }
        public void FinishSubscribing()
        {
            // Empty
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

        // THE NEXT TWO METHODS ARE PART OF THE OBSERVER PATTERN (where this is the base class, not the observer)
        // Subscribes a CheaterObserver to this observer
        public void SubscribeToCheating(CheaterObserver observer)
        {
            if (_cheaterObservers.Contains(observer)) return;

            _cheaterObservers.Add(observer);
        }

        // Notifies all observers when at least one new cheater is found
        private void notifyObservers()
        {
            if (!_notifyObservers) return;

            foreach (var observer in _cheaterObservers)
            {
                observer.Notify();
            }
        }

        // Finds all new cheaters based on current data
        private void checkCheaters()
        {
            _cheaterCheckRunning= true;

            foreach (var racer in _recentlyUpdated)
            {
                List<long> mySensorTimes = _racerTimes[racer.BibNumber];
                foreach (var otherRacer in _racers.Values)
                {
                    if (otherRacer.Group != racer.Group) 
                    {
                        int infractionCount = 0;
                        List<long> otherSensorTimes = _racerTimes[otherRacer.BibNumber];
            
                        for (int i = mySensorTimes.Count - 1; i >= mySensorTimes.Count - 3 && i >= 0; i--)
                        {
                            if (i >= otherSensorTimes.Count) break;
                            if (infractionCount >= 2) break;
                            if (_cheaters.Contains((racer, otherRacer)) || _cheaters.Contains((otherRacer, racer))) break;

                            if (Math.Abs(mySensorTimes[i] - otherSensorTimes[i]) <= 3000) // If they are within three seconds
                            {
                                infractionCount++;
                            }
                        }
            
                        if (infractionCount >= 2)
                        {
                            _cheaters.Add((racer, otherRacer));
                            _notifyObservers= true;
                        }
                    }
                }
            }
            _cheaterCheckRunning = false;
        }

        // Returns all current found cheaters
        public List<(Racer cheater, Racer cheatingWith)> getCheaters()
        {
            return _cheaters;
        }

        // Finishes computing all cheaters once the race is finshed
        public void FinalizeRace()
        {
            if (_finalized) return; // Won't run twice
            _finalized = true;

            // Finish current computation
            while (_cheaterCheckRunning) ;

            // Start and finish final process
            Notify();
            while (_cheaterCheckRunning) ;
            
            // Notifying observers
            notifyObservers();
        }
    }
}
