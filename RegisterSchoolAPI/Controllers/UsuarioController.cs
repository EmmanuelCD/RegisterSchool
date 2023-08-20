using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models;
using RegisterSchoolAPI.Domain;
using RegisterSchoolAPI.Dto;
using RegisterSchoolAPI.Tools;
using System.Net;

namespace RegisterSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuario Servicio;
        protected ApiResponse _ApiResponse;
        private readonly IMapper _Mapper;
        public UsuarioController(IUsuario usuario, IMapper mapper) 
        {
            Servicio = usuario;
            _Mapper = mapper;
            _ApiResponse = new();
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAll() 
        {
            try
            {
                var result = await Servicio.GetAll();
                if (result != null)
                {
                    _ApiResponse.Result = result;
                    _ApiResponse.StatusCode = HttpStatusCode.OK;
                    return Ok(_ApiResponse);
                }
                _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                _ApiResponse.IsSuccess = false;
                return NotFound(_ApiResponse);
            }
            catch (Exception ex)
            {
                _ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                _ApiResponse.IsSuccess = false;
                _ApiResponse.ErrorMessage = new List<string> { ex.Message };
                return BadRequest(_ApiResponse);
            }
            
                
            
        }
        [HttpGet(":id")]
        public async Task<ActionResult<ApiResponse>> Get(int id)
        {
            try
            {
                if(id == 0)
                {
                    _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                    _ApiResponse.IsSuccess = false;
                    return NotFound(_ApiResponse);
                }
                var result = await Servicio.GetById(id);
                if (result != null)
                {
                    _ApiResponse.Result = result;
                    _ApiResponse.StatusCode = HttpStatusCode.OK;
                    return Ok(_ApiResponse);
                }
                _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                _ApiResponse.IsSuccess = false;
                return NotFound(_ApiResponse);
            }
            catch (Exception ex)
            {
                _ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                _ApiResponse.IsSuccess=false;
                _ApiResponse.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(_ApiResponse);
            }
            
        }
        [HttpPost]
        public async  Task<ActionResult<ApiResponse>> Post([FromBody]DtoCreateUsuario usuario)
        {
            try
            {
                var result = await Servicio.Insert(usuario);
                if (result == true)
                {
                    _ApiResponse.StatusCode = HttpStatusCode.OK;
                    _ApiResponse.Result = "Successfully";
                    return Ok(_ApiResponse);
                }
                _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                _ApiResponse.IsSuccess = false;
                return NotFound(_ApiResponse);
            }
            catch (Exception ex)
            {
                _ApiResponse.StatusCode=HttpStatusCode.BadRequest;
                _ApiResponse.IsSuccess = false;
                _ApiResponse.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(_ApiResponse);
            }
            
        }
        [HttpPatch(":id")]
        [Authorize]
        public async Task<ActionResult<ApiResponse>> Patch([FromBody]DtoUpdateUsuario usuario, int id)
        {
            try
            {
               
                if (usuario != null)
                {
                    var result = await Servicio.Updated(usuario, id);
                    if (result)
                    {
                        _ApiResponse.StatusCode = HttpStatusCode.OK;
                        _ApiResponse.Result = result;
                        return Ok(_ApiResponse);
                    }
                    _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                    _ApiResponse.IsSuccess = false;
                    return NotFound(_ApiResponse);
                }
                _ApiResponse.StatusCode = HttpStatusCode.NotFound;
                _ApiResponse.IsSuccess = false;
                return NotFound(_ApiResponse);
            }
            catch (Exception ex)
            {
                _ApiResponse.StatusCode = HttpStatusCode.BadRequest;
                _ApiResponse.IsSuccess = false;
                _ApiResponse.ErrorMessage = new List<string>() { ex.Message };
                return BadRequest(_ApiResponse);
            }
           
           
        }
    }
}
