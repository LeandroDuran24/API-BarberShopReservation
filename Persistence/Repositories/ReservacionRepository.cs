using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class ReservacionRepository :IReservacionRepository
    {
        private readonly AplicationDbContext _aplicationDbContext;

        public ReservacionRepository(AplicationDbContext aplicationDbContext)
        {
           _aplicationDbContext = aplicationDbContext;

        }

        public async Task GuardarReservacion(Reservacion reserva)
        {
            try
            {
               _aplicationDbContext.Add(reserva);
                await _aplicationDbContext.SaveChangesAsync();
              

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
