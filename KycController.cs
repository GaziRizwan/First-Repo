using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.Kyc;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class KycController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public KycController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("status")]
        public async Task<IActionResult> StatusByPId([FromBody] KycStatusByPIdRequest request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }
    }
}
