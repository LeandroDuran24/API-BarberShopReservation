using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IReservacionRepository
    {
        Task GuardarReservacion(Reservacion reserva);

        Task<List<Reservacion>> GetListReservaciones();

        Task<List<ReservacionDetalle>> GetListServiciosReservaciones(int idReserva );

        Task<Reservacion> GetReservacion(int idReserva);

        Task<List<ReservacionDetalle>> GetReservacionesHoy();


        Task EliminarReservacion(Reservacion reserva);
        Task EditarReservacion(Reservacion reserva);
    }
}
