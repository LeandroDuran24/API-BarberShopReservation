using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioReservacionRepository _calendarioReservacionRepository;

        public CalendarioController(ICalendarioReservacionRepository calendarioReservacionRepository)
        {
            this._calendarioReservacionRepository = calendarioReservacionRepository;
        }

        [HttpGet("{idEstilista}")]

        public async Task<IActionResult>Get(int idEstilista)
        {
            try
            {
                var calendarioReservaciones = await _calendarioReservacionRepository.GetReservacionesCalendario(idEstilista);
                return Ok(calendarioReservaciones);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
