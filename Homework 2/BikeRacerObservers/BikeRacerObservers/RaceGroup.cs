using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    public class RaceGroup
    {
        [Index(0)]
        public int Id { get; set; }
        [Index(1)]
        public string Name { get; set; }
        [Index(2)]
        public long StartTime { get; set; }
        [Index(3)]
        public int StartNumber { get; set; } // Starting bib number
        [Index(4)]
        public long EndNumber { get; set; } // Ending bib number
    }
}
