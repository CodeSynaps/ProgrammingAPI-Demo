using Programming.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Programming.API.Security
{
    public class APIKeyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync (HttpRequestMessage request, CancellationToken
            cancellationToken)
        {
            //var queryString = request.RequestUri.ParseQueryString();
            //var apiKey = queryString["apiKey"];
            //Artık fiddler'da header kısmına ekleyip bağlanabiliyoruz.
            var apiKey = request.Headers.GetValues("apiKey").FirstOrDefault();
            UserDAL userDal = new UserDAL();
            var user = userDal.GetUserByApiKey(apiKey);
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "apiKey"));
                HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken);

        }
    }
}