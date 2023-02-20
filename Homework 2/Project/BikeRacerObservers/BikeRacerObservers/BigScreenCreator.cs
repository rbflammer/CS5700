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
    // Helper form used in the creation of a BigScreen and BigScreenObserver
    // Used to get the name of the new observer and screen
    public partial class BigScreenCreator : Form
    {
        private BigScreenObserver _observer;
        public BigScreenCreator(BigScreenObserver observer)
        {
            _observer= observer;

            InitializeComponent();
        }

        // Sets the name of the new observer
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            _observer.SetName(NameTxt.Text);
            this.Close();
        }
    }
}
