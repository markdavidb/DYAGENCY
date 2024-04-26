using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYAGENCY.Backend.Model;

namespace DYAGENCY.Enums.Gasoline.BMW
{
    public enum eSedanBMW
    {
        i5 = 210000,
        i3 = 160000,
        i7 = 325000,
    }

    public enum eSUVBMW
    {
        X5 = 270000,
        X4 = 200000,
        X7 = 310000,
    }

    public class CarDetails
    {
        public int Horsepower { get; set; }
        public int FuelType { get; set; }
        public double EngineDisplacement { get; set; }
        public double FuelEfficiency { get; set; }
    }

    public class CarDetailsProvider
    {
        private static readonly Dictionary<(eSedanBMW, int), CarDetails> sedanCarDetailsMap = new Dictionary<(eSedanBMW, int), CarDetails>()
{
    { (eSedanBMW.i5, 2022), new CarDetails { Horsepower = 200, FuelType = 95, EngineDisplacement = 2.5, FuelEfficiency = 15 } },
    { (eSedanBMW.i5, 2023), new CarDetails { Horsepower = 210, FuelType = 95, EngineDisplacement = 2.7, FuelEfficiency = 14 } },
    { (eSedanBMW.i3, 2022), new CarDetails { Horsepower = 150, FuelType = 95, EngineDisplacement = 3, FuelEfficiency = 12 } },
    { (eSedanBMW.i3, 2023), new CarDetails { Horsepower = 160, FuelType = 95, EngineDisplacement = 3.2, FuelEfficiency = 11.5 } },
    { (eSedanBMW.i7, 2022), new CarDetails { Horsepower = 300, FuelType = 95, EngineDisplacement = 4.4, FuelEfficiency = 12 } },
    { (eSedanBMW.i7, 2023), new CarDetails { Horsepower = 310, FuelType = 95, EngineDisplacement = 4.7, FuelEfficiency = 11.8 } }
};

        private static readonly Dictionary<(eSUVBMW, int), CarDetails> suvCarDetailsMap = new Dictionary<(eSUVBMW, int), CarDetails>()
{
    { (eSUVBMW.X5, 2022), new CarDetails { Horsepower = 250, FuelType = 95, EngineDisplacement = 3.0, FuelEfficiency = 12 } },
    { (eSUVBMW.X5, 2023), new CarDetails { Horsepower = 260, FuelType = 95, EngineDisplacement = 3.2, FuelEfficiency = 11.5 } },
    { (eSUVBMW.X4, 2022), new CarDetails { Horsepower = 200, FuelType = 95, EngineDisplacement = 2.2, FuelEfficiency = 11 } },
    { (eSUVBMW.X4, 2023), new CarDetails { Horsepower = 210, FuelType = 95, EngineDisplacement = 2.5, FuelEfficiency = 10.5 } },
    { (eSUVBMW.X7, 2022), new CarDetails { Horsepower = 300, FuelType = 95, EngineDisplacement = 4.0, FuelEfficiency = 12 } },
    { (eSUVBMW.X7, 2023), new CarDetails { Horsepower = 310, FuelType = 95, EngineDisplacement = 4.3, FuelEfficiency = 11.7 } }
};


        public static CarDetails GetCarDetails(eSedanBMW carModel, int year)
        {
            // Construct a unique key using the car model and year
            var key = (carModel, year);

            if (sedanCarDetailsMap.ContainsKey(key))
                return sedanCarDetailsMap[key];

            return null; // Car details not found for the specified model and year
        }

        public static CarDetails GetCarDetails(eSUVBMW carModel, int year)
        {
            // Construct a unique key using the car model and year
            var key = (carModel, year);

            if (suvCarDetailsMap.ContainsKey(key))
                return suvCarDetailsMap[key];

            return null; // Car details not found for the specified model and year
        }

    }
}
