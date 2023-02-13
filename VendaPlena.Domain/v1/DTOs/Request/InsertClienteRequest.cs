using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlana.Domain.v1.DTOs.Request
{
    public class InsertClienteRequest
    {
        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor informe um {0}")]
        public string Email { get; set; }

    }
}
