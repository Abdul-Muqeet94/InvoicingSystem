using System;
using System.Collections.Generic;
using System.Linq;
using SimpleInvoices;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL{

    public class Customers {
        private readonly InvoiceContext _db ;
        public Customers (InvoiceContext context){
            _db=context;
        }
        public List<CustomFieldRes> getCustomFields()
        {
            List<CustomFieldRes> toReturn =new List<CustomFieldRes>();
            var db=_db;
            var fields=db.customFields.Where(c=>c.tableName.Equals("Customers")).ToList();
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
        public List<UserViewRes> getCustomers (int id)
        {
            var db=_db;
            List<UserViewRes> toReturn =new List<UserViewRes>();
            List<CustomFields> fields=new List<CustomFields>();
            var usertype=db.userType.Where(c=>c.name.Equals("Customer")).FirstOrDefault();
            List<SimpleInvoices.CustomersBillers> userList=new List<SimpleInvoices.CustomersBillers>();
            if(id==0)
            {
              userList=db.customersBillers.Where(c=>c.userType.Equals(usertype) && c.enable==true).ToList();
              fields=db.customFields.Where(c=>c.tableName.Equals(Constant.TABLE_CUSTOMER)).ToList();
            }
            else
            {
             userList=db.customersBillers.Where(c=>c.Id.Equals(id) && c.userType.Equals(usertype) && c.enable==true).ToList();
              fields=db.customFields.Where(c=>c.tableName.Equals(Constant.TABLE_CUSTOMER)).ToList();
            }
            
            if(userList.Count>0)
            {
                foreach(var entity in userList)
                {
                    toReturn.Add(new UserViewRes(){
                        name=entity.name,
                        contact=entity.contact,
                        city=entity.city,
                        id=entity.Id,
                        email=entity.email,
                        address=entity.address,
                        customfields=(fields!=null)?bll_getcustomFields(fields,entity):new List<CustomFieldRes>()
                    });
                }
            }
            else{
                return toReturn;
            }
            return toReturn;
        }
        public List<CustomFieldRes> bll_getcustomFields(List<SimpleInvoices.CustomFields> customField,CustomersBillers customer){
            List<CustomFieldRes> toReturn =new List<CustomFieldRes>();
            
            for(int i=0;i<customField.Count;i++){

                toReturn[i].fieldName=customField[i].fieldName;
                toReturn[i].fieldValue=(customField[i].FieldValues.Where(c=>c.customBillers==customer).FirstOrDefault()!=null)?
                customField[i].FieldValues.Where(c=>c.customBillers==customer).FirstOrDefault().value:" ";
            }
            
            return toReturn;
        }
        public BaseResponse addCustomer(UserViewReq customer)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var Customer=db.customersBillers.Where(c=>c.email.Equals(customer.email)).FirstOrDefault();
            if(Customer==null)
            {
                SimpleInvoices.CustomersBillers cust=new SimpleInvoices.CustomersBillers();
                if(!db.userType.Any())
                {
                    Console.WriteLine("value is empty");
                    List<UsersType> types=new List<UsersType>();
                    
                    types.Add(new SimpleInvoices.UsersType(){
                        name="Customer",
                        enable=true
                    });
                    
                    types.Add(new SimpleInvoices.UsersType(){
                        name="Biller",
                        enable=true
                    });
                    db.userType.AddRange(types);
                    db.SaveChanges();
                }
                
                cust.name=customer.name;
                cust.address=customer.address;
                cust.city=customer.city;
                cust.contact=customer.contact;
                cust.email=customer.email;
                cust.enable=Constant.USER_ACTIVE;
                cust.userType=db.userType.Where(c=>c.name.Equals("Customer")).FirstOrDefault();
                if(customer.customFields.Count>0)
                {
                    foreach(var entity in customer.customFields)
                    {
                        string name=entity.fieldName;
                        var field=db.customFields.Where(c=>c.tableName.Equals("Customer") && c.fieldName.Equals(name)).FirstOrDefault();
                   field.FieldValues.Add(new FieldValue {
                        value=entity.fieldValue,
                        customBillers=cust 
                    });
                    
                   List<FieldValue> fieldValue=new List<FieldValue>();
                   fieldValue=field.FieldValues;
                    db.FieldValues.AddRange(fieldValue);
                    }
                    
                }
                db.customersBillers.Add(cust);
                if(db.SaveChanges()>=1)
                {
                    toReturn.status=1;
                    toReturn.developerMessage="Customer has been created";
                }
                else
                {
                    toReturn.status=2;
                    toReturn.developerMessage="Customer can not been created";
                }
            }
            else
            {
                toReturn.status=-2;
                toReturn.developerMessage="customer is already Created";
            }
            return toReturn;
        }

        public BaseResponse editCustomer(UserViewReq customer)
        {
            var db=_db;
            BaseResponse toReturn =new BaseResponse();
            var entity =db.customersBillers.Where(c=>c.Id.Equals(customer.id)).FirstOrDefault();
            if(entity!=null)
            {
                entity.address=customer.address;
                entity.contact=customer.contact;
                entity.city=customer.city;
                entity.email=customer.email;
                entity.name=customer.name;
                if(db.SaveChanges()==1)
                {
                    toReturn.status=1;
                    toReturn.developerMessage="Edit customer Successfully";

                }
                else
                {
                    toReturn.status=2;
                    toReturn.developerMessage="unable to Edit customer";
                }
            }
            else
            {
                toReturn.status=-1;
                toReturn.developerMessage="Cannot find user with that name";
            }
            return toReturn;

        }

        public BaseResponse deleteCustomer(int id)
        {
            BaseResponse toReturn =new BaseResponse();
            var db=_db;
            var entity=db.customersBillers.Where(c=>c.Id.Equals(id)).FirstOrDefault();
            if(entity!=null)
            {
            entity.enable=false;
            if(db.SaveChanges()==1)
            {
                toReturn.status=1;
                toReturn.developerMessage="Delete Customer Successfull";
            }
            else
            {
                 toReturn.status=2;
                toReturn.developerMessage="Unable to delete customer";
            }
            }
            else{
                toReturn.status=-1;
                toReturn.developerMessage="Unable to find customer with id "+id;
            }
            return toReturn;
        }

    }
}