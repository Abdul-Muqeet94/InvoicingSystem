using System.Collections.Generic;

namespace SimpleInvoices {
    public class CustomersBillersProducts:identity{
        public CustomersBillers billers { get;set; }
        public CustomersBillers customers { get;set; }
        public product product { get;set; }

    }
}