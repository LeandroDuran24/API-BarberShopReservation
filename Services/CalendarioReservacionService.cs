using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class CalendarioReservacionService:ICalendarioReservacionService
    {
        private readonly ICalendarioReservacionService _calendarioReservacionService;

        public CalendarioReservacionService(ICalendarioReservacionService calendarioReservacionService)
        {
            _calendarioReservacionService = calendarioReservacionService;
        }

        public  async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
            await _calendarioReservacionService.GuardarCalendarioReservacion(calendar);
        }
    }
}
