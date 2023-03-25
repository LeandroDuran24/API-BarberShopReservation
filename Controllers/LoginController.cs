using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;
using BEBarberShop.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public LoginController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            this._usuarioService = usuarioService;
            _configuration = configuration;
        }


        //LOGIN

        [HttpPost]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] Usuario user)
        {

            try
            {
                user.Password = Encriptar.EncriptarPassword(user.Password);
               var usuario = await _usuarioService.IniciarSesion(user);
                string tokenString = JwtConfiguration.GetToken(usuario, _configuration);


                return Ok(new { token = tokenString });
             
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
