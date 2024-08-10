using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class CreditCard : Payment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Cvv { get; set; }
        public string BillingAddress { get; set; }

        public CreditCard() { }

        // Constructor
        public CreditCard(double a, DateTime pd, int pi, bool ps, string ti, string cardNumber, string cardHolderName, DateTime expiryDate, int cvv, string billingAddress): base(a, pd, pi, ps, ti)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpiryDate = expiryDate;
            Cvv = cvv;
            BillingAddress = billingAddress;
        }
    }
}
