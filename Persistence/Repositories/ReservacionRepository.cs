using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly AplicationDbContext _aplicationDbContext;

        public ReservacionRepository(AplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;

        }

        public async Task EditarReservacion(Reservacion reserva)
        {
            _aplicationDbContext.Update(reserva);
            await _aplicationDbContext.SaveChangesAsync();
        }

        public async Task EliminarReservacion(Reservacion reserva)
        {
            reserva.Activo = 0;
            _aplicationDbContext.Entry(reserva).State = EntityState.Modified;
            await _aplicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Reservacion>> GetListReservaciones()
        {
            var listReservaciones = await _aplicationDbContext.Reservacion.Where(x => x.Activo == 1).Include(x => x.ListReservacionDetalle)
                .Select(x => new Reservacion
                {
                    Id = x.Id,
                    Hora = x.Hora,
                    Fecha = x.Fecha,
                    Usuario = new Usuario { NombreUsuario = x.Usuario.NombreUsuario },
                    Estilista = new Estilista { Nombre = x.Estilista.Nombre, Apellidos = x.Estilista.Apellidos },
                    Cliente = new Cliente { Nombre = x.Cliente.Nombre, Apellidos = x.Cliente.Apellidos }

                }).ToListAsync();

            return listReservaciones;
        }

        public async Task<List<ReservacionDetalle>> GetListServiciosReservaciones(int idReserva)
        {
            //var listServicios = await _aplicationDbContext.ReservacionDetalle.Where(x => x.ReservacionId == idReserva).Select(x => new Servicio { Id = x.Servicio.Id, Nombre = x.Servicio.Nombre, Precio = x.Servicio.Precio }).ToListAsync();
            var listServicios = await _aplicationDbContext.ReservacionDetalle.Where(x=>x.ReservacionId==idReserva).Select(x => new ReservacionDetalle
            {
                ReservacionId = x.ReservacionId,
                Servicio = new Servicio { Nombre = x.Servicio.Nombre },
                Reservacion = new Reservacion
                {
                   
                    Activo=1,
                    Hora = x.Reservacion.Hora,
                    Fecha = x.Reservacion.Fecha,
                    Usuario = new Usuario { NombreUsuario = x.Reservacion.Usuario.NombreUsuario },
                    Estilista = new Estilista { Nombre = x.Reservacion.Estilista.Nombre, Apellidos = x.Reservacion.Estilista.Apellidos },
                    Cliente = new Cliente { Nombre = x.Reservacion.Cliente.Nombre, Apellidos = x.Reservacion.Cliente.Apellidos }
                }
            }).ToListAsync();

            return listServicios;
        }

        public async Task<Reservacion> GetReservacion(int idReserva)
        {
           var reservacion = await _aplicationDbContext.Reservacion.Where(x => x.Activo == 1 && x.Id == idReserva).FirstOrDefaultAsync();

            return reservacion;
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
