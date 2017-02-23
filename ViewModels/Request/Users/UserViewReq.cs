using System.Collections.Generic;

namespace SimpleInvoices.ViewModels{
    public class UserViewReq{
        public UserViewReq(){
            customFields=new List<CustomFieldRes>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string address {get;set;}
        public string contact {get;set;}
        public string email {get;set;}
        public string city {get;set;}
        public List<CustomFieldRes> customFields {get;set;}
        
    }
}