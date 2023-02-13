using Cinema.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VendaPlana.Domain.v1.DTOs.Request;
using VendaPlana.Domain.v1.DTOs.Response;
using VendaPlena.Domain.v1.DTOs.Response;
using VendaPlena.Domain.v1.Extensions;
using VendaPlena.Domain.v1.Interfaces.Repositories;
using VendaPlena.Domain.v1.Interfaces.Services;

namespace VendaPlena.Domain.v1.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public APIMessage FindCliente(int id)
        {
            try
            {
                ClienteResponse cliente =  _clienteRepository.FindCliente(id);
                return new APIMessage(HttpStatusCode.OK, cliente, "OK");
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.OK, "", ex.Message);
            }
            
        }

        public APIMessage FindAllClientes()
        {
            try
            {
                IEnumerable<ClientesResponse> clientes = _clienteRepository.FindAllClientes();
                return new APIMessage(HttpStatusCode.OK, clientes,"OK");
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.OK, "",ex.Message);
            }

        }


        public APIMessage InsertCliente(InsertClienteRequest cliente)
        {
            try
            {
                if (!CPF.ValidateCPF(cliente.CPF)) return new APIMessage(HttpStatusCode.BadRequest, "", "CPF Invalido");
                if (cliente.Nome.Length == 0) return new APIMessage(HttpStatusCode.BadRequest, "", "Nome Invalido");
                if (!Date.ValidadeDate(cliente.DataNascimento)) return new APIMessage(HttpStatusCode.BadRequest, "", "Data invalida");

                cliente.CPF = cliente.CPF.Replace(".","").Replace("-","");

                _clienteRepository.InsertCliente(cliente);
                return new APIMessage(HttpStatusCode.OK, "", "Cliente cadastrado");

            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, "", ex.Message);
            }

        }

        public APIMessage RemoveCliente(int id)
        {
            try
            {
                _clienteRepository.RemoveCliente(id);
                return new APIMessage(HttpStatusCode.OK, true, "Cliente removido");
            }
            catch (Exception ex)
            {
                return new APIMessage(HttpStatusCode.InternalServerError, false, ex.Message);
            }
            
        }
    }
}
