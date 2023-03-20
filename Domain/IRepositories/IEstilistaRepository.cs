using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IEstilistaRepository
    {
        Task GuardarEstilista(Estilista estilista);

        Task<List<Estilista>> GetEstilistas();

        Task<Estilista> BuscarEstilista(int estilista);

        Task EliminarEstilista(Estilista estilista);

        Task EditarEstilista(Estilista estilista);
    }
}
