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

        private void BigScreen_Load(object sender, EventArgs e)
        {
            Text = _name;
        }

        public void Update()
        {
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

        public void Subscribe(Racer racer)
        {
            if (_racers.Contains(racer)) return;
            _racers.Add(racer);
            Update();
        }

        public void Unsubscribe(Racer racer)
        {
            if (!_racers.Contains(racer)) return;

            _racers.Remove(racer);
            Update();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            Update();
        }
    }
}
