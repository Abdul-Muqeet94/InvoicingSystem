using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleInvoices;
using SimpleInvoices.ViewModels;
namespace SimpleInvoices.BLL
{
    public class Payment
    {
        private readonly InvoiceContext _db;
        public Payment(InvoiceContext context)
        {
            _db = context;
        }
        public BaseResponse createPayment(PaymentReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var invoice = db.ledgers.Where(c => c.enable && c.Id.Equals(req.invoiceId)).FirstOrDefault();
            var payType = db.paymentTypes.Where(c => c.enable == true && c.Id.Equals(req.paymentTypeId)).FirstOrDefault();
            SimpleInvoices.Payment pay = new SimpleInvoices.Payment();
            pay.amount = req.amount;
            pay.paymentTypes = payType;
            pay.enable=true;
            db.payment.Add(pay);
            invoice.payment.Add(pay);
            db.SaveChanges();
            invoice.balance = invoice.amount - req.amount;
            db.SaveChanges();
            return toReturn;
        }
        public List<PaymentRes> getPayment (int id){
            var db =_db;
            List<PaymentRes> toReturn=new List<PaymentRes>();
            List<SimpleInvoices.Payment> pay = new List<SimpleInvoices.Payment>();
            Ledgers invoice=new Ledgers();
            if(id==0){
              pay=  db.payment.Where(c=>c.enable==true).ToList();
            }
            else{
               pay =db.payment.Where(c=>c.enable==true && c.Id.Equals(id)).Include(c=>c.paymentTypes).ToList();
            }
            foreach(var item in pay){
              invoice=db.ledgers.Where(c=>c.payment.Contains(item)).SingleOrDefault();
                
                toReturn.Add(new PaymentRes{
                    amount=item.amount,
                    invoiceName=invoice.invoiceName,
                    paymentType=item.paymentTypes.name
                });
            }
            return toReturn;
            
        }

#region PayementType

        public BaseResponse createPaymentType(PaymentTypeReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            db.paymentTypes.Add(new PaymentTypes{
                name=req.name
            });
            if (db.SaveChanges() > 0)
            {
                toReturn.status = 1;
                toReturn.developerMessage = "Payment type created Successfully";
            }
            return toReturn;
        }
        public List<PaymentTypeRes> getPaymentType(){
            List<PaymentTypeRes> toReturn =new List<PaymentTypeRes>();
            var db=_db;
            var payType=db.paymentTypes.Where(c=>c.enable==true).ToList();
             foreach (var item in payType)
            {
                toReturn.Add(new PaymentTypeRes{
                    id=item.Id,
                    name=item.name
                });
            }
             return toReturn;
        }
        #endregion
    }










}