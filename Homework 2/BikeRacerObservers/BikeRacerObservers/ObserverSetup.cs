using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    public partial class ObserverSetup : Form
    {
        private string _groupPath;
        private string _racerPath;
        private string _sensorPath;

        private List<Sensor> _sensors;
        private Dictionary<int, RaceGroup> _raceGroups;
        private Dictionary<string, Racer> _racers;

        private Dictionary<string, RacerObserver> _racerObservers;


        private bool subscribeButtonEnabled;
        private bool unsubscribeButtonEnabled;

        public ObserverSetup(string groupPath, string racerPath, string sensorPath)
        {
            _groupPath= groupPath;
            _racerPath= racerPath;
            _sensorPath= sensorPath;

            _sensors= new List<Sensor>();
            _raceGroups= new Dictionary<int, RaceGroup>();
            _racers= new Dictionary<string, Racer>();

            _racerObservers= new Dictionary<string, RacerObserver>();

            subscribeButtonEnabled= false;
            unsubscribeButtonEnabled= false;
            InitializeComponent();
        }

        private void ObserverSetup_Load(object sender, EventArgs e)
        {
            ObservedRacersListView.Items.Clear();

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
            };

            using (var streamReader = new StreamReader(_sensorPath))
            using (var csvSplitter = new CsvReader(streamReader, csvConfig) )
            {
                var sensors = csvSplitter.GetRecords<Sensor>();
                foreach (var sensor in sensors)
                {
                    _sensors.Add(sensor);
                }
            }

            using (var streamReader = new StreamReader(_groupPath))
            using (var csvSplitter = new CsvReader(streamReader, csvConfig))
            {
                var groups = csvSplitter.GetRecords<RaceGroup>();
                foreach (var group in groups)
                {
                    _raceGroups.Add(group.Id, group);
                }
            }

            using (var streamReader = new StreamReader(_racerPath))
            using (var csvSplitter = new CsvReader(streamReader, csvConfig))
            {
                var racers = csvSplitter.GetRecords<Racer>();
                foreach (var racer in racers)
                {
                    racer.StartTime = _raceGroups[racer.Group].StartTime;
                    _racers.Add(racer.BibNumber.ToString(), racer);
                }
            }


            CheatingComputer cheatingComputer = new CheatingComputer();
            cheatingComputer.SetName("Cheating Computer");

            foreach (var racer in _racers.Values)
            {
                cheatingComputer.Subscribe(racer);
            }
            _racerObservers.Add(cheatingComputer.GetName(), cheatingComputer);
            ObserversOfRacersListView.Items.Add(new ListViewItem(cheatingComputer.GetName()));

            DataReceiver dataReceiver = new DataReceiver();
            dataReceiver.Start(_racers);

            UpdateScreens();
        }




        private void CreateRacerObserverBtn_Click(object sender, EventArgs e)
        {
            BigScreenObserver newObserver = new BigScreenObserver();

            BigScreenCreator creator = new BigScreenCreator(newObserver);
            creator.ShowDialog();

            if (newObserver.GetName() == "") return;

            BigScreenForm newScreen= new BigScreenForm(newObserver.GetName());
            newObserver.SetScreen(newScreen);
            newScreen.Show();

            _racerObservers.Add(newObserver.GetName(), newObserver);
            ObserversOfRacersListView.Items.Add(new ListViewItem(newObserver.GetName()));

        }

        private void CreateCheaterObserverBtn_Click(object sender, EventArgs e)
        {

        }

        private void UnobservedRacersListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateScreens()
        {
            UnobservedRacersListView.Items.Clear();
            ObservedRacersListView.Items.Clear();

            // If no item is selected
            if (ObserversOfRacersListView.SelectedItems.Count == 0)
            {
                ObservedRacersLbl.Text = "Select Racer Observer.";
                foreach (var racer in _racers)
                {
                    ListViewItem newItem = new ListViewItem(racer.Value.BibNumber.ToString());
                    newItem.SubItems.Add(racer.Value.FirstName + " " + racer.Value.LastName);

                    UnobservedRacersListView.Items.Add(newItem);
                }
            }
            else
            {
                ObservedRacersLbl.Text = "Observed Racers of " + ObserversOfRacersListView.SelectedItems[0].Text;
                RacerObserver observer = _racerObservers[ObserversOfRacersListView.SelectedItems[0].Text];
                List<Racer> observedRacers = observer.GetRacers();

                foreach (var racer in observedRacers)
                {
                    ListViewItem newItem = new ListViewItem(racer.BibNumber.ToString());
                    newItem.SubItems.Add(racer.FirstName + " " + racer.LastName);

                    ObservedRacersListView.Items.Add(newItem);
                }

                foreach (var racer in _racers)
                {
                    if (!observedRacers.Contains(racer.Value))
                    {
                        ListViewItem newItem = new ListViewItem(racer.Value.BibNumber.ToString());
                        newItem.SubItems.Add(racer.Value.FirstName + " " + racer.Value.LastName);

                        UnobservedRacersListView.Items.Add(newItem);
                    }
                }
            }
        }

        private void ObserverSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void SubscribeBtn_Click(object sender, EventArgs e)
        {
            if (!subscribeButtonEnabled) return;
            RacerObserver observer = null;
            if (ObserversOfRacersListView.SelectedItems.Count == 1)
            {
                observer = _racerObservers[ObserversOfRacersListView.SelectedItems[0].Text];
            }

            foreach (ListViewItem item in UnobservedRacersListView.SelectedItems)
            {
                observer.Subscribe(_racers[item.Text]);
            }

            observer.FinishSubscribing();

            UpdateScreens();
        }
        private void UnsubscribeBtn_Click(object sender, EventArgs e)
        {
            if (!unsubscribeButtonEnabled) return;

            RacerObserver observer = null;
            if (ObserversOfRacersListView.SelectedItems.Count == 1)
            {
                observer = _racerObservers[ObserversOfRacersListView.SelectedItems[0].Text];
            }

            foreach (ListViewItem item in ObservedRacersListView.SelectedItems)
            {
                observer.Unsubscribe(_racers[item.Text]);
            }

            observer.FinishSubscribing();

            UpdateScreens();
        }

        private void ObserversOfRacersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObserversOfRacersListView.SelectedItems.Count == 1)
            {
                subscribeButtonEnabled= true;
                unsubscribeButtonEnabled = true;
            } 
            else
            {
                subscribeButtonEnabled= false;
                unsubscribeButtonEnabled = false;
            }

            UpdateScreens();
        }
    }
}
