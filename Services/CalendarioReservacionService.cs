using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class CalendarioReservacionService:ICalendarioReservacionService
    {
        private readonly ICalendarioReservacionService _calendarioReservacionService;

        public async Task EliminarFechaReservaCalendario(int idReserva)
        {
            await _calendarioReservacionService.EliminarFechaReservaCalendario(idReserva);
        }

        public async Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista, DateTime fechaReserva)
        {
            var lista = await _calendarioReservacionService.GetReservacionesCalendario(idEstilista,fechaReserva);
            return lista;
        }

        public  async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
            await _calendarioReservacionService.GuardarCalendarioReservacion(calendar);
        }
    }
}
