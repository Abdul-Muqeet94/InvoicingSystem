using System.Collections.Generic;

namespace SimpleInvoices {
    public class CustomersBillersProducts:identity{
        public Billers billers { get;set; }
        public Customer customers { get;set; }
        public product product { get;set; }

    }
}