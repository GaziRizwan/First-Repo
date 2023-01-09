using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Contexts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace _2C2P.eKYC.Api.Controllers
{
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class AuthenBaseController : BaseController
    {
        protected long GetCallerId()
        {
            long callerId = 0;

            var claims = this.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                    var data = JsonConvert.DeserializeObject<UserData>(claim.Value);
                    callerId = data.CallerId;
                    break;
                }
            }

            return callerId;
        }
    }
}