using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Repositories;
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
        private readonly ICalendarioReservacionRepository calendarioReservacionRepository;

        public ReservaController(IReservacionRepository reservacionRepository,ICalendarioReservacionRepository calendarioReservacionRepository)
        {
                this.reservacionRepository = reservacionRepository;
            this.calendarioReservacionRepository = calendarioReservacionRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservacion reserva)
        {
            try
            {
                CalendarioReservaciones calendario = new CalendarioReservaciones();
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

              

                reserva.Activo = 1;
                reserva.FechaCreacion = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                reserva.UsuarioId = idUsuario;
                

                //Guardo la reserva con el detalle
                await reservacionRepository.GuardarReservacion(reserva);

                //Guardo la reserva en la tabla calendario
                calendario.ReservacionId = reserva.Id;
                calendario.FechaReserva = reserva.Fecha;
                calendario.HoraInicio = reserva.Hora;
                calendario.Activo = 1;
                calendario.HoraFinal =CalcularHoraFinal(reserva.Hora,reserva.TiempoEstimadoCita) ;
                await calendarioReservacionRepository.GuardarCalendarioReservacion(calendario);


                return Ok(new { message = "Se ha registrado la reserva" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listReservaciones = await reservacionRepository.GetListReservaciones();
                return Ok(listReservaciones);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("GetReservacionServicios/{idReserva}")]

        public async Task<IActionResult> GetServicios(int idReserva)
        {
            try
            {
                var listReservacionesServicios = await reservacionRepository.GetListServiciosReservaciones(idReserva);
                return Ok(listReservacionesServicios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Reservacion reserva)
        {
            try
            {
                var reservacion = await reservacionRepository.GetReservacion(reserva.Id);
                reservacion.Hora = reserva.Hora;
                reservacion.Fecha = reserva.Fecha;
                reservacion.ClienteId = reserva.ClienteId;
                reservacion.EstilistaId = reserva.EstilistaId;
                reservacion.ListReservacionDetalle = reserva.ListReservacionDetalle;
                await reservacionRepository.EditarReservacion(reservacion);
                return Ok(new { message = "La Reservacion fue editada" });
               

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

             
        }
        [HttpDelete("{idReserva}")]
        public async Task<IActionResult> Delete(int idReserva)
        {
            try
            {

                var reserva = await reservacionRepository.GetReservacion(idReserva);
                
                if (reserva != null)
                {

                    await reservacionRepository.EliminarReservacion(reserva);
                    await calendarioReservacionRepository.EliminarFechaReservaCalendario(idReserva);

                    return Ok(new { message = "Se ha eliminado la Reservacion" });
                }
                else
                {
                    return BadRequest(new { message = "No se ha encontrado la reservacion" });
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Fecha")]
        public string CalcularHoraFinal(string horaCita, string tiempoEstimado)
        {

            DateTime horaFormateado =  Convert.ToDateTime(horaCita);
            string[] tmpCita = tiempoEstimado.Split(":");

            horaFormateado = horaFormateado.AddMinutes(Convert.ToInt32(tmpCita[1]));
            horaFormateado = horaFormateado.AddHours(Convert.ToInt32(tmpCita[0]));
           

            return Convert.ToString((horaFormateado).ToString("H:mm"));
        }
    }
}
