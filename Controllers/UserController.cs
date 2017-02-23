using Microsoft.AspNetCore.Mvc;
using SimpleInvoices.ViewModels;
namespace SimpleInvoices.Controllers
{
    public class UserController: BaseController
    {
        public UserController(InvoiceContext context):base(context)
        { }

         [Route("api/users/register"), HttpPost]
         public BaseResponse AddUser([FromBody] RegisterUserReq user)
		{
			return new BLL.Users(_db).addUsers(user);
		}
        
    }
}