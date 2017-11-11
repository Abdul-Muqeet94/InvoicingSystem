using System.Collections.Generic;

namespace SimpleInvoices.ViewModels
{
    public class BillerSalesCustomer
    {
        public BillerSalesCustomer(){
            customer=new List<customerSales>();
        }
        public string billerName {get;set;}
        public List<customerSales> customer {get;set;}
    }

    public class customerSales {
        public string customerName {get;set;}
        public double sales {get;set;}
    }
}