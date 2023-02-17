﻿using System;
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

        private void CheaterDisplay_Load(object sender, EventArgs e)
        {
            Text = _name;
        }

        public void Update(List<(Racer cheater, Racer cheatedWith)> cheaters)
        {
            _cheaters= cheaters;

            updateScreens();
        }

        public void AddObserver(CheaterObserver observer)
        {
            _observer = observer;
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Update(_observer.GetCheaters());

            updateScreens();
        }
    }
}
