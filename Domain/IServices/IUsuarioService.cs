using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IUsuarioService
    {
        Task<Usuario> IniciarSesion(Usuario user);

        Task GuardarUsuario(Usuario user);

        Task<Usuario> BuscarUsuario(int user);

        Task<List<Usuario>> GetUsuarios();

        Task EliminarUsuario(Usuario user);

        Task EditarUsuario(Usuario user);

        Task CambiarPassword(Usuario user);
        Task<bool> ValidateExistence(Usuario usuario);
    }
}
