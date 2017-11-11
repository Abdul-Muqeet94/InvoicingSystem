using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers
{
    public class ReportsController:BaseController
    {
        public ReportsController(InvoiceContext context):base(context){
        }

        [Route("api/reports/totalsales"), HttpPost]
        public ToSalesRes totalSales ()
        {
           return new BLL.Reports(_db).totalSales();
        }
        [Route("api/reports/totalsalescustomerwise"), HttpPost]
        public TotalSalesCustomerRes totalSalesCustomerWise ()
        {
           return new BLL.Reports(_db).totalCustomerSales();
        }
        [Route("api/reports/totaltaxes"), HttpPost]
        public double totalTaxes ()
        {
           return new BLL.Reports(_db).totalTaxesReport();
        }
        [Route("api/reports/totalproduct"), HttpPost]
        public List<productSoldRes> totalProduct ()
        {
           return new BLL.Reports(_db).productSold();
        }
        [Route("api/reports/customerproduct"), HttpPost]
        public List<productCustomerRes> customerWiseProduct ()
        {
           return new BLL.Reports(_db).productCustomer();
        }
        [Route("api/reports/totalsalesbiller"), HttpPost]
        public BillerSalesRes totalSalesBiller ()
        {
           return new BLL.Reports(_db).billerSales();
        }
        [Route("api/reports/totalsalesbillercustomer"), HttpPost]
        public List<BillerSalesCustomer> billerSalesCustomers ()
        {
           return new BLL.Reports(_db).billerSalesCustomerWise();
        }
        [Route("api/reports/debatorbyowned"), HttpPost]
        public List<InvoiceRes> debatorByOwned ()
        {
           return new BLL.Reports(_db).debatorByOwned();
        }
         [Route("api/reports/debatorbyownedcustomer"), HttpPost]
        public List<InvoiceRes> debatorByOwnedCustomer ()
        {
           return new BLL.Reports(_db).debatorByOwnedCustomer();
        }
         [Route("api/reports/invoicebyfilter"), HttpPost]
        public List<InvoiceRes> getInvoiceByFilter([FromBody] invoiceFilter filter)
        {
           return new BLL.Reports(_db).getInvoicebyFilter(filter);
        }

         [Route("api/reports/backupdb"), HttpPost]
        public string DbBackup()
        {
            return new BLL.Reports(_db).dbBackUp();
        }


   /* billerSalesCustomerWise  debatorByOwned
     [Route("api/reports/totalsales"), HttpPost]
        public InvoiceRes totalSales ()
        {
           // return new BLL.Biller(_db).addBiller(biller);
        }

        string dbname = _dbContext.Database.Connection.Database;

const string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT,
    NOINIT,  NAME = N'MajesticDb-Ali-Full Database Backup',
    SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

int path = _dbContext.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior
    .DoNotEnsureTransaction,
    string.Format(sqlCommand, dbname, "MajesticDB"));
       
        */
    }
}