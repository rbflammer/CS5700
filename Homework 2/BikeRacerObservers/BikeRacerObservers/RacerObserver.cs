using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRacerObservers
{
    public interface RacerObserver
    {
        void Update(Racer racer);
        void Unsubscribe(Racer racer);
    }
}
