using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;

        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaServicios = await _servicioRepository.GetServicios();
                return Ok(listaServicios);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idServicio}")]
        public async Task<IActionResult> GetServicio(int idServicio)
        {
            try
            {
                var service = await _servicioRepository.BuscarServicio(idServicio);
                return Ok(service);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Servicio service)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

                service.UsuarioId = idUsuario;
                service.Activo = 1;
                service.FechaCreacion = DateTime.Now;
                await _servicioRepository.GuardarServicio(service);
                return Ok(new { message = "Servicio Registrado con Exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Servicio service)
        {
            try
            {

               var servicio = await _servicioRepository.BuscarServicio(service.Id);
                servicio.Nombre = service.Nombre;
                servicio.Precio = service.Precio;
                servicio.Duracion = service.Duracion;
                await _servicioRepository.EditarServicio(servicio);
                return Ok(new { message = "El servicio fue editado" });
             
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idServicio}")]
        public async Task<IActionResult> Delete (int idServicio)
        {
            try
            {
                var servicio = await _servicioRepository.BuscarServicio(idServicio);

                if(servicio!=null)
                {

                    await _servicioRepository.EliminarServicio(servicio);
                    return Ok(new { message = "Se ha eliminado el servicio" });
                }
                else
                {
                    return BadRequest(new { message = "No se ha encontrado el servicio" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
