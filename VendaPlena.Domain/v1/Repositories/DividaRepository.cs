using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaPlena.Domain.v1.DTOs.Request;
using VendaPlena.Domain.v1.DTOs.Response;
using VendaPlena.Domain.v1.Interfaces.Repositories;
using VendaPlena.Infrastructure;
using VendaPlena.Infrastructure.EntityModels.Models;

namespace VendaPlena.Domain.v1.Repositories
{
    public class DividaRepository : IDividaRepository
    {
        private readonly VendaPlenaContext _context;

        public DividaRepository(VendaPlenaContext context)
        {
            _context = context;
        }
        public IEnumerable<DividaClienteResponse> FindDividasCliente(int idCliente)
        {
           return  _context.Divida.Where(x => x.ClienteId == idCliente && !x.Paga)
            .Select(x => new DividaClienteResponse
            {
                Id = x.Id,
                Valor = x.Valor,
                dataCriacao = x.DataCriacao.ToString("dd/MM/yyyy")
            }).ToList();
        }

        public void CadastrarDivida(CadastrarDividaRequest divida)
        {
            Divida _divida = new Divida
            {
                ClienteId = divida.clienteId,
                Valor = divida.valor,
                Paga = false,
                DataCriacao = DateTime.Now,
            };
            _context.Add(_divida);
            _context.SaveChanges();

        }
        public decimal TotalDevido()
        {
            return _context.Divida.Where(x => !x.Paga).Sum(y => y.Valor);
        }
        public bool PagarDivida(int id)
        {
           Divida div = _context.Divida.Find(id);
            if(div == null) return false;

            div.Paga = true;
            div.DataPagamento = DateTime.Now;
            _context.SaveChanges();
            return true;    
        }

        public bool DividaAberta(int idCliente)
        {
            bool emAberto =  _context.Divida.Where(x => x.ClienteId == idCliente && !x.Paga).Any();
            return emAberto;
        }

    }
}
