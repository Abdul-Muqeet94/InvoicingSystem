using System;
using System.Linq;
using SimpleInvoices.ViewModels;

namespace SimpleInvoices.BLL
{

    public class Login
    {
        private readonly InvoiceContext _db;
        public Login(InvoiceContext context)
        {
            _db = context;
        }
        public BaseResponse loginUser(loginReq login)
        {
           
            try{
            var db = _db;
            BaseResponse toReturn = new BaseResponse();
            if(!db.biller.Any())
            {
                Billers toAdd=new SimpleInvoices.Billers();
                toAdd.address="N/A";
                toAdd.city="Karachi";
                toAdd.contact="03322238179";
                toAdd.email="danishbcd@gmail.com";
                toAdd.enable=true;
                toAdd.name="danish";
                Passwords.setPassword(toAdd,toAdd.name);
                db.biller.Add(toAdd);
                db.SaveChanges();
            }
            var biller = db.biller.Where(c => c.email.Equals(login.email)).FirstOrDefault();
           
             if (biller != null)
            {
                if (Passwords.validate(biller, login.password))
                {
                    toReturn.status = biller.Id;
                    toReturn.developerMessage = "User Exists";
                }
            }
            else
            {
                toReturn.status = -1;
                toReturn.developerMessage = "biller with this name and id does not exists";
            }
            return toReturn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                 BaseResponse toReturn = new BaseResponse();
                 return toReturn;
                
            }
        }

    }
}