using SimpleInvoices.ViewModels;
using SimpleInvoices.Utils;

namespace SimpleInvoices.BLL{
    public class CustomField{
        protected readonly InvoiceContext _db;
        public CustomField(InvoiceContext context){
            _db=context;
        }

        public BaseResponse addCustomField(CustomFieldReq customField){
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            db.customFields.Add(new CustomFields{
                fieldName=customField.fieldName,
                tableName=customField.tableName,
                enable=Constant.USER_ACTIVE
                
            });
            if(db.SaveChanges()==1){
                toReturn.developerMessage="Custom Field Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="Custom Field cannot be added";
                toReturn.status=2;

            }
            return toReturn;
        }
    }
}