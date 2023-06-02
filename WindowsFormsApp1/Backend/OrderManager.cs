using System;
using System.Collections.Generic;
using System.ComponentModel;
using WindowsFormsApp1.Backend.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Backend.Utils;


namespace WindowsFormsApp1
{
    public class OrderManager
    {
        private static BindingList<Vehicle> vehicles;

        static OrderManager()
        {

            vehicles = FileUtils.LoadVehiclesFromFile();

        }

        public static void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public static BindingList<Vehicle> GetVehicles()
        {

            return vehicles;
        }

        public static void RemoveVehicle(Vehicle vehicle)
        {
            int index = vehicles.IndexOf(vehicle);
            if (index >= 0)
            {
                vehicles.RemoveAt(index);
            }
        }


        public static BindingList<T> GetSpecificVehicles<T>() where T : Vehicle
        {
            BindingList<T> specificVehicles = new BindingList<T>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is T specificVehicle)
                {
                    specificVehicles.Add(specificVehicle);
                }
            }

            return specificVehicles;
        }

        public static BindingList<T> GetSpecificVehiclesByCriterion<T>(string criterion) where T : Vehicle
        {
            BindingList<T> specificVehicles = new BindingList<T>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle is T specificVehicle)
                {
                    // Custom logic to filter vehicles based on the criterion
                    if (specificVehicle.phoneNumber.StartsWith(criterion))
                    {
                        specificVehicles.Add(specificVehicle);
                    }
                }
            }

            return specificVehicles;
        }


        internal static void SaveVehicles(object sender, FormClosingEventArgs e)
        {
            FileUtils.SaveVehicleToFile(vehicles);
        }
    }
}
