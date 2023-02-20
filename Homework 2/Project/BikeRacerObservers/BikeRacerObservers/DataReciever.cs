using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using Messages;

namespace BikeRacerObservers
{
    // Helpser class used to recieve udp racer data on its own thread
    public class DataReceiver
    {
        private UdpClient udpClient;
        private bool keepGoing;
        private Thread myRunThread;

        private Dictionary<string, Racer> _racers;

        private bool finalizedRace;

        // Starts listening for incoming racer data
        public void Start(Dictionary<string, Racer> racers)
        {
            _racers= racers;

            udpClient = new UdpClient(14000);
            keepGoing = true;
            finalizedRace = false;
            myRunThread = new Thread(new ThreadStart(Run));
            myRunThread.IsBackground = true;
            myRunThread.Start();
        }

        // Listens for incoming racer data and updates racers accordingly
        private void Run()
        {
            while (keepGoing)
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                udpClient.Client.ReceiveTimeout = 1000;
                byte[] messageByes;
                try
                {
                    messageByes = udpClient.Receive(ref ep);
                    if (messageByes != null)
                    {
                        RacerStatus statusMessage = RacerStatus.Decode(messageByes);
                        if (statusMessage != null)
                        {
                            _racers[statusMessage.RacerBibNumber.ToString()].Update(statusMessage.SensorId, statusMessage.Timestamp);
                            finalizedRace = false;
                        }
                    }
                }
                catch (SocketException err)
                {
                    if (!finalizedRace) // Informs all racers that the race is finished when the data stops coming in
                    {
                        finalizedRace = true;
                        foreach (var racer in _racers.Values)
                        {
                            racer.FinalizeRace();
                        }
                    }
                    if (err.SocketErrorCode != SocketError.Interrupted && err.SocketErrorCode != SocketError.TimedOut)
                        throw err;
                }
            }
        }
    }
}

