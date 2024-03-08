using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("{statusCode}")]
        public ObjectResult HandleStatus(HttpStatusCode statusCode)
        {
            APIResponse response = new()
            {
                StatusCode = statusCode,
                Success = false
            };

            ObjectResult result = new(response)
            {
                StatusCode = (int)statusCode
            };

            return result;
        }
    }
}
