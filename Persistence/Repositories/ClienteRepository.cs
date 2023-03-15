using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext aplicationDbContext;

        public async Task<Cliente> BuscarCliente(int cliente)
        {
            var clienteSearch = await aplicationDbContext.Clientes.Where(x=> x.Id==cliente && x.Activo==1).FirstOrDefaultAsync();
            return clienteSearch;
        }

        public async Task EditarCliente(Cliente cliente)
        {
            aplicationDbContext.Update(cliente);
            await aplicationDbContext.SaveChangesAsync();

        }

        public async Task EliminarCliente(Cliente cliente)
        {
            cliente.Activo = 0;
            aplicationDbContext.Entry(cliente).State = EntityState.Modified;
            await aplicationDbContext.SaveChangesAsync();
        }

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
