using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers{
    public class BillerController:BaseController{

        public BillerController(InvoiceContext context):base(context){
            
        }

        [Route("api/biller/create"), HttpPost]
        public BaseResponse addBiller ([FromBody] UserViewReq biller)
        {
            return new BLL.Biller(_db).addBiller(biller);
        }
        [Route("api/biller/edit"), HttpPost]
        public BaseResponse editBiller ([FromBody] UserViewReq biller)
        {
            return new BLL.Biller(_db).editBiller(biller);
        }
        [Route("api/biller/delete"), HttpPost]
        public BaseResponse deleteBiller ([FromBody] int biller)
        {
            return new BLL.Biller(_db).deleteBiller(biller);
        }
        [Route("api/biller/getCustomers"), HttpPost]
        public List<UserViewRes> getCustomers ([FromBody] int customer)
        {
            return new BLL.Customers(_db).getCustomers(customer);
        }

    }
}