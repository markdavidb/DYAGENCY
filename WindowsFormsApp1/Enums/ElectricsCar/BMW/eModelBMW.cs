using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Enums.ElectricsCar.BMW
{
    public enum eModelBMW
    {
        iX = 150000,
        i7 = 250000,
        i4 = 178000,
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
        private static readonly Dictionary<eModelBMW, Dictionary<int, CarDetails>> carDetailsMap = new Dictionary<eModelBMW, Dictionary<int, CarDetails>>()
        {
            {
                eModelBMW.iX, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { MaxKm = 460, Horsepower = 335, BatteryLife = 8, BatteryWarranty = 8 } },
                    { 2023, new CarDetails { MaxKm = 500, Horsepower = 350, BatteryLife = 9, BatteryWarranty = 9 } }
                }
            },
            {
                eModelBMW.i7, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { MaxKm = 70, Horsepower = 369, BatteryLife = 10, BatteryWarranty = 10 } },
                    { 2023, new CarDetails { MaxKm = 80, Horsepower = 380, BatteryLife = 11, BatteryWarranty = 11 } }
                }
            },
            {
                eModelBMW.i4, new Dictionary<int, CarDetails>
            {
                    { 2022, new CarDetails { MaxKm = 550, Horsepower = 335, BatteryLife = 12, BatteryWarranty = 12 } },
                    { 2023, new CarDetails { MaxKm = 600, Horsepower = 350, BatteryLife = 13, BatteryWarranty = 13 } }
                }
            }
        };

        public static CarDetails GetCarDetails(eModelBMW carModel, int year)
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
