using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext aplicationDbContext;

        public async Task<List<Cliente>> GetClientes()
        {
            return await aplicationDbContext.Clientes.Where(x => x.Activo == 1).ToListAsync();
        }

        public async Task GuardarCliente(Cliente cliente)
        {
            aplicationDbContext.Add(cliente);
          await  aplicationDbContext.SaveChangesAsync();
        }
    }
}
