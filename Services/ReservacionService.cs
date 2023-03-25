using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class ReservacionService:IReservacionService
    {

        private readonly IReservacionRepository reservacionRepository;

        public async Task GuardarReservacion(Reservacion reserva)
        {
            await reservacionRepository.GuardarReservacion(reserva);
        }
    }
}
