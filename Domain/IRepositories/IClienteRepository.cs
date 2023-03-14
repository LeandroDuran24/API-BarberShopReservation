using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public class IClienteRepository
    {

        Task Cliente GuardarCliente(Cliente cliente);
    }
}
