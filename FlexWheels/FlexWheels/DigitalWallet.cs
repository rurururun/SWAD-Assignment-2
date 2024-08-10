using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    internal class DigitalWallet : Payment
    {
        public string WalletId { get; set; }
        public string WalletProvider { get; set; }
        public string LinkedAccount { get; set; }
        public string TransactionReferenceNo { get; set; }

        public DigitalWallet() { }

        // Constructor
        public DigitalWallet(double a, DateTime pd, int pi, bool ps, string ti, string walletId, string walletProvider, string linkedAccount, string transactionReferenceNo): base(a, pd, pi, ps, ti)
        {
            WalletId = walletId;
            WalletProvider = walletProvider;
            LinkedAccount = linkedAccount;
            TransactionReferenceNo = transactionReferenceNo;
        }
    }
}
