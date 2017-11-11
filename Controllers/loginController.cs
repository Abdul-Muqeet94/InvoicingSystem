using System;
using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;
using Microsoft.AspNetCore.Http;

namespace SimpleInvoices.Controllers
{


    public class loginController : BaseController
    {
        public const string sessionId="id";
        public loginController(InvoiceContext context) : base(context) { }

        [Route("api/login/biller"), HttpPost]
        public BaseResponse loginUser([FromBody] loginReq req)
        {
            return new BLL.Login(_db).loginUser(req);
        }
        [Route("api/login/savesession"), HttpPost]
        public int? StoreSession([FromBody] int id)
        {
           // HttpContext
           // SessionClass _session=new SessionClass();
        
            HttpContext.Session.SetInt32(sessionId, id);
            
            return HttpContext.Session.GetInt32(sessionId);
        }
        [Route("api/login/getsession"), HttpPost]
        public int? getSession()
        {
            // Console.WriteLine(req.email + "    " + req.password);
            int? sesionid = HttpContext.Session.GetInt32(sessionId);
            return sesionid;
        }
    }



}