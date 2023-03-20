using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly AplicationDbContext _context;

        public ServicioRepository(AplicationDbContext contex)
        {
            _context = contex;
        }

        public async Task<Servicio> BuscarServicio(int servicio)
        {
            var service= await _context.Servicios.Where(x => x.Id == servicio && x.Activo == 1).FirstOrDefaultAsync();
            return service;
        }


        public async Task EditarServicio(Servicio service)
        {

            _context.Update(service);
            await _context.SaveChangesAsync();

        }

        public async Task EliminarServicio(Servicio service)
        {
            service.Activo = 0;
            _context.Entry(service).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task<List<Servicio>> GetServicios()
        {
           var listService = await _context.Servicios.Where(x => x.Activo == 1).ToListAsync();
            return listService;
        }

        public async Task GuardarServicio(Servicio service)
        {
           _context.Add(service);
           await _context.SaveChangesAsync();
        }
    }
}
