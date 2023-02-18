using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeRacerObservers
{
    public partial class FileSelector : Form
    {
        public FileSelector()
        {
            InitializeComponent();
        }

        private void GroupBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog groupOfd = new OpenFileDialog()
            {
                Title = "Find Group CSV File",

                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (groupOfd.ShowDialog() == DialogResult.OK)
            {
                GroupFileTxt.Text = groupOfd.FileName;
            }
        }

        private void RacerBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog racerOfd = new OpenFileDialog()
            {
                Title = "Find Racer CSV File",

                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (racerOfd.ShowDialog() == DialogResult.OK)
            {
                RacerFileTxt.Text = racerOfd.FileName;
            }
        }

        private void SensorBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog sensorOfd = new OpenFileDialog()
            {
                Title = "Find Sensor CSV File",

                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (sensorOfd.ShowDialog() == DialogResult.OK)
            {
                SensorFileTxt.Text = sensorOfd.FileName;
            }
        }

        private void displayError()
        {
            ErrorLbl.Text = "Please enter valid file locations in all fields.";
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (!File.Exists(GroupFileTxt.Text) || !File.Exists(RacerFileTxt.Text) || !File.Exists(SensorFileTxt.Text))
            {
                displayError();
                return;
            }

            ObserverSetup observerSetup = new ObserverSetup(GroupFileTxt.Text, RacerFileTxt.Text, SensorFileTxt.Text);
            observerSetup.Show();
            this.Hide();
        }

        private void FileSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
