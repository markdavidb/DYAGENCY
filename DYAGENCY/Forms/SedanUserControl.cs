using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DYAGENCY.Backend.Enums;


namespace DYAGENCY.Forms
{
    public partial class SedanUserControl : UserControl
    {

        public bool IsSunRoofChecked
        {
            get { return cbSunRoof.Checked; }
        }

        public eInteriorColor SelectedInteriorColor
        {
            get { return (eInteriorColor)cbInteriorColor.SelectedItem; }
        }

        public int SelectedPassengerCapacity
        {
            get { return int.Parse(cbPassengerCapacity.SelectedItem.ToString()); }
        }


        public SedanUserControl()
        {

            InitializeComponent();

            cbInteriorColor.DataSource = Enum.GetValues(typeof(eInteriorColor));
            cbPassengerCapacity.Items.Add("5");
            cbPassengerCapacity.Items.Add("6");
            cbPassengerCapacity.Items.Add("7");
            cbPassengerCapacity.SelectedIndex = 0;


        }

       


        private void cbSunRoof_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbPassengerCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}