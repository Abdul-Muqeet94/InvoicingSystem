using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers
{
    public class InvoiceController : BaseController
    {
        public InvoiceController(InvoiceContext context) : base(context)
        {

        }
        [Route("api/invoice/createinvoice"), HttpPost]
        public BaseResponse createInvoice([FromBody] InvoiceReq invoice)
        {
            return new BLL.Invoice(_db).createInvoice(invoice);
        }

        [Route("api/invoice/getinvoice"), HttpPost]
        public List<InvoiceRes> getInvoice([FromBody] InvoiceFilter fil)
        {
            return new BLL.Invoice(_db).getAllInvoice(fil.id, fil.type);
        }

        [Route("api/invoice/deleteinvoice"), HttpPost]
        public BaseResponse deleteInvoice([FromBody] int id)
        {
            return new BLL.Invoice(_db).deleteInvoice(id);
        }
        [Route("api/invoice/populatedropdown"), HttpPost]
        public List<UserDropdownRes> getDropDown([FromBody] String name)
        {
            return new BLL.Invoice(_db).getDropdownRes(name);
        }
        [Route("api/invoice/editInvoice"), HttpPost]
        public BaseResponse editInvoice([FromBody] InvoiceRes res)
        {
            return new BLL.Invoice(_db).editInvoice(res);
        }
        [Route("api/invoice/sendemail"), HttpPost]
        public BaseResponse sendEmail([FromBody] int id)
        {
            //Console.WriteLine(id +"sending email ID ................................");
            return new BLL.Invoice(_db).sendEmail(id);
        }
    }
}