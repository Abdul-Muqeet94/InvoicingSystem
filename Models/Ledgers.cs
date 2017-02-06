using System;

namespace SimpleInvoices {
    public class Ledgers:identity {
        public DateTime dueDate {get;set;}
        public double amount {get;set;}
        public double balance {get;set;}
        public CustomersBillersProducts customersBillersProducts {get;set;}
        
    }
}