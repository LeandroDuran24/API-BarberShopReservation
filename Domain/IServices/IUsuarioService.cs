using BEBarberShop.Domain.Models;

namespace BEBarberShop.Domain.IServices
{
    public interface IUsuarioService
    {
        Task<Usuario> IniciarSesion(Usuario user);

        Task GuardarUsuario(Usuario user);


        Task<List<Usuario>> GetUsuarios();
    }
}
