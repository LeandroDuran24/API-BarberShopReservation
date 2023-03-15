using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IClienteService
    {
        Task GuardarCliente(Cliente cliente);
        Task<List<Cliente>> GetClientes();

        Task<Cliente> BuscarCliente(int cliente);

        Task EliminarCliente(Cliente cliente);

        Task EditarCliente(Cliente cliente);

    }
}
