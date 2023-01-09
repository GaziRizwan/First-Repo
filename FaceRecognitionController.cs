using System.Threading.Tasks;
using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.FaceRecognition.Compare;
using _2C2P_eKYC.DataObjects.Api.FaceRecognition.Detect;
using _2C2P_eKYC.DataObjects.Api.FaceRecognition.Inquiry;
using _2C2P_eKYC.DataObjects.Api.FaceRecognition.TransactionInquiry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class FaceRecognitionController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public FaceRecognitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("comparison")]
        public async Task<IActionResult> FaceComparison([FromBody] FaceComparisonRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("transactions/{id}")]
        public async Task<IActionResult> InquiryById([FromRoute] string id)
        {
            return Ok(await _mediator.Send(new FaceTransactionInquiryRequest { Id = id }));
        }

        [MapToApiVersion("2")]
        [HttpPost("facedetection")]
        public async Task<IActionResult> FaceDetection([FromBody] FaceDetectionRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpGet("facetransactions/{id}")]
        public async Task<IActionResult> FaceDetectionInquiryById([FromRoute] string id)
        {
            return Ok(await _mediator.Send(new FaceDetectionTransactionInquiryRequest { Id = id }));
        }
    }
}