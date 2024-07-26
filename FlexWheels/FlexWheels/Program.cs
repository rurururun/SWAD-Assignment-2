using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test vehicle class
            Vehicle vehicle = new Vehicle("a", "b", DateTime.Now, 1, "c", "d", "e", DateTime.Now);
            Console.WriteLine(vehicle.ToString());
            Console.ReadLine();

            // Test booking class
            Booking booking = new Booking(DateTime.Now, DateTime.Now, 1, "a", "b", "c", "d");
            Console.WriteLine(booking.ToString());
            Console.ReadLine();

            // Test prime class
            Prime prime = new Prime(DateTime.Now, "a", DateTime.Now, "b", "c", true, DateTime.Now, "d", DateTime.Now, DateTime.Now, 1.1, 1.1, new List<string> { "1", "2" });
            Console.WriteLine(prime.ToString());
            Console.ReadLine();

            // Test Data
            /*Vehicle vehicle1 = new Vehicle();
            Booking booking1 = new Booking();*/

            // Implementation Of Sequence Diagram

            // Main Program

            // Features
        }
    }
}