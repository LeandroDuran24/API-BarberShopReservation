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

        public async Task EliminarFechaReservaCalendario(int idReserva)
        {
            var reserva = await aplicationDbContext.CalendarioReservacion.Where(x => x.ReservacionId == idReserva).FirstOrDefaultAsync();            
            reserva.Activo = 0;
            aplicationDbContext.Entry(reserva).State = EntityState.Modified;
            await aplicationDbContext.SaveChangesAsync();
        }

        public async Task<List<CalendarioReservaciones>> GetReservacionesCalendario(int idEstilista, DateTime fechaReserva)
        {
            var lista = await aplicationDbContext.CalendarioReservacion.Where(x => x.Reservacion.EstilistaId == idEstilista &x.Activo==1 & x.FechaReserva.Date == fechaReserva.Date).ToListAsync();

            return lista;
        }

        public async Task GuardarCalendarioReservacion(CalendarioReservaciones calendar)
        {
          aplicationDbContext.Add(calendar);
            await aplicationDbContext.SaveChangesAsync();

        }
    }
}
