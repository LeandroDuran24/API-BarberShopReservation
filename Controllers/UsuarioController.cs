using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.DTO;
using BEBarberShop.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

                var validateExistence = await _usuarioRepository.ValidateExistence(user);

                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + user.NombreUsuario + " ya existe" });
                }

                user.Activo = 1;
                user.FechaCreacion = DateTime.Now;
                user.Password = Encriptar.EncriptarPassword(user.Password);
                await _usuarioRepository.GuardarUsuario(user);
                return Ok(new { Message = "Usuario Registrado con Exito !" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
               var listUsuarios =  await _usuarioRepository.GetUsuarios();
                return Ok(listUsuarios);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetUsuario(int idUsuario)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(idUsuario);
                return Ok(usuario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> Delete(int idUsuario)
        {
            try
            {
                var usuario =await _usuarioRepository.BuscarUsuario(idUsuario);

                if(usuario!=null)
                {
                    await _usuarioRepository.EliminarUsuario(usuario);
                    return Ok(new { message = "Se ha eliminado el usuario" });
                }
                else
                {
                    return NotFound(new { message = "No se ha encontrado el usuario" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Usuario user)
        {
            try
            {

                var usuario = await _usuarioRepository.BuscarUsuario(user.Id);
                usuario.Nombre = user.Nombre;
                usuario.Apellidos = user.Apellidos;

                await _usuarioRepository.EditarUsuario(usuario);


                return Ok(new {message="El usuario fue editado"});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("CambiarPassword")]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO user)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);
                string passwordEncriptada = Encriptar.EncriptarPassword(user.passwordAnterior);
                var usuario = await _usuarioRepository.ValidatePassword(idUsuario, passwordEncriptada);


                if (usuario == null)
                {
                    return BadRequest(new { message = "Password incorrecta" });
                }
                else
                {
                    usuario.Password = Encriptar.EncriptarPassword(user.nuevaPassword);
                    await _usuarioRepository.CambiarPassword(usuario);
                    return Ok(new { message = "La Password fue actualizada con exito..." });
                } 


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
