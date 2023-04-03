using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;

namespace BEBarberShop.Persistence.Repositories
{
    public class CalendarioReservacionRepository : ICalendarioReservacionRepository
    {
        private readonly AplicationDbContext aplicationDbContext;

        public CalendarioReservacionRepository(AplicationDbContext aplicationDbContext)
        {
            this.aplicationDbContext = aplicationDbContext; 
        }

        public async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
          aplicationDbContext.Add(calendar);
            await aplicationDbContext.SaveChangesAsync();

        }
    }
}
