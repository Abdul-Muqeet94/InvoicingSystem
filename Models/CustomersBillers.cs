namespace SimpleInvoices {
    public class CustomersBillers:identity{
        public string name {get;set;}
        public string address {get;set;}
        public string contact {get;set;}
        public string email {get;set;}
        public string city {get;set;}
        public UsersType userType {get;set;}
    }
}