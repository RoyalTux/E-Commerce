using System.Data.Entity;
using DLL.Extensibility.Entities;

namespace DLL.Context
{
    internal class OrderLineBuilder
    {
        public static void BuildOrderLine(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OrderLine>()
                .Property(x => x.Price)
                .HasPrecision(9, 2)
                .IsRequired();

            modelBuilder.Entity<OrderLine>()
                .HasRequired(x => x.Order);
        }
    }
}
