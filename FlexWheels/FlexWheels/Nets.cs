using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Nets : Payment
    {
        public string AccountNumber { get; set; }
        public string TransactionReferenceNo { get; set; }
        public string BankName { get; set; }

        public Nets() { }

        // Constructor
        public Nets(double a, DateTime pd, int pi, bool ps, string ti, string accountNumber, string transactionReferenceNo, string bankName): base(a, pd, pi, ps, ti)
        {
            AccountNumber = accountNumber;
            TransactionReferenceNo = transactionReferenceNo;
            BankName = bankName;
        }
    }
}



