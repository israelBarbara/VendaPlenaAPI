using Cinema.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaPlena.Domain.v1.DTOs.Request;

namespace VendaPlena.Domain.v1.Interfaces.Services
{
    public interface IDividaServices
    {
        public APIMessage FindDividasCliente(int idCliente);

        public APIMessage CadastrarDivida(CadastrarDividaRequest divida);
        public APIMessage TotalDevido();
        public APIMessage payDebt(int id);

    }
}
