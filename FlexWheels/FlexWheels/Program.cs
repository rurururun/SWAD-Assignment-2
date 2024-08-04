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
            string[] photos = { "1", "2" };
            Vehicle grSupra = new Vehicle("Toyota", "GR Supra", "2024", 100000, photos, "SBA1234A", photos, new DateTime(2024, 7, 20), 1, new List<Booking>());
            Booking grSupraBooking = new Booking(new DateTime(2024, 7, 21), new DateTime(2024, 7, 22), "FlexWheels Station", "Bukit Gombak", "", "", 1, "Ongoing", grSupra);
            Vehicle grYaris = new Vehicle("Toyota", "GR Yaris", "2024", 100000, photos, "RD2345R", photos, new DateTime(2024, 7, 20), 2, new List<Booking>());
            Booking grYarisBooking = new Booking(new DateTime(2024, 7, 22), new DateTime(2024, 7, 23), "FlexWheels Station", "Bukit Gombak", "", "", 2, "Ongoing", grYaris);
            grSupra.BookingList.Add(grSupraBooking);
            grYaris.BookingList.Add(grYarisBooking);
            List<Booking> bookings = new List<Booking>
            {
                grSupraBooking,
                grYarisBooking
            };
            Renter renter = new Renter(new DateTime(2002, 12, 12), "A0123456A", new DateTime(2067, 12, 12), "A0123456A", "20 MCCALLUM STREET #17-04 SINGAPORE 069046", true, new DateTime(2024, 7, 20), 1, bookings);


            // Implementation Of Sequence Diagram

            // Main Program
            string showMainMenu = "";

            while (true)
            {
                if (showMainMenu == "")
                {
                    MainMenu();
                    showMainMenu = "Shown";
                }

                Console.Write("Choose A Profile: ");
                string? profileChosen = Console.ReadLine();

                if (profileChosen != null)
                {
                    if (profileChosen == "1")
                    {
                        Console.Clear();
                        ReturnVehicle(renter);
                        showMainMenu = "";
                    }
                    else
                    {
                        Console.WriteLine("====================================================================");
                        Console.WriteLine("Please choose a valid profile");
                        Console.WriteLine("====================================================================");
                    }
                }
                else
                {
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("Please choose a profile");
                    Console.WriteLine("====================================================================");
                }
            }

            // Features (Functions)
            static void MainMenu()
            {
                Console.WriteLine("====================================================================");
                Console.WriteLine("----------------------------- Profiles -----------------------------");
                Console.WriteLine("====================================================================");
                Console.WriteLine("1. Renter (Return Vehicle, Choose Return Method, Make Payment)");
                Console.WriteLine("====================================================================");
            }

            // Return Vehicle - Chua Guo Heng (S10223608)
            static void ReturnVehicle(Renter r)
            {
                int positionOfVehicleChosen;
                string? confirmationOfReturningVehicle = "";

                // Display list of vehicles the renter is currently renting
                DisplayListOfVehiclesCurrentlyRenting(r.Bookings);

                while (true)
                {
                    if (confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                    {
                        confirmationOfReturningVehicle = "";
                        Console.Clear();
                        DisplayListOfVehiclesCurrentlyRenting(r.Bookings);
                    }

                    Console.Write("Choose A Vehicle You Would Like To Return: ");
                    string? optionChosen = Console.ReadLine();
                    if (optionChosen != null)
                    {
                        bool isInt = int.TryParse(optionChosen, out positionOfVehicleChosen);
                        if (isInt)
                        {
                            if (positionOfVehicleChosen > 0 && positionOfVehicleChosen <= r.Bookings.Count)
                            {
                                Console.Clear();

                                DisplayVehicleChosen(r.Bookings[Convert.ToInt32(optionChosen) - 1].V);

                                while (true)
                                {
                                    Console.Write("Return This Vehicle? (Y/N): ");
                                    confirmationOfReturningVehicle = Console.ReadLine();
                                    if (confirmationOfReturningVehicle == "Y" || confirmationOfReturningVehicle == "y" || confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                                    {
                                        if (confirmationOfReturningVehicle == "N" || confirmationOfReturningVehicle == "n")
                                        {
                                            break;
                                        }

                                        // Begin process of returning vehicle

                                        bool acknowledge = false;
                                        while (!acknowledge) // Should this be acknowledge or the status that will be received from "Make Payment" Use Case?
                                        {
                                            Console.Clear();

                                            // Display return methods
                                            DisplayReturnMethods();

                                            while (true)
                                            {
                                                // Prompt for return method
                                                Console.Write("Choose One Of The Return Methods: ");
                                                string? returnOption = Console.ReadLine();
                                                string[] returnMethods = { "Drop Off", "Desired Location" };
                                                string[] flexWheelsStations = { "Bukit Batok", "Bukit Gombak", "Choa Chu Kang", "Jurong East" };

                                                int returnOptionChosen;
                                                int flexWheelsStationOptionChosen;
                                                bool returnOptionIsInt = int.TryParse(returnOption, out returnOptionChosen);

                                                string returnMethod = "";
                                                string returnLocation = "";

                                                bool confirmReturnLocation = false;

                                                // Check whether user input is valid
                                                if (returnOptionIsInt && returnOptionChosen > 0 && returnOptionChosen <= returnMethods.Length)
                                                {
                                                    returnMethod = returnMethods[returnOptionChosen - 1];
                                                    Console.Clear();

                                                    // Check whether return method chosen is Drop Off
                                                    if (returnOptionChosen == 1)
                                                    {
                                                        while (!confirmReturnLocation)
                                                        {
                                                            if (returnLocation == "")
                                                            {
                                                                returnLocation = "shown";

                                                                Console.Clear();

                                                                // Display a list of FlexWheels Station location
                                                                DisplayFlexWheelsStations(flexWheelsStations);
                                                            }

                                                            while (true)
                                                            {
                                                                // Prompt for choice of FlexWheels Station
                                                                Console.Write("Choose one of the FlexWheels stations: ");
                                                                string? flexWheelsStationOption = Console.ReadLine();

                                                                bool flexWheelsStationOptionIsInt = int.TryParse(flexWheelsStationOption, out flexWheelsStationOptionChosen);

                                                                if (!flexWheelsStationOptionIsInt || flexWheelsStationOptionChosen <= 0 || flexWheelsStationOptionChosen > flexWheelsStations.Length)
                                                                {
                                                                    Console.WriteLine("===================================================================");
                                                                    Console.WriteLine("Please choose a valid option");
                                                                    Console.WriteLine("===================================================================");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("===================================================================");

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

                                                                    if (confirmReturnLocation)
                                                                    {
                                                                        returnLocation = flexWheelsStations[flexWheelsStationOptionChosen - 1];
                                                                    }
                                                                    else
                                                                    {
                                                                        returnLocation = "";
                                                                    }

                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    // Check whether return method chosen is Desired Location
                                                    else if (returnOptionChosen == 2)
                                                    {
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
                                                            break;
                                                        }

                                                        Console.Clear();

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
                                                                            returnLocation = returnLocationEntered;
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
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("=======================================================================");
                                                                Console.WriteLine("Please enter a valid location");
                                                                Console.WriteLine("=======================================================================");
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("==========================================");
                                                        Console.WriteLine("Please choose one of the options");
                                                        Console.WriteLine("==========================================");
                                                    }

                                                    // Update booking

                                                    Booking currentBooking = r.Bookings[Convert.ToInt32(optionChosen) - 1];
                                                    currentBooking.ReturnMethod = returnMethod;
                                                    currentBooking.ReturnLocation = returnLocation;
                                                    r.Bookings[Convert.ToInt32(optionChosen) - 1] = currentBooking;

                                                    Console.Clear();

                                                    Console.WriteLine(r.Bookings[Convert.ToInt32(optionChosen) - 1].ToString());
                                                    Console.WriteLine("===========================================");
                                                    Console.Write("Press enter to proceed to payment");
                                                    Console.ReadLine();

                                                    Console.Clear();

                                                    // Call "Make Payment" function (Get a status from "Make Payment" function that will break all the loops)

                                                    return;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("==========================================");
                                                    Console.WriteLine("Please choose one of the options");
                                                    Console.WriteLine("==========================================");
                                                }
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

            static void DisplayListOfVehiclesCurrentlyRenting(List<Booking> b)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("----------------------------- Welcome -----------------------------");
                Console.WriteLine("===================================================================");
                Console.WriteLine("     Sequence     |       Model       |    License Plate Number    ");
                Console.WriteLine("-------------------------------------------------------------------");
                for (int i = 0; i < b.Count; i++)
                {
                    Console.WriteLine("         " + (i + 1) + "        |      " + b[i].V.Model + "     |          " + b[i].V.LicensePlateNumber);
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
                Console.WriteLine("Additional fees will be charged for returning vehicle at your");
                Console.WriteLine("desired location");
                Console.WriteLine("===================================================================");
            }

            static void DisplayFlexWheelsStations(string[] s)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("----------------------- FlexWheels Stations -----------------------");
                Console.WriteLine("===================================================================");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + s[i]);
                }
                Console.WriteLine("===================================================================");
            }
        }
    }
}