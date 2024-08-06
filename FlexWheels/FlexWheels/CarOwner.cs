using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexWheels;

namespace FlexWheels
{
    internal class CarOwner
    {
        public float Earning { get; set; }
        public List<Vehicle> OwnedCars { get; set; }
        public string Address { get; set; }
        public int NumberOfVehicles { get; set; }
        public float Rating { get; set; }

        public CarOwner(float e, List<Vehicle> oc, string addr, int numVehicle, float r) 
        { 
            Earning = e;
            OwnedCars = oc;
            Address = addr;
            NumberOfVehicles = numVehicle;
            Rating = r;

        }

    }
}
