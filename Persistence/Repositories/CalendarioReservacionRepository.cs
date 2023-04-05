using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class CalendarioReservacionRepository : ICalendarioReservacionRepository
    {
        private readonly AplicationDbContext aplicationDbContext;

        public CalendarioReservacionRepository(AplicationDbContext aplicationDbContext)
        {
            this.aplicationDbContext = aplicationDbContext; 
        }

        public async Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista)
        {
            var lista = await aplicationDbContext.CalendarioReservacion.Where(x => x.Reservacion.EstilistaId == idEstilista & x.FechaReserva.Date == DateTime.Now.Date).ToListAsync();

            return lista;
        }

        public async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
          aplicationDbContext.Add(calendar);
            await aplicationDbContext.SaveChangesAsync();

        }
    }
}
