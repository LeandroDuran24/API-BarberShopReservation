using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class EstilistaRepository :IEstilistaRepository
    {
        private readonly AplicationDbContext aplicationDbContext;
        public EstilistaRepository(AplicationDbContext aplicationDbContext)
        {
            this.aplicationDbContext = aplicationDbContext;
        }

        public async Task<Estilista> BuscarEstilista(int estilista)
        {
            var estilistaSearch =  await aplicationDbContext.Estilistas.Where(x => x.Id == estilista && x.Activo == 1).FirstOrDefaultAsync();

            return estilistaSearch;
        }

        public async Task EditarEstilista(Estilista estilista)
        {
            aplicationDbContext.Update(estilista);
            await aplicationDbContext.SaveChangesAsync();
        }

        public async Task EliminarEstilista(Estilista estilista)
        {
            estilista.Activo = 0;
            aplicationDbContext.Entry(estilista).State = EntityState.Modified;
            await aplicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Estilista>> GetEstilistas()
        {
            return await aplicationDbContext.Estilistas.Where(x => x.Activo == 1).ToListAsync();
            
        }

        public async Task GuardarEstilista(Estilista estilista)
        {
            aplicationDbContext.Add(estilista);
            await aplicationDbContext.SaveChangesAsync();
        }

       
    }
}
