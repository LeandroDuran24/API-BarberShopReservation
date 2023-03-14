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
        public async Task<IActionResult> Post([FromBody]Cliente cliente)
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
    }
}
