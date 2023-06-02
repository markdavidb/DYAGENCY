using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class SUVUserControl : UserControl
    {

        public bool Is4x4
        {
            get { return check4x4.Checked; }
        }

        public int SelectedPassengerCapacitySUV
        {
            get { return int.Parse(cbPassengerCapacitySUV.SelectedItem.ToString()); }
        }
        public SUVUserControl()
        {
            InitializeComponent();
            cbPassengerCapacitySUV.Items.Add("5");
            cbPassengerCapacitySUV.Items.Add("6");
            cbPassengerCapacitySUV.Items.Add("7");
            cbPassengerCapacitySUV.SelectedIndex = 0;
        }

    }
}
