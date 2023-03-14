using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IClienteRepository
    {
        Task GuardarCliente(Cliente cliente);
    }
}
