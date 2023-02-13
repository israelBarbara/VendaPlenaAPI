using Cinema.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaPlana.Domain.v1.DTOs.Request;

namespace VendaPlena.Domain.v1.Interfaces.Services
{
    public interface IClienteServices
    {
        public APIMessage FindCliente(int id);
        public APIMessage FindAllClientes();
        public APIMessage InsertCliente(InsertClienteRequest cliente);
        public APIMessage RemoveCliente(int id);

    }
}
