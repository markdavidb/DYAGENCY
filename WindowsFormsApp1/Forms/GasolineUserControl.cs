using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Backend.Enums;
using WindowsFormsApp1.Backend;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1.Controls;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Backend.Model;
using WindowsFormsApp1.Enums.Gasoline.BMW;
using WindowsFormsApp1.Enums.Gasoline.Mercedes;
using System.Windows.Documents;
using WindowsFormsApp1.Enums.ElectricsCar.BMW;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class GasolineUserControl : UserControl
    {


        private BindingList<SUV> suvs;
        private BindingList<Private> privates;
        private BindingList<ElectricCar> electrics;

        private SedanUserControl sedanUserControl;
        private SUVUserControl suvUserControl;
        private OrdersUserControl ordersUserControl;


        private Image carPicture;

        public event EventHandler ObjectAdded;


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }

        public GasolineUserControl(BindingList<SUV> suvs, BindingList<Private> privates)
        {
            InitializeComponent();
            DoubleBuffered = true;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);


            this.suvs = suvs ?? new BindingList<SUV>();
            this.privates = privates ?? new BindingList<Private>();


            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy"; // Customize the format as needed
            dateTimePicker.MinDate = DateTime.Now;


            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;

            cbType.Items.Add("SUV");
            cbType.Items.Add("Sedan");


            UpdatePriceLabel();


            cbType.SelectedIndexChanged += cbType_SelectedIndexChanged;


            // Attach event handlers for other ComboBoxes
            cbManufacturer.SelectedIndexChanged += cbManufacturer_SelectedIndexChanged;
            cbModifcations.SelectedIndexChanged += cbModifcations_SelectedIndexChanged;
            cbModel.SelectedIndexChanged += cbModel_SelectedIndexChanged;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            tbPhone.KeyPress += tbPhone_KeyPress;
            tbLastName.KeyPress += tbFirstName_KeyPress;

            cbType.SelectedIndex = 0;

            cbManufacturer.DataSource = Enum.GetValues(typeof(eManufacturer));
            cbYear.DataSource = Enum.GetValues(typeof(eYears))
                         .Cast<int>()
                         .Select(y => y.ToString())
                         .ToList();

            List<string> sedanMercedesValues = Enum.GetNames(typeof(eSedanMercedes))
            .Select(name => name.Replace("_", " "))
               .ToList();


            cbColor.DataSource = Enum.GetValues(typeof(eColor));
            cbModifcations.DataSource = Enum.GetValues(typeof(eModifications))
                .Cast<eModifications>()
                .Select(m => new { Value = m, Display = GetEnumDescription(m) })
                .ToList();
            cbModifcations.DisplayMember = "Display";
            cbModifcations.ValueMember = "Value";

            cbManufacturer.DataSource = Enum.GetValues(typeof(eManufacturer));

            cbType_SelectedIndexChanged(cbType, EventArgs.Empty);


        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute != null ? attribute.Description : value.ToString();
        }


        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected manufacturer
            eManufacturer selectedManufacturer = (eManufacturer)cbManufacturer.SelectedItem;

            // Get the selected type
            string selectedType = cbType.SelectedItem?.ToString();

            // Clear the existing items in the model dropdown by setting the DataSource to null
            cbModel.DataSource = null;
            cbModel.Items.Clear();


            // Populate the model dropdown based on the selected manufacturer and type
            if (selectedManufacturer == eManufacturer.Mercedes)
            {
                if (selectedType == "SUV")
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eSUVMercedes));
                }
                else if (selectedType == "Sedan")
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eSedanMercedes));
                }
            }
            else if (selectedManufacturer == eManufacturer.BMW)
            {
                if (selectedType == "SUV")
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eSUVBMW));
                }
                else if (selectedType == "Sedan")
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eSedanBMW));
                }
            }

            // Select the first item in the model dropdown if available
            if (cbModel.Items.Count > 0)
            {
                cbModel.SelectedIndex = 0;
            }
            UpdatePriceLabel();
            givePicture();
            UpdateCarInfo();

        }




        public void UpdateCarInfo() // updaing the car label info according to the model
        {
            string selectedModel = cbModel.SelectedItem?.ToString();
            string selectedManufacturer = cbManufacturer.SelectedItem?.ToString();
            string selectedType = cbType.SelectedItem?.ToString();
            string selectedModification = cbModifcations.SelectedIndex == 0 ? "Standard" : "High level";
            double enginePower = 0;
            int hp = 0;
            int fuel = 0;
            double km = 0;

            if (selectedModel != null && selectedManufacturer != null && selectedType != null && cbYear.SelectedItem != null)
            {
                int year;
                if (int.TryParse(cbYear.SelectedItem.ToString(), out year))
                {
                    if (selectedManufacturer.StartsWith("BMW"))
                    {
                        if (selectedType == "Sedan")
                        {
                            // Parse the selected BMW model
                            if (Enum.TryParse(selectedModel, out eSedanBMW bmwModel))
                            {
                                Enums.Gasoline.BMW.CarDetails bmwDetails = Enums.Gasoline.BMW.CarDetailsProvider.GetCarDetails(bmwModel, year);
                                if (bmwDetails != null)
                                {
                                    enginePower = bmwDetails.EngineDisplacement;
                                    hp = bmwDetails.Horsepower;
                                    fuel = bmwDetails.FuelType;
                                    km = bmwDetails.FuelEfficiency;
                                }
                            }
                        }
                        else if (selectedType == "SUV")
                        {
                            if (Enum.TryParse(selectedModel, out eSUVBMW bmwModel))
                            {
                                Enums.Gasoline.BMW.CarDetails bmwDetails = Enums.Gasoline.BMW.CarDetailsProvider.GetCarDetails(bmwModel, year);
                                if (bmwDetails != null)
                                {
                                    enginePower = bmwDetails.EngineDisplacement;
                                    hp = bmwDetails.Horsepower;
                                    fuel = bmwDetails.FuelType;
                                    km = bmwDetails.FuelEfficiency;
                                }
                            }
                        }
                    }
                    else if (selectedManufacturer.StartsWith("Mercedes"))
                    {
                        // Parse the selected Mercedes model
                        if (selectedType == "Sedan")
                        {
                            if (Enum.TryParse(selectedModel, out eSedanMercedes mercedesModel))
                            {
                                Enums.Gasoline.Mercedes.CarDetails mercedesDetails = Enums.Gasoline.Mercedes.CarDetailsProvider.GetCarDetails(mercedesModel, year);
                                if (mercedesDetails != null)
                                {
                                    enginePower = mercedesDetails.EngineDisplacement;
                                    hp = mercedesDetails.Horsepower;
                                    fuel = mercedesDetails.FuelType;
                                    km = mercedesDetails.FuelEfficiency;
                                }
                            }
                        }
                        else if (selectedType == "SUV")
                        {
                            if (Enum.TryParse(selectedModel, out eSUVMercedes mercedesModel))
                            {
                                Enums.Gasoline.Mercedes.CarDetails mercedesDetails = Enums.Gasoline.Mercedes.CarDetailsProvider.GetCarDetails(mercedesModel, year);
                                if (mercedesDetails != null)
                                {
                                    enginePower = mercedesDetails.EngineDisplacement;
                                    hp = mercedesDetails.Horsepower;
                                    fuel = mercedesDetails.FuelType;
                                    km = mercedesDetails.FuelEfficiency;
                                }
                            }
                        }
                    }

                    lbEngineCapacityLive.Text = enginePower.ToString();
                    lbHP.Text = hp.ToString();
                    lbFuelType.Text = fuel.ToString();
                    lbKMperLiter.Text = km.ToString();
                }
            }
        }



        private void cbModifcations_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCarInfo();
            UpdatePriceLabel();

        }

        public void givePicture()
        {

            // Get the selected model
            string selectedModel = cbModel.SelectedItem?.ToString();
            string selectedType = cbType.SelectedItem?.ToString();
            string selectedColor = cbColor.SelectedItem?.ToString();

            if (selectedModel != null)
            {

                System.Drawing.Image carPicture = null;

                if (selectedType == "SUV")
                {
                    SUV suv = new SUV();

                    carPicture = suv.DisplayCarPicture(selectedModel, selectedColor, cbModel);
                }
                else if (selectedType == "Sedan")
                {
                    Private sedan = new Private();
                    carPicture = sedan.DisplayCarPicture(selectedModel, selectedColor, cbModel);
                }

                if (carPicture != null)
                {
                    pictureBox.Image = carPicture;
                    // Add SUV or Sedan to BindingList here if necessary
                }
            }
        }
        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCarInfo();
            UpdatePriceLabel();
            givePicture();

        }


        private void btSubmitOrder_Click(object sender, EventArgs e) // Submit order
        {

            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string selectedPhone = tbPhone.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(selectedPhone))
            {
                MessageBox.Show("Please enter costumers details.");
                return; // Stop further execution
            }

            string manufacturer = cbManufacturer.Text;
            string model = cbModel.Text;
            int year = int.Parse(cbYear.Text);
            double price = int.Parse(lbPrice.Text);
            string selectedModification = cbModifcations.SelectedItem.ToString();
            bool carModifications = (selectedModification == "High level");
            string color = cbColor.Text;
            int HP = int.Parse(lbHP.Text);
            double engineCapacity = double.Parse(lbEngineCapacityLive.Text);
            int fuelType = int.Parse(lbFuelType.Text);
            int kpl = int.Parse(lbKMperLiter.Text);
            DateTime selectedDate = dateTimePicker.Value;


            Vehicle vehicle = null; // Declare the vehicle object outside the if-else blocks

            if (cbType.SelectedItem.ToString() == "SUV")
            {
                int seatingCapacity = suvUserControl.SelectedPassengerCapacitySUV;
                bool has4x4 = suvUserControl.Is4x4;

                // Use the SUV object as needed
                SUV suv = new SUV(selectedPhone, selectedDate, firstName, lastName, manufacturer, model, color, year, price, fuelType, HP, engineCapacity, kpl, seatingCapacity, has4x4);
                OrderManager.AddVehicle(suv);
                suvs.Add(suv);

                vehicle = suv;
            }
            else if (cbType.SelectedItem.ToString() == "Sedan")
            {
                string selectedInteriorColor = sedanUserControl.SelectedInteriorColor.ToString();
                int passengerCapacity = sedanUserControl.SelectedPassengerCapacity;
                bool hasSunroof = sedanUserControl.IsSunRoofChecked;

                // Use the Private object as needed
                Private sedan = new Private(selectedPhone, selectedDate, firstName, lastName, manufacturer, model, color, year, price, fuelType, HP, engineCapacity, kpl, passengerCapacity, hasSunroof, selectedInteriorColor);
                OrderManager.AddVehicle(sedan);
                privates.Add(sedan);

                vehicle = sedan;
            }


            if (vehicle != null)
            {
                MessageBox.Show("Order submitted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to submit order. Please check the selected vehicle type.");
            }

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbManufacturer.SelectedItem != null)
            {
                eManufacturer selectedManufacturer = (eManufacturer)cbManufacturer.SelectedItem;
                string selectedType = cbType.SelectedItem.ToString();

                panelType.Controls.Clear();

                if (selectedType == "SUV")
                {
                    if (suvUserControl == null)
                    {
                        suvUserControl = new SUVUserControl();
                    }
                    suvUserControl.Dock = DockStyle.Fill;
                    panelType.Controls.Add(suvUserControl);

                    if (selectedManufacturer == eManufacturer.Mercedes)
                    {

                        cbModel.DataSource = Enum.GetValues(typeof(eSUVMercedes)).Cast<eSUVMercedes>().ToList();
                    }
                    else if (selectedManufacturer == eManufacturer.BMW)
                    {
                        cbModel.DataSource = Enum.GetValues(typeof(eSUVBMW)).Cast<eSUVBMW>().ToList();
                    }
                }
                else if (selectedType == "Sedan")
                {
                    if (sedanUserControl == null)
                    {
                        sedanUserControl = new SedanUserControl();
                    }
                    sedanUserControl.Dock = DockStyle.Fill;
                    panelType.Controls.Add(sedanUserControl);

                    if (selectedManufacturer == eManufacturer.Mercedes)
                    {
                        cbModel.DataSource = Enum.GetValues(typeof(eSedanMercedes)).Cast<eSedanMercedes>().ToList();
                    }
                    else if (selectedManufacturer == eManufacturer.BMW)
                    {
                        cbModel.DataSource = Enum.GetValues(typeof(eSedanBMW)).Cast<eSedanBMW>().ToList();
                    }
                }
                UpdatePriceLabel();
                UpdateCarInfo();

            }
        }


        private void lbPrice_Click(object sender, EventArgs e)
        {

            UpdatePriceLabel();

        }




        private void UpdatePriceLabel()
        {
            if (cbManufacturer.SelectedItem != null && cbType.SelectedItem != null && cbModel.SelectedItem != null && cbYear.SelectedItem != null)
            {
                eManufacturer selectedManufacturer = (eManufacturer)cbManufacturer.SelectedItem;
                string selectedType = cbType.SelectedItem.ToString();

                if (selectedType == "SUV")
                {
                    if (selectedManufacturer == eManufacturer.Mercedes)
                    {
                        eSUVMercedes selectedModel = (eSUVMercedes)cbModel.SelectedItem;
                        int basePrice = (int)selectedModel;
                        int price = basePrice + GetYearAdjustment();

                        if (cbModifcations.Text == "High Level")
                        {
                            // Add the additional amount for high-level modification
                            price += 15000; 
                        }

                        lbPrice.Text = price.ToString();
                    }
                    else if (selectedManufacturer == eManufacturer.BMW)
                    {
                        eSUVBMW selectedModel = (eSUVBMW)cbModel.SelectedItem;
                        int basePrice = (int)selectedModel;
                        int price = basePrice + GetYearAdjustment();

                        if (cbModifcations.Text == "High Level")
                        {
                           
                            price += 15000; 
                        }

                        lbPrice.Text = price.ToString();
                    }
                }
                else if (selectedType == "Sedan")
                {
                    if (selectedManufacturer == eManufacturer.Mercedes)
                    {
                        eSedanMercedes selectedModel = (eSedanMercedes)cbModel.SelectedItem;
                        int basePrice = (int)selectedModel;
                        int price = basePrice + GetYearAdjustment();

                        if (cbModifcations.Text == "High Level")
                        {
                          
                            price += 15000; 
                        }

                        lbPrice.Text = price.ToString();
                    }
                    else if (selectedManufacturer == eManufacturer.BMW)
                    {
                        eSedanBMW selectedModel = (eSedanBMW)cbModel.SelectedItem;
                        int basePrice = (int)selectedModel;
                        int price = basePrice + GetYearAdjustment();

                        if (cbModifcations.Text == "High Level")
                        {
                           
                            price += 15000;
                        }

                        lbPrice.Text = price.ToString();
                    }
                }
            }
            else
            {
                lbPrice.Text = string.Empty; // Clear the price label if any selection is null
            }
        }




        private int GetYearAdjustment() // This method is used to adjust the price based on the selected year
        {
            int yearAdjustment = 0;

            if (cbYear.SelectedItem != null && int.TryParse(cbYear.SelectedItem.ToString(), out int selectedYear))
            {
                if (selectedYear == (int)eYears.Year2023)
                {
                    yearAdjustment = 20000;
                }
                else if (selectedYear == (int)eYears.Year2022)
                {
                    yearAdjustment = 15000;
                }

            }

            return yearAdjustment;
        }


        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();
            UpdateCarInfo();

        }


        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Block the input if it is not a letter, space, or control character
            }

            if (tbFirstName.Text.Length >= 16 && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                e.Handled = true; // Block the input if the length is already 16 and it's not a backspace (\b) or space character
            }
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block the input if it is not a digit or control character
            }

            if (tbPhone.Text.Length >= 10 && e.KeyChar != '\b')
            {
                e.Handled = true; // Block the input if the length is already 10 and it's not a backspace (\b)
            }
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block the input if it is not a letter or control character
            }

            if (tbLastName.Text.Length >= 16 && e.KeyChar != '\b')
            {
                e.Handled = true; // Block the input if the length is already 32 and it's not a backspace (\b)
            }
        }


        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tbPhone.Text.Length > 10)
            {
                tbPhone.Text = tbPhone.Text.Substring(0, 10); // Limit the text to the first 10 characters
            }
        }


        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
            if (tbFirstName.Text.Length > 16)
            {
                tbFirstName.Text = tbFirstName.Text.Substring(0, 16); // Limit the text to the first 16 characters
            }
        }
        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            if (tbFirstName.Text.Length > 16)
            {
                tbFirstName.Text = tbLastName.Text.Substring(0, 32); // Limit the text to the first 32 characters
            }
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            givePicture();
        }

        private void cbModifcations_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           UpdatePriceLabel();
        }

        private void tbFirstName_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
