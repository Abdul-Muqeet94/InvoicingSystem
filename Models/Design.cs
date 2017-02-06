using System.Collections.Generic;

namespace SimpleInvoices {
    public class Design:identity {
       
        public string fabric {get;set;}
        public string cut {get;set;}
        public string color {get;set;}
        public string note {get;set;}
        public List<ProcuctDesign> productDesign {get;set;}
    }
}