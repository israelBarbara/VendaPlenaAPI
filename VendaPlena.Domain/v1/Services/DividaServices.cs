using Cinema.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaPlena.Domain.v1.DTOs.Response;
using VendaPlena.Domain.v1.Interfaces.Repositories;
using VendaPlena.Domain.v1.Interfaces.Services;
using System.Net;
using VendaPlena.Domain.v1.DTOs.Request;
using VendaPlena.Infrastructure;

namespace VendaPlena.Domain.v1.Services
{
    public class DividaServices : IDividaServices
    {
        private readonly IDividaRepository _dividaRepository;
        private readonly IClienteRepository _clienteRepository;

        public DividaServices(IDividaRepository dividaRepository, IClienteRepository clienteRepository)
        {
            _dividaRepository = dividaRepository;
            _clienteRepository = clienteRepository;
        }


        public APIMessage FindDividasCliente(int idCliente)
        {
            IEnumerable<DividaClienteResponse> dividas = _dividaRepository.FindDividasCliente(idCliente);
            return new APIMessage(HttpStatusCode.OK, dividas, "");
        }

        public APIMessage CadastrarDivida(CadastrarDividaRequest divida)
        {
            try
            {
                ClienteResponse cliente = _clienteRepository.FindCliente(divida.clienteId);

                if(cliente == null) return new APIMessage(HttpStatusCode.NotFound, "Nao encontrado", "");
                bool emAberto = _dividaRepository.DividaAberta(divida.clienteId);

                if (emAberto) return new APIMessage(HttpStatusCode.BadRequest, "Cliente possui dividas em aberto", "");

                _dividaRepository.CadastrarDivida(divida);
                return new APIMessage(HttpStatusCode.OK, cliente, "");
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, "Erro", "");
            }
        }

        public APIMessage TotalDevido()
        {
            decimal totalDivida = _dividaRepository.TotalDevido();
            return new APIMessage(HttpStatusCode.OK, totalDivida, "");
        }

        public APIMessage payDebt(int id)
        {
            try
            {
                bool pago = _dividaRepository.PagarDivida(id);
                return new APIMessage(HttpStatusCode.OK, pago, "");
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, "" , ex.Message);
            }
        }


    }
}
