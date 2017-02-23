namespace SimpleInvoices{
    public class InvoiceRes{
        public int id {get;set;}
        public int customerId {get;set;}
        public string custName{get;set;}
        public string billerId{get;set;}
        public string billerName {get;set;}
        public int productId{get;set;}
        public string productName{get;set;}
        public double price {get;set;}
    }
}