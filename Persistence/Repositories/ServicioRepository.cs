using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Persistence.Context;

namespace BEBarberShop.Persistence.Repositories
{
    public class ServicioRepository : IServicioRepository
    {

        private readonly AplicationDbContext _context;

        public ServicioRepository(AplicationDbContext contex)
        {
            _context = contex;
        }

    }
}
