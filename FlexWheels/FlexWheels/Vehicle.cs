using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Vehicle
    {
        private string make;
        private string model;
        private string year;
        private int mileage;
        private string[] photos;
        private string licensePlateNumber;
        private string[] insurance;
        private DateTime inspectionDate;
        private int vehicleId;
        private List<Booking> bookingList;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public string[] Photos
        {
            get { return photos; }
            set { photos = value; }
        }

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            set { licensePlateNumber = value; }
        }

        public string[] Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        public DateTime InspectionDate
        {
            get { return inspectionDate; }
            set { inspectionDate = value; }
        }

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        public List<Booking> BookingList
        {
            get { return bookingList; }
            set { bookingList = value; }
        }

        public Vehicle() { }

        public Vehicle(string mk, string md, string y, int mge, string[] p, string lpn, string[] i, DateTime id, int v, List<Booking> bl)
        {
            make = mk;
            model = md;
            year = y;
            mileage = mge;
            photos = p;
            licensePlateNumber = lpn;
            insurance = i;
            inspectionDate = id;
            vehicleId = v;
            bookingList = bl;
        }

        public string printArray(string[] array)
        {
            string arrayToBePrinted = "";

            for (int i = 0; i < array.Length; i++)
            {
                arrayToBePrinted += array[i] + "\n";
            }

            return arrayToBePrinted;
        }

        public override string ToString()
        {
            return "Make: " + Make + "\nModel: " + Model + "\nYear: " + Year + "\nMileage: " + Mileage + " km\nPhotos:\n" + printArray(Photos) + "License Plate Number: " + LicensePlateNumber + "\nInsurance:\n" + printArray(Insurance) + "Inspection Date: " + InspectionDate.Day + "/" + InspectionDate.Month + "/" + InspectionDate.Year + "\nVehicle ID: " + VehicleId;
        }
    }
}
