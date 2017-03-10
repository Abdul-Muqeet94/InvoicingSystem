using System;
using System.Collections.Generic;
namespace SimpleInvoices.ViewModels{
    public class InvoiceReq{
        public int id {get;set;}
        public DateTime date{get;set;}
        public int customerId{get;set;}
        public int billerId {get;set;}
        public List<ProductViewReq> product {get;set;}
        public string note{get;set;}

    }
}