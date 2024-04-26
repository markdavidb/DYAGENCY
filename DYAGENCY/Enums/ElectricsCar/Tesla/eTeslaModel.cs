using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYAGENCY.Enums.ElectricsCar.Tesla
{
    public enum eModelTesla
    {
        Model3 = 200060
    }

    public class CarDetails
    {
        public int MaxKm { get; set; }
        public int Horsepower { get; set; }
        public int BatteryLife { get; set; }
        public int BatteryWarranty { get; set; }
    }

    public class CarDetailsProvider
    {
        private static readonly Dictionary<eModelTesla, Dictionary<int, CarDetails>> carDetailsMap = new Dictionary<eModelTesla, Dictionary<int, CarDetails>>()
        {
            {
                eModelTesla.Model3, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { MaxKm = 450, Horsepower = 325, BatteryLife = 8, BatteryWarranty = 8 } },
                    { 2023, new CarDetails { MaxKm = 500, Horsepower = 350, BatteryLife = 9, BatteryWarranty = 9 } }
                }
            }
        };

        public static CarDetails GetCarDetails(eModelTesla carModel, int year)
        {
            if (carDetailsMap.ContainsKey(carModel))
            {
                var yearDetailsMap = carDetailsMap[carModel];
                if (yearDetailsMap.ContainsKey(year))
                    return yearDetailsMap[year];
            }

            return null; // Car details not found for the specified model and year
        }
    }
}
