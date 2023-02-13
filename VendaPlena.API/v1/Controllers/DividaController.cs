using Cinema.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using VendaPlena.Domain.v1.DTOs.Request;
using VendaPlena.Domain.v1.Interfaces.Services;

namespace VendaPlena.API.v1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DividaController : ControllerBase
    {
        private readonly IDividaServices _services;

        public DividaController(IDividaServices services)
        {
            _services = services;
        }

        [HttpGet("Cliente-Dividas")]
        public IActionResult FindDividasCliente(int idCliente)
        {
            APIMessage result = _services.FindDividasCliente(idCliente);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpGet("Total-Divida")]
        public IActionResult TotalDivida()
        {
            APIMessage result = _services.TotalDevido();
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPut("{id}")]
        public IActionResult PayDebt(int id)
        {
            APIMessage result = _services.payDebt(id);
            return StatusCode((int)result.StatusCode, result.Content);
        }
        [HttpPost]
        public IActionResult CadastrarDivida(CadastrarDividaRequest divida)
        {
            APIMessage result = _services.CadastrarDivida(divida);
            return StatusCode((int)result.StatusCode, result.Content);
        }


    }
}
