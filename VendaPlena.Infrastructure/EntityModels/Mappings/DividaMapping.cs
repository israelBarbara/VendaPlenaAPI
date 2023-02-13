using VendaPlena.Infrastructure.EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaPlena.Infrastructure.EntityModels.Mappings
{
    public class DividaMapping : IEntityTypeConfiguration<Divida>
    {
        public void Configure(EntityTypeBuilder<Divida> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("DIVIDA");
        }
    }
}
