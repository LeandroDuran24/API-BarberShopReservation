using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface ICalendarioReservacionService
    {
        Task GuardarCalendarioReservacion(CalendarioReservaciones calendar);
        Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista);
    }
}
