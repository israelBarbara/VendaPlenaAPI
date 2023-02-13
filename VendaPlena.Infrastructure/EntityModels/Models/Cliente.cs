using VendaPlena.Infrastructure.EntityModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaPlena.Infrastructure
{
    public partial class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }      
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<Divida> Dividas { get; set; }
    }
}