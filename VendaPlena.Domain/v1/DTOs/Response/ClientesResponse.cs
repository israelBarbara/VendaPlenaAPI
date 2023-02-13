namespace VendaPlana.Domain.v1.DTOs.Response
{
    public class ClientesResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public decimal TotalDivida { get; set; }

    }
}