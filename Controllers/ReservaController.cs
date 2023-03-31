using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Repositories;
using BEBarberShop.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservacionRepository reservacionRepository;

        public ReservaController(IReservacionRepository reservacionRepository)
        {
                this.reservacionRepository = reservacionRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservacion reserva)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

                reserva.Activo = 1;
                reserva.FechaCreacion = DateTime.Now;
                reserva.UsuarioId = idUsuario;


                await reservacionRepository.GuardarReservacion(reserva);
                return Ok(new { message = "Se ha registrado la reserva" });
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
                var listReservaciones = await reservacionRepository.GetListReservaciones();
                return Ok(listReservaciones);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{idReserva}")]
        [Route("ListServicios")]
        public async Task<IActionResult> GetServicios(int idReserva)
        {
            try
            {
                var listReservacionesServicios = await reservacionRepository.GetListServiciosReservaciones(idReserva);
                return Ok(listReservacionesServicios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
