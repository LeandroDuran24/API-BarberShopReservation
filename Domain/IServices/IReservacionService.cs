using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IReservacionService
    {
        Task GuardarReservacion(Reservacion reserva);
        Task<List<Reservacion>> GetListReservaciones();
    }
}
