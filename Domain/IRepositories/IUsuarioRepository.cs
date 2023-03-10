using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> IniciarSesion(Usuario user);

        Task GuardarUsuario(Usuario user);

        Task<List<Usuario>> GetUsuarios();
    }
}
