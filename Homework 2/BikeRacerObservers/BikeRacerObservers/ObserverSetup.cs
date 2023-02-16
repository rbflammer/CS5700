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
        private Dictionary<int, Racer> _racers;
        public ObserverSetup(string groupPath, string racerPath, string sensorPath)
        {
            _groupPath= groupPath;
            _racerPath= racerPath;
            _sensorPath= sensorPath;

            _sensors= new List<Sensor>();
            _raceGroups= new Dictionary<int, RaceGroup>();
            _racers= new Dictionary<int, Racer>();
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
                    _racers.Add(racer.BibNumber, racer);
                }
            }

            foreach (var racer in _racers)
            {
                ListViewItem newItem = new ListViewItem(racer.Value.BibNumber.ToString());
                newItem.SubItems.Add(racer.Value.FirstName + " " + racer.Value.LastName);

                UnobservedRacersListView.Items.Add(newItem);
            }

        }

        private void UnsubscribeBtn_Click(object sender, EventArgs e)
        {

        }

        private void OtherRacersLbl_Click(object sender, EventArgs e)
        {

        }

        private void CreateRacerObserverBtn_Click(object sender, EventArgs e)
        {

        }

        private void UnobservedRacersListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
