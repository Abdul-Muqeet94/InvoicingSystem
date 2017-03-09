using System;
using System.Collections.Generic;
namespace SimpleInvoices.ViewModels{
    public class InvoiceReq{
        public int id {get;set;}
        public DateTime deliveryDate{get;set;}
        public DateTime createdDate{get;set;}
        public DateTime dueDate {get;set;}
        public int customerId{get;set;}
        public int billerId {get;set;}
        public List<ProductViewReq> product {get;set;}

    }
}