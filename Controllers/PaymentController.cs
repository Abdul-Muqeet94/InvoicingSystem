using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers
{
    public class PaymentController:BaseController
    {
        public PaymentController(InvoiceContext context):base(context){

        }
        /*        [Route("api/payment/createpayment"),HttpPost]
        public BaseResponse createPayment([FromBody] paymentReq payment){
            return new BLL.Payment(_db).createPayment(payment);
        }
         */

    }
}