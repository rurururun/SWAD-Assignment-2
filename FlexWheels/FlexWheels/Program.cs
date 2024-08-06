﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            



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

            // Validate Driving License - Min Pyae Thar (S10240099)
            List<Admin> admins = new List<Admin>
            {
                new Admin("admin1", "SuperAdmin", DateTime.Now),
                new Admin("admin2", "Admin", DateTime.Now)
            };

            // valid Renter Object with valid license number
            Renter renter1 = new Renter(
                new DateTime(1980, 5, 15),                // DateOfBirth
                "A1234567",                              // DrivingLicenseNumber (valid)
                new DateTime(2035, 5, 15),                // DrivingLicenseExpiryDate (future date)
                "S1234567A",                              // Nric
                "10 MAIN STREET, #05-06, SINGAPORE 123456", // Address
                true,                                    // ValidatedDrivingLicense
                new DateTime(2024, 8, 1),                 // ValidationDate
                1,                                       // RenterId
                new List<Booking>()                      // Bookings (empty for this example)
            );

            // Renter object with an empty license number
            Renter renterEmptyLicense = new Renter(
                new DateTime(1980, 5, 15),                // DateOfBirth
                "",                                      // DrivingLicenseNumber (empty)
                new DateTime(2035, 5, 15),                // DrivingLicenseExpiryDate (future date)
                "S1234567A",                              // Nric
                "10 MAIN STREET, #05-06, SINGAPORE 123456", // Address
                true,                                    // ValidatedDrivingLicense
                new DateTime(2024, 8, 1),                 // ValidationDate
                1,                                       // RenterId
                new List<Booking>()                      // Bookings (empty for this example)
            );

            // Renter object with a license number that will not match the test input
            Renter renterInvalidLicense = new Renter(
                new DateTime(1980, 5, 15),                // DateOfBirth
                "A1234567",                              // DrivingLicenseNumber (valid but different from input)
                new DateTime(2035, 5, 15),                // DrivingLicenseExpiryDate (future date)
                "S1234567A",                              // Nric
                "10 MAIN STREET, #05-06, SINGAPORE 123456", // Address
                true,                                    // ValidatedDrivingLicense
                new DateTime(2024, 8, 1),                 // ValidationDate
                2,                                       // RenterId
                new List<Booking>()                      // Bookings (empty for this example)
            );

            // Renter object with an expired license
            Renter renterExpiredLicense = new Renter(
                new DateTime(1980, 5, 15),                // DateOfBirth
                "B2345678",                              // DrivingLicenseNumber (valid format)
                new DateTime(2000, 1, 1),                 // DrivingLicenseExpiryDate (past date)
                "S1234567B",                              // Nric
                "20 SECOND STREET, #03-04, SINGAPORE 234567", // Address
                true,                                    // ValidatedDrivingLicense
                new DateTime(2024, 8, 1),                 // ValidationDate
                3,                                       // RenterId
                new List<Booking>()                      // Bookings (empty for this example)
            );

            // Renter object with an incorrectly formatted license number
            Renter renterInvalidFormat = new Renter(
                new DateTime(1980, 5, 15),                // DateOfBirth
                "1234567",                               // DrivingLicenseNumber (invalid format)
                new DateTime(2035, 5, 15),                // DrivingLicenseExpiryDate (future date)
                "S1234567C",                              // Nric
                "30 THIRD STREET, #12-34, SINGAPORE 345678", // Address
                true,                                    // ValidatedDrivingLicense
                new DateTime(2024, 8, 1),                 // ValidationDate
                4,                                       // RenterId
                new List<Booking>()                      // Bookings (empty for this example)
            );

			//making Renter List
			List<Renter> renters = new List<Renter> { renter1, renterInvalidLicense, renterExpiredLicense, renterEmptyLicense, renterInvalidFormat };


            // making admin List



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
                    else if (profileChosen == "2")
                    {

                        Console.Clear();
                        DisplayAllRenters(renters);
                        SelectRenterAndValidate(renters);
						showMainMenu = "";
					}
                    else if (profileChosen == "3")
                    {
                        Console.Clear();
                        CarOwnerMenu();  // Sheethal 
                        showMainMenu = "";
                    }
                    else if (profileChosen == "4")
                    {
                        Console.Clear();
                        CancelRentalMenu();
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
				Console.WriteLine("2. Admin (Validate Driver License)");
                Console.WriteLine("3. Car Owner (Register Vehicle) ");
                Console.WriteLine("4. Renter (Cancel Rental)");  // Added Cancel Rental option
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
                Console.WriteLine("===============================================");
                Console.WriteLine("------------- FlexWheels Stations -------------");
                Console.WriteLine("===============================================");
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + s[i]);
                }
                Console.WriteLine("===============================================");
            }

            // Validate Driving License - Min Pyae Thar (S10240099)
            static void DisplayAllRenters(List<Renter> renters)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("--------------------------- List of Renters -----------------------");
                Console.WriteLine("===================================================================");
                foreach (var renter in renters)
                {
                    Console.WriteLine(renter.ToString());
                    Console.WriteLine("-------------------------------------------------------------------");
                }
                Console.WriteLine("===================================================================");
            }

            static void SelectRenterAndValidate(List<Renter> renters)
            {
                while (true)
                {
                    Console.WriteLine("Enter Renter ID to validate their driver's license, or type 'exit' to go back to the main menu:");

                    string? input = Console.ReadLine();

                    if (input?.ToLower() == "exit")
                    {
                        break; // Exit the loop and return to the main menu
                    }

                    if (int.TryParse(input, out int renterId))
                    {
                        var selectedRenter = renters.Find(r => r.RenterId == renterId);

                        if (selectedRenter != null)
                        {
                            Console.WriteLine($"Selected Renter:\n{selectedRenter}");
                            ValidateLicense(selectedRenter.DrivingLicenseNumber, selectedRenter);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Renter ID. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Renter ID.");
                    }

                    // Pause to allow the user to read the output
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }

            static void TestLicenseValidation(Renter renter)
            {
                Console.WriteLine("Running Test Cases for License Validation...\n");

                // Test Case TC-006: Submitting Empty License Info
                ValidateLicense("", renter);
                // Test Case TC-007: Submitting Expired License Info
                ValidateLicense("EXPIRED1234", renter);
                // Test Case TC-008: Submitting Non-Existent License Info
                ValidateLicense("NONEXISTENT", renter);
                // Test Case TC-009: Submitting Incorrectly Formatted License Info
                ValidateLicense("12345ABC", renter);
                // Test Case TC-010: Submitting Suspended License Info
                ValidateLicense("SUSPENDED1234", renter);
            }

            static void ValidateLicense(string license, Renter renter)
            {
                Console.WriteLine($"Validating License: {license} for NRIC: {renter.Nric}, Date of Birth: {renter.DateOfBirth.ToShortDateString()}");

                // Simulate license validation
                if (string.IsNullOrEmpty(license))
                {
                    Console.WriteLine("Error: Driver's license number cannot be empty.");
                }
                else if (license != renter.DrivingLicenseNumber)
                {
                    Console.WriteLine("Error: Driver's license number does not match the record.");
                }
                else if (DateTime.Now > renter.DrivingLicenseExpiryDate)
                {
                    Console.WriteLine("Error: Driver's license is expired.");
                }
                else if (license.Length != 8 || !char.IsLetter(license[0]))
                {
                    Console.WriteLine("Error: Invalid format for driver's license number.");
                }
                else
                {
                    Console.WriteLine("Driver's license validated successfully.");
                }

                Console.WriteLine();
            }

            // Sheethal: Car Owner menu options
            static void CarOwnerMenu()
            {
                while (true)
                {
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("--------------------- Car Owner Options ---------------------");
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("1. Register a vehicle");
                    Console.WriteLine("2. Validate a vehicle");
                    Console.WriteLine("3. Show registered vehicles");
                    Console.WriteLine("4. Exit to main menu");
                    Console.WriteLine("====================================================================");
                    Console.Write("Choose an option: ");
                    string? input = Console.ReadLine();
                    if (input == "1")
                    {
                        TestVehicleRegistration();  // Sheethal: Register vehicle
                    }
                    else if (input == "2")
                    {
                        ValidateVehicle();  // Sheethal: Validate vehicle
                    }
                    else if (input == "3")
                    {
                        ShowRegisteredVehicles();  // Sheethal: Show registered vehicles
                    }
                    else if (input == "4")
                    {
                        Console.Clear();
                        break;  // Sheethal: Exit to main menu
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please choose a valid option.");
                    }
                }
            }

            // Sheethal: Method to call the vehicle registration process
            static void TestVehicleRegistration()
            {
                VehicleRegistration registration = new VehicleRegistration();
                registration.RegisterVehicle();
            }

            // Sheethal: Method to call the vehicle validation process
            static void ValidateVehicle()
            {
                VehicleRegistration registration = new VehicleRegistration();
                registration.ValidateVehicle();
            }

            // Sheethal: Method to call the display registered vehicles process
            static void ShowRegisteredVehicles()
            {
                VehicleRegistration registration = new VehicleRegistration();
                registration.DisplayRegisteredVehicles();
            }


            static void CancelRentalMenu()
            {
                CancelRental cancelRentalService = new CancelRental();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("--------------------- Cancel Rental Options ---------------------");
                    Console.WriteLine("====================================================================");
                    Console.WriteLine("1. Cancel Rental");
                    Console.WriteLine("2. Exit to main menu");
                    Console.WriteLine("====================================================================");
                    Console.Write("Choose an option: ");
                    string? input = Console.ReadLine();

                    if (input == "1")
                    {
                        cancelRentalService.DisplayBookings();
                        Console.WriteLine("Enter Booking ID to cancel:");
                        if (int.TryParse(Console.ReadLine(), out int bookingId))
                        {
                            string result = cancelRentalService.CancelBooking(bookingId);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Booking ID. Please enter a numeric value.");
                        }
                    }
                    else if (input == "2")
                    {
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Please select a valid option.");
                    }

                    // Display updated list of active bookings
                    if (!exit)
                    {
                        Console.WriteLine("Updated list of active bookings:");
                        cancelRentalService.DisplayBookings();
                    }
                }
            }
        }
    }
}