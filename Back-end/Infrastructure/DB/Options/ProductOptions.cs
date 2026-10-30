
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DB.Options
{
    internal class ProductOptions : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Category).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
