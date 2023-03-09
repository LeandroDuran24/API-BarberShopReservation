using BEBarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Context
{
    public class AplicationDbContext:DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }


        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options) 
        {

        }
    }
}
