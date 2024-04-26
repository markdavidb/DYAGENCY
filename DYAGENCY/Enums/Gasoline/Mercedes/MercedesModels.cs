using System;
using System.Collections.Generic;
using System.ComponentModel;
using DYAGENCY.Backend.Model;

namespace DYAGENCY.Enums.Gasoline.Mercedes
{
    public enum eSedanMercedes
    {
        [Description("E Class")]
        E_Class = 150000,

        [Description("S Class")]
        S_Class = 200000,

        [Description("C Class")]
        C_Class = 140000
    }

    public enum eSUVMercedes
    {
        [Description("GLE")]
        GLE = 300000,

        [Description("GLA")]
        GLA = 250000,

        [Description("GLC")]
        GLC = 157000,

        [Description("GLS")]
        GLS = 350000
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
        private static readonly Dictionary<(eSedanMercedes, int), CarDetails> sedanCarDetailsMap = new Dictionary<(eSedanMercedes, int), CarDetails>()
        {
            { (eSedanMercedes.E_Class, 2022), new CarDetails { Horsepower = 200, FuelType = 95, EngineDisplacement = 2.0, FuelEfficiency = 14 } },
            { (eSedanMercedes.E_Class, 2023), new CarDetails { Horsepower = 210, FuelType = 95, EngineDisplacement = 2.2, FuelEfficiency = 13.5 } },
            { (eSedanMercedes.S_Class, 2022), new CarDetails { Horsepower = 250, FuelType = 98, EngineDisplacement = 3.5, FuelEfficiency = 13 } },
            { (eSedanMercedes.S_Class, 2023), new CarDetails { Horsepower = 260, FuelType = 98, EngineDisplacement = 3.7, FuelEfficiency = 12.5 } },
            { (eSedanMercedes.C_Class, 2022), new CarDetails { Horsepower = 180, FuelType = 95, EngineDisplacement = 1.8, FuelEfficiency = 16 } },
            { (eSedanMercedes.C_Class, 2023), new CarDetails { Horsepower = 190, FuelType = 95, EngineDisplacement = 2.0, FuelEfficiency = 15.5 } }
        };

        private static readonly Dictionary<(eSUVMercedes, int), CarDetails> suvCarDetailsMap = new Dictionary<(eSUVMercedes, int), CarDetails>()
        {
            { (eSUVMercedes.GLE, 2022), new CarDetails { Horsepower = 250, FuelType = 95, EngineDisplacement = 3.0, FuelEfficiency = 12 } },
            { (eSUVMercedes.GLE, 2023), new CarDetails { Horsepower = 260, FuelType = 95, EngineDisplacement = 3.2, FuelEfficiency = 11.5 } },
            { (eSUVMercedes.GLA, 2022), new CarDetails { Horsepower = 200, FuelType = 98, EngineDisplacement = 2.0, FuelEfficiency = 11 } },
            { (eSUVMercedes.GLA, 2023), new CarDetails { Horsepower = 210, FuelType = 98, EngineDisplacement = 2.2, FuelEfficiency = 10.5 } },
            { (eSUVMercedes.GLC, 2022), new CarDetails { Horsepower = 180, FuelType = 95, EngineDisplacement = 2.2, FuelEfficiency = 13 } },
            { (eSUVMercedes.GLC, 2023), new CarDetails { Horsepower = 190, FuelType = 95, EngineDisplacement = 2.4, FuelEfficiency = 12.5 } },
            { (eSUVMercedes.GLS, 2022), new CarDetails { Horsepower = 300, FuelType = 98, EngineDisplacement = 3.5, FuelEfficiency = 10 } },
            { (eSUVMercedes.GLS, 2023), new CarDetails { Horsepower = 310, FuelType = 98, EngineDisplacement = 3.7, FuelEfficiency = 9.5 } }
        };

        public static CarDetails GetCarDetails(eSedanMercedes carModel, int year)
        {
            // Construct a unique key using the car model and year
            var key = (carModel, year);

            if (sedanCarDetailsMap.ContainsKey(key))
                return sedanCarDetailsMap[key];

            return null; // Car details not found for the specified model and year
        }

        public static CarDetails GetCarDetails(eSUVMercedes carModel, int year)
        {
            // Construct a unique key using the car model and year
            var key = (carModel, year);

            if (suvCarDetailsMap.ContainsKey(key))
                return suvCarDetailsMap[key];

            return null; // Car details not found for the specified model and year
        }
    }
}
