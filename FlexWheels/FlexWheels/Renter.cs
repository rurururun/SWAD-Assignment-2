using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Renter
    {
        private DateTime dateOfBirth;
        private string drivingLicenseNumber;
        private DateTime drivingLicenseExpiryDate;
        private string nric;
        private string address;
        private bool validatedDrivingLicense;
        private DateTime validationDate;
        private int renterId;
        private List<Booking> bookings;

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth= value; }
        }

        public string DrivingLicenseNumber
        {
            get { return drivingLicenseNumber; }
            set { drivingLicenseNumber= value; }
        }

        public DateTime DrivingLicenseExpiryDate
        {
            get { return drivingLicenseExpiryDate; }
            set { drivingLicenseExpiryDate = value; }
        }

        public string Nric
        {
            get { return nric; }
            set { nric= value; }
        }

        public string Address
        {
            get { return address; }
            set { address= value; }
        }

        public bool ValidatedDrivingLicense
        {
            get { return validatedDrivingLicense; }
            set { validatedDrivingLicense = value; }
        }

        public DateTime ValidationDate
        {
            get { return validationDate; }
            set { validationDate= value; }
        }

        public int RenterId
        {
            get { return renterId; }
            set { renterId= value; }
        }

        public List<Booking> Bookings
        {
            get { return bookings; }
            set { bookings= value; }
        }

        public Renter(DateTime dob, string dln, DateTime dlexp, string ic, string addr, bool valid, DateTime validDate, int id, List<Booking> b)
        {
            dateOfBirth = dob;
            drivingLicenseNumber = dln;
            drivingLicenseExpiryDate = dlexp;
            nric = ic;
            address = addr;
            validatedDrivingLicense = valid;
            validationDate = validDate;
            renterId = id;
            bookings = b;
        }

        public override string ToString()
        {
            return "Date Of Birth: " + DateOfBirth.Day + "/" + DateOfBirth.Month + "/" + DateOfBirth.Year + "\nDriving License Number: " + DrivingLicenseNumber + "\nDriving License Expiry Date: " + DrivingLicenseExpiryDate.Day + "/" + DrivingLicenseExpiryDate.Month + "/" + DrivingLicenseExpiryDate.Year + "\nNRIC: " + Nric + "\nAddress: " + Address + "\nValidated Driving License: " + (ValidatedDrivingLicense ? "Yes" : "No") + "\nValidation Date: " + ValidationDate.Day + "/" + ValidationDate.Month + "/" + ValidationDate.Year + "\nRenter Id: " + RenterId + "\nNumber Of Bookings: " + Bookings.Count;
        }
    }
}
