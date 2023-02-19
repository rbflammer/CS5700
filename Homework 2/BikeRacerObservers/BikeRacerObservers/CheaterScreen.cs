using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    // Form to display observed cheaters from an observer
    public partial class CheaterScreen : Form
    {
        private List<(Racer cheater, Racer cheatedWith)> _cheaters;
        private string _name;
        private CheaterObserver _observer;
        public CheaterScreen(string name)
        {
            _cheaters = new List<(Racer cheater, Racer cheatedWith)>();

            _name = name;
            InitializeComponent();
        }

        // Sets the name of the window
        private void CheaterDisplay_Load(object sender, EventArgs e)
        {
            Text = _name;
        }

        // Updates the screen with new cheater information
        public void Update(List<(Racer cheater, Racer cheatedWith)> cheaters)
        {
            _cheaters= cheaters;

            updateScreens();
        }
        
        // Sets the observer to this screen
        public void AddObserver(CheaterObserver observer)
        {
            _observer = observer;
        }

        // Updates the screen with new cheater information
        private void updateScreens() 
        {
            CheatersListView.Items.Clear();
            CheatingWithListView.Items.Clear();
            foreach ((Racer cheater, Racer cheatedWith) cheaterCombo in _cheaters)
            {
                Racer cheater = cheaterCombo.cheater;
                Racer cheatedWith = cheaterCombo.cheatedWith;

                ListViewItem newItem = new ListViewItem(cheater.BibNumber.ToString());
                newItem.SubItems.Add(cheater.LastName + ", " + cheater.FirstName);
                if (cheater.CurrentSensorNumber != null)
                {
                    newItem.SubItems.Add(cheater.CurrentSensorNumber.ToString());
                    newItem.SubItems.Add(TimeSpan.FromMilliseconds((double)cheater.CurrentSensorTime - (double)cheater.StartTime).ToString(@"hh\:mm\:ss\.fff"));
                }

                CheatersListView.Items.Add(newItem);

                newItem = new ListViewItem(cheatedWith.BibNumber.ToString());
                newItem.SubItems.Add(cheatedWith.LastName + ", " + cheatedWith.FirstName);
                if (cheatedWith.CurrentSensorNumber != null)
                {
                    newItem.SubItems.Add(cheatedWith.CurrentSensorNumber.ToString());
                    newItem.SubItems.Add(TimeSpan.FromMilliseconds((double)cheatedWith.CurrentSensorTime - (double)cheatedWith.StartTime).ToString(@"hh\:mm\:ss\.fff"));
                }

                CheatingWithListView.Items.Add(newItem);
            }
        }
    }
}
