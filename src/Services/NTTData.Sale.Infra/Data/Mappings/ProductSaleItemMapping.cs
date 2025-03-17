using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTTData.Sale.Domain.Sales;

namespace NTTData.Sale.Infra.Data.Mappings
{
    public class ProductSaleItemMapping : IEntityTypeConfiguration<ProductSaleItem>
    {
        public void Configure(EntityTypeBuilder<ProductSaleItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProductName)
                .IsRequired()
                .HasColumnType("varchar(250)");

            
            builder.HasOne(c => c.Sale)
                .WithMany(c => c.ProductItems);

            builder.ToTable("ProductSaleItem");
        }
    }
}
