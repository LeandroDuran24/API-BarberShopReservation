using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public async Task<List<Cliente>> GetClientes()
        {
            return await _clienteRepository.GetClientes();
        }

        public async Task GuardarCliente(Cliente cliente)
        {
           await _clienteRepository.GuardarCliente(cliente);
        }
    }
}
