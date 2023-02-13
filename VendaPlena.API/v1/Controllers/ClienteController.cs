using Cinema.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using VendaPlana.Domain.v1.DTOs.Request;
using VendaPlena.Domain.v1.Interfaces.Services;

namespace VendaPlena.API.v1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _services;

        public ClienteController(IClienteServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult InsertCliente(InsertClienteRequest cliente)
        {
            APIMessage result = _services.InsertCliente(cliente);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpGet("Clientes")]
        public IActionResult GetClientes()
        {
            APIMessage result = _services.FindAllClientes();
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            APIMessage result = _services.FindCliente(id);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            APIMessage result = _services.RemoveCliente(id);
            return StatusCode((int)result.StatusCode, result.Content);
        }

    }
}
