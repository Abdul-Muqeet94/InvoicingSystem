using System.Collections.Generic;

namespace SimpleInvoices.ViewModels
{
    public class billerInvoiceRes
    {
        public string customerName{get;set;}
        public billerInvoiceRes(){
            invoices=new List<InvoiceRes>();
        }
        List<InvoiceRes> invoices=new List<InvoiceRes>();
    }
}