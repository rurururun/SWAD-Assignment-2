using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
    public class DigitalWallet
    {
        public string WalletId { get; set; }
        public string WalletProvider { get; set; }
        public string LinkedAccount { get; set; }
        public string TransactionReferenceNo { get; set; }

        // Constructor
        public DigitalWallet(string walletId, string walletProvider, string linkedAccount, string transactionReferenceNo)
        {
            WalletId = walletId;
            WalletProvider = walletProvider;
            LinkedAccount = linkedAccount;
            TransactionReferenceNo = transactionReferenceNo;
        }
    }
}
