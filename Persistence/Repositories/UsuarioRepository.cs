using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEBarberShop.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AplicationDbContext aplicationDbContext;

        public UsuarioRepository(AplicationDbContext context)
        {
            aplicationDbContext = context;
        }

        public async Task GuardarUsuario(Usuario user)
        {
            aplicationDbContext.Add(user);
            await aplicationDbContext.SaveChangesAsync();
        }

        public async Task<Usuario> IniciarSesion(Usuario user)
        {
            var usuario = await aplicationDbContext.Usuarios.Where(x => x.NombreUsuario == user.NombreUsuario).FirstOrDefaultAsync();

            if (usuario != null)
            {
                if (user.Password == usuario.Password)
                {
                    return usuario;
                }
                else
                {
                    throw new InvalidOperationException("Usuario o contraseña incorrecta");
                }

            }
            else
            {
                throw new InvalidOperationException("Usuario no existe");
            }

        }
    }
}
