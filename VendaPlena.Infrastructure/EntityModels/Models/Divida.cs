using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaPlena.Infrastructure.EntityModels.Models
{
    public partial class Divida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public bool Paga { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataPagamento  { get; set; }

        //ef relation
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
