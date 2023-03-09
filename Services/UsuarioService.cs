using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.IServices;
using BEBarberShop.Domain.Models;

namespace BEBarberShop.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService( IUsuarioRepository usuarioRepository )
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task GuardarUsuario(Usuario user)
        {
            await _usuarioRepository.GuardarUsuario(user);
        }

        public async Task<Usuario> IniciarSesion(Usuario user)
        {

          return await _usuarioRepository.IniciarSesion(user);
        }
    }
}
