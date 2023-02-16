using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
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

        public int? CurrentSensorNumber { get; set; } = 0;

        public long? CurrentSensorTime { get; set; }

        private List<RacerObserver> _observers;

        public Racer()
        {
            _observers= new List<RacerObserver>();
            EndTime = 0;
            CurrentSensorNumber = 0;
        }

        public void Subscribe()
        {
            // TODO: Fill this out
        }

        public void Unsubscribe()
        {
            // TODO: Fill this out
        }

        public void Update()
        {
            // TODO: Fill this out
        }

        private void InformObservers()
        {
            foreach (var observer in _observers) 
            {
                observer.Update(this);
            }
        }
    }
}
