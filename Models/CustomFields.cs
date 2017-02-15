using System.Collections.Generic;

namespace SimpleInvoices {
    public class CustomFields:identity {
        public string fieldName {get;set;}
        public List<FieldValue> FieldValues{get;set;}
        public string tableName {get;set;}
    }
}