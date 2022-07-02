using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DevInSales.Core.Entities;

namespace DevInSales.Core.Data.Mappings
{
    public class SaleProductMap : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SaleProducts");


            builder.HasKey(p => p.Id);

            builder.Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Sales)
                .WithMany()
                .HasForeignKey(p => p.SaleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Products)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}