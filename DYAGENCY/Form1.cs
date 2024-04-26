
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using DYAGENCY.Backend.Model;
using DYAGENCY.Forms;
using System.Runtime.InteropServices;

namespace DYAGENCY
{
    public partial class Form1 : Form
    {

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;


        private Dashboard dashboardUserControl;
        private OrdersUserControl ordersUserControl;
        private AvailableCarsUserControl availableCarsUserControl;
        private GasolineUserControl gasolineUserControl;
        private ElectircCarUserControl electricCarUserControl;

        private UserControl activeUserControl; // Keep track of the active UserControl


        private BindingList<SUV> suvs;
        private BindingList<Private> privates;
        private BindingList<ElectricCar> electrics;


        private Dictionary<Type, UserControl> loadedUserControls;

        public Form1()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            loadedUserControls = new Dictionary<Type, UserControl>();



            // Initialize all the user controls
            ordersUserControl = new OrdersUserControl(suvs, privates, electrics);
            dashboardUserControl = new Dashboard();
            availableCarsUserControl = new AvailableCarsUserControl();
            gasolineUserControl = new GasolineUserControl(suvs, privates);
            electricCarUserControl = new ElectircCarUserControl(electrics);

            // Add all the user controls to the panel
            panelDesktop.Controls.Add(dashboardUserControl);
            panelDesktop.Controls.Add(ordersUserControl);
            panelDesktop.Controls.Add(availableCarsUserControl);
            panelDesktop.Controls.Add(gasolineUserControl);
            panelDesktop.Controls.Add(electricCarUserControl);

            activeUserControl = dashboardUserControl;



            // Add all the user controls to the loadedUserControls dictionary
            loadedUserControls.Add(typeof(Dashboard), dashboardUserControl);
            loadedUserControls.Add(typeof(OrdersUserControl), ordersUserControl);
            loadedUserControls.Add(typeof(AvailableCarsUserControl), availableCarsUserControl);
            loadedUserControls.Add(typeof(GasolineUserControl), gasolineUserControl);
            loadedUserControls.Add(typeof(ElectircCarUserControl), electricCarUserControl);

            customizeDesing();

            Controls.Add(ordersUserControl);


            this.FormClosing += new FormClosingEventHandler(OrderManager.SaveVehicles);

            OpenUserControl(dashboardUserControl);
            btnDashboard_Click(btnDashboard, EventArgs.Empty); // Simulate button click


        }


        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void customizeDesing()
        {
            panel1.Visible = false;

        }

        private void hideMenu()
        {

            if (panel1.Visible == true)
                panel1.Visible = false;

        }

        private void showSubMenu(Panel subMenu)
        {

            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void OpenUserControl(UserControl userControl)
        {
            Type userControlType = userControl.GetType();

            if (activeUserControl?.GetType() != userControlType)
            {
                if (!loadedUserControls.ContainsKey(userControlType))
                {
                    loadedUserControls.Add(userControlType, userControl);
                }

                panelDesktop.Controls.Clear();
                panelDesktop.Controls.Add(userControl);
                userControl.Dock = DockStyle.Fill;

                activeUserControl = userControl;
            }

            userControl.Visible = true;
        }



        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void ActivateButtonSub(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
               
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }




        private void btnDashboard_Click(object sender, EventArgs e)
        {
            hideMenu();

            ActivateButton(sender, RGBColors.color1);
            OpenUserControl(dashboardUserControl);

        }


        private void btnOrders_Click(object sender, EventArgs e)
        {
            hideMenu();
            lbTitleChildForm.Text = "Orders";
            ActivateButton(sender, RGBColors.color2);
            OpenUserControl(ordersUserControl);

            ordersUserControl.RefreshDataGridView();
            ordersUserControl.Refresh();
        }





        private void btnAvailableCars_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            lbTitleChildForm.Text = "Available Cars";
            OpenUserControl(dashboardUserControl);
            showSubMenu(panel1);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            hideMenu();
            ActivateButton(sender, RGBColors.color5);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {

            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lbTitleChildForm.Text = "Dashboard";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        private void btnGasoline_Click(object sender, EventArgs e)
        {
            lbTitleChildForm.Text = "Gasoline Car";
            OpenUserControl(gasolineUserControl);
            ActivateButtonSub(sender, RGBColors.color1);

        }

        private void btnElectricCar_Click(object sender, EventArgs e)
        {
            lbTitleChildForm.Text = "Electric Car";
            OpenUserControl(electricCarUserControl);
            ActivateButtonSub(sender, RGBColors.color4);

        }



        private void btnExit_Click_2(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
