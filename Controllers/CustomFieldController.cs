using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers{
    public class CustomFieldController:BaseController{
        public CustomFieldController(InvoiceContext db):base(db){
        }

        [Route("api/customer/addcustomfield"),HttpPost]
        public BaseResponse addCustomField([FromBody] CustomFieldReq fields){
            return new BLL.CustomField(_db).addCustomField(fields);
        }
    }
}