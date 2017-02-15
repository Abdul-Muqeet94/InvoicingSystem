namespace SimpleInvoices{
    public class FieldValue:identity {
        public string value {get;set;}
        public CustomersBillers customBillers{get;set;}
        public int IdUser {get;set;}
    }
}