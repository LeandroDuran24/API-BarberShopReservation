using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IClienteRepositorye
    {
        Task GuardarCliente(Cliente cliente);
    }
}
