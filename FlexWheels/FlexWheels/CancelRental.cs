using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexWheels;

using System;
using System.Collections.Generic;

namespace FlexWheels
{
    public class PaymentService
    {
        public bool ProcessCancellationFee(int renterId, decimal amount)
        {
            // Logic to process payment
            Console.WriteLine($"Processed cancellation fee of ${amount} for renter {renterId}");
            return true;
        }
    }

    public class CancelRental
    {
        private List<Booking> bookings = new List<Booking>();
        private PaymentService paymentService = new PaymentService();

        public CancelRental()
        {
            // Sample data for testing
            string[] photos = { "1", "2" };
            Vehicle grSupra = new Vehicle("Toyota", "GR Supra", "2024", 100000, photos, "SBA1234A", photos, new DateTime(2024, 7, 20), 1, new List<Booking>());
            Vehicle grYaris = new Vehicle("Toyota", "GR Yaris", "2024", 100000, photos, "RD2345R", photos, new DateTime(2024, 7, 20), 2, new List<Booking>());
            Vehicle civic = new Vehicle("Honda", "Civic", "2024", 90000, photos, "SDC1234B", photos, new DateTime(2024, 7, 20), 3, new List<Booking>());
            Vehicle accord = new Vehicle("Honda", "Accord", "2024", 95000, photos, "SAA2345C", photos, new DateTime(2024, 7, 20), 4, new List<Booking>());
            Vehicle camry = new Vehicle("Toyota", "Camry", "2024", 92000, photos, "SCA3456D", photos, new DateTime(2024, 7, 20), 5, new List<Booking>());

            bookings.Add(new Booking(DateTime.Now.AddDays(2), DateTime.Now.AddDays(5), "Pickup", "LocationA", "", "", 1, "Active", grSupra));
            bookings.Add(new Booking(DateTime.Now.AddDays(8), DateTime.Now.AddDays(10), "Pickup", "LocationB", "", "", 2, "Active", grYaris));
            bookings.Add(new Booking(DateTime.Now.AddDays(3), DateTime.Now.AddDays(6), "Pickup", "LocationC", "", "", 3, "Active", civic));
            bookings.Add(new Booking(DateTime.Now.AddDays(9), DateTime.Now.AddDays(11), "Pickup", "LocationD", "", "", 4, "Active", accord));
            bookings.Add(new Booking(DateTime.Now.AddDays(1), DateTime.Now.AddDays(4), "Pickup", "LocationE", "", "", 5, "Active", camry));
        }

        public void DisplayBookings()
        {
            Console.WriteLine("====================================================================");
            Console.WriteLine("--------------------------- Active Bookings ------------------------");
            Console.WriteLine("====================================================================");
            foreach (var booking in bookings)
            {
                if (booking.BookingStatus == "Active")
                {
                    Console.WriteLine(booking.ToString());
                    Console.WriteLine("====================================================================");
                }
            }
        }

        public string CancelBooking(int bookingId)
        {
            Booking booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking == null)
            {
                return "Booking not found.";
            }

            if (booking.BookingStatus == "Cancelled")
            {
                return "Booking is already cancelled.";
            }

            // Display booking details and prompt for confirmation
            Console.WriteLine(booking.ToString());
            Console.WriteLine("Do you want to cancel this booking? (yes/no)");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() != "yes")
            {
                return "Cancellation aborted.";
            }

            DateTime currentDate = DateTime.Now;
            if ((booking.StartDate - currentDate).TotalDays < 7)
            {
                decimal cancellationFee = CalculateCancellationFee(booking);
                Console.WriteLine($"Cancellation fee: ${cancellationFee}");
                Console.WriteLine("Do you want to proceed with the cancellation and pay the fee? (yes/no)");
                confirmation = Console.ReadLine();
                if (confirmation.ToLower() != "yes")
                {
                    return "Cancellation is successful.";
                }

                bool paymentSuccess = paymentService.ProcessCancellationFee(booking.BookingId, cancellationFee);
                if (!paymentSuccess)
                {
                    return "Cancellation failed due to payment processing error.";
                }
            }

            booking.BookingStatus = "Cancelled";
            bookings.Remove(booking);
            Console.WriteLine("Booking cancelled successfully.");
            return "Booking cancelled successfully.";
        }

        private decimal CalculateCancellationFee(Booking booking)
        {
            return 50.0m; // Flat fee for simplicity
        }
    }
}
