using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Domain.v1.DTOs.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public decimal TotalDivida { get; set; }

    }
}
