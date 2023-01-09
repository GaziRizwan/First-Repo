using System.Threading.Tasks;
using _2C2P_eKYC.DataObjects.Api.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [AllowAnonymous]
    [Consumes("application/x-www-form-urlencoded")]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("oauth2/token")]
        public async Task<IActionResult> OAuth([FromHeader(Name = "Authorization")] string credentials, [FromForm] string grant_type)
        {
            return Ok(await _mediator.Send(new AuthenticationRequest { Credential = credentials, GrantType = grant_type }));
        }
    }
}