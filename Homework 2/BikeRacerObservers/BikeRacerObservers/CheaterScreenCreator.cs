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
    public partial class CheaterScreenCreator : Form
    {
        private CheaterObserver _observer;
        public CheaterScreenCreator(CheaterObserver observer)
        {
            _observer = observer;

            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            _observer.SetName(NameTxt.Text);
            this.Close();
        }
    }
}
