using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization; // Add this namespace
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{

    public partial class Dashboard : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }


        private Color defaultBorderColor = Color.Red;  // Set the default border color
        private Button selectedButton = null;  // Keep track of the currently selected button

        public Dashboard()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 100; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CultureInfo englishCulture = new CultureInfo("en-US");

            lbClock.Text = DateTime.Now.ToString("HH:mm:ss", englishCulture);
            lbDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy", englishCulture);
        }

  
    }
}
