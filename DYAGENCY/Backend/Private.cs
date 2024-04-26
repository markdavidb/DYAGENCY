using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYAGENCY.Backend.Model
{
    [Serializable]

    public class Private : Gasoline
    {

        public int passengerCapacity;
        public bool HasSunroof;
        public string interiorColor;

        public Private()
        {

        }

        public int PassengerCapacity { get => passengerCapacity; set => passengerCapacity = value; }
        public bool hasSunroof { get => HasSunroof; set => HasSunroof = value; }
        public string InteriorColor { get => interiorColor; set => interiorColor = value; }

        public Private(string phone, DateTime date, string firstName, string lastName, string manufacturer, string model, string color, int year, double price, double fueltype, int HP, double engineCapacity, int kpl, int passengerCapacity, bool hasSunroof, string interiorColor)
            : base( phone, date, firstName, lastName, manufacturer, model, color, year, price, fueltype, HP, engineCapacity, kpl)
        {
            this.passengerCapacity = passengerCapacity;
            this.HasSunroof = hasSunroof;
            this.interiorColor = interiorColor;
        }



        public override System.Drawing.Image DisplayCarPicture(string selectedModel, string selectedColor, System.Windows.Forms.ComboBox cbModel)
        {
            string selectedCarModel = cbModel.SelectedItem?.ToString();

            if (selectedCarModel != null && selectedCarModel == selectedModel)
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory; // Get the base path of the project's executable file
                string imageFolderPath = Path.Combine(basePath, "..", "..", "Pictures"); // Construct the path to the "Pictures" folder

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
