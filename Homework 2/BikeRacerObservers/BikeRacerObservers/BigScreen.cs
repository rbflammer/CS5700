using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    // Big Screen display of observed racer's progress
    public partial class BigScreenForm : Form
    {
        private List<Racer> _racers;
        private DateTime _lastUpdated;
        public bool FinsishedContentLoading;
        private string _name;

        public BigScreenForm(string name)
        {
            _racers = new List<Racer>();
            _lastUpdated= DateTime.Now;

            _name= name;
            FinsishedContentLoading= false;

            InitializeComponent();
        }

        // Sets the text of the window upon load
        private void BigScreen_Load(object sender, EventArgs e)
        {
            Text = _name;
        }

        // Refreshes the screen once the race is finished
        public void FinalizeRace()
        {
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                    DisplayListView.Invoke((MethodInvoker)delegate { refreshScreen(); });
                else
                    refreshScreen();
            }
        }

        // Updates the screen with new information
        public void Update()
        {
            // Only refreshes every half a second (this makes the results more readable during the race)
            if ((DateTime.Now - _lastUpdated).TotalMilliseconds < 500 && !FinsishedContentLoading) return;
            if (FinsishedContentLoading) FinsishedContentLoading= false;
            _lastUpdated = DateTime.Now;

            // These make the method run from the non-main thread
            if (IsHandleCreated)
            {
                if (InvokeRequired)
                    DisplayListView.Invoke((MethodInvoker)delegate { refreshScreen(); });
                else
                    refreshScreen();
            }
        }

        // Refrheses the ListView of the screen
        private void refreshScreen()
        {
            bubbleSortRacers();

            DisplayListView.Items.Clear();
            foreach (Racer racer in _racers)
            {
                ListViewItem newItem = new ListViewItem(racer.BibNumber.ToString());
                newItem.SubItems.Add(racer.FirstName + " " + racer.LastName);
                if (racer.CurrentSensorNumber != null)
                {
                    newItem.SubItems.Add(racer.CurrentSensorNumber.ToString());
                    newItem.SubItems.Add(TimeSpan.FromMilliseconds((double)racer.CurrentSensorTime).ToString(@"hh\:mm\:ss\.fff"));
                    //newItem.SubItems.Add(TimeSpan.FromMilliseconds((double)racer.CurrentSensorTime - (double)racer.StartTime).ToString(@"hh\:mm\:ss\.fff"));
                }

                DisplayListView.Items.Add(newItem);
            }   
        }

        // Sorts the racers by time and furthest sensor
        // This only occurs maximum 2 times a second, so it is okay to be O(n^2)
        private void bubbleSortRacers()
        {
            List<Racer> sortedRacers = new List<Racer>();

            while (_racers.Count > 0)
            {
                Racer bestRacer = _racers[0];
                int maxSensor = 0;
                long lowestTime = long.MaxValue;
                foreach (Racer racer in _racers)
                {
                    if (racer.CurrentSensorNumber > maxSensor)
                    {
                        bestRacer = racer;
                        maxSensor = (int)racer.CurrentSensorNumber;
                        lowestTime = (long)racer.CurrentSensorTime - (long)racer.StartTime ;
                    }
                    else if (racer.CurrentSensorNumber == maxSensor && racer.CurrentSensorTime - racer.StartTime < lowestTime)
                    {
                        bestRacer = racer;
                        lowestTime = (long)racer.CurrentSensorTime - (long) racer.StartTime;
                    }
                }
                sortedRacers.Add(bestRacer);
                _racers.Remove(bestRacer);
            }
            _racers = sortedRacers;
        }

        // Adds a racer to this screen
        public void Subscribe(Racer racer)
        {
            if (_racers.Contains(racer)) return;
            _racers.Add(racer);
            Update();
        }

        // Removes a racer from this screen
        public void Unsubscribe(Racer racer)
        {
            if (!_racers.Contains(racer)) return;

            _racers.Remove(racer);
            Update();
        }
    }
}
