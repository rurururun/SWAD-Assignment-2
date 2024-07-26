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
/*            // Test vehicle class
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

            // Test renter class
            Renter renter = new Renter(DateTime.Now, "a", DateTime.Now, "b", "c", true, DateTime.Now);
            Console.WriteLine(renter.ToString());
            Console.ReadLine();*/

            // Test Data

            // Return Vehicle - Chua Guo Heng (S10223608)
            Vehicle grSupra = new Vehicle("Toyota", "GR Supra", new DateTime(2024, 1, 1), 100000, "", "SBA1234A", "", new DateTime(2024, 7, 20), true, new List<Booking>());
            Booking grSupraBooking = new Booking(new DateTime(2024, 7, 21), new DateTime(2024, 7, 22), 24, "FlexWheels Station", "Bukit Gombak", "", "", grSupra);
            Vehicle grYaris = new Vehicle("Toyota", "GR Yaris", new DateTime(2024, 1, 1), 100000, "", "RD2345R", "", new DateTime(2024, 7, 20), true, new List<Booking>());
            Booking grYarisBooking = new Booking(new DateTime(2024, 7, 22), new DateTime(2024, 7, 23), 24, "FlexWheels Station", "Bukit Gombak", "", "", grYaris);
            List<Booking> bookings = new List<Booking>
            {
                grSupraBooking,
                grYarisBooking
            };
            Renter renter = new Renter(new DateTime(2002, 12, 12), "A0123456A", new DateTime(2067, 12, 12), "A0123456A", "20 MCCALLUM STREET #17-04 SINGAPORE 069046", true, new DateTime(2024, 7, 20), 1, bookings);


            // Implementation Of Sequence Diagram

            // Main Program

            // Create 3 profiles, 1 Car Owner, 1 Renter, and 1 Admin (To be confirmed)

            while (true)
            {
                MainMenu();
                string? profileChosen = Console.ReadLine();

                if (profileChosen != null)
                {
                    if (profileChosen == "1")
                    {
                        Console.Clear();
                        ReturnVehicle(renter);
                    }
                    else
                    {
                        Console.WriteLine("Please choose a valid profile");
                    }
                }
                else
                {
                    Console.WriteLine("Please choose a profile");
                }
            }

            // Features (Functions)
            static void MainMenu()
            {
                Console.WriteLine("==============================");
                Console.WriteLine("------ Choose A Profile ------");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Renter (Return Vehicle)");
                Console.WriteLine("==============================");
                Console.Write("Profile: ");
            }

            // Return Vehicle - Chua Guo Heng (S10223608)
            static void ReturnVehicle(Renter r)
            {
                DisplayListOfVehiclesCurrentlyRenting(r);
            }

            static void DisplayListOfVehiclesCurrentlyRenting(Renter r)
            {
                while (true)
                {
                    Console.WriteLine("===========================================");
                    Console.WriteLine("----------------- Welcome -----------------");
                    Console.WriteLine("===========================================");
                    List<Vehicle> v = GetListOfVehicles(r.Bookings);
                    for (int i = 0; i < v.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + v[i].Model);
                    }
                    Console.WriteLine("===========================================");
                    Console.Write    ("Choose A Vehicle You Would Like To Return: ");
                    string? optionChosen = Console.ReadLine();
                    if (optionChosen != null)
                    {
                        int testing;
                        bool isInt = int.TryParse(optionChosen.ToCharArray(), out testing);
                        if (isInt)
                        {
                            if (testing > 0 && testing < v.Count)
                            {
                                Console.Clear();

                                Vehicle vehicleChosen = v[Convert.ToInt32(optionChosen) - 1];
                                DisplayVehicleChosen(vehicleChosen);
                                string? confirmationOfReturningVehicle = Console.ReadLine();
                                if (confirmationOfReturningVehicle == "Y" || confirmationOfReturningVehicle == "y")
                                {
                                    // Begin process of returning vehicle
                                    bool acknowledge = false;
                                    while (!acknowledge)
                                    {
                                        Console.Clear();

                                        // Prompt for return method
                                        DisplayReturnMethods();
                                        string? returnMethod = Console.ReadLine();

                                        // Check whether return method is Drop Off or Desired Location
                                        if (returnMethod == "1")
                                        {
                                            // Drop Off
                                        }
                                        else if (returnMethod == "2")
                                        {
                                            // Desired Location
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please choose one of the options");
                                        }
                                    }
                                }
                                else if (confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                                {
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Please choose one of the options");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please choose a vehicle in the list");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid choice");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please choose a vehicle");
                    }
                }
            }

            static List<Vehicle> GetListOfVehicles(List<Booking> b)
            {
                List<Vehicle> vehicles = new List<Vehicle>();
                for (int i = 0; i < b.Count; i++)
                {
                    vehicles.Add(b[i].V);
                }
                return vehicles;
            }

            static void DisplayVehicleChosen(Vehicle v)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("------------- Vehicle Details -------------");
                Console.WriteLine("===========================================");
                Console.WriteLine(v.ToString());
                Console.WriteLine("===========================================");
                Console.Write("Return This Vehicle? (Y/N): ");
            }

            static void DisplayReturnMethods()
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("------------- Return Methods -------------");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Drop off at any FlexWheels station");
                Console.WriteLine("2. Return at a desired location");
                Console.WriteLine("==========================================");
                Console.Write("Choose One Of The Return Methods: ");
            }
        }
    }
}