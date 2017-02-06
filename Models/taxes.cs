using System.Collections.Generic;

namespace SimpleInvoices {
    public class Taxes:identity {
        public string name {get;set;}
        public string value {get;set;}
        public List<ProductTaxes> productTaxes {get;set;}
    }
}