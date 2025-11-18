using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Programming.API.Security
{
    public class APIAuthorizeAttiribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            var actionRolse = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UserDAL userDAL = new UserDAL();
            var user = userDAL.GetUserByName(userName);
            if (user!=null){

            }
            else{

            }
        }
    }
}