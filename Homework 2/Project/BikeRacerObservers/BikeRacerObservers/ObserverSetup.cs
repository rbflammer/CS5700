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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    // Main form of the application.
    // Allows user to create observers, and subscribe/unsubscribe observers from racers
    public partial class ObserverSetup : Form
    {
        private string _groupPath;
        private string _racerPath;
        private string _sensorPath;

        private List<Sensor> _sensors;
        private Dictionary<int, RaceGroup> _raceGroups;
        private Dictionary<string, Racer> _racers;

        private Dictionary<string, RacerObserver> _racerObservers;
        private Dictionary<string, CheaterObserver> _cheaterObservers;
        private CheatingComputer _cheatingComputer;

        private bool _subscribeButtonEnabled;
        private bool _unsubscribeButtonEnabled;
        private bool _usingCheater;

        private FileSelector _parent;

        public ObserverSetup(string groupPath, string racerPath, string sensorPath, FileSelector parent)
        {
            _groupPath = groupPath;
            _racerPath = racerPath;
            _sensorPath = sensorPath;

            _sensors = new List<Sensor>();
            _raceGroups = new Dictionary<int, RaceGroup>();
            _racers = new Dictionary<string, Racer>();

            _racerObservers = new Dictionary<string, RacerObserver>();
            _cheaterObservers = new Dictionary<string, CheaterObserver>();

            _subscribeButtonEnabled = false;
            _unsubscribeButtonEnabled = false;
            _usingCheater = false;
            InitializeComponent();
            _parent = parent;  
        }

        // Loads in all data files and sets up cheating computer
        private void ObserverSetup_Load(object sender, EventArgs e)
        {
            ObservedRacersListView.Items.Clear();

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
            };

            // Reading in all data
            try
            {
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
            } 
            catch // Displays an error message then closes
            {
                MessageBox.Show("Failure parsing at least one of the files. Please re-launch and try again");
                _parent.Close();
                this.Close();
            }

            // Setting up cheating computer
            CheatingComputer cheatingComputer = new CheatingComputer();
            cheatingComputer.SetName("Cheating Computer");

            foreach (var racer in _racers.Values)
            {
                cheatingComputer.Subscribe(racer);
            }

            // Adding cheating computer to Observers of Racers
            _cheatingComputer = cheatingComputer;
            _racerObservers.Add(cheatingComputer.GetName(), cheatingComputer);
            ObserversOfRacersListView.Items.Add(new ListViewItem(cheatingComputer.GetName()));

            // Sets-up DataReciever
            DataReceiver dataReceiver = new DataReceiver();
            dataReceiver.Start(_racers);

            UpdateScreens();
        }

        // Creates a racer observer. Launches external form to help
        private void CreateRacerObserverBtn_Click(object sender, EventArgs e)
        {
            BigScreenObserver newObserver = new BigScreenObserver();

            BigScreenCreator creator = new BigScreenCreator(newObserver);
            creator.ShowDialog();

            if (newObserver.GetName() == "" || newObserver.GetName() == null) return;

            BigScreen newScreen= new BigScreen(newObserver.GetName());
            newObserver.SetScreen(newScreen);
            newScreen.Show();

            _racerObservers.Add(newObserver.GetName(), newObserver);
            ObserversOfRacersListView.Items.Add(new ListViewItem(newObserver.GetName()));

        }

        // Creates a cheater observer. Launches another form to help.
        private void CreateCheaterObserverBtn_Click(object sender, EventArgs e)
        {
            CheaterObserver newObserver = new CheaterObserver(_cheatingComputer);

            CheaterScreenCreator creator = new CheaterScreenCreator(newObserver);
            creator.ShowDialog();

            if (newObserver.GetName() == "" || newObserver.GetName() == null) return;

            CheaterScreen newScreen = new CheaterScreen(newObserver.GetName());
            newObserver.SetScreen(newScreen);
            newScreen.Show();

            _cheaterObservers.Add(newObserver.GetName(), newObserver);
            CheaterObserverListView.Items.Add(new ListViewItem(newObserver.GetName()));
        }

        // Updates the racer listviews to show subscribed/unsubscribed racers
        private void UpdateScreens()
        {
            UnobservedRacersListView.Items.Clear();
            ObservedRacersListView.Items.Clear();

            // If no item is selected
            if (ObserversOfRacersListView.SelectedItems.Count == 0 && CheaterObserverListView.SelectedItems.Count == 0)
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
                List<Racer> observedRacers = new List<Racer>();
                if (!_usingCheater)
                {
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
                        observedRacers = observer.GetRacers();
                    }
                }
                else
                {
                    if (CheaterObserverListView.SelectedItems.Count == 0)
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
                        ObservedRacersLbl.Text = "Observed Racers of " + CheaterObserverListView.SelectedItems[0].Text;
                        CheaterObserver observer = _cheaterObservers[CheaterObserverListView.SelectedItems[0].Text];
                        observedRacers = observer.GetRacers();
                    }
                }

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

        // Closes everything when this form closes
        private void ObserverSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Subscribes selected observer to selected unobserved racers
        private void SubscribeBtn_Click(object sender, EventArgs e)
        {
            if (!_subscribeButtonEnabled) return;

            if (!_usingCheater)
            {
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
            }
            else
            {
                CheaterObserver observer = null;
                if (CheaterObserverListView.SelectedItems.Count == 1)
                {
                    observer = _cheaterObservers[CheaterObserverListView.SelectedItems[0].Text];
                }

                foreach (ListViewItem item in UnobservedRacersListView.SelectedItems)
                {
                    observer.Subscribe(_racers[item.Text]);
                }

                observer.FinishSubscribing();
            }

            UpdateScreens();
        }

        // Unsubscribes selected observer from selected observed racers
        private void UnsubscribeBtn_Click(object sender, EventArgs e)
        {
            if (!_unsubscribeButtonEnabled) return;

            if (!_usingCheater)
            {
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
            }
            else
            {
                CheaterObserver observer = null;
                if (CheaterObserverListView.SelectedItems.Count == 1)
                {
                    observer = _cheaterObservers[CheaterObserverListView.SelectedItems[0].Text];
                }

                foreach (ListViewItem item in ObservedRacersListView.SelectedItems)
                {
                    observer.Unsubscribe(_racers[item.Text]);
                }

                observer.FinishSubscribing();
            }

            UpdateScreens();
        }

        // Updates selected observer and screens when a new observer is selected/deselected
        private void ObserversOfRacersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ObserversOfRacersListView.SelectedItems.Count == 1)
            {
                _subscribeButtonEnabled= true;
                _unsubscribeButtonEnabled = true;
                _usingCheater = false;
            } 
            else
            {
                _subscribeButtonEnabled= false;
                _unsubscribeButtonEnabled = false;
                _usingCheater = false;
            }

            UpdateScreens();
        }

        // Updates selected observer and screens when a new observer is selected/deselected
        private void CheaterObserverListView_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            if (CheaterObserverListView.SelectedItems.Count == 1)
            {
                _subscribeButtonEnabled = true;
                _unsubscribeButtonEnabled = true;
                _usingCheater = true;
            }
            else
            {
                _subscribeButtonEnabled = false;
                _unsubscribeButtonEnabled = false;
                _usingCheater = false;
            }

            UpdateScreens();
        }
    }
}
