using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.LivenessDetection;
using _2C2P_eKYC.DataObjects.Api.LivenessDetection.Transaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("2")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class LivenessDetectionController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public LivenessDetectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("livedetection")]
        public async Task<IActionResult> IdentifyLivenessDetection([FromBody] LivenessDetectionV2Request request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("livedetection/transaction/{id}")]
        public async Task<IActionResult> GetTransactionDetails([FromRoute] string id)
        {
            return Ok(await _mediator.Send(new LivenessDetectionTransactionV2Request { Id = id }));
        }
    }
}
