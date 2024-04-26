using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYAGENCY.Backend.Model
{
    [Serializable]

    public class ElectricCar : Vehicle
    {

        int _maxKm;
        int _HP;
        int _batteryPrice;
        int _batteryLife;
        int _batteryWarrenty;

        public ElectricCar()
        {
        }

        public int maxKm { get => _maxKm; set => _maxKm = value; }
        public int HP { get => _HP; set => _HP = value; }
        public int batteryPrice { get => _batteryPrice; set => _batteryPrice = value; }
        public int batteryLife { get => _batteryLife; set => _batteryLife = value; }
        public int batteryWarrenty { get => _batteryWarrenty; set => _batteryWarrenty = value; }



        public ElectricCar(string phone, DateTime date, string firstName, string lastName,string manufacturer, string model, string color, int year, double price, int maxKM, int HP, int batteryPrice, int batteryLife, int baatteryWarrenty)
            : base(phone, date, firstName,  lastName,manufacturer, model, color, year, price)
        {
            this._maxKm = maxKM;
            this._HP = HP;
            this._batteryPrice = batteryPrice;
            this._batteryLife = batteryLife;
            this._batteryWarrenty = baatteryWarrenty;

        }

        public override System.Drawing.Image DisplayCarPicture(string selectedModel, string selectedColor, System.Windows.Forms.ComboBox cbModel)
        {
            string selectedCarModel = cbModel.SelectedItem?.ToString();

            if (selectedCarModel != null && selectedCarModel == selectedModel)
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory; // Get the base path of the project's executable file
                string imageFolderPath = Path.Combine(basePath, "..", "..", "PictureElectric"); // Construct the path to the "Pictures" folder

                string imageFileName = $"{selectedModel}{selectedColor}.png"; // Combine the model and color to create the image file name

                string imagePath = Path.Combine(imageFolderPath, imageFileName); // Combine the image folder path and file name

                if (File.Exists(imagePath))
                {
                    return System.Drawing.Image.FromFile(imagePath); // Load and return the image
                }
            }

            // Return null or handle other cases if needed
            return null;
        }

    }
}
