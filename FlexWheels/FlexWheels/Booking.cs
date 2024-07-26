using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Booking
    {
        private DateTime startDate;
        private DateTime endDate;
        private int rentalPeriod; // What is this? Days? Hours? Months?
        private string pickupMethod;
        private string pickupLocation;
        private string returnMethod;
        private string returnLocation;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int RentalPeriod
        {
            get { return rentalPeriod; }
            set { rentalPeriod = value; }
        }

        public string PickupMethod
        {
            get { return pickupMethod; }
            set { pickupMethod = value; }
        }

        public string PickupLocation
        {
            get { return pickupLocation; }
            set { pickupLocation = value; }
        }

        public string ReturnMethod
        {
            get { return returnMethod; }
            set { returnMethod = value; }
        }

        public string ReturnLocation
        {
            get { return returnLocation; }
            set { returnLocation = value; }
        }

        public Booking(DateTime sd, DateTime ed, int rp, string pm, string pl, string rm, string rl)
        {
            startDate = sd;
            endDate = ed;
            rentalPeriod = rp;
            pickupMethod = pm;
            pickupLocation = pl;
            returnMethod = rm;
            returnLocation = rl;
        }

        public override string ToString()
        {
            return "Start Date: " + StartDate.Day + "/" + StartDate.Month + "/" + StartDate.Year + "\nEnd Date: " + EndDate.Day + "/" + EndDate.Month + "/" + EndDate.Year + "\nRental Period: " + RentalPeriod + "\nPickup Method: " + PickupMethod + "\nPickup Location: " + PickupLocation + "\nReturn Method: " + ReturnMethod + "\nReturn Location: " + ReturnLocation;
        }
    }
}
