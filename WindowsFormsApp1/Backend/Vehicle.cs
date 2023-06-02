using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms; // Add this using statement for the Windows Forms namespace

namespace WindowsFormsApp1.Backend.Model
{
    [Serializable]

    public abstract class Vehicle

    {


        string _firstName;
        string _lastName;
        string _manufacturer;
        string _model;
        string _color;
        int _year;
        double _price;
        DateTime _date;
        string _phoneNumber;

        public Vehicle()
        {
        }

        public string phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public DateTime date { get => _date; set => _date = value; }

        public string firstName { get => _firstName; set => _firstName = value; }
        public string lastName { get => _lastName; set => _lastName = value; }
        public string model { get => _model; set => _model = value; }
        public string manuFacturer { get => _manufacturer; set => _manufacturer = value; }
        public string color { get => _color; set => _color = value; }
        public int year { get => _year; set => _year = value; }
        public double price { get => _price; set => _price = value; }
        public Vehicle(string phone, DateTime date, string firstName, string lastName, string manufacturer, string model, string color, int year, double price)
        {
            this._phoneNumber = phone;
            this._firstName = firstName;
            this._lastName = lastName;
            this._manufacturer = manufacturer;
            this._model = model;
            this._color = color;
            this._year = year;
            this._price = price;
            this._date = date;
        }

        public virtual System.Drawing.Image DisplayCarPicture(string selectedModel,string selectedColor, System.Windows.Forms.ComboBox cbModel)
        {
            // Default implementation (can be overridden by derived classes)
            return null;
        }

    }

}
