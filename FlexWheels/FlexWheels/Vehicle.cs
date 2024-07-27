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
        private DateTime year; // Seems vague, what is this?
        private int mileage; // In terms of KM or Miles?
        private string photos;
        private string licensePlateNumber;
        private string insurance;
        private DateTime inspectionDate;
        private bool rentalStatus;
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

        public DateTime Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public string Photos
        {
            get { return photos; }
            set { photos = value; }
        }

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            set { licensePlateNumber = value; }
        }

        public string Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        public DateTime InspectionDate
        {
            get { return inspectionDate; }
            set { inspectionDate = value; }
        }

        public bool RentalStatus
        {
            get { return rentalStatus; }
            set { rentalStatus = value; }
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

        public Vehicle(string mk, string md, DateTime y, int mge, string p, string lpn, string i, DateTime id, bool rs, int v, List<Booking> bl)
        {
            make = mk;
            model = md;
            year = y;
            mileage = mge;
            photos = p;
            licensePlateNumber = lpn;
            insurance = i;
            inspectionDate = id;
            rentalStatus = rs;
            vehicleId = v;
            bookingList = bl;
        }

        public override string ToString()
        {
            return "Make: " + Make + "\nModel: " + Model + "\nYear: " + Year.Year + "\nMileage: " + Mileage + "\nPhotos: " + Photos + "\nLicense Plate Number: " + LicensePlateNumber + "\nInsurance: " + Insurance + "\nInspection Date: " + InspectionDate.Day + "/" + InspectionDate.Month + "/" + InspectionDate.Year + "\nRental Status: " + (RentalStatus ? "Rented" : "Not Rented") + "\nVehicle ID: " + VehicleId;
        }
    }
}
