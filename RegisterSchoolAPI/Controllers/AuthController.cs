using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterSchoolAPI.Domain.Auth;
using RegisterSchoolAPI.Dto;
using RegisterSchoolAPI.Tools;
using System.Net;

namespace RegisterSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuth _Auth;
        protected ApiResponse _ApiResponse;
        public AuthController(IAuth auth)
        {
            _Auth = auth;
            _ApiResponse = new();
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Login(AuthDto auth)
        {
            try
            {
                var result = await _Auth.Autenticate(auth);
                if (result == null)
                {
                    _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                    _ApiResponse.IsSuccess = false;
                    return NotFound(_ApiResponse);
                }
                _ApiResponse.Result = result;
                _ApiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_ApiResponse);
            }
            catch (Exception ex)
            {
                _ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                _ApiResponse.IsSuccess = false;
                _ApiResponse.ErrorMessage = new List<string> { ex.Message };
                return BadRequest(_ApiResponse);
            }
            

        }
    }
}
