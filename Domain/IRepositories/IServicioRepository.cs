using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IServicioRepository
    {
        Task GuardarServicio(Servicio service);

        Task<List<Servicio>> GetServicios();

        Task<Servicio> BuscarServicio(int servicio);

        Task EliminarServicio(Servicio service);

        Task EditarServicio(Servicio service);
    }
}
