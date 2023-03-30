using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

                reserva.Activo = 1;
                reserva.FechaCreacion = DateTime.Now;
                reserva.UsuarioId = 1;
                reserva.ListReservacionDetalle[0].Id = 0;


                await reservacionRepository.GuardarReservacion(reserva);
                return Ok(new { message = "Se ha registrado la reserva" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
