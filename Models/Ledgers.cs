using System;

namespace SimpleInvoices {
    public class Ledgers:identity {
        public DateTime createdDate{get;set;}
        public DateTime deliveryDate{get;set;}
        public DateTime dueDate {get;set;}
        public double amount {get;set;}
        public double balance {get;set;}
        public int quantity {get;set;}
        public CustomersBillersProducts customersBillersProducts {get;set;}
        public Taxes tax {get;set;}
        
    }
}