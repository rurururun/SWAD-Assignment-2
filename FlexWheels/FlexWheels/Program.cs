﻿using System;
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
            Vehicle grSupra = new Vehicle("Toyota", "GR Supra", new DateTime(2024, 1, 1), 100000, "", "SBA1234A", "", new DateTime(2024, 7, 20), true, 1, new List<Booking>());
            Booking grSupraBooking = new Booking(new DateTime(2024, 7, 21), new DateTime(2024, 7, 22), 24, "FlexWheels Station", "Bukit Gombak", "", "", 1, grSupra);
            Vehicle grYaris = new Vehicle("Toyota", "GR Yaris", new DateTime(2024, 1, 1), 100000, "", "RD2345R", "", new DateTime(2024, 7, 20), true, 2, new List<Booking>());
            Booking grYarisBooking = new Booking(new DateTime(2024, 7, 22), new DateTime(2024, 7, 23), 24, "FlexWheels Station", "Bukit Gombak", "", "", 2, grYaris);
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
                Console.WriteLine("==================================================================");
                Console.WriteLine("------------------------ Choose A Profile ------------------------");
                Console.WriteLine("==================================================================");
                Console.WriteLine("1. Renter (Return Vehicle, Choose Return Method, Make Payment)");
                Console.WriteLine("==================================================================");
                Console.Write("Profile: ");
            }

            // Return Vehicle - Chua Guo Heng (S10223608)
            static void ReturnVehicle(Renter r)
            {
                // Get list of vehicles the renter is currently renting
                List<Vehicle> v = r.GetListOfVehicles();
                DisplayListOfVehiclesCurrentlyRenting(v);

                while (true)
                {
                    Console.Write("Choose A Vehicle You Would Like To Return: ");
                    string? optionChosen = Console.ReadLine();
                    if (optionChosen != null)
                    {
                        int positionOfVehicleChosen;
                        bool isInt = int.TryParse(optionChosen.ToCharArray(), out positionOfVehicleChosen);
                        if (isInt)
                        {
                            if (positionOfVehicleChosen > 0 && positionOfVehicleChosen < v.Count)
                            {
                                Console.Clear();

                                Vehicle vehicleChosen = v[Convert.ToInt32(optionChosen) - 1];
                                DisplayVehicleChosen(vehicleChosen);

                                while (true)
                                {
                                    Console.Write("Return This Vehicle? (Y/N): ");
                                    string? confirmationOfReturningVehicle = Console.ReadLine();
                                    if (confirmationOfReturningVehicle == "Y" || confirmationOfReturningVehicle == "y" || confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                                    {
                                        if (confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                                        {
                                            continue;
                                        }

                                        // Begin process of returning vehicle
                                        Console.Clear();

                                        // Display return methods
                                        DisplayReturnMethods();

                                        bool acknowledge = false;
                                        while (!acknowledge)
                                        {
                                            // Prompt for return method
                                            Console.Write("Choose One Of The Return Methods: ");
                                            string? returnOption = Console.ReadLine();
                                            string returnMethod = "Drop Off";

                                            // Check whether user input is valid
                                            if (returnOption == "1" || returnOption == "2")
                                            {
                                                // Check whether return method is Desired Location
                                                if (returnOption == "2")
                                                {
                                                    Console.Clear();

                                                    // Display additional fees being charged
                                                    DisplayAdditionalFees();

                                                    while (true)
                                                    {
                                                        // Prompt for acknowledgement
                                                        Console.Write("Do you acknowledge the additional fees being charged? (Y/N): ");
                                                        string? acknowledgeOption = Console.ReadLine();
                                                        if (acknowledgeOption == "Y" || acknowledgeOption == "y" || acknowledgeOption == "N" || acknowledgeOption == "n")
                                                        {
                                                            if (acknowledgeOption == "Y" || acknowledgeOption == "y")
                                                            {
                                                                acknowledge = true;
                                                            }
                                                            else
                                                            {
                                                                acknowledge = false;
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("===================================================================");
                                                            Console.WriteLine("Please choose a valid option");
                                                            Console.WriteLine("===================================================================");
                                                        }
                                                    }

                                                    if (!acknowledge)
                                                    {
                                                        continue;
                                                    }

                                                    returnMethod = "Desired Location";
                                                }
                                                Console.Clear();

                                                string returnLocation = "";
                                                bool confirmReturnLocation = false;

                                                while (!confirmReturnLocation)
                                                {
                                                    Console.WriteLine("=======================================================================");
                                                    Console.WriteLine("--------------------------- Return Location ---------------------------");
                                                    Console.WriteLine("=======================================================================");

                                                    while (true)
                                                    {
                                                        // Prompt for return location
                                                        Console.Write("Enter a return location: ");
                                                        string? returnLocationEntered = Console.ReadLine();

                                                        if (returnLocationEntered != null)
                                                        {
                                                            returnLocation = returnLocationEntered;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("=======================================================================");
                                                            Console.WriteLine("Please enter a valid location");
                                                            Console.WriteLine("=======================================================================");
                                                        }
                                                    }

                                                    Console.WriteLine("=======================================================================");

                                                    // Prompt to confirm return location
                                                    while (true)
                                                    {
                                                        Console.Write("Are you sure this is the correct return location? (Y/N): ");
                                                        string? confirmOption = Console.ReadLine();

                                                        if (confirmOption == "Y" || confirmOption == "y" || confirmOption == "N" || confirmOption == "n")
                                                        {
                                                            if (confirmOption == "Y" || confirmOption == "y")
                                                            {
                                                                confirmReturnLocation = true;
                                                            }
                                                            else
                                                            {
                                                                confirmReturnLocation = false;
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("=======================================================================");
                                                            Console.WriteLine("Please choose a valid option");
                                                            Console.WriteLine("=======================================================================");
                                                        }
                                                    }
                                                }

                                                // Update booking
                                                Booking currentBooking = r.GetBookingByPosition(positionOfVehicleChosen - 1);
                                                currentBooking.ReturnMethod = returnMethod;
                                                currentBooking.ReturnLocation = returnLocation;
                                                r.UpdateBooking(r.GetBookingByPosition(positionOfVehicleChosen - 1).BookingId, currentBooking);
                                                Console.WriteLine(r.GetBookingByPosition(positionOfVehicleChosen - 1).ToString());
                                                Console.ReadLine();

                                                Console.Clear();

                                                // Call "Make Payment" function (Get a status from "Make Payment" function that will break all the loops)
                                            }
                                            else
                                            {
                                                Console.WriteLine("==========================================");
                                                Console.WriteLine("Please choose one of the options");
                                                Console.WriteLine("==========================================");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("===========================================");
                                        Console.WriteLine("Please choose one of the options");
                                        Console.WriteLine("===========================================");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("===================================================================");
                                Console.WriteLine("Please choose a vehicle in the list");
                                Console.WriteLine("===================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("===================================================================");
                            Console.WriteLine("Please enter a valid choice");
                            Console.WriteLine("===================================================================");
                        }
                    }
                    else
                    {
                        Console.WriteLine("===================================================================");
                        Console.WriteLine("Please choose a vehicle");
                        Console.WriteLine("===================================================================");
                    }
                }
            }

            static void DisplayListOfVehiclesCurrentlyRenting(List<Vehicle> v)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("----------------------------- Welcome -----------------------------");
                Console.WriteLine("===================================================================");
                for (int i = 0; i < v.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + v[i].Model + "   " + v[i].LicensePlateNumber);
                }
                Console.WriteLine("===================================================================");
            }

            static void DisplayVehicleChosen(Vehicle v)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("------------- Vehicle Details -------------");
                Console.WriteLine("===========================================");
                Console.WriteLine(v.ToString());
                Console.WriteLine("===========================================");
            }

            static void DisplayReturnMethods()
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("------------- Return Methods -------------");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Drop off at any FlexWheels station");
                Console.WriteLine("2. Return at a desired location");
                Console.WriteLine("==========================================");
            }

            static void DisplayAdditionalFees()
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("------------------------- Additional Fees -------------------------");
                Console.WriteLine("===================================================================");
                Console.WriteLine("Additional Fees: $10");
                Console.WriteLine("===================================================================");
            }
        }
    }
}