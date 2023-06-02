using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Backend.Model;

namespace WindowsFormsApp1.Enums.ElectricsCar.Mercedes
{
    public enum eModelMercedes
    {
        EQE = 250000,
        EQB = 330000,
        EQS = 400000,
    }

    public class CarDetails
    {
        public int Horsepower { get; set; }
        public int MaxKm { get; set; }
        public int BatteryLife { get; set; }
        public int BatteryWarranty { get; set; }
    }

    public class CarDetailsProvider
    {
        private static readonly Dictionary<eModelMercedes, Dictionary<int, CarDetails>> carDetailsMap = new Dictionary<eModelMercedes, Dictionary<int, CarDetails>>()
        {
            {
                eModelMercedes.EQB, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { Horsepower = 190, MaxKm = 500, BatteryLife = 8, BatteryWarranty = 10 } },
                    { 2023, new CarDetails { Horsepower = 200, MaxKm = 550, BatteryLife = 9, BatteryWarranty = 11 } }
                }
            },
            {
                eModelMercedes.EQE, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { Horsepower = 408, MaxKm = 450, BatteryLife = 10, BatteryWarranty = 12 } },
                    { 2023, new CarDetails { Horsepower = 420, MaxKm = 500, BatteryLife = 11, BatteryWarranty = 13 } }
                }
            },
            {
                eModelMercedes.EQS, new Dictionary<int, CarDetails>
                {
                    { 2022, new CarDetails { Horsepower = 516, MaxKm = 550, BatteryLife = 12, BatteryWarranty = 15 } },
                    { 2023, new CarDetails { Horsepower = 530, MaxKm = 600, BatteryLife = 13, BatteryWarranty = 16 } }
                }
            }
        };

        public static CarDetails GetCarDetails(eModelMercedes carModel, int year)
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
