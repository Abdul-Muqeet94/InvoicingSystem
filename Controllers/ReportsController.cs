using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers
{
    public class ReportsController:BaseController
    {
        public ReportsController(InvoiceContext context):base(context){}
/*
        [Route("api/reports/getCustomerWise"),HttpPost]
        public ReportsView getCutomerReport (ReqView req){

            return new BLL.Reports(_db).getCustomerReport(req);

        }
          */
    }
}