using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class Payment
    {
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentId { get; set; }
        public bool PaymentStatus { get; set; }
        public string TransactionId { get; set; }

        public Payment(float a, DateTime pd, int pi, bool ps, string ti) 
        { 
            Amount = a;
            PaymentDate = pd;
            PaymentId = pi;
            PaymentStatus = ps;
            TransactionId = ti;
        }
    }
}
