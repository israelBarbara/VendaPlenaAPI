using VendaPlana.Domain.v1.DTOs.Request;
using VendaPlana.Domain.v1.DTOs.Response;
using VendaPlena.Domain.v1.DTOs.Response;
using VendaPlena.Infrastructure;

namespace VendaPlena.Domain.v1.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        public void InsertCliente(InsertClienteRequest cliente);
        public ClienteResponse FindCliente(int id);
        public bool RemoveCliente(int id);
        public IEnumerable<ClientesResponse> FindAllClientes();

    }
}
