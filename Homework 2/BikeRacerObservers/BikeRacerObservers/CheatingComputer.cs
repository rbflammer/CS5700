using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
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

        public CheatingComputer()
        {
            _racers = new Dictionary<int, Racer>();
            _racerTimes= new Dictionary<int, List<long>>();

            _cheaters = new List<(Racer cheater, Racer cheatingWith)>();
            _recentlyUpdated = new List<Racer>();

            _cheaterCheckRunning = false;

            _cheaterObservers = new List<CheaterObserver>();
            _notifyObservers = false;
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
            _racerTimes.Add(racer.BibNumber, new List<long>());
            racer.Subscribe(this);
        }

        public void Unsubscribe(Racer racer)
        {
            // If not subsribed to this racer
            if (!_racers.ContainsKey(racer.BibNumber)) return;

            _racers.Remove(racer.BibNumber);
            racer.Unsubscribe(this);
        }

        public void FinishSubscribing()
        {
            // Empty
        }

        public void Notify()
        {
            if (_cheaterCheckRunning) return;

            notifyObservers();

            foreach (var racer in _racers.Values)
            {
                if (_racerTimes[racer.BibNumber].Count >= racer.CurrentSensorNumber)
                {
                    _racerTimes[racer.BibNumber].Add((long)racer.CurrentSensorTime);
                    _recentlyUpdated.Add(racer);
                }
            }

            _cheaterThread = new Thread(new ThreadStart(checkCheaters));
            _cheaterThread.Start();
            _cheaterCheckRunning= true;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SubscribeToCheating(CheaterObserver observer)
        {
            if (_cheaterObservers.Contains(observer)) return;

            _cheaterObservers.Add(observer);
        }

        private void notifyObservers()
        {
            if (!_notifyObservers) return;

            foreach (var observer in _cheaterObservers)
            {
                observer.Notify();
            }
        }

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
            
                        for (int i = mySensorTimes.Count - 1; i > mySensorTimes.Count - 3 && i >= 0; i--)
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
                            Console.WriteLine($"Found new cheaters {racer.BibNumber} and {otherRacer.BibNumber} with time difference {mySensorTimes[mySensorTimes.Count - 1] - otherSensorTimes[otherSensorTimes.Count - 1]} and {mySensorTimes[mySensorTimes.Count - 2] - otherSensorTimes[otherSensorTimes.Count - 2]}");
                            _cheaters.Add((racer, otherRacer));
                            _notifyObservers= true;
                        }
                    }
                }
            }
            _cheaterCheckRunning = false;
        }

        public List<(Racer cheater, Racer cheatingWith)> getCheaters()
        {
            return _cheaters;
        }
    }
}
