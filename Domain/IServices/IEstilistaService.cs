using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IEstilistaService
    {
        Task GuardarEstilista(Estilista estilista);

        Task<List<Estilista>> GetEstilistas();

        Task<Estilista> BuscarEstilista(int estilista);

        Task EliminarEstilista(Estilista estilista);

        Task EditarEstilista(Estilista estilista);
    }
}
