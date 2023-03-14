using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IClienteService
    {
        Task Cliente GuardarCliente(Cliente cliente);
    }
}
