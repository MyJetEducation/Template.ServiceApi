using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Service.AssetsDictionaryApi.Models;
using Service.Web;

namespace Service.AssetsDictionaryApi.Controllers
{
    [OpenApiTag("Controller", Description = "description")]
    [Route("/api/v1/controller")]
    public class AssetsDictionaryApiController : BaseController
    {
        [HttpPost("method1")]
        [SwaggerResponse(HttpStatusCode.OK, typeof (DataResponse<Response>), Description = "Ok")]
        public async ValueTask<IActionResult> Method1Async()
        {
            var userId = GetUserId();
            if (userId == null)
                return StatusResponse.Error(ResponseCode.UserNotFound);

            return DataResponse<Response>.Ok(new Response());
        }

        [HttpPost("method2")]
        [SwaggerResponse(HttpStatusCode.OK, typeof (StatusResponse), Description = "Status")]
        public async ValueTask<IActionResult> Method2Async([FromBody] Request request)
        {
            var userId = GetUserId();
            if (userId == null)
                return StatusResponse.Error(ResponseCode.UserNotFound);

            return StatusResponse.Ok();
        }
    }
}
