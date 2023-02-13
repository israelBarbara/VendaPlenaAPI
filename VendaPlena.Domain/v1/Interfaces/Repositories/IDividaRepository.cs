using VendaPlena.Domain.v1.DTOs.Request;
using VendaPlena.Domain.v1.DTOs.Response;


namespace VendaPlena.Domain.v1.Interfaces.Repositories
{
    public interface IDividaRepository
    {
        IEnumerable<DividaClienteResponse> FindDividasCliente(int idCliente);
        public void CadastrarDivida(CadastrarDividaRequest divida);
        public decimal TotalDevido();
        public bool PagarDivida(int id);

        public bool DividaAberta(int idCliente);
    }
}
