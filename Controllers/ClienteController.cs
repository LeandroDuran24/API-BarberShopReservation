using BEBarberShop.Domain.IRepositories;
using BEBarberShop.Domain.Models;
using BEBarberShop.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEBarberShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                try
                {
                    cliente.Activo = 1;
                    cliente.FechaCreacion = DateTime.Now;
                    await _clienteRepository.GuardarCliente(cliente);
                    return Ok(new { Message = "Cliente Registrado con Exito !" });

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
                var listClientes = await _clienteRepository.GetClientes();
                return Ok(listClientes);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{idCliente}")]
        public async Task<IActionResult> GetCliente(int idCliente)
        {
            try
            {
                var cliente = await _clienteRepository.BuscarCliente(idCliente);
                return Ok(cliente);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete(int idCliente)
        {
            try
            {
                var cliente = await _clienteRepository.BuscarCliente(idCliente);

                if (cliente != null)
                {
                    await _clienteRepository.EliminarCliente(cliente);
                    return Ok(new { message = "Se ha eliminado el cliente" });
                }
                else
                {
                    return BadRequest(new { message = "No se ha encontrado el cliente" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {

                var client = await _clienteRepository.BuscarCliente(cliente.Id);
                client.Nombre = cliente.Nombre;
                client.Apellidos = cliente.Apellidos;
                client.Celular = cliente.Celular;
                client.Direccion = cliente.Direccion;
                client.Sexo = cliente.Sexo;
                client.FechaNacimiento = cliente.FechaNacimiento;
                client.Provincia = cliente.Provincia;
                cliente.Identificacion = cliente.Identificacion;
                client.TipoIdentificacion = cliente.TipoIdentificacion;

                await _clienteRepository.EditarCliente(cliente);

                return Ok(new { message = "El cliente fue editado" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
