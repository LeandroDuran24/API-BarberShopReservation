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
    public class EstilistaController : ControllerBase
    {
        private readonly IEstilistaRepository estilistaRepository;

        public EstilistaController(IEstilistaRepository estilistaRepository)
        {
            this.estilistaRepository = estilistaRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estilista estilista)
        {
            try
            {
                try
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfiguration.GetTokenIdUsuario(identity);

                    estilista.UsuarioId = idUsuario;
                    estilista.Activo = 1;
                    estilista.FechaCreacion = DateTime.Now;
                    await estilistaRepository.GuardarEstilista(estilista);
                    return Ok(new { Message = "Estilista Registrado con Exito !" });

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
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
                var listEstilista = await estilistaRepository.GetEstilistas();
                return Ok(listEstilista);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{idEstilista}")]
        public async Task<IActionResult> GetEstilista(int idEstilista)
        {
            try
            {
                var cliente = await estilistaRepository.BuscarEstilista(idEstilista);
                return Ok(cliente);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{idEstilista}")]
        public async Task<IActionResult> Delete(int idEstilista)
        {
            try
            {
                var estilista = await estilistaRepository.BuscarEstilista(idEstilista);

                if (estilista != null)
                {
                    await estilistaRepository.EliminarEstilista(estilista);
                    return Ok(new { message = "Se ha eliminado el estilista" });
                }
                else
                {
                    return NotFound(new { message = "No se ha encontrado el estilista" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Estilista estilista)
        {
            try
            {


                var estilist = await estilistaRepository.BuscarEstilista(estilista.Id);
               estilist.Nombre = estilista.Nombre;
               estilist.Apellidos = estilista.Apellidos;
               estilist.Celular = estilista.Celular;
               estilist.Direccion = estilista.Direccion;
               estilist.Sexo = estilista.Sexo;
               estilist.FechaNacimiento = estilista.FechaNacimiento;
                estilist.Provincia = estilista.Provincia;
                estilist.Identificacion = estilista.Identificacion;
                estilist.TipoIdentificacion = estilista.TipoIdentificacion;

                await estilistaRepository.EditarEstilista(estilist);

                return Ok(new { message = "El estilista fue editado" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
