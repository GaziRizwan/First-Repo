using _2C2P_eKYC.DataObjects.Api.CDD.Inquiry;
using _2C2P_eKYC.DataObjects.Api.CDD.SingleRegisterValidation;
using _2C2P_eKYC.DataObjects.Api.CDD.ValidateByCitizenId;
using _2C2P_eKYC.DataObjects.Api.CDD.ValidateByPassportNumber;
using _2C2P_eKYC.DataObjects.Api.CDD.ValidateGeneral;
using _2C2P_eKYC.DataObjects.Api.CDD.ValidateRegistration;
using _2C2P_eKYC.DataObjects.Api.V2.CDD.ValidateGeneral;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]/customers")]
    public class CddController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public CddController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("validation/citizen-id")]
        public async Task<IActionResult> ValidateByCitizenId([FromBody] ValidateByCitizenIdRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("validation/passport-number")]
        public async Task<IActionResult> ValidateByPassportNumber([FromBody] ValidateByPassportNumberRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("transactions/{id}")]
        public async Task<IActionResult> InquiryById([FromRoute] string id)
        {
            return Ok(await _mediator.Send(new CddTransactionInquiryRequest { Id = id }));
        }

        [HttpPost("registervalidation")]
        public async Task<IActionResult> ValidateRegistration([FromBody] RegisterValidationRequest request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("validation")]
        public async Task<IActionResult> ValidateGeneral([FromBody] GeneralValidationRequest request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpPost("single-register/validation")]
        public async Task<IActionResult> SingleRegisterValidation([FromBody] SingleRegisterValidationV2Request request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpPost("single-general/validation")]
        public async Task<IActionResult> SingleGeneralValidation([FromBody] GeneralValidationV2Request request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }
    }
}