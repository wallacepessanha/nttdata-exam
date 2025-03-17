using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NTTData.Sale.Infra.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Domain.Sales.Sale>
    {
        public void Configure(EntityTypeBuilder<Domain.Sales.Sale> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.OwnsOne(p => p.Customer, e =>
            {
                e.Property(pe => pe.FullName)
                    .HasColumnName("FullName");

                e.Property(pe => pe.Email)
                    .HasColumnName("Email");                
            });
           
            builder.HasMany(c => c.ProductItems)
                .WithOne(c => c.Sale)
                .HasForeignKey(c => c.SaleId);

            builder.ToTable("Sales");

        }
    }
}
