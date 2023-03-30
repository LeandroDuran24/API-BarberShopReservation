using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IReservacionRepository
    {
        Task GuardarReservacion(Reservacion reserva);

        Task<List<Reservacion>> GetListReservaciones();
    }
}
