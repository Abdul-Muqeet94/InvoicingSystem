using System;

namespace SimpleInvoices.ViewModels{
    public class InvoiceReq{
        public int id {get;set;}
        public DateTime deliveryDate{get;set;}
        public DateTime createdDate{get;set;}
        public DateTime dueDate {get;set;}
        public double amount {get;set;}
         public int quantity {get;set;}
        public int customerId{get;set;}
        public int billerId {get;set;}
        public int productId {get;set;}
        public ProductViewReq product {get;set;}

    }
}