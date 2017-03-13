using System.Collections.Generic;

namespace SimpleInvoices {
    public class Payment:identity {
        public double amount {get;set;}
        public PaymentTypes paymentTypes {get;set;}
    }
}