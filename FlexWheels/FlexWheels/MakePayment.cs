using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

public class MakePayment
{
    public void SelectPayment(double amount)
    {
        Console.WriteLine("Select Payment Method: 1. NETS 2. Credit Card 3. Digital Wallet");
        int paymentMethod = int.Parse(Console.ReadLine());

        switch (paymentMethod)
        {
            case 1:
                ProcessNetsPayment(amount);
                break;

            case 2:
                ProcessCreditCardPayment(amount);
                break;

            case 3:
                ProcessDigitalWalletPayment(amount);
                break;

            default:
                Console.WriteLine("Invalid payment method selected.");
                break;
        }
    }

    private void ProcessNetsPayment(double amount)
    {
        Console.WriteLine("Enter Internet Banking ID:");
        string netBankingID = Console.ReadLine();
        Console.WriteLine("Enter PIN:");
        string pin = Console.ReadLine();
        Console.WriteLine("Processing NETS payment...");
        // Add NETS payment processing logic here
        Console.WriteLine("NETS payment successful.");
    }

    private void ProcessCreditCardPayment(double amount)
    {
        Console.WriteLine("Enter Card Number:");
        string cardNumber = Console.ReadLine();
        Console.WriteLine("Enter Expiry Date:");
        string expiryDate = Console.ReadLine();
        Console.WriteLine("Enter CVC:");
        string cvc = Console.ReadLine();
        Console.WriteLine("Processing Credit Card payment...");
        // Add Credit Card payment processing logic here
        Console.WriteLine("Credit Card payment successful.");
    }

    private void ProcessDigitalWalletPayment(double amount)
    {
        Console.WriteLine("Processing Digital Wallet payment...");
        // Add Digital Wallet payment processing logic here
        Console.WriteLine("Digital Wallet payment successful.");
    }
}

