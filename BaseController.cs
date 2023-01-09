using System.Net.Mime;
using _2C2P.eKYC.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _2C2P.eKYC.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ServiceFilter(typeof(RequestResponseLoggingFilter), Order = 1)]
    public class BaseController : ControllerBase { }
}