using System.Collections.Generic;

namespace SimpleInvoices.ViewModels{
    public class ProductViewReq{
        public ProductViewReq()
        {
            customField =new List<CustomFieldRes>();
            design=new List<DesignViewReq>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string color {get;set;}
        public string note {get;set;}
        public string description {get;set;}
        public double price {get;set;}
        public List<CustomFieldRes> customField {get;set;}
        public List<DesignViewReq> design {get;set;}
        
    }
}