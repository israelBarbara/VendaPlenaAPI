using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Domain.v1.DTOs.Request
{
    public class CadastrarDividaRequest
    {
        public int clienteId { get; set; }
        public decimal valor { get; set; }
    }
}
