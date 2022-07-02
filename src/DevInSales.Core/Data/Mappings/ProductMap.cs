using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DevInSales.Core.Entities;
namespace DevInSales.Core.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Opcional, pois por convenção nossa propriedade já seria a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(255)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.SuggestedPrice)
                .HasColumnType("decimal(18,2)")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasData(
                new Product(1, "Coca-Cola", new decimal(3.50)),
                new Product(2, "cerveja Bohemia", new decimal(3.99)),
                new Product(3, "Cerveja Itaipava", new decimal(3.59)),
                new Product(4, "Ceveja Spaten", new decimal(3.49)),
                new Product(5, "Cerveja Heineken", new decimal(5.59)),
                new Product(6, "Cerveja Corona", new decimal(5.99)),
                new Product(7, "Cerveja Stella", new decimal(3.19)),
                new Product(8, "Cerveja Amstel", new decimal(3.49)),
                new Product(9, "Cerveja Budweiser", new decimal(4.19)),
                new Product(10, "Cerveja Brahma", new decimal(3.79))

                );                
        }
    }

}
