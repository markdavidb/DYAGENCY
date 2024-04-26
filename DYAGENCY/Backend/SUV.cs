using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms; // Add this using statement for the Windows Forms namespace
using System.IO;

namespace DYAGENCY.Backend.Model
{
    [Serializable]

    public class SUV : Gasoline
    {


        int _seatingCapacity;
        bool _has4x4;

        public int seatingcapacity { get => _seatingCapacity; set => _seatingCapacity = value; }
        public bool has4x4 { get => _has4x4; set => _has4x4 = value; }

        public SUV()
        {

        }

        public SUV(string phone, DateTime date, string firstName, string lastName, string manufacturer, string model, string color, int year, double price, double fueltype, int HP, double engineCapacity, int kpl, int seatingcapacity, bool has4x4)
            : base(phone, date, firstName, lastName, manufacturer, model, color, year, price, fueltype, HP, engineCapacity, kpl)
        {

            this._seatingCapacity = seatingcapacity;
            this._has4x4 = has4x4;
        }

        // Rest of the class



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
