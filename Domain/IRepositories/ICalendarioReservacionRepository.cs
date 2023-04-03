using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface ICalendarioReservacionRepository
    {

        Task GuardarCalendarioReservacion(CalendarioReservaciones calendar);
    }
}
