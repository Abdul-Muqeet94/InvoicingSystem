using System.Collections.Generic;

namespace SimpleInvoices {
    public class Design:identity {
       public Design(){
           productDesign=new List<ProductDesign>();
       }
       public string name {get;set;}
        public string fabric {get;set;}
        public string cut {get;set;}
        public string color {get;set;}
        public string note {get;set;}
        public List<ProductDesign> productDesign {get;set;}
    }
}