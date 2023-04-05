using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface ICalendarioReservacionRepository
    {

        Task GuardarCalendarioReservacion(CalendarioReservaciones calendar);

        Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista, DateTime fechaReserva);

        Task EliminarFechaReservaCalendario(int idReserva);
    }
}
