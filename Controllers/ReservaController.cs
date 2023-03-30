﻿using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservacionRepository reservacionRepository;

        public ReservaController(IReservacionRepository reservacionRepository)
        {
                this.reservacionRepository = reservacionRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservacion reserva)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

                reserva.Activo = 1;
                reserva.FechaCreacion = DateTime.Now;
                reserva.UsuarioId = idUsuario;


                await reservacionRepository.GuardarReservacion(reserva);
                return Ok(new { message = "Se ha registrado la reserva" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
