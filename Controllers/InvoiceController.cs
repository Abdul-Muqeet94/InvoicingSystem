using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers
{
    public class InvoiceController:BaseController{
        public InvoiceController(InvoiceContext context):base(context){

        }
        [Route("api/invoice/createinvoice"),HttpPost]
        public BaseResponse createInvoice([FromBody] InvoiceReq invoice)
        {
            return new BLL.Invoice(_db).createInvoice(invoice);
        } 
    }
}