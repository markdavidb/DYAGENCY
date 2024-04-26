using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DYAGENCY.Enums;
using DYAGENCY.Backend.Enums;
using DYAGENCY.Enums.ElectricsCar.Mercedes;
using DYAGENCY.Enums.ElectricsCar.BMW;
using DYAGENCY.Backend.Model;
using DYAGENCY.Enums.Gasoline.BMW;
using DYAGENCY.Enums.Gasoline.Mercedes;
using DYAGENCY.Backend.Enums.ElectricsCar;
using DYAGENCY.Enums.ElectricsCar.Tesla;

namespace DYAGENCY.Forms
{
    public partial class ElectircCarUserControl : UserControl
    {

        private BindingList<ElectricCar> electrics;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }

        public ElectircCarUserControl(BindingList<ElectricCar> electric)
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.electrics = electrics ?? new BindingList<ElectricCar>();

            cbManufacturer.DataSource = Enum.GetValues(typeof(eManufactureElectric));
            cbYear.DataSource = Enum.GetValues(typeof(eElectricYears))
                .Cast<eElectricYears>()
                .Select(y => (int)y)
                .ToList();

            cbColor.DataSource = Enum.GetValues(typeof(eColor));
            cbModifications.DataSource = Enum.GetValues(typeof(eModifications))
                .Cast<eModifications>()
                .Select(m => new { Value = m, Display = GetEnumDescription(m) })
                .ToList();
            cbModifications.DisplayMember = "Display";
            cbModifications.ValueMember = "Value";

            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy"; // Customize the format as needed
            dateTimePicker.MinDate = DateTime.Now;

            electrics = new BindingList<ElectricCar>();

            cbManufacturer.SelectedIndexChanged += cbManufacturer_SelectedIndexChanged;

            cbManufacturer_SelectedIndexChanged(null, null);


            this.electrics = electrics;

        }

        private string GetEnumDescription(Enum value) 
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute != null ? attribute.Description : value.ToString();
        }


        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e) // updating model combobox according to manufacturer
        {
            if (cbManufacturer.SelectedItem != null)
            {
                eManufactureElectric selectedManufacturer = (eManufactureElectric)cbManufacturer.SelectedItem;

                if (selectedManufacturer == eManufactureElectric.Mercedes)
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eModelMercedes)).Cast<eModelMercedes>().ToList();
                }
                else if (selectedManufacturer == eManufactureElectric.BMW)
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eModelBMW)).Cast<eModelBMW>().ToList();
                }
                else if (selectedManufacturer == eManufactureElectric.Tesla)
                {
                    cbModel.DataSource = Enum.GetValues(typeof(eModelTesla)).Cast<eModelTesla>().ToList();
                }
            }

            UpdatePriceLabel();
            givePicture();
            UpdateCarInfo();
        }


        public void givePicture() // updating car picture
        {

            // Get the selected model
            string selectedModel = cbModel.SelectedItem?.ToString();
            string selectedManufacturer = cbManufacturer.SelectedItem?.ToString();
            string selectedColor = cbColor.SelectedItem?.ToString();

            if (selectedModel != null)
            {


                System.Drawing.Image carPicture = null;



                ElectricCar electric = new ElectricCar();
                carPicture = electric.DisplayCarPicture(selectedModel, selectedColor, cbModel);


                if (carPicture != null)
                {
                    pictureBox.Image = carPicture;
                    // Add SUV or Sedan to BindingList here if necessary
                }
            }
        }

        public void UpdateCarInfo() // updating car label info 
        {
            if (cbManufacturer.SelectedItem != null && cbModel.SelectedItem != null && cbYear.SelectedItem != null)
            {
                string selectedModel = cbModel.SelectedItem?.ToString();
                string selectedManufacturer = cbManufacturer.SelectedItem?.ToString();
                string selectedModification = cbModifications.SelectedIndex == 0 ? "Standard" : "High level";

                var maxKM = 0;
                var HP = 0;
                var batteryLife = 0;
                var batteryWarranty = 0;

                int selectedYear;
                if (int.TryParse(cbYear.SelectedItem?.ToString(), out selectedYear))
                {
                    if (selectedManufacturer.StartsWith("BMW"))
                    {
                        if (Enum.TryParse(selectedModel, out eModelBMW bmwModel))
                        {
                            Enums.ElectricsCar.BMW.CarDetails bmwDetails = Enums.ElectricsCar.BMW.CarDetailsProvider.GetCarDetails(bmwModel, selectedYear);
                            if (bmwDetails != null)
                            {
                                maxKM = bmwDetails.MaxKm;
                                HP = bmwDetails.Horsepower;
                                batteryLife = bmwDetails.BatteryLife;
                                batteryWarranty = bmwDetails.BatteryWarranty;
                            }
                        }
                    }
                    else if (selectedManufacturer.StartsWith("Mercedes"))
                    {
                        if (Enum.TryParse(selectedModel, out eModelMercedes mercedesModel))
                        {
                            Enums.ElectricsCar.Mercedes.CarDetails mercedesDetails = Enums.ElectricsCar.Mercedes.CarDetailsProvider.GetCarDetails(mercedesModel, selectedYear);
                            if (mercedesDetails != null)
                            {
                                maxKM = mercedesDetails.MaxKm;
                                HP = mercedesDetails.Horsepower;
                                batteryLife = mercedesDetails.BatteryLife;
                                batteryWarranty = mercedesDetails.BatteryWarranty;
                            }
                        }
                    }
                    else if (selectedManufacturer.StartsWith("Tesla"))
                    {
                        if (Enum.TryParse(selectedModel, out eModelTesla teslaModel))
                        {
                            Enums.ElectricsCar.Tesla.CarDetails teslaDetails = Enums.ElectricsCar.Tesla.CarDetailsProvider.GetCarDetails(teslaModel, selectedYear);
                            if (teslaDetails != null)
                            {
                                maxKM = teslaDetails.MaxKm;
                                HP = teslaDetails.Horsepower;
                                batteryLife = teslaDetails.BatteryLife;
                                batteryWarranty = teslaDetails.BatteryWarranty;
                            }
                        }
                    }
                }

                lbBatteryLife.Text = batteryLife.ToString();
                lbHP.Text = HP.ToString();
                lbMAX.Text = maxKM.ToString();
                lbBatteryWarrenty.Text = batteryWarranty.ToString();
            }
        }


        private int GetYearAdjustment() // Getting the year adjustment according to the selected year
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

        private void UpdatePriceLabel() // Updating the price label according to the selected car
        {
            if (cbManufacturer.SelectedItem != null && cbModel.SelectedItem != null && cbYear.SelectedItem != null && cbModifications != null && cbModifications.SelectedItem != null)
            {
                eManufactureElectric selectedManufacturer = (eManufactureElectric)cbManufacturer.SelectedItem;
                eModifications selectedModification = (eModifications)((dynamic)cbModifications.SelectedItem).Value;

                if (selectedManufacturer == eManufactureElectric.Mercedes)
                {
                    eModelMercedes selectedModel = (eModelMercedes)cbModel.SelectedItem;

                    int basePrice = (int)selectedModel;
                    int price = basePrice + GetYearAdjustment();
                    if (cbModifications.Text == "High Level")
                    {
                        price += 10000;
                    }
                    lbPrice.Text = price.ToString();
                }
                else if (selectedManufacturer == eManufactureElectric.BMW)
                {
                    eModelBMW selectedModel = (eModelBMW)cbModel.SelectedItem;
                    int basePrice = (int)selectedModel;
                    int price = basePrice + GetYearAdjustment();
                    if (cbModifications.Text == "High Level")
                    {
                        price += 10000;
                    }
                    lbPrice.Text = price.ToString();
                }
                else if (selectedManufacturer == eManufactureElectric.Tesla)
                {
                    eModelTesla selectedModel = (eModelTesla)cbModel.SelectedItem;
                    int basePrice = (int)selectedModel;
                    int price = basePrice + GetYearAdjustment();
                    if (cbModifications.Text == "High Level")
                    {
                        price += 10000;
                    }
                    lbPrice.Text = price.ToString();
                }
            }
            else
            {
                lbPrice.Text = string.Empty; // Clear the price label if any selection is null
            }
        }


       
        private void SubmitOrder_Click(object sender, EventArgs e) // Submit order button
        {
            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string selectedPhone = tbPhone.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(selectedPhone))
            {
                MessageBox.Show("Please enter costumers details.");
                return; // Stop further execution
            }

            Vehicle vehicle = null; // Declare the vehicle object outside the if-else blocks

            string manufacturer = cbManufacturer.Text;
            string model = cbModel.Text;
            int year = int.Parse(cbYear.Text);
            double price = int.Parse(lbPrice.Text);
            string selectedModification = cbModifications.SelectedItem.ToString();
            bool carModifications = (selectedModification == "High level");
            string color = cbColor.Text;
            int HP = int.Parse(lbHP.Text);
            int _maxKm = int.Parse(lbMAX.Text);
            int _HP = int.Parse(lbHP.Text);
            int _batteryPrice = 5000;
            int _batteryLife = int.Parse(lbBatteryLife.Text);
            int _batteryWarrenty = int.Parse(lbBatteryWarrenty.Text);
            DateTime selectedDate = dateTimePicker.Value;


            ElectricCar electric = new ElectricCar(selectedPhone, selectedDate, firstName, lastName, manufacturer, model, color, year, price, _maxKm, _HP, _batteryPrice, _batteryLife, _batteryWarrenty);
            OrderManager.AddVehicle(electric);
            electrics.Add(electric);

            vehicle = electric;

            if (vehicle != null)
            {
                MessageBox.Show("Order submitted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to submit order. Please check the selected vehicle type.");
            }

        }

        private void cbModel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateCarInfo();
            givePicture();
            UpdatePriceLabel();
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
                tbFirstName.Text = tbFirstName.Text.Substring(0, 32); // Limit the text to the first 32 characters
            }
        }


        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            if (tbFirstName.Text.Length > 16)
            {
                tbFirstName.Text = tbLastName.Text.Substring(0, 32); // Limit the text to the first 32 characters
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


        private void cbModifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePriceLabel();

        }

        private void cbYear_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateCarInfo();
            UpdatePriceLabel();

        }

        private void cbColor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            givePicture();
        }
    }

}


