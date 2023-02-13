using VendaPlena.Infrastructure.EntityModels.Models;
using Microsoft.EntityFrameworkCore;

namespace VendaPlena.Infrastructure
{
    public class VendaPlenaContext :DbContext
    {

        public VendaPlenaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Divida> Divida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //se esquecer de mapear algum campo do tipo string no banco vira como varchar(100) como default, e nao varchar(max)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendaPlenaContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }


    }
}