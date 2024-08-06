using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Booking
    {
        public bool IsReturn { get; set; } // janani part
        public bool IsCancelled { get; set; } // janani part

        private DateTime startDate;
        private DateTime endDate;
        private string pickupMethod;
        private string pickupLocation;
        private string returnMethod;
        private string returnLocation;
        private int bookingId;
        private string bookingStatus;
        private Vehicle v;

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

        public int BookingId
        {
            get { return bookingId; }
            set { bookingId = value; }
        }

        public string BookingStatus
        {
            get { return bookingStatus; }
            set { bookingStatus = value; }
        }

        public Vehicle V
        {
            get { return v; }
            set { v = value; }
        }

        public Booking() { }

        public Booking(DateTime sd, DateTime ed, string pm, string pl, string rm, string rl, int b, string bs, Vehicle vehicle)
        {
            startDate = sd;
            endDate = ed;
            pickupMethod = pm;
            pickupLocation = pl;
            returnMethod = rm;
            returnLocation = rl;
            bookingId = b;
            bookingStatus = bs;
            v = vehicle;
        }

        public override string ToString()
        {
            return "===========================================" + "\n------------- Booking Details -------------" + "\n===========================================" + "\nStart Date: " + StartDate.Day + "/" + StartDate.Month + "/" + StartDate.Year + "\nEnd Date: " + EndDate.Day + "/" + EndDate.Month + "/" + EndDate.Year + "h\nPickup Method: " + PickupMethod + "\nPickup Location: " + PickupLocation + "\nReturn Method: " + ReturnMethod + "\nReturn Location: " + ReturnLocation + "\nBooking ID: " + BookingId + "\nBooking Status: " + BookingStatus + "\n===========================================" + "\n------------- Vehicle Details -------------" + "\n===========================================\n" + V.ToString();
        }
    }
}
