using System.Collections.Generic;

namespace SimpleInvoices.ViewModels{
    public class UserViewRes{
        public UserViewRes(){
            customfields=new List<CustomFieldRes>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string address {get;set;}
        public string contact {get;set;}
        public string email {get;set;}
        public string city {get;set;}
        public double total{get;set;}
        public double paid{get;set;}
        public double owing{get;set;}
        public List<CustomFieldRes> customfields{get;set;}

    }
}