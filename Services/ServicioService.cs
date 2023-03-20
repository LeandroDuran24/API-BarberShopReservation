using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;

namespace BEBarberShop.Services
{
    public class ServicioService :IServicioService
    {
        private readonly IServicioRepository servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }
    }
}
