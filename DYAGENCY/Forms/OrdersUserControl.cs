using System.ComponentModel;
using System.Windows.Forms;
using System;
using DYAGENCY.Backend.Model;
using System.Drawing;
using System.Windows.Documents;
using System.Text;

namespace DYAGENCY.Forms
{
    public partial class OrdersUserControl : UserControl
    {

        private BindingList<SUV> suvList;
        private BindingList<Private> sedanList;
        private BindingList<ElectricCar> electricList;


        private string placeholderText = "Enter phone number...";
        private bool isPlaceholderActive = true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }



        Color headerColor = Color.FromArgb(109, 122, 224);

        public OrdersUserControl(BindingList<SUV> suvs, BindingList<Private> sedans, BindingList<ElectricCar> electrics)
        {
            InitializeComponent();

            suvList = suvs;
            sedanList = sedans;
            electricList = electrics;


            DeleteButton.Click -= DeleteButton_Click; // Unsubscribe first
            DeleteButton.Click += DeleteButton_Click; // Then subscribe again
            searchBox.TextChanged += searchBox_TextChanged_1;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;

            comboBox1.Items.Add("SUV");
            comboBox1.Items.Add("Sedan");
            comboBox1.Items.Add("Electric Car");
            comboBox1.SelectedIndex = 0;


            ShowPlaceholderText();


            // Remove the last row from the respective list


            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.EnableHeadersVisualStyles = false; // Disable default header styles
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68); // Set the background color of cells
            dataGridView1.DefaultCellStyle.ForeColor = Color.White; // Set the text color of cells
            dataGridView1.DefaultCellStyle.Font = new Font("Century Gothic", 9); // Set the font for cell text
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Set the alignment for cell text


            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 30, 68); // Set the background color of column headers
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Set the text color of column headers
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Bold); // Set the font for column header text

            dataGridView1.GridColor = Color.FromArgb(31, 30, 68); // Set the color of gridlines
            dataGridView1.BorderStyle = BorderStyle.None; // Remove the border around the DataGridView

            dataGridView1.RowHeadersVisible = false; // Hide the row headers

            // Customize the appearance of selected cells
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 62, 95); // Set the background color of selected cells
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White; // Set the text color of selected cells

            // Adjust column widths to fill the available space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            RefreshDataGridView();


        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (isPlaceholderActive)
            {
                ClearPlaceholderText();
            }
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text))
            {
                ShowPlaceholderText();
                RefreshDataGridView();

            }
        }

        private void ShowPlaceholderText()
        {
            searchBox.Text = placeholderText;
            searchBox.ForeColor = SystemColors.GrayText;
            isPlaceholderActive = true;
        }

        private void ClearPlaceholderText()
        {
            searchBox.Text = string.Empty;
            searchBox.ForeColor = SystemColors.WindowText;
            isPlaceholderActive = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {



            if (comboBox1.SelectedItem.ToString() == "SUV")
            {
                BindingList<SUV> suv = OrderManager.GetSpecificVehicles<SUV>();
                dataGridView1.DataSource = suv;

                CustomizeColumns(comboBox1.SelectedItem.ToString());

            }
            else if (comboBox1.SelectedItem.ToString() == "Sedan")
            {
                BindingList<Private> sedan = OrderManager.GetSpecificVehicles<Private>();
                dataGridView1.DataSource = sedan;
                CustomizeColumns(comboBox1.SelectedItem.ToString());




            }
            else if (comboBox1.SelectedItem.ToString() == "Electric Car")
            {
                BindingList<ElectricCar> electric = OrderManager.GetSpecificVehicles<ElectricCar>();

                dataGridView1.DataSource = electric;
                CustomizeColumns(comboBox1.SelectedItem.ToString());




            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event handler code for cell content click
        }

        private Vehicle GetSelectedVehicle()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Vehicle selectedVehicle = dataGridView1.SelectedRows[0].DataBoundItem as Vehicle;
                return selectedVehicle;
            }

            return null;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Vehicle selectedVehicle = GetSelectedVehicle();

            if (selectedVehicle != null)
            {
                // Display a confirmation dialog to ask the user if they want to delete the object
                DialogResult result = MessageBox.Show("Are you sure you want to cancel the order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    OrderManager.RemoveVehicle(selectedVehicle);
                    RefreshDataGridView();
                }
            }
        }

        private void btShowFullOrder_Click(object sender, EventArgs e)
        {
            // Check if a row is currently selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Retrieve the desired information from the selected row
                string manufacturer = selectedRow.Cells["Manufacturer"].Value?.ToString();
                string model = selectedRow.Cells["Model"].Value?.ToString();
                string year = selectedRow.Cells["Year"].Value?.ToString();
                string color = selectedRow.Cells["Color"].Value?.ToString();
                string firstName = selectedRow.Cells["firstName"].Value?.ToString();
                string lastName = selectedRow.Cells["lastName"].Value?.ToString();
                string phoneNumber = selectedRow.Cells["phoneNumber"].Value?.ToString();

                DateTime? estimatedDeliveryDateValue = selectedRow.Cells["date"].Value as DateTime?;

                // Check if any of the values are null or empty
                if (!string.IsNullOrEmpty(manufacturer) &&
                    !string.IsNullOrEmpty(model) &&
                    !string.IsNullOrEmpty(year) &&
                    !string.IsNullOrEmpty(color) &&
                    !string.IsNullOrEmpty(firstName) &&
                    !string.IsNullOrEmpty(lastName) &&
                    estimatedDeliveryDateValue != null)
                {

                    string estimatedDeliveryDateString = estimatedDeliveryDateValue.Value.ToString("yyyy-MM-dd");


                    // Create a StringBuilder to store the information
                    StringBuilder information = new StringBuilder();
                    if (comboBox1.Text == "SUV")
                    {
                        string hp = selectedRow.Cells["HP"].Value.ToString();
                        string fueltype = selectedRow.Cells["FuelType"].Value.ToString();
                        string kpl = selectedRow.Cells["kpl"].Value.ToString();
                        string enginecapacity = selectedRow.Cells["EngineCapacity"].Value.ToString();
                        string has4x4 = selectedRow.Cells["Has4x4"].Value.ToString();
                        string seatingcapacity = selectedRow.Cells["SeatingCapacity"].Value.ToString();

                        information.AppendLine($"First Name: {firstName}");
                        information.AppendLine($"Last Name: {lastName}");
                        information.AppendLine($"Phone Numbeer: {phoneNumber}");
                        information.AppendLine($"Manufacturer: {manufacturer}");
                        information.AppendLine($"Model: {model}");
                        information.AppendLine($"Year: {year}");
                        information.AppendLine($"Color: {color}");

                        information.AppendLine($"HP: {hp}");
                        information.AppendLine($"Fuel Type; {fueltype}");
                        information.AppendLine($"KM/L: {kpl}");
                        information.AppendLine($"Engine CC: {enginecapacity}");
                        information.AppendLine($"Has 4WD: {has4x4}");
                        information.AppendLine($"Seating Capacity: {seatingcapacity}");
                        information.AppendLine($"Estimated Delivery Time: {estimatedDeliveryDateString}");

                    }
                    else if (comboBox1.Text == "Sedan")
                    {
                        string hp = selectedRow.Cells["HP"].Value.ToString();
                        string fueltype = selectedRow.Cells["FuelType"].Value.ToString();
                        string kpl = selectedRow.Cells["kpl"].Value.ToString();
                        string passengercapacity = selectedRow.Cells["PassengerCapacity"].Value.ToString();
                        string hassunroof = selectedRow.Cells["hasSunroof"].Value.ToString();
                        string interiorcolor = selectedRow.Cells["InteriorColor"].Value.ToString();

                        information.AppendLine($"First Name: {firstName}");
                        information.AppendLine($"Last Name: {lastName}");
                        information.AppendLine($"Phone Numbeer: {phoneNumber}");

                        information.AppendLine($"Manufacturer: {manufacturer}");
                        information.AppendLine($"Model: {model}");
                        information.AppendLine($"Year: {year}");
                        information.AppendLine($"Color: {color}");

                        information.AppendLine($"HP: {hp}");
                        information.AppendLine($"Fuel Type; {fueltype}");
                        information.AppendLine($"KM/L: {kpl}");
                        information.AppendLine($"Passenger Capacity: {passengercapacity}");
                        information.AppendLine($"Has Sun Roof: {hassunroof}");
                        information.AppendLine($"Interior Color: {interiorcolor}");
                        information.AppendLine($"Estimated Delivery Time: {estimatedDeliveryDateString}");


                    }
                    else if (comboBox1.Text == "Electric Car")
                    {
                        string hp = selectedRow.Cells["HP"].Value.ToString();
                        string HP = selectedRow.Cells["HP"].Value.ToString();
                        string maxKm = selectedRow.Cells["maxKm"].Value.ToString();
                        string batteryPrice = selectedRow.Cells["batteryPrice"].Value.ToString();
                        string batteryLife = selectedRow.Cells["batteryLife"].Value.ToString();
                        string batteryWarrenty = selectedRow.Cells["batteryWarrenty"].Value.ToString();

                        information.AppendLine($"First Name: {firstName}");
                        information.AppendLine($"Last Name: {lastName}");
                        information.AppendLine($"Phone Numbeer: {phoneNumber}");

                        information.AppendLine($"Manufacturer: {manufacturer}");
                        information.AppendLine($"Model: {model}");
                        information.AppendLine($"Year: {year}");
                        information.AppendLine($"Color: {color}");
                        information.AppendLine($"HP: {HP}");
                        information.AppendLine($"Max KM; {maxKm}");
                        information.AppendLine($"Battery Replace Price: {batteryPrice}");
                        information.AppendLine($"Battery Life: {batteryLife} Years");
                        information.AppendLine($"Warrenrty: {batteryWarrenty} Years");
                        information.AppendLine($"Estimated Delivery Time: {estimatedDeliveryDateString}");



                    }

                    // Display the information in a MessageBox or any other desired way
                    MessageBox.Show(information.ToString(), "Full Order Information");
                }
                else
                {
                    MessageBox.Show("No valid order selected.", "Information");
                }
            }
            else
            {
                MessageBox.Show("No order selected.", "Information");
            }
        }


        private void searchBox_TextChanged_1(object sender, EventArgs e)
        {
            string searchTerm = searchBox.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                RefreshDataGridView();
                return;
            }

            if (comboBox1.SelectedItem.ToString() == "SUV")
            {
                BindingList<SUV> suv = OrderManager.GetSpecificVehiclesByCriterion<SUV>(searchTerm);
                dataGridView1.DataSource = suv;
                CustomizeColumns(comboBox1.SelectedItem.ToString());


            }
            else if (comboBox1.SelectedItem.ToString() == "Sedan")
            {
                BindingList<Private> sedan = OrderManager.GetSpecificVehiclesByCriterion<Private>(searchTerm);
                dataGridView1.DataSource = sedan;
                CustomizeColumns(comboBox1.SelectedItem.ToString());

            }
            else if (comboBox1.SelectedItem.ToString() == "Electric Car")
            {
                BindingList<ElectricCar> electric = OrderManager.GetSpecificVehiclesByCriterion<ElectricCar>(searchTerm);
                dataGridView1.DataSource = electric;
                CustomizeColumns(comboBox1.SelectedItem.ToString());


            }
        }


        private void CustomizeColumns(string selectedItem)
        {
            if (selectedItem == "SUV")
            {
                // Customize individual column properties
                dataGridView1.Columns["price"].HeaderText = "Price";
                dataGridView1.Columns["manuFacturer"].HeaderText = "Manufacturer";
                dataGridView1.Columns["year"].HeaderText = "Year";
                dataGridView1.Columns["model"].HeaderText = "Model";
                dataGridView1.Columns["color"].HeaderText = "Color";
                dataGridView1.Columns["firstName"].HeaderText = "First Name";
                dataGridView1.Columns["lastName"].HeaderText = "Last Name";
                dataGridView1.Columns["date"].HeaderText = "Estimated Delivery Time";
                dataGridView1.Columns["phoneNumber"].HeaderText = "Phone Number";

                dataGridView1.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd";

                // Set the display order of columns
                dataGridView1.Columns["firstName"].DisplayIndex = 0;
                dataGridView1.Columns["lastName"].DisplayIndex = 1;
                dataGridView1.Columns["Manufacturer"].DisplayIndex = 2;
                dataGridView1.Columns["Model"].DisplayIndex = 3;
                dataGridView1.Columns["Year"].DisplayIndex = 4;
                dataGridView1.Columns["Color"].DisplayIndex = 5;
                dataGridView1.Columns["Price"].DisplayIndex = 6;

                // Hide unnecessary columns
                dataGridView1.Columns["HP"].Visible = false;
                dataGridView1.Columns["FuelType"].Visible = false;
                dataGridView1.Columns["kpl"].Visible = false;
                dataGridView1.Columns["EngineCapacity"].Visible = false;
                dataGridView1.Columns["Has4x4"].Visible = false;
                dataGridView1.Columns["SeatingCapacity"].Visible = false;
            }
            else if (selectedItem == "Sedan")
            {
                dataGridView1.Columns["price"].HeaderText = "Price";
                dataGridView1.Columns["manuFacturer"].HeaderText = "Manufacturer";
                dataGridView1.Columns["year"].HeaderText = "Year";
                dataGridView1.Columns["model"].HeaderText = "Model";
                dataGridView1.Columns["color"].HeaderText = "Color";
                dataGridView1.Columns["firstName"].HeaderText = "First Name";
                dataGridView1.Columns["lastName"].HeaderText = "Last Name";
                dataGridView1.Columns["phoneNumber"].HeaderText = "Phone Number";

                // Set the display order of columns
                dataGridView1.Columns["firstName"].DisplayIndex = 0;
                dataGridView1.Columns["lastName"].DisplayIndex = 1;
                dataGridView1.Columns["Manufacturer"].DisplayIndex = 2;
                dataGridView1.Columns["Model"].DisplayIndex = 3;
                dataGridView1.Columns["Year"].DisplayIndex = 4;
                dataGridView1.Columns["Color"].DisplayIndex = 5;
                dataGridView1.Columns["Price"].DisplayIndex = 6;

                // Hide unnecessary columns
                dataGridView1.Columns["HP"].Visible = false;
                dataGridView1.Columns["FuelType"].Visible = false;
                dataGridView1.Columns["kpl"].Visible = false;
                dataGridView1.Columns["EngineCapacity"].Visible = false;
                dataGridView1.Columns["PassengerCapacity"].Visible = false;
                dataGridView1.Columns["hasSunroof"].Visible = false;
                dataGridView1.Columns["InteriorColor"].Visible = false;
            }
            else if (selectedItem == "Electric Car")
            {
                dataGridView1.Columns["price"].HeaderText = "Price";
                dataGridView1.Columns["manuFacturer"].HeaderText = "Manufacturer";
                dataGridView1.Columns["year"].HeaderText = "Year";
                dataGridView1.Columns["model"].HeaderText = "Model";
                dataGridView1.Columns["color"].HeaderText = "Color";
                dataGridView1.Columns["firstName"].HeaderText = "First Name";
                dataGridView1.Columns["lastName"].HeaderText = "Last Name";
                dataGridView1.Columns["phoneNumber"].HeaderText = "Phone Number";

                // Set the display order of columns
                dataGridView1.Columns["firstName"].DisplayIndex = 0;
                dataGridView1.Columns["lastName"].DisplayIndex = 1;
                dataGridView1.Columns["Manufacturer"].DisplayIndex = 2;
                dataGridView1.Columns["Model"].DisplayIndex = 3;
                dataGridView1.Columns["Year"].DisplayIndex = 4;
                dataGridView1.Columns["Color"].DisplayIndex = 5;
                dataGridView1.Columns["Price"].DisplayIndex = 6;

                // Hide unnecessary columns
                dataGridView1.Columns["HP"].Visible = false;
                dataGridView1.Columns["maxKm"].Visible = false;
                dataGridView1.Columns["batteryPrice"].Visible = false;
                dataGridView1.Columns["batteryLife"].Visible = false;
                dataGridView1.Columns["batteryWarrenty"].Visible = false;
            }
        }

    }
}
