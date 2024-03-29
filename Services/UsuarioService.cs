﻿using BEBarberShop.Domain.IRepositories;
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

        public async Task<Usuario> BuscarUsuario(int user)
        {
            return await _usuarioRepository.BuscarUsuario(user);
        }

        public async Task CambiarPassword(Usuario user)
        {
           await _usuarioRepository.CambiarPassword(user);
        }

        public async Task EditarUsuario(Usuario user)
        {
            await _usuarioRepository.EditarUsuario(user);
        }

        public async Task EliminarUsuario(Usuario user)
        {
            await _usuarioRepository.EliminarUsuario(user);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
          return  await _usuarioRepository.GetUsuarios();
        }

        public async Task GuardarUsuario(Usuario user)
        {
            await _usuarioRepository.GuardarUsuario(user);
        }

        public async Task<Usuario> IniciarSesion(Usuario user)
        {

          return await _usuarioRepository.IniciarSesion(user);
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            return await _usuarioRepository.ValidateExistence(usuario);

        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            return await _usuarioRepository.ValidatePassword(idUsuario, passwordAnterior);
        }
    }
}
