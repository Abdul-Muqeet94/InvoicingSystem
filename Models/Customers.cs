using System.Collections.Generic;

namespace SimpleInvoices {
    public class Customers:identity {
        public string name {get;set;}
        public string address {get;set;}
        public string contact {get;set;}
        public string email {get;set;}
        public string city {get;set;}
        public List<CustomersBillersProducts> customersBillersProducts {get;set;}
    }
}