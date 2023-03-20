using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class ServicioService :IServicioService
    {
        private readonly IServicioRepository servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public async Task<Servicio> BuscarServicio(int servicio)
        {
            return await servicioRepository.BuscarServicio(servicio);
        }

        public async Task EditarServicio(Servicio service)
        {
            await servicioRepository.EditarServicio(service);
        }

        public async Task EliminarServicio(Servicio service)
        {
            await servicioRepository.EliminarServicio(service);
        }

        public async Task<List<Servicio>> GetServicios()
        {
            return await servicioRepository.GetServicios();
        }

        public async Task GuardarServicio(Servicio service)
        {
            await servicioRepository.GuardarServicio(service);
        }
    }
}
