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
    // Sheethal: Class for managing vehicle registration
    public class VehicleRegistration
    {
        // Sheethal: Static list to store registered vehicles
        private static List<Vehicle> vehicles = new List<Vehicle>();

        // Sheethal: Method to register a new vehicle
        public void RegisterVehicle()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("--------------------- Register a New Vehicle ---------------------");
            Console.WriteLine("===================================================================");

            string make = PromptForInput("Enter vehicle make: ");
            string model = PromptForInput("Enter vehicle model: ");
            string year = PromptForInput("Enter vehicle year: ");
            int mileage = PromptForIntInput("Enter vehicle mileage: ");
            string licensePlate = PromptForInput("Enter license plate: ");
            DateTime inspectionDate = PromptForDateInput("Enter inspection date (MM/DD/YYYY): ");
            string[] photos = PromptForInput("Enter photos (separate by commas): ").Split(',');
            string[] insurance = PromptForInput("Enter insurance information (separate by commas): ").Split(',');

            Vehicle vehicle = new Vehicle(make, model, year, mileage, photos, licensePlate, insurance, inspectionDate, 0, new List<Booking>());
            vehicles.Add(vehicle);
            Console.WriteLine("===================================================================");
            Console.WriteLine("Vehicle registered successfully!");
            Console.WriteLine("===================================================================");
        }

        // Sheethal: Method to validate a vehicle against predefined data
        public void ValidateVehicle()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("--------------------- Validate Vehicle Information ---------------------");
            Console.WriteLine("===================================================================");

            string make = PromptForInput("Enter vehicle make: ");
            string model = PromptForInput("Enter vehicle model: ");
            string year = PromptForInput("Enter vehicle year: ");
            int mileage = PromptForIntInput("Enter vehicle mileage: ");
            string licensePlate = PromptForInput("Enter license plate: ");
            DateTime inspectionDate = PromptForDateInput("Enter inspection date (MM/DD/YYYY): ");
            string[] photos = PromptForInput("Enter photos (separate by commas): ").Split(',');
            string[] insurance = PromptForInput("Enter insurance information (separate by commas): ").Split(',');

            bool isValid = true;
            isValid &= ValidateField("Vehicle Make", make, "Toyota");
            isValid &= ValidateField("Vehicle Model", model, "Camry");
            isValid &= ValidateField("Vehicle Year", year, "2020");
            isValid &= ValidateField("Vehicle Mileage", mileage, 15000);
            isValid &= ValidateField("License Plate", licensePlate, "ABC1234");
            isValid &= ValidateField("Inspection Date", inspectionDate, new DateTime(2024, 1, 1));
            isValid &= ValidateField("Photos", string.Join(",", photos), "photo1,photo2");
            isValid &= ValidateField("Insurance", string.Join(",", insurance), "valid");

            Console.WriteLine("====================================================================");  // Sheethal: Adding a line to separate error messages

            if (isValid)
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("Vehicle validation successful!");
                Console.WriteLine("===================================================================");
            }
            else
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine("Vehicle validation failed! Please check the entered information.");
                Console.WriteLine("===================================================================");
            }
        }

        // Sheethal: Method to display all registered vehicles
        public void DisplayRegisteredVehicles()
        {
            Console.WriteLine("===================================================================");
            Console.WriteLine("--------------------- Registered Vehicles ---------------------");
            Console.WriteLine("===================================================================");
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles registered.");
            }
            else
            {
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine(vehicle.ToString());
                    Console.WriteLine("===================================================================");
                }
            }
            Console.WriteLine();
        }

        // Sheethal: Utility methods for prompting user input and validation
        private string PromptForInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private int PromptForIntInput(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return PromptForIntInput(prompt);
            }
        }

        private DateTime PromptForDateInput(string prompt)
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid date in MM/DD/YYYY format.");
                return PromptForDateInput(prompt);
            }
        }

        private bool ValidateField(string fieldName, string input, string expectedValue)
        {
            if (input != expectedValue)
            {
                Console.WriteLine($"Invalid {fieldName}. Expected: {expectedValue}");
                return false;
            }
            return true;
        }

        private bool ValidateField(string fieldName, int input, int expectedValue)
        {
            if (input != expectedValue)
            {
                Console.WriteLine($"Invalid {fieldName}. Expected: {expectedValue}");
                return false;
            }
            return true;
        }

        private bool ValidateField(string fieldName, DateTime input, DateTime expectedValue)
        {
            if (input != expectedValue)
            {
                Console.WriteLine($"Invalid {fieldName}. Expected: {expectedValue.ToString("MM/dd/yyyy")}");
                return false;
            }
            return true;
        }
    }
}
