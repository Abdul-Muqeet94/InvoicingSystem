using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using SimpleInvoices;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL{
    public class Invoice {
        public readonly InvoiceContext _db;
        public Invoice (InvoiceContext context){
            _db=context;
        }
        public List<UserDropdownRes> getDropdownRes(string user){
            var db=_db;
            List<UserDropdownRes> dropdownRes=new List<UserDropdownRes>();
            if(user.ToLower().Equals("customer")){
                var usersList=db.customer.Where(c=>c.enable==true).ToList();
                foreach (var entity in usersList){
                    dropdownRes.Add(new UserDropdownRes{
                        id=entity.Id,
                        name=entity.name
                    });
                }
                
            }
            else if(user.ToLower().Equals("biller")){
                 var usersList=db.biller.Where(c=>c.enable==true).ToList();
                foreach (var entity in usersList){
                    dropdownRes.Add(new UserDropdownRes{
                        id=entity.Id,
                        name=entity.name
                    });
                }
            }
            else if(user.ToLower().Equals("product")){
                 var usersList=db.products.Where(c=>c.enable==true).ToList();
                foreach (var entity in usersList){
                    dropdownRes.Add(new UserDropdownRes{
                        id=entity.Id,
                        name=entity.name
                    });
                }
            }
            return dropdownRes;
            
        }
        public BaseResponse createInvoice(List<InvoiceReq> invoiceList){
            BaseResponse toReturn=new BaseResponse();
            CustomersBillersProducts customerBillerProduct=new CustomersBillersProducts();
            var db=_db;
            try{
                foreach(var invoice in invoiceList){
            var customer=db.customer.Where(c=>c.Id.Equals(invoice.customerId)).FirstOrDefault();
            var biller=db.biller.Where(c=>c.Id.Equals(invoice.billerId)).FirstOrDefault();
            var product=db.products.Where(c=>c.Id.Equals(invoice.productId)).FirstOrDefault();
            if(product==null){
                int productId=new SimpleInvoices.BLL.Products(db).addProduct(invoice.product).status;
                if(productId >0){
                    product=db.products.Where(c=>c.Id==productId).FirstOrDefault();
                } 
            }
            if(customer!=null && biller!=null && product!=null ){
                customerBillerProduct.customers=customer;
                customerBillerProduct.billers=biller;
                customerBillerProduct.product=product;
                customerBillerProduct.enable=Constant.USER_ACTIVE;
                db.customersBillersProducts.Add(customerBillerProduct);
                Double bal=(product.price*invoice.quantity)-invoice.amount;
                db.ledgers.Add(new Ledgers{
                    quantity=invoice.quantity,
                    createdDate=invoice.createdDate,
                    dueDate=invoice.dueDate,
                    amount=invoice.amount,
                    balance=bal,
                    customersBillersProducts=customerBillerProduct,
                    enable=Constant.USER_ACTIVE
                });
                
            }
                }
                if(db.SaveChanges()>0){
                    toReturn.developerMessage="Invoice Created Successfully";
                    toReturn.status=1;
                }
                else{
                    toReturn.developerMessage="Unable to Create invoice";
                    toReturn.status=2;
                }
            return toReturn;
            }
            catch (Exception ex){
                return new BaseResponse();
            }
            
        }
        public List<InvoiceRes> getAllInvoice(){
            List<InvoiceRes> toReturn=new List<InvoiceRes>();
            
            return toReturn;
        }

    }
}