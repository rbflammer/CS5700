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
    public partial class BigScreenCreator : Form
    {
        private BigScreenObserver _observer;
        public BigScreenCreator(BigScreenObserver observer)
        {
            _observer= observer;

            InitializeComponent();
        }

        private void BigScreenCreator_Load(object sender, EventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            _observer.SetName(NameTxt.Text);
            this.Close();
        }
    }
}
