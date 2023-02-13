using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Domain.v1.DTOs.Response
{
    public class DividaClienteResponse
    {
        public int Id { get; set; }    
        public decimal Valor { get; set; }
        public string dataCriacao { get; set; }

    }
}
