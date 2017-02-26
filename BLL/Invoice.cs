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
                if(new SimpleInvoices.BLL.Products(db).addProduct(invoice.product).status==1){
                    product=db.products.Where(c=>c.Id==invoice.productId).FirstOrDefault();
                } 
            }
            if(customer!=null && biller!=null && product!=null ){
                customerBillerProduct.customers=customer;
                customerBillerProduct.billers=biller;
                customerBillerProduct.product=product;
                customerBillerProduct.enable=Constant.USER_ACTIVE;
                db.customersBillersProducts.Add(customerBillerProduct);
                Double bal=product.price-invoice.amount;
                db.ledgers.Add(new Ledgers{
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