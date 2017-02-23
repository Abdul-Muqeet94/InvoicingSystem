using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.Controllers{
    public class CustomFieldController:BaseController{
        public CustomFieldController(InvoiceContext db):base(db){
        }
       [Route("api/customfield/getcustomfield"),HttpPost]
        public List<CustomFieldRes> getCustomField([FromBody] string tableName)
        {
            return new BLL.CustomField(_db).getCustomFields(tableName);
        }

        [Route("api/customfield/addcustomfield"),HttpPost]
        public BaseResponse addCustomField([FromBody] CustomFieldReq fields){
            return new BLL.CustomField(_db).addCustomField(fields);
        }
    }
}