using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    // Data class used for decoding sensor data
    public class Sensor
    {
        [Index(0)]
        public int MileLocation { get; set; }
        [Index(1)]
        public int Number { get; set; }
    }
}
