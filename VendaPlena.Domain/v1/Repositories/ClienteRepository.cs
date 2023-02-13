using VendaPlana.Domain.v1.DTOs.Response;
using VendaPlana.Domain.v1.DTOs.Request;
using VendaPlena.Domain.v1.Interfaces.Repositories;
using VendaPlena.Infrastructure;
using VendaPlena.Domain.v1.DTOs.Response;

namespace VendaPlena.Domain.v1.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VendaPlenaContext _context;

        public ClienteRepository(VendaPlenaContext context)
        {
            _context = context;
        }
        public ClienteResponse FindCliente(int id)
        {
            Cliente? _cliente = _context.Cliente.Find(id);
            if (_cliente == null) return null;

            ClienteResponse _clienteR = new ClienteResponse
            {
                Id = _cliente.Id,
                Nome = _cliente.Nome,
                TotalDivida = _context.Divida.Where(x => x.ClienteId == id && !x.Paga).Sum(y => y.Valor)
            };

            return _clienteR;
        }
        public IEnumerable<ClientesResponse> FindAllClientes()
        {
            return (from C in _context.Cliente
                    select new ClientesResponse
                    {
                        Id = C.Id,
                        Nome = C.Nome,
                        Email = C.Email,
                        Cpf = C.Cpf,
                        Idade = Convert.ToInt32((DateTime.Now - C.DataNascimento).TotalDays / 365),
                        TotalDivida = _context.Divida.Where(x => x.ClienteId == C.Id && !x.Paga).Sum(y => y.Valor)
                    }).OrderByDescending(v => v.TotalDivida).ToList();
        }
        public void InsertCliente(InsertClienteRequest cliente)
        {
            Cliente _cliente = new Cliente
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.CPF,
                DataNascimento = Convert.ToDateTime(cliente.DataNascimento)
            };
            _context.Cliente.Add(_cliente);
            _context.SaveChanges();
        }

        public bool RemoveCliente(int id)
        {
            Cliente? _cliente = _context.Cliente.Find(id);
            if (_cliente == null) return false;

            _context.Remove(_cliente);
            _context.SaveChanges();
            return true;
        }
    }
}
