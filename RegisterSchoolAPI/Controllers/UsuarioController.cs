using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Models;
using RegisterSchoolAPI.Dominio;
using RegisterSchoolAPI.Dto;

namespace RegisterSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        readonly IUsuario Servicio;
        public UsuarioController(IUsuario usuario) 
        {
            Servicio = usuario;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await Servicio.GetAll();
            if(result != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet(":id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = Servicio.GetById(id);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        public IActionResult Post(DtoCreateUsuario usuario)
        {
            var result = Servicio.Insert(usuario);
            if (result.Result.Item1 == true)
                return Ok();
            return BadRequest(result);
        }
        [HttpPatch(":id")]
        public async Task<IActionResult> Patch(DtoUpdateUsuario usuario, int id)
        {
            if (Servicio.GetById(id).Id != id)
            {
                return NotFound("Id invalido.");
            }
             var result  = await  Servicio.Updated(usuario, id);
            if (result.Item1)
                return Ok();
            return BadRequest("No se pudo actualizar el recurso!");
        }
    }
}
