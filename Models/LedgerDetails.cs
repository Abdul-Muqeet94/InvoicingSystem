using System.Collections.Generic;

namespace SimpleInvoices {
    public class LedgerDetails:identity {
        public double amount {get;set;}
        public PaymentTypes paymentTypes {get;set;}
        public List<Ledgers> ledgers {get;set;}
    }
}