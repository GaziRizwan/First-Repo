using _2C2P.eKYC.Api.Filters;
using _2C2P_eKYC.DataObjects.Api.DipChip;
using _2C2P_eKYC.DataObjects.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ServiceFilter(typeof(CustomAuthorizeFilter), Order = 2)]
    public class DipChipController : AuthenBaseController
    {
        private readonly IMediator _mediator;

        public DipChipController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region V1 & V2
        [HttpPost("statusforsuperrich")]
        public async Task<IActionResult> StatusForSuperRich([FromBody] DipChipStatusForSuperrichRequest request)
        {
            var claims = this.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                    var data = JsonConvert.DeserializeObject<UserData>(claim.Value);
                    request.CallerId = data.CallerId;
                    break;
                }
            }
            return Ok(await _mediator.Send(request));
        }
        #endregion

        #region V1 
        [MapToApiVersion("1")]
        [HttpPost("status")]
        public async Task<IActionResult> StatusByPId([FromBody] DipChipStatusByPIdRequest request)
        {
            var claims = this.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                    var data = JsonConvert.DeserializeObject<UserData>(claim.Value);
                    request.CallerId = data.CallerId;
                    break;
                }
            }
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("1")]
        [HttpPost("statuspassport")]
        public async Task<IActionResult> StatusByPassport([FromBody] DipChipStatusByPassportRequest request)
        {
            var claims = this.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                    var data = JsonConvert.DeserializeObject<UserData>(claim.Value);
                    request.CallerId = data.CallerId;
                    break;
                }
            }
            return Ok(await _mediator.Send(request));
        }
        #endregion

        #region V2
        [MapToApiVersion("2")]
        [HttpPost("status")]
        public async Task<IActionResult> StatusByPId([FromBody] DipChipStatusByPIdV2Request request)
        {
            var claims = this.User.Claims;

            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                    var data = JsonConvert.DeserializeObject<UserData>(claim.Value);
                    request.CallerId = data.CallerId;
                    break;
                }
            }
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpPost("statuspassport")]
        public async Task<IActionResult> StatusByPassport([FromBody] DipChipStatusByPassportV2Request request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpPost("statusbywalletcompany")]
        public async Task<IActionResult> StatusByWalletCompany([FromBody] DipChipStatusByWalletCompanyV2Request request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }

        [MapToApiVersion("2")]
        [HttpPost("statuspassportbywalletcompany")]
        public async Task<IActionResult> StatusPassportByWalletCompany([FromBody] DipChipStatusPassportByWalletCompanyV2Request request)
        {
            request.CallerId = this.GetCallerId();
            return Ok(await _mediator.Send(request));
        }
        #endregion
    }
}
