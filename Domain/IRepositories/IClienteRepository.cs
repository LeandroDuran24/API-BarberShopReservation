using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IClienteRepository
    {
        Task GuardarCliente(Cliente cliente);

        Task<List<Cliente>> GetClientes();

        Task<Cliente> BuscarCliente(int cliente);

        Task EliminarCliente(Cliente cliente);

        Task EditarCliente(Cliente cliente);
    }
}
