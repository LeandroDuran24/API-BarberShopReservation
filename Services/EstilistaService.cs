using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class EstilistaService :IEstilistaService
    {
        private readonly IEstilistaRepository _estilistaRepository;

        public EstilistaService(IEstilistaRepository estilistaRepository)
        {
            _estilistaRepository= estilistaRepository;
        }

        public async Task<Estilista> BuscarEstilista(int estilista)
        {
            return await _estilistaRepository.BuscarEstilista(estilista) ;
        }

        public async Task EditarEstilista(Estilista estilista)
        {
             await _estilistaRepository.EditarEstilista(estilista);
        }

        public async Task EliminarEstilista(Estilista estilista)
        {
            await _estilistaRepository.EliminarEstilista(estilista);
        }

        public async Task<List<Estilista>> GetEstilistas()
        {
           return await _estilistaRepository.GetEstilistas();
        }

        public async Task GuardarEstilista(Estilista estilista)
        {
            await _estilistaRepository.GuardarEstilista(estilista);
        }
    }
}
