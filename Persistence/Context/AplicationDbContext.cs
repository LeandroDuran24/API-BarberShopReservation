using BEBarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
        public DbSet<Estilista> Estilistas { get; set; }

        public DbSet<Servicio> Servicios { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options) 
        {

        }
    }
}
