using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class CalendarioReservacionService:ICalendarioReservacionService
    {
        private readonly ICalendarioReservacionService _calendarioReservacionService;

        public async Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista)
        {
            var lista = await _calendarioReservacionService.GetReservacionesCalendario(idEstilista);
            return lista;
        }

        public  async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
            await _calendarioReservacionService.GuardarCalendarioReservacion(calendar);
        }
    }
}
