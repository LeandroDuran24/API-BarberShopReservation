using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> IniciarSesion(Usuario user);

        Task GuardarUsuario(Usuario user);

        Task<List<Usuario>> GetUsuarios();

        Task<Usuario> BuscarUsuario(int user);

        Task EliminarUsuario(Usuario user);

        Task EditarUsuario(Usuario user);

        Task CambiarPassword(Usuario user);

        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
    }
}
