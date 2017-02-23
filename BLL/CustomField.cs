using SimpleInvoices.ViewModels;
using SimpleInvoices.Utils;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SimpleInvoices.BLL{
    public class CustomField{
        protected readonly InvoiceContext _db;
        public CustomField(InvoiceContext context){
            _db=context;
        }

         public List<CustomFieldRes> getCustomFields(string tableName)
        {
            List<CustomFieldRes> toReturn =new List<CustomFieldRes>();
            var db=_db;
            
            var fields=db.customFields.Where(c=>c.tableName.Equals(tableName)).Include(c=>c.FieldValues).ToList();
            if(fields.Count>0)
            {
                foreach(var entity in fields)
                {
                    toReturn.Add(new CustomFieldRes{
                        fieldName=entity.fieldName
                    });
                }
            }
            return toReturn;
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