using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.Customer.RiskProfile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class CustomerController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("riskprofile")]
        public async Task<IActionResult> RiskProfile([FromBody] CustomerRiskProfileRequest request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }
    }
}
