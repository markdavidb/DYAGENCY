using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DYAGENCY.Backend.Model
{
    [Serializable]

    public class Gasoline : Vehicle
    {


        double _fuelType;
        int _HP;
        double _engineCapacity;
        int _kpl;

        public Gasoline()
        {
        }

        public double FuelType { get => _fuelType; set => _fuelType = value; }

        public double EngineCapacity { get => _engineCapacity; set => _engineCapacity = value; }

        public int kpl { get => _kpl; set => _kpl = value; }


        public int HP { get => _HP; set => _HP = value; }


        public Gasoline(string phone, DateTime date, string firstName, string lastName, string manufacturer, string model, string color, int year, double price, double fueltype, int HP, double engineCapacity, int kpl)
            : base(phone, date, firstName, lastName, manufacturer, model, color, year, price)
        {

            this._fuelType = fueltype;
            this._engineCapacity = engineCapacity;
            this._HP = HP;
            this._kpl = kpl;

        }


    }
}
