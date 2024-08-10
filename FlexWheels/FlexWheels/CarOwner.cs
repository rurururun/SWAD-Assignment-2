using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexWheels;

namespace FlexWheels
{
    internal class CarOwner : Account
    {
        public double Earning { get; set; }
        public List<Vehicle> OwnedCars { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }

        public CarOwner() { }

        public CarOwner(string n, string cn, int i, string e, string pass, double earn, List<Vehicle> oc, string addr, double r): base(n, cn, i, e, pass)
        { 
            Earning = earn;
            OwnedCars = oc;
            Address = addr;
            Rating = r;
        }

        public string PrintOwnedCars(List<Vehicle> v)
        {
            string carsToBePrinted = "";

            for (int i = 0; i < v.Count; i++)
            {
                carsToBePrinted += "Vehicle " + (i + 1) + "\n" + v.ToString() + "\n";
            }

            return carsToBePrinted;
        }

        public override string ToString()
        {
            return base.ToString() + "\nEarnings: " + Earning + "\nOwned Cars:\n" + PrintOwnedCars(OwnedCars) + "Address: " + Address + "\nRating: " + Rating;
        }
    }
}
