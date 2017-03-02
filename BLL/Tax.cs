using System.Collections.Generic;
using System.Linq;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL{
    public class Tax
    {
         private readonly InvoiceContext _db ;
        public Tax(InvoiceContext db){
            _db=db;
        }
        public List<TaxViewRes> getAllTax(int id){
            List<TaxViewRes> toreturn=new List<TaxViewRes>();
            var db=_db;
            List<Taxes> tax=new List<Taxes>();
            if(id.Equals(0)){
                 tax=db.taxes.Where(m=>m.enable==true).ToList();
            }
            else{
                tax=db.taxes.Where(m=>m.Id.Equals(id) && m.enable==true).ToList();
            }
            foreach(var entity in tax){
            toreturn.Add(new TaxViewRes{
                id=entity.Id,
                name=entity.name
            });

            }
            return toreturn;
        }
        public BaseResponse addTax(TaxViewReq tax){
                BaseResponse toreturn =new BaseResponse();
                var db=_db;
                db.taxes.Add(new Taxes{
                    name=tax.name,
                    percent=tax.percentage,
                    enable=true
                });
                if(db.SaveChanges()>0){
                    toreturn.status=1;
                    toreturn.developerMessage="add taxes successfull";
                }
                else{
                    toreturn.status=2;
                    toreturn.developerMessage="unable to add taxes";
                }

                return toreturn;
        }
    }
}