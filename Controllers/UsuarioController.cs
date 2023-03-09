using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository= usuarioRepository;
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody]Usuario user)
        {
            try
            {
                user.FechaCreacion = DateTime.Now;
                await _usuarioRepository.GuardarUsuario(user);
                return Ok(new { Message = "Usuario Registrado con Exito !" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
