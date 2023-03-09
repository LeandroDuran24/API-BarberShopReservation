using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }


        //LOGIN

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario user)
        {

            try
            {
               var usuario = await _usuarioService.IniciarSesion(user);

                return Ok(usuario);
             
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
