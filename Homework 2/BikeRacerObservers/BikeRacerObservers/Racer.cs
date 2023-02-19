using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    // THIS CLASS APPLIES THE OBSERVER PATTERN
    // Class used to store data for racer and update listening observers
    public class Racer
    {
        [Index(0)]
        public string FirstName { get; set; }
        [Index(1)]
        public string LastName { get; set; }
        [Index(2)]
        public int BibNumber { get; set; }
        [Index(3)]
        public int Group { get; set; }
        
        public long? StartTime { get; set; }

        public long? EndTime { get; set; }

        public int? CurrentSensorNumber { get; set; }

        public long? CurrentSensorTime { get; set; }

        private List<RacerObserver> _observers;

        private bool informingObservers;

        public Racer()
        {
            _observers= new List<RacerObserver>();
            EndTime = 0;
            CurrentSensorNumber = 0;
            CurrentSensorTime = 0;
            informingObservers= false;
        }


        // THE FOLLOWING FOUR METHODS ARE PART OF THE OBSERVER PATTERN
        // Subscribes an observer to this racer
        public void Subscribe(RacerObserver observer)
        {
            if (_observers.Contains(observer)) return;

            while (informingObservers) ; // Mutex for observer informing

            _observers.Add(observer);

        }

        // Unsubscribes an observer from this racer
        public void Unsubscribe(RacerObserver observer)
        {
            if (!_observers.Contains(observer)) return;

            while (informingObservers) ; // Mutex for observer informing

            _observers.Remove(observer);
        }

        // Updates this racer with new information
        public void Update(int currentSensorNumber, long currentSensorTime)
        {
            CurrentSensorNumber = currentSensorNumber;
            CurrentSensorTime = currentSensorTime;

            InformObservers();
        }

        // Informs observers when updated
        private void InformObservers()
        {
            informingObservers= true;
            foreach (var observer in _observers) 
            {
                observer.Notify();
            }
            informingObservers= false;
        }

        // Informs observers that the race is finalized
        public void FinalizeRace()
        {
            informingObservers = true;
            foreach (var observer in _observers)
            {
                observer.FinalizeRace();
            }
            informingObservers = false;
        }
    }
}
