using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleInvoices {

public class product:identity {
    public string name {get;set;}
    public string color {get;set;}
    public double price {get;set;}
    public string note {get;set;}
    public string description {get;set;}
    public double unitPrice{get;set;}
    public List<ProductTaxes> productTaxes {get;set;}
    public List<CustomersBillersProducts> customersBillersProduct {get;set;}
    public List<ProcuctDesign> productDesign {get;set;}
    public DateTime createdOn {get {
        return createdOn;
    } set 
    {
        this.createdOn=DateTime.Now;
    }}
    }
}