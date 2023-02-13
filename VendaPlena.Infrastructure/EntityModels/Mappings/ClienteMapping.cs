using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Infrastructure.EntityModels.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");


            builder.Property(c => c.Cpf)
            .IsRequired()
            .HasColumnType("varchar(11)");

            builder.Property(c => c.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");

            builder.HasMany(f => f.Dividas)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId);

            builder.ToTable("CLIENTE");
        }
    }
}
