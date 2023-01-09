using System.Threading.Tasks;
using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.Dopa.CheckStatusByLaser;
using _2C2P_eKYC.DataObjects.Api.Dopa.Inquiry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]/customers")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class DopaController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public DopaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("check-status-by-laser")]
        public async Task<IActionResult> CheckStatusByLaser([FromBody] CheckStatusByLaserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("transactions/{id}")]
        public async Task<IActionResult> InquiryById([FromRoute] string id)
        {
            return Ok(await _mediator.Send(new DopaTransactionInquiryRequest { Id = id }));
        }
    }
}