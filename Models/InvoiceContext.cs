
using Microsoft.EntityFrameworkCore;

namespace SimpleInvoices {
    public class InvoiceContext :DbContext{

        public InvoiceContext(DbContextOptions<InvoiceContext> dbContext):base(dbContext){
        }
       
        public DbSet<FieldValue> FieldValues {get;set;}
        public DbSet <SimpleInvoices.Users> users {get;set;}
        public DbSet <product> products {get;set;}
        public DbSet <Design> design {get;set;}
        public DbSet <ProcuctDesign> productDesign {get;set;}
        public DbSet <CustomersBillers> customersBillers {get;set;}
        public DbSet<UsersType> userType {get;set;}
        public DbSet<LedgerDetails> ledgerDetails {get;set;}
        public DbSet<Ledgers> ledgers {get;set;}
        public DbSet<CustomersBillersProducts> customersBillersProducts {get;set;}
        public DbSet<PaymentTypes> paymentTypes {get;set;}
        public DbSet<Taxes> taxes {get;set;}
        public DbSet<CustomFields> customFields {get;set;}
        public DbSet<ProductTaxes> ProductTaxes {get;set;}
    }
}